using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MPPCIndustrySectionGroupSparePartsDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MPPCIndustrySectionGroupSparePartsDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MPPCIndustrySectionGroupSparePartsDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MPPCIndustrySectionGroupSpareParts GetMPPCIndustrySectionGroupSparePartsbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupSpareParts
                where b.id == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }        

        public List<MPPCIndustrySectionGroupSpareParts> GetAllMPPCIndustrySectionGroupSpareParts()
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupSpareParts
                where b.id > 0
                select b;

            var listMPPCIndustrySectionGroupSpareParts = empQuery.ToList();
            return listMPPCIndustrySectionGroupSpareParts;
        }

        public List<MPPCIndustrySectionGroupSpareParts> GetAllMPPCIndustrySectionGroupSparePartsByid(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupSpareParts
                where b.id == id
                           select b;

            var listMPPCIndustrySectionGroupSpareParts = empQuery.ToList();
            return listMPPCIndustrySectionGroupSpareParts;
        }

        public List<MPPCIndustrySectionGroupSpareParts> GetAllMPPCIndustrySectionGroupSparePartsByCategoryid(int categoryid)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupSpareParts
                           where b.MPPCInductryId == categoryid
                           select b;

            var listMPPCIndustrySectionGroupSpareParts = empQuery.ToList();
            return listMPPCIndustrySectionGroupSpareParts;
        }

        public List<MPPCIndustrySectionGroupSpareParts> GetAllMPPCIndustrySectionGroupSparePartsByCategoryidSectionid(int categoryid, int sectionid)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupSpareParts
                           where b.MPPCInductryId == categoryid && b.MWebSectionId==sectionid
                           select b;

            var listMPPCIndustrySectionGroupSpareParts = empQuery.ToList();
            return listMPPCIndustrySectionGroupSpareParts;
        }

        public List<MPPCIndustrySectionGroupSpareParts> GetAllMPPCIndustrySectionGroupSparePartsBySectionId(int Sectionid)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupSpareParts
                           where b.MWebSectionId == Sectionid
                           select b;

            var listMPPCIndustrySectionGroupSpareParts = empQuery.ToList();
            return listMPPCIndustrySectionGroupSpareParts;
        }

        public List<MPPCIndustrySectionGroupSpareParts> GetAllMPPCIndustrySectionGroupSparePartsByGroupId(int groupid)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustrySectionGroupSpareParts
                           where b.MWebGroupId == groupid
                           select b;

            var listMPPCIndustrySectionGroupSpareParts = empQuery.ToList();
            return listMPPCIndustrySectionGroupSpareParts;
        }

        public List<MPPCIndustrySectionGroupSpareParts> GetAllMPPCIndustrySectionGroupSparePartsListBySQL(string sql)
        {
            List<MPPCIndustrySectionGroupSpareParts> MPPCIndustrySectionGroupSparePartsList = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.MPPCIndustrySectionGroupSpareParts.SqlQuery(sql).ToList<MPPCIndustrySectionGroupSpareParts>();
                    MPPCIndustrySectionGroupSparePartsList = empQuery;
                }
                return MPPCIndustrySectionGroupSparePartsList;
        }
        
    }
}
