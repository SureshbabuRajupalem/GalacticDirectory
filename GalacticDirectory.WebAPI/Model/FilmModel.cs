using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDirectory.WebAPI.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Episode_id { get; set; }
        public string Opening_crawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string Release_Date { get; set; }
        [NotMapped]
        public IEnumerable<string> Characters { get; set; }
        [NotMapped]
        public IEnumerable<string> Planets { get; set; }
        [NotMapped]
        public IEnumerable<string> Starships { get; set; }
        [NotMapped]
        public IEnumerable<object> Vehicles { get; set; }
        [NotMapped]
        public IEnumerable<string> Species { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
    }
   
}

