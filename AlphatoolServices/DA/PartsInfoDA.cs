using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class PartsInfoDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public PartsInfoDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public PartsInfoDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public PartsInfo GetPartsInfobyPartNo(string partno)
        {
            var empQuery = from b in _obAlphaToolEntities.PartsInfo
                           where b.Partno == partno
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

      

        public bool Insert(PartsInfo objUser)
        {
            _obAlphaToolEntities.PartsInfo.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        
        public List<PartsInfo> GetAllPartsInfo()
        {
            var empQuery = from b in _obAlphaToolEntities.PartsInfo
                           //where b.PartsInfoID > 0
                select b;

            var listPartsInfo = empQuery.ToList();
            return listPartsInfo;
        }

        public List<PartsInfo> GetAllPartsInfoByPartNo(string partno)
        {
            var empQuery = from b in _obAlphaToolEntities.PartsInfo
                           where b.Partno == partno
                           select b;

            var listPartsInfo = empQuery.ToList();
            return listPartsInfo;
        }

      
    }
}
