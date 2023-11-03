using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MOtherRef3Da
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MOtherRef3Da()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MOtherRef3Da(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MOtherRef3 GetMOtherRef3byId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MOtherRef3
                           where b.OtherRef3ID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MOtherRef3 objUser)
        {
            _obAlphaToolEntities.MOtherRef3.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MOtherRef3 obj)
        {
            MOtherRef3 existing = _obAlphaToolEntities.MOtherRef3.Find(obj.OtherRef3ID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MOtherRef3.Remove(GetMOtherRef3byId(id));
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

        public List<MOtherRef3> GetAllMOtherRef3()
        {
            var empQuery = from b in _obAlphaToolEntities.MOtherRef3
                           where b.OtherRef3ID > 0
                select b;

            var listMOtherRef3 = empQuery.ToList();
            return listMOtherRef3;
        }

        public List<MOtherRef3> GetAllMOtherRef3ById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.MOtherRef3
                           where b.OtherRef3ID == groupId
                           select b;

            var listMOtherRef3 = empQuery.ToList();
            return listMOtherRef3;
        }
    }
}
