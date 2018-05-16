using HotDogs.Model;
using HotDogs.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotDogs.Service
{
    public class HotDogDataService
    {
        private static HotDogRepository hotDogRepository = new HotDogRepository();

        public List<Hotdog> GetAllHotDogs()
        {
            return hotDogRepository.GetAllHotDogs();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogRepository.GetGroupHotDogs();
        }

        public List<Hotdog> GetHotDogsForGroups(int hotDogGroupId)
        {
            return hotDogRepository.GetHotDogsForGroup(hotDogGroupId);
        }
        public List<Hotdog> GetFavouriteHotDogs()
        {
            return hotDogRepository.GetFavouriteHotDogs();
        }

        public Hotdog GetHotDogById(int hotDogId)
        {
            return hotDogRepository.GetHotDogById(hotDogId);
        }
    }
}
