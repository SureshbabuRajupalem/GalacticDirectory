using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalacticDirectory.DAL.Data;
using GalacticDirectory.DAL.Models;
using GalacticDirectory.DAL.Services;
using GalacticDirectory.WebAPI.Models;

namespace GalacticDirectory.WebAPI.Mapper
{
    public class BindEntityToEFModel
    {
        private readonly StarWarDBContext _SWDBContext;
        private IRepository<DAL.Models.People> _reppm;
        private IRepository<DAL.Models.Film> _repf;
        private List<Models.PeopleModel> _entity;
        //  private IList<DAL.EFModels.PeopleModel> _peopleList;
        private DAL.Models.People pm;
       // private IList<Film> _f;
        private FilmModel _fm;
        // private IList<FilmModel> _fmList;
        //public BindEntityToEFModel(StarWarDBContext SWDBContext) =>_SWDBContext= SWDBContext;
        public BindEntityToEFModel(List<Models.PeopleModel> pmentity, StarWarDBContext SWDBContext)
        {
            _SWDBContext = SWDBContext;
            _entity = pmentity;    
            _fm = new FilmModel();
            
            _reppm = new Repository<DAL.Models.People>(_SWDBContext);
            _repf = new Repository<DAL.Models.Film>(_SWDBContext);
            MapEntityToModel();

        }
        public void MapEntityToModel()
        {

            foreach (var e in _entity)
            {
                pm = new DAL.Models.People();
                pm.Birth_year = e.Birth_year; pm.Created = e.Created; pm.Edited = e.Edited;
                pm.Eye_color = e.Eye_color; pm.Gender = e.Gender; pm.Hair_color = e.Hair_color;
                pm.Height = e.Height; pm.Homeworld = e.Homeworld; pm.Mass = e.Mass; pm.Name = e.Name;              
                pm.Skin_color = e.Skin_color;
                pm.Url = e.Url;
                // _peopleList.Add(pm);
                _reppm.Insert(pm);
                pm = null;

            }

            //if (_f != null)
            //{
            //    foreach (var f in _f)
            //    {
            //        _fm.ID = 0;
            //        _fm.Name = f.Name;
            //        // _fm.PeopleID = f.PeopleID;
            //        // _fmList.Add(_fm);
            //        _repf.Insert(_fm);

            //    }
            //}

        }
    }
}
