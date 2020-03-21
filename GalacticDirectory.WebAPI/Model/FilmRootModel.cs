using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GalacticDirectory.WebAPI.Models
{
    public class FilmRootModel
    {
        public int Count { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }
        public List<FilmModel> Results { get; set; }
    }
}
