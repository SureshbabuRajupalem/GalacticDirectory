using GalacticDirectory.DAL.Data;
using GalacticDirectory.WebAPI.Mapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GalacticDirectory.WebAPI.Models.Helpers
{
    public class GalacticAPIHelper:IGalacticAPIHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string BaseUri = "/api/people/";
        private string Uri = string.Empty;
        private List<PeopleModel> _PeopleDetails;
        private List<FilmModel> _Films;
        private static int TotalPeopleCount;
        private int pageSize = 0;
        private int p_ID;
        private BindEntityToEFModel _EntityToModel;
        private readonly StarWarDBContext _SWDBContext;
        public GalacticAPIHelper()
        {

        }
        public GalacticAPIHelper(IHttpClientFactory httpClientFactory, StarWarDBContext SWDBContext)
        {
            _SWDBContext = SWDBContext;
            _httpClientFactory = httpClientFactory;
            _PeopleDetails = new List<PeopleModel>();
            _Films = new List<FilmModel>();


        }
        public  List<PeopleModel> GetPeopleDetails()//async Task
        {
            // Get an instance of HttpClient from the factpry that we registered
            // in Startup.cs

            var client = _httpClientFactory.CreateClient("API Client");

            if (string.IsNullOrEmpty(Uri)) { Uri = BaseUri; }

            var result = client.GetAsync(Uri).Result;


            if (result.IsSuccessStatusCode)
            {
                var resContent = result.Content;

                // var content = await result.Content.ReadAsStringAsync();
                var resultContent = resContent.ReadAsStringAsync().Result;
                PeopleRootModel rootModel = JsonConvert.DeserializeObject<PeopleRootModel>(resultContent);
                if (string.IsNullOrEmpty(rootModel.Previous)) TotalPeopleCount = rootModel.Count;

                while (TotalPeopleCount > 0)
                {

                    if (!string.IsNullOrEmpty(rootModel.Next) && rootModel.Next.IndexOf("?") > 0)
                    {

                        Uri = string.Empty;
                        Uri = BaseUri + rootModel.Next.Substring(rootModel.Next.IndexOf("?"), rootModel.Next.Length - rootModel.Next.IndexOf("?"));

                    }
                    for (int res = 0; res <= rootModel.Results.Length - 1; res++)
                    {

                        string SubUrl = rootModel.Results[res].Url
                            .Substring(rootModel.Results[res].Url.IndexOf("people/"), rootModel.Results[res].Url.Length - rootModel.Results[res].Url.IndexOf("people/"));
                        string PeopleID = SubUrl
                            .Substring(SubUrl.IndexOf("/") + 1, SubUrl.LastIndexOf("/") - SubUrl.IndexOf("/") - 1);

                        p_ID = Convert.ToInt32(PeopleID);

                        // rootModel.results[res].People_ID = p_ID;

                        //for (int i = 0; i <= rootModel.Results[res].Films.Length - 1; i++)
                        //{
                        //  //  _Films.Add(new Film(i + 1, rootModel.results[res].Films[i]));//rootModel.results[res].People_ID,

                        //}
                    }
                    TotalPeopleCount -= rootModel.Results.Count();
                    pageSize = rootModel.Results.ToList<PeopleModel>().Count >= pageSize
                                                        ? rootModel.Results.ToList<PeopleModel>().Count : pageSize;
                    _PeopleDetails.AddRange(rootModel.Results.ToList<PeopleModel>());
                     GetPeopleDetails();//await
                }
                return _PeopleDetails;
            }
            else
            {
                return null;
            }

        }

    }
}
