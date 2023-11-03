using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class AffiliationsDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public AffiliationsDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public AffiliationsDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

       

        public List<Affiliations> GetAllAffiliations()
        {
            var empQuery = from b in _obAlphaToolEntities.Affiliations
                          
                select b;

            var listAffiliations = empQuery.ToList();
            return listAffiliations;
        }

        public List<Affiliations> GetAllAffiliationsByid(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.Affiliations
                           select b;

            var listAffiliations = empQuery.ToList();
            return listAffiliations;
        }

        public List<Affiliations> GetAllAffiliationsBySQL(string sql)
        {
            List<Affiliations> AffiliationsList = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.Affiliations.SqlQuery(sql).ToList<Affiliations>();
                    AffiliationsList = empQuery;
                }
                return AffiliationsList;
        }
        
    }
}
