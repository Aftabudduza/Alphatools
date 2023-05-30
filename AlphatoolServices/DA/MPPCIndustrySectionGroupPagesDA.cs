using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MPPCIndustrySectionGroupPagesDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MPPCIndustrySectionGroupPagesDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MPPCIndustrySectionGroupPagesDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MPPCIndustrySectionGroupPages GetMPPCIndustrySectionGroupPagesbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupPages
                where b.id == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        

        public List<MPPCIndustrySectionGroupPages> GetAllMPPCIndustrySectionGroupPages()
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupPages
                           where b.id > 0 && b.MWebSectionId > 0
                select b;

            var listMPPCIndustrySectionGroupPages = empQuery.ToList();
            return listMPPCIndustrySectionGroupPages;
        }

        public List<MPPCIndustrySectionGroupPages> GetAllMPPCIndustrySectionGroupPagesByid(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupPages
                where b.id == id
                           select b;

            var listMPPCIndustrySectionGroupPages = empQuery.ToList();
            return listMPPCIndustrySectionGroupPages;
        }

        public List<MPPCIndustrySectionGroupPages> GetAllMPPCIndustrySectionGroupPagesByCategoryid(int categoryid)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupPages
                           where b.MPPCInductryId == categoryid && b.MWebSectionId > 0
                           select b;

            var listMPPCIndustrySectionGroupPages = empQuery.ToList();
            return listMPPCIndustrySectionGroupPages;
        }

        public List<MPPCIndustrySectionGroupPages> GetAllMPPCIndustrySectionGroupPagesByCategoryidSectionid(int categoryid, int sectionid)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupPages
                           where b.MPPCInductryId == categoryid && b.MWebSectionId==sectionid
                           select b;

            var listMPPCIndustrySectionGroupPages = empQuery.ToList();
            return listMPPCIndustrySectionGroupPages;
        }

        public List<MPPCIndustrySectionGroupPages> GetAllMPPCIndustrySectionGroupPagesBySectionId(int Sectionid)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupPages
                           where b.MWebSectionId == Sectionid
                           select b;

            var listMPPCIndustrySectionGroupPages = empQuery.ToList();
            return listMPPCIndustrySectionGroupPages;
        }

        public List<MPPCIndustrySectionGroupPages> GetAllMPPCIndustrySectionGroupPagesByGroupId(int groupid)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupPages
                           where b.MWebGroupId == groupid && b.MWebSectionId > 0
                           select b;

            var listMPPCIndustrySectionGroupPages = empQuery.ToList();
            return listMPPCIndustrySectionGroupPages;
        }

        public List<MPPCIndustrySectionGroupPages> GetAllMPPCIndustrySectionGroupPagesListBySQL(string sql)
        {
            List<MPPCIndustrySectionGroupPages> MPPCIndustrySectionGroupPagesList = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.MPPCIndustrySectionGroupPages.SqlQuery(sql).ToList<MPPCIndustrySectionGroupPages>();
                    MPPCIndustrySectionGroupPagesList = empQuery;
                }
                return MPPCIndustrySectionGroupPagesList;
        }
        
    }
}
