using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MFlyerDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MFlyerDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MFlyerDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MFlyer GetMFlyerbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MFlyer
                           where b.FlyerID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MFlyer objUser)
        {
            _obAlphaToolEntities.MFlyer.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MFlyer obj)
        {
            MFlyer existing = _obAlphaToolEntities.MFlyer.Find(obj.FlyerID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MFlyer.Remove(GetMFlyerbyId(id));
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public MWebGroup GetMWebGroupbyCategoryId(int categoryId)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.MWebGroup
        //                   where b.CategoryID == categoryId
        //                   select b;

        //    var objUser = empQuery.ToList().FirstOrDefault();

        //    return objUser;
        //}

        //public User GetUserBySql(string sql)
        //{
        //    var empQuery = _obAlphaToolEntities.User.SqlQuery(sql).ToList().FirstOrDefault();
        //    var objUser = empQuery;
        //    return objUser;
        //}

        public List<MFlyer> GetAllMFlyer()
        {
            var empQuery = from b in _obAlphaToolEntities.MFlyer
                           where b.FlyerID > 0
                select b;

            var listMFlyer = empQuery.ToList();
            return listMFlyer;
        }

        public List<MFlyer> GetAllMFlyerById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.MFlyer
                           where b.FlyerID == groupId
                           select b;

            var listMFlyer = empQuery.ToList();
            return listMFlyer;
        }
    }
}
