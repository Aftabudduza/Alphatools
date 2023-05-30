using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class LinksDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public LinksDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public LinksDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

       

        public List<Links> GetAllLinks()
        {
            var empQuery = from b in _obAlphaToolEntities.Links
                          
                select b;

            var listLinks = empQuery.ToList();
            return listLinks;
        }

        public List<Links> GetAllLinksByid(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.Links
                           select b;

            var listLinks = empQuery.ToList();
            return listLinks;
        }

        public List<Links> GetAllLinksBySQL(string sql)
        {
            List<Links> LinksList = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.Links.SqlQuery(sql).ToList<Links>();
                    LinksList = empQuery;
                }
                return LinksList;
        }
        
    }
}
