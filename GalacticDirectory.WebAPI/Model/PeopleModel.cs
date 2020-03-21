using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalacticDirectory.WebAPI.Models
{
    public class PeopleModel
    {
      
       
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string Hair_color { get; set; }
        public string Skin_color { get; set; }
        public string Eye_color { get; set; }
        public string Birth_year { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
        //public string[] Films { get; set; }
        //public string[] Species { get; set; }
        //public string[] Startships { get; set; }
        //public string[] Vehicles { get; set; }
    }
}
