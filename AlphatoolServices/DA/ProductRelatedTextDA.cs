using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class ProductRelatedTextDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public ProductRelatedTextDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public ProductRelatedTextDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public ProductRelatedText GetProductRelatedTextbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductRelatedText
                where b.ProductPageCode == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        //public bool Insert(ProductRelatedText objUser)
        //{
        //    _obAlphaToolEntities.ProductRelatedText.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public bool Update(ProductRelatedText obj)
        //{
        //    ProductRelatedText existing = _obAlphaToolEntities.ProductRelatedText.Find(obj.WebSectionID);
        //    ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
        //    _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
        //    _obAlphaToolEntities.SaveChanges();

        //    return true;
        //}

        //public bool DeleteById(int id)
        //{
        //    _obAlphaToolEntities.ProductRelatedText.Remove(GetProductRelatedTextbyId(id));
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public ProductRelatedText GetProductRelatedTextbyCategoryId(int categoryId)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.ProductRelatedText
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

        public List<ProductRelatedText> GetAllProductRelatedText()
        {
            var empQuery = from b in _obAlphaToolEntities.ProductRelatedText
                where b.ProductPageCode > 0
                select b;

            var listProductRelatedText = empQuery.ToList();
            return listProductRelatedText;
        }

        public List<ProductRelatedText> GetAllProductRelatedTextByid(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductRelatedText
                where b.ProductPageCode == id
                           select b;

            var listProductRelatedText = empQuery.ToList();
            return listProductRelatedText;
        }
    }
}
