using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MppcIndustryPagesDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MppcIndustryPagesDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MppcIndustryPagesDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        //public MPPCIndustryPages GetCategoryCrosRefferencebyId(int id)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.MPPCIndustryPages
        //        where b.ID == id
        //        select b;

        //    var objUser = empQuery.ToList().FirstOrDefault();

        //    return objUser;
        //}

        public bool Insert(MPPCIndustryPages objUser)
        {
            _obAlphaToolEntities.MPPCIndustryPages.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public bool Update(MPPCIndustryPages obj)
        //{
        //    MPPCIndustryPages existing = _obAlphaToolEntities.MPPCIndustryPages.Find(obj.ID);
        //    ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
        //    _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
        //    _obAlphaToolEntities.SaveChanges();

        //    return true;
        //}

        //public bool DeleteById(int id)
        //{
        //    _obAlphaToolEntities.MPPCIndustryPages.Remove(GetCategoryCrosRefferencebyId(id));
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public MPPCIndustryPages GetMPPCIndustryPagesbyMppcIndustryCode(int categoryId)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustryPages
                           where b.PPCIndustryCode == categoryId
                           select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }



        //public User GetUserBySql(string sql)
        //{
        //    var empQuery = _obAlphaToolEntities.User.SqlQuery(sql).ToList().FirstOrDefault();
        //    var objUser = empQuery;
        //    return objUser;
        //}

        public List<MPPCIndustryPages> GetAllMPPCIndustryPages()
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustryPages                           
                           select b;

            var listMPPCIndustryPages = empQuery.ToList();
            return listMPPCIndustryPages;
        }

        public List<MPPCIndustryPages> GetAllMPPCIndustryPagesByMPPCIndustryCode(int categoryCode)
        {
            var empQuery = from b in _obAlphaToolEntities.MPPCIndustryPages
                           where b.PPCIndustryCode==categoryCode
                           select b;

            var listMPPCIndustryPages = empQuery.ToList();
            return listMPPCIndustryPages;
        }
    }
}
