using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class PartsPageDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public PartsPageDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public PartsPageDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }


        public PartsPage GetPartsPagebyPartCode(string code)
        {
            var empQuery = from b in _obAlphaToolEntities.PartsPage
                           where b.PartsPC == code
                           select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public PartsPage GetPartsPagebyPPC(double code)
        {
            var empQuery = from b in _obAlphaToolEntities.PartsPage
                           where b.PPC ==  code
                           select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }
        public List<PartsPage> GetAllPartsPage()
        {
            var empQuery = from b in _obAlphaToolEntities.PartsPage
                where b.PPC > 0
                select b;

            var listPartsPage = empQuery.ToList();
            return listPartsPage;
        }

      

        public List<PartsPage> GetAllPartsPageBySectionId(int Sectionid)
        {
            var empQuery = from b in _obAlphaToolEntities.PartsPage
                           where b.WebSectionID == Sectionid
                           select b;

            var listPartsPage = empQuery.ToList();
            return listPartsPage;
        }

        public List<PartsPage> GetAllPartsPageByGroupId(int groupid)
        {
            var empQuery = from b in _obAlphaToolEntities.PartsPage
                           where b.WebGroupID == groupid
                           select b;

            var listPartsPage = empQuery.ToList();
            return listPartsPage;
        }

        public List<PartsPage> GetAllPartsPageListBySQL(string sql)
        {
            List<PartsPage> PartsPageList = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.PartsPage.SqlQuery(sql).ToList<PartsPage>();
                    PartsPageList = empQuery;
                }
                return PartsPageList;
        }
        
    }
}
