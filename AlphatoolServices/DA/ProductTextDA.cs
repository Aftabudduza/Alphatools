using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class ProductTextDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public ProductTextDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public ProductTextDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public ProductText GetProductTextbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductText
                where b.ProductPageCode == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        //public bool Insert(ProductText objUser)
        //{
        //    _obAlphaToolEntities.ProductText.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public bool Update(ProductText obj)
        //{
        //    ProductText existing = _obAlphaToolEntities.ProductText.Find(obj.WebSectionID);
        //    ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
        //    _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
        //    _obAlphaToolEntities.SaveChanges();

        //    return true;
        //}

        //public bool DeleteById(int id)
        //{
        //    _obAlphaToolEntities.ProductText.Remove(GetProductTextbyId(id));
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public ProductText GetProductTextbyCategoryId(int categoryId)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.ProductText
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

        public List<ProductText> GetAllProductText()
        {
            var empQuery = from b in _obAlphaToolEntities.ProductText
                where b.ProductPageCode > 0
                select b;

            var listProductText = empQuery.ToList();
            return listProductText;
        }

        public List<ProductText> GetAllProductTextByid(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductText
                where b.ProductPageCode == id
                           select b;

            var listProductText = empQuery.ToList();
            return listProductText;
        }
    }
}
