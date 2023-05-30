using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class WebfieldsDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public WebfieldsDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public WebfieldsDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public Webfields GetWebfieldsbyPartNo(string id)
        {
            var empQuery = from b in _obAlphaToolEntities.Webfields
                where b.PartNo == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public Webfields GetWebfieldsbyProductId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.Webfields
                           where b.ProductPageCode == id
                           select b;

            var objWebField = empQuery.ToList().FirstOrDefault();

            return objWebField;
        }

        public bool Insert(Webfields objUser)
        {
            _obAlphaToolEntities.Webfields.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public bool Update(Webfields obj)
        //{
        //    Webfields existing = _obAlphaToolEntities.Webfields.Find(obj.WebfieldsID);
        //    ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
        //    _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
        //    _obAlphaToolEntities.SaveChanges();

        //    return true;
        //}

        //public bool DeleteById(int id)
        //{
        //    _obAlphaToolEntities.Webfields.Remove(GetWebfieldsbyId(id));
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

        public List<Webfields> GetAllWebfields()
        {
            var empQuery = from b in _obAlphaToolEntities.Webfields
                           //where b.WebfieldsID > 0
                select b;

            var listWebfields = empQuery.ToList();
            return listWebfields;
        }

        public List<Webfields> GetAllWebfieldsByPartNo(string partno)
        {
            var empQuery = from b in _obAlphaToolEntities.Webfields
                           where b.PartNo == partno
                           select b;

            var listWebfields = empQuery.ToList();
            return listWebfields;
        }

        public List<Webfields> GetAllWebfieldsByProductId(int productId)
        {
            var empQuery = from b in _obAlphaToolEntities.Webfields
                           where b.ProductPageCode == productId
                           select b;

            var listWebfields = empQuery.ToList();
            return listWebfields;
        }
    }
}
