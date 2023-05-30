using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class Test_PBDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public Test_PBDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public Test_PBDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public Test_PB GetTest_PBbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.Test_PB
                where b.ProductPageCode == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(Test_PB objUser)
        {
            _obAlphaToolEntities.Test_PB.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(Test_PB obj)
        {
            Test_PB existing = _obAlphaToolEntities.Test_PB.Find(obj.ProductPageCode);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.Test_PB.Remove(GetTest_PBbyId(id));
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

        public List<Test_PB> GetAllTest_PB()
        {
            var empQuery = from b in _obAlphaToolEntities.Test_PB
                           where b.PBID > 0
                select b;

            var listTest_PB = empQuery.ToList();
            return listTest_PB;
        }

        //public List<Test_PB> GetAllTest_PBById(int groupId)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.Test_PB
        //                   where b.VideoID == groupId
        //                   select b;

        //    var listTest_PB = empQuery.ToList();
        //    return listTest_PB;
        //}

        public List<Test_PB> GetAllTest_PBByProductId(int productid)
        {
            var empQuery = from b in _obAlphaToolEntities.Test_PB
                           where b.ProductPageCode == productid
                           select b;

            var listTest_PB = empQuery.ToList();
            return listTest_PB;
        }

        public List<Test_PB> GetAllTest_PBBySQL(string sql)
        {
            List<Test_PB> Test_PBlist = null;

            if (sql != "")
            {
                var empQuery = _obAlphaToolEntities.Test_PB.SqlQuery(sql).ToList<Test_PB>();
                Test_PBlist = empQuery;
            }
            return Test_PBlist;

        }
    }
}
