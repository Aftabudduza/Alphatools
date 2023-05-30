using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class ProductPageDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public ProductPageDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public ProductPageDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public ProductPage GetProductPagebyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductPage
                where b.ProductPageCode == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        //public bool Insert(ProductPage objUser)
        //{
        //    _obAlphaToolEntities.ProductPage.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public bool Update(ProductPage obj)
        //{
        //    ProductPage existing = _obAlphaToolEntities.ProductPage.Find(obj.WebSectionID);
        //    ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
        //    _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
        //    _obAlphaToolEntities.SaveChanges();

        //    return true;
        //}

        //public bool DeleteById(int id)
        //{
        //    _obAlphaToolEntities.ProductPage.Remove(GetProductPagebyId(id));
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public ProductPage GetProductPagebyCategoryId(int categoryId)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.ProductPage
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

        public List<ProductPage> GetAllProductPage()
        {
            var empQuery = from b in _obAlphaToolEntities.ProductPage
                where b.ProductPageCode > 0
                select b;

            var listProductPage = empQuery.ToList();
            return listProductPage;
        }

        public List<ProductPage> GetAllProductPageByid(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductPage
                where b.ProductPageCode == id
                           select b;

            var listProductPage = empQuery.ToList();
            return listProductPage;
        }

        public List<ProductPage> GetAllProductPageBySectionId(int Sectionid)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductPage
                           where b.WebSectionID == Sectionid
                           select b;

            var listProductPage = empQuery.ToList();
            return listProductPage;
        }

        public List<ProductPage> GetAllProductPageByGroupId(int groupid)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductPage
                           where b.WebGroupID == groupid
                           select b;

            var listProductPage = empQuery.ToList();
            return listProductPage;
        }

        public List<ProductPage> GetAllProductPageListBySQL(string sql)
        {
            List<ProductPage> ProductPageList = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.ProductPage.SqlQuery(sql).ToList<ProductPage>();
                    ProductPageList = empQuery;
                }
                return ProductPageList;
        }
        
    }
}
