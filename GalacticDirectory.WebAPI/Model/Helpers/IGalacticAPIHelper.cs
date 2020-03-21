using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalacticDirectory.WebAPI.Models;

namespace GalacticDirectory.WebAPI.Models.Helpers
{
    interface IGalacticAPIHelper
    {
         List<PeopleModel> GetPeopleDetails();//Task
    }
}
