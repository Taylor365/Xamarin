using HotDogs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotDogs.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>()
        {
            new HotDogGroup()
            {
                HotDogGroupId = 1, Title = "Meat Lovers", ImgPath = "", HotDogs = new List<Hotdog>()
                {
                    new Hotdog()
                    {
                        HotDogId = 1,
                        Name = "Regular Hot Dog",
                        ShortDesc = "The best there is on the planet",
                        Desc = "Bun and Dog with mustard",
                        ImgPath = "hotdog1",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>(){"Regular bun, Dog, Mustard"},
                        Price = 8,
                        IsFavourite = true
                    },
                    new Hotdog()
                    {
                        HotDogId = 2,
                        Name = "Sauerkraut Dog",
                        ShortDesc = "Germanic twist",
                        Desc = "Bun and Dog with Sauerkraut",
                        ImgPath = "hotdog2",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>(){"Regular bun, Dog, Sauerkraut"},
                        Price = 10,
                        IsFavourite = false,
                    },
                    new Hotdog()
                    {
                        HotDogId = 3,
                        Name = "Mega Dog",
                        ShortDesc = "Big flavour, big taste",
                        Desc = "Bun and Dog with Bacon and Cheese",
                        ImgPath = "hotdog3",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>(){"Regular bun, Dog, Bacon, Cheese"},
                        Price = 18,
                        IsFavourite = false,
                    }
                }
            },
            new HotDogGroup()
            {
                HotDogGroupId = 2, Title = "Veggie Lovers", ImgPath = "", HotDogs = new List<Hotdog>()
                {
                    new Hotdog()
                    {
                        HotDogId = 4,
                        Name = "Veggie Dog",
                        ShortDesc = "For non-meat lovers!",
                        Desc = "Just a bun",
                        ImgPath = "hotdog4",
                        Available = true,
                        PrepTime = 5,
                        Ingredients = new List<string>(){"Regular bun"},
                        Price = 5,
                        IsFavourite = false,
                    },
                    new Hotdog()
                    {
                        HotDogId = 5,
                        Name = "Supreme Veg Dog",
                        ShortDesc = "The Delux Veggie Option",
                        Desc = "Bun and Veggie Dog with Ketchup",
                        ImgPath = "hotdog5",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>(){"Regular bun, Veggie Dog, Ketchup"},
                        Price = 15,
                        IsFavourite = false,
                    },
                    new Hotdog()
                    {
                        HotDogId = 5,
                        Name = "Extra Long Veggie",
                        ShortDesc = "The Big size option",
                        Desc = "Large Bun and Veggie Dog with Ketchup AND Mustard",
                        ImgPath = "hotdog6",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>(){"Large Regular bun, Veggie Dog, Ketchup, Mustard"},
                        Price = 18,
                        IsFavourite = false,
                    }
                }
            }
        };

        public List<Hotdog> GetAllHotDogs()
        {
            IEnumerable<Hotdog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                select hotDog;

            return hotDogs.ToList<Hotdog>();
        }

        public Hotdog GetHotDogById(int hotDogId)
        {
            IEnumerable<Hotdog> hotDogs =
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

        public List<Hotdog> GetHotDogsForGroup(int hotDogGroupId)
        {
            var group = hotDogGroups.Where(h => h.HotDogGroupId == hotDogGroupId).FirstOrDefault();

            if (group != null)
            {
                return group.HotDogs;
            }
            return null;
        }

        public List<Hotdog> GetFavouriteHotDogs()
        {
            IEnumerable<Hotdog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                where hotDog.IsFavourite
                select hotDog;

            return hotDogs.ToList<Hotdog>();
        }
    }
}
