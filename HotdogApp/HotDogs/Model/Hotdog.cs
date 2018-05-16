using System;
using System.Collections.Generic;
using System.Text;

namespace HotDogs.Model
{
    public class Hotdog
    {
        public int HotDogId { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Desc { get; set; }
        public string ImgPath { get; set; }
        public int Price { get; set; }

        public bool Available { get; set; }
        public int PrepTime { get; set; }

        public List<string> Ingredients { get; set; }
        public bool IsFavourite { get; set; }
        public string GroupName { get; set; }
    }
}
