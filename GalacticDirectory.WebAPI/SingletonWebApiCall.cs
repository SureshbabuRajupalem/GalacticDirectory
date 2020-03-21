using GalacticDirectory.DAL.Data;
using GalacticDirectory.DAL.Services;
using GalacticDirectory.WebAPI.Mapper;
using GalacticDirectory.WebAPI.Models;
using GalacticDirectory.WebAPI.Models.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GalacticDirectory.WebAPI
{
    public static class SingletonWebApiCall
    {
        private  static IHttpClientFactory _httpClientFactory;       
        private  static StarWarDBContext _SWDBContext;
        private readonly static IRepository<DAL.Models.People> _reppm;
        static  DAL.Models.People _pm;
        private static List<FilmModel> _Films;
        private static List<Models.PeopleModel> _PeopleDetails;
        public static  void ExternalWebApiCall(IHttpClientFactory httpClientFactory,StarWarDBContext SWDBContext)//async
        {
            _httpClientFactory = httpClientFactory;
            _SWDBContext = SWDBContext;
            _PeopleDetails =  new GalacticAPIHelper(_httpClientFactory, _SWDBContext).GetPeopleDetails();//await
            new BindEntityToEFModel(_PeopleDetails, _SWDBContext);
           

        }
    }
}
