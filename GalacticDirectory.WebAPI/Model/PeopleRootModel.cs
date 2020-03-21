using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalacticDirectory.WebAPI.Models
{
    public class PeopleRootModel
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public PeopleModel[] Results { get; set; }
    }
}
