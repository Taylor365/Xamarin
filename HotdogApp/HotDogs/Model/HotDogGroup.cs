using System;
using System.Collections.Generic;
using System.Text;

namespace HotDogs.Model
{
    public class HotDogGroup
    {
        public int HotDogGroupId { get; set; }
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public List<Hotdog> HotDogs { get; set; }
    }
}
