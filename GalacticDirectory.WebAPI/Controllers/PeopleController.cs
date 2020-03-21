using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GalacticDirectory.DAL.Data;
using GalacticDirectory.DAL.Services;
using GalacticDirectory.WebAPI.Models;
using GalacticDirectory.WebAPI.Models.Helpers;
using GalacticDirectory.DAL.Models;
using GalacticDirectory.WebAPI.Mapper;

namespace GalacticDirectory.WebAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PeopleController> _logger;
        private readonly StarWarDBContext _SWDBContext;
        private readonly IRepository<DAL.Models.People> _reppm;
        DAL.Models.People _pm;
        private List<FilmModel> _Films;
        private List<Models.PeopleModel> _PeopleDetails;
        private static bool alreadyExecuted = false;
       
        public PeopleController(ILogger<PeopleController> logger, IHttpClientFactory httpClientFactory, StarWarDBContext SWDBContext) 
        {

            _logger = logger;
            _SWDBContext = SWDBContext;
            _reppm = new Repository<DAL.Models.People>(_SWDBContext);
            _pm = new DAL.Models.People();
            _Films = new List<FilmModel>();
            _httpClientFactory = httpClientFactory;
            _PeopleDetails = new List<Models.PeopleModel>();
            if (!alreadyExecuted)
            {
                SingletonWebApiCall.ExternalWebApiCall(_httpClientFactory, _SWDBContext);
                alreadyExecuted = true;
            }
        }
        // GET api/values
        [HttpGet]
        [ResponseCache(CacheProfileName = "default")]
        public  IEnumerable<DAL.Models.People> Get()
        {
            return  _reppm.List();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<DAL.Models.People> Get(int id)
        {
            return _reppm.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DAL.Models.People pm )
        {
            _reppm.Update(pm);           
            return RedirectToAction(nameof(Get));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(DAL.Models.People pm )
        {
            _reppm.Delete(pm);
            return RedirectToAction(nameof(Get));

        }
                
    }
}
