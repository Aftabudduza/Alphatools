using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MOtherRef2Da
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MOtherRef2Da()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MOtherRef2Da(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MOtherRef2 GetMOtherRef2byId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MOtherRef2
                           where b.OtherRef2ID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MOtherRef2 objUser)
        {
            _obAlphaToolEntities.MOtherRef2.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MOtherRef2 obj)
        {
            MOtherRef2 existing = _obAlphaToolEntities.MOtherRef2.Find(obj.OtherRef2ID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MOtherRef2.Remove(GetMOtherRef2byId(id));
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

        public List<MOtherRef2> GetAllMOtherRef2()
        {
            var empQuery = from b in _obAlphaToolEntities.MOtherRef2
                           where b.OtherRef2ID > 0
                select b;

            var listMOtherRef2 = empQuery.ToList();
            return listMOtherRef2;
        }

        public List<MOtherRef2> GetAllMOtherRef2ById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.MOtherRef2
                           where b.OtherRef2ID == groupId
                           select b;

            var listMOtherRef2 = empQuery.ToList();
            return listMOtherRef2;
        }
    }
}
