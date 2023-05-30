using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MOtherRef1Da
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MOtherRef1Da()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MOtherRef1Da(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MOtherRef1 GetMOtherRef1byId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MOtherRef1
                           where b.OtherRef1ID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MOtherRef1 objUser)
        {
            _obAlphaToolEntities.MOtherRef1.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MOtherRef1 obj)
        {
            MOtherRef1 existing = _obAlphaToolEntities.MOtherRef1.Find(obj.OtherRef1ID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MOtherRef1.Remove(GetMOtherRef1byId(id));
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

        public List<MOtherRef1> GetAllMOtherRef1()
        {
            var empQuery = from b in _obAlphaToolEntities.MOtherRef1
                           where b.OtherRef1ID > 0
                select b;

            var listMOtherRef1 = empQuery.ToList();
            return listMOtherRef1;
        }

        public List<MOtherRef1> GetAllMOtherRef1ById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.MOtherRef1
                           where b.OtherRef1ID == groupId
                           select b;

            var listMOtherRef1 = empQuery.ToList();
            return listMOtherRef1;
        }
    }
}
