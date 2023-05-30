using System.Collections.Generic;
using System.Data;
using System.Data.Common.CommandTrees;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class TNTechNoteFAQDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public TNTechNoteFAQDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public TNTechNoteFAQDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public TNTechNoteFAQ GetTNTechNoteFAQbyTnfqid(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.TNTechNoteFAQ
                where b.TNFAQID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(TNTechNoteFAQ objUser)
        {
            _obAlphaToolEntities.TNTechNoteFAQ.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public bool Update(TNTechNoteFAQ obj)
        //{
        //    TNTechNoteFAQ existing = _obAlphaToolEntities.TNTechNoteFAQ.Find(obj.TNTechNoteFAQID);
        //    ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
        //    _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
        //    _obAlphaToolEntities.SaveChanges();

        //    return true;
        //}

        //public bool DeleteById(int id)
        //{
        //    _obAlphaToolEntities.TNTechNoteFAQ.Remove(GetTNTechNoteFAQbyId(id));
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

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

        public List<TNTechNoteFAQ> GetAllTNTechNoteFAQ()
        {
            var empQuery = from b in _obAlphaToolEntities.TNTechNoteFAQ
                           //where b.TNTechNoteFAQID > 0
                select b;

            var listTNTechNoteFAQ = empQuery.ToList();
            return listTNTechNoteFAQ;
        }

        public List<TNTechNoteFAQ> GetAllTNTechNoteFAQByTNid(int tnid)
        {
            var empQuery = from b in _obAlphaToolEntities.TNTechNoteFAQ
                           where b.TNID == tnid
                           select b;

            var listTNTechNoteFAQ = empQuery.ToList();
            return listTNTechNoteFAQ;
        }

        public List<TNTechNoteFAQ> GetAllTNTechNoteFAQBySQL(string sql)
        {
            List<TNTechNoteFAQ> productinfolist = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.TNTechNoteFAQ.SqlQuery(sql).ToList<TNTechNoteFAQ>();
                    productinfolist = empQuery;
                }
                return productinfolist;
            
        }

        public List<TNTechNoteFAQ> GetAllTNTechNoteFAQByProductId(int productId)
        {
            var empQuery = from b in _obAlphaToolEntities.TNTechNoteFAQ
                           where b.ProductPageCode == productId
                           select b;

            var listTNTechNoteFAQ = empQuery.ToList();
            return listTNTechNoteFAQ;
        }
    }
}
