using HotDogs.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotDogs.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>();

        string url = "http://gillcleerenpluralsight.blob.core.windows.net/files/hotdogs.json";

        public HotDogRepository()
        {
            Task.Run(() => this.LoadDataAsync(url)).Wait();
        }
        private async Task LoadDataAsync(string uri)
        {
            if (hotDogGroups != null)
            {
                string responseJsonString = null;

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);

                        HttpResponseMessage response = await getResponse;

                        responseJsonString = await response.Content.ReadAsStringAsync();

                        hotDogGroups = JsonConvert.DeserializeObject<List<HotDogGroup>>(responseJsonString);
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                    }
                }
            }
        }
            //Old Hard-coded Data
            /*{
            new HotDogGroup()
            {
                HotDogGroupId = 1, Title = "Meat Lovers", ImagePath = "", HotDogs = new List<HotDog>()
                {
                    new HotDog()
                    {
                        HotDogId = 1,
                        Name = "Regular Hot Dog",
                        ShortDescription = "The best there is on the planet",
                        Description = "Bun and Dog with mustard",
                        ImagePath = "hotdog1",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>(){"Regular bun, Dog, Mustard"},
                        Price = 8,
                        IsFavorite = true
                    },
                    new HotDog()
                    {
                        HotDogId = 2,
                        Name = "Sauerkraut Dog",
                        ShortDescription = "Germanic twist",
                        Description = "Bun and Dog with Sauerkraut",
                        ImagePath = "hotdog2",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>(){"Regular bun, Dog, Sauerkraut"},
                        Price = 10,
                        IsFavorite = false,
                    },
                    new HotDog()
                    {
                        HotDogId = 3,
                        Name = "Mega Dog",
                        ShortDescription = "Big flavour, big taste",
                        Description = "Bun and Dog with Bacon and Cheese",
                        ImagePath = "hotdog3",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>(){"Regular bun, Dog, Bacon, Cheese"},
                        Price = 18,
                        IsFavorite = false,
                    }
                }
            },
            new HotDogGroup()
            {
                HotDogGroupId = 2, Title = "Veggie Lovers", ImagePath = "", HotDogs = new List<HotDog>()
                {
                    new HotDog()
                    {
                        HotDogId = 4,
                        Name = "Veggie Dog",
                        ShortDescription = "For non-meat lovers!",
                        Description = "Just a bun",
                        ImagePath = "hotdog4",
                        Available = true,
                        PrepTime = 5,
                        Ingredients = new List<string>(){"Regular bun"},
                        Price = 5,
                        IsFavorite = false,
                    },
                    new HotDog()
                    {
                        HotDogId = 5,
                        Name = "Supreme Veg Dog",
                        ShortDescription = "The Delux Veggie Option",
                        Description = "Bun and Veggie Dog with Ketchup",
                        ImagePath = "hotdog5",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>(){"Regular bun, Veggie Dog, Ketchup"},
                        Price = 15,
                        IsFavorite = false,
                    },
                    new HotDog()
                    {
                        HotDogId = 5,
                        Name = "Extra Long Veggie",
                        ShortDescription = "The Big size option",
                        Description = "Large Bun and Veggie Dog with Ketchup AND Mustard",
                        ImagePath = "hotdog6",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>(){"Large Regular bun, Veggie Dog, Ketchup, Mustard"},
                        Price = 18,
                        IsFavorite = false,
                    }
                }
            }
        };*/

        public List<HotDog> GetAllHotDogs()
        {
            IEnumerable<HotDog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                select hotDog;

            return hotDogs.ToList<HotDog>();
        }

        public HotDog GetHotDogById(int hotDogId)
        {
            IEnumerable<HotDog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                where hotDog.HotDogId == hotDogId
                select hotDog;

            return hotDogs.FirstOrDefault();
        }

        public List<HotDogGroup> GetGroupHotDogs()
        {
            return hotDogGroups;
        }

        public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
        {
            var group = hotDogGroups.Where(h => h.HotDogGroupId == hotDogGroupId).FirstOrDefault();

            if (group != null)
            {
                return group.HotDogs;
            }
            return null;
        }

        public List<HotDog> GetFavouriteHotDogs()
        {
            IEnumerable<HotDog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                where hotDog.IsFavorite
                select hotDog;

            return hotDogs.ToList<HotDog>();
        }
    }
}
