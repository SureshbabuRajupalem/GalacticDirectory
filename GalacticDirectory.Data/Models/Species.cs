using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDirectory.DAL.Models
{
    public class Species
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int PeopleID { get; set; }
        public string Name { get; set; }
        public IEnumerable<People> people { get; set; }
        public IEnumerable<Film> Films { get; set; }
    }
}
