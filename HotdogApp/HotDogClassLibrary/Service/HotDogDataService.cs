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

        public HotDogDataService()
        {

        }
        public List<HotDog> GetAllHotDogs()
        {
            return hotDogRepository.GetAllHotDogs();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogRepository.GetGroupHotDogs();
        }

        public List<HotDog> GetHotDogsForGroups(int hotDogGroupId)
        {
            return hotDogRepository.GetHotDogsForGroup(hotDogGroupId);
        }
        public List<HotDog> GetFavouriteHotDogs()
        {
            return hotDogRepository.GetFavouriteHotDogs();
        }

        public HotDog GetHotDogById(int hotDogId)
        {
            return hotDogRepository.GetHotDogById(hotDogId);
        }
    }
}
