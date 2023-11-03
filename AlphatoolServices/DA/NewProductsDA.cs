using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class NewProductsDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public NewProductsDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public NewProductsDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public NewProducts GetNewProductsbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.NewProducts
                where b.ProductPageCode == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        //public bool Insert(NewProducts objUser)
        //{
        //    _obAlphaToolEntities.NewProducts.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public bool Update(NewProducts obj)
        //{
        //    NewProducts existing = _obAlphaToolEntities.NewProducts.Find(obj.WebSectionID);
        //    ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
        //    _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
        //    _obAlphaToolEntities.SaveChanges();

        //    return true;
        //}

        //public bool DeleteById(int id)
        //{
        //    _obAlphaToolEntities.NewProducts.Remove(GetNewProductsbyId(id));
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public NewProducts GetNewProductsbyCategoryId(int categoryId)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.NewProducts
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

        public List<NewProducts> GetAllNewProducts()
        {
            var empQuery = from b in _obAlphaToolEntities.NewProducts
                           where b.ProductPageCode > 0
                select b;

            var listNewProducts = empQuery.ToList();
            return listNewProducts;
        }

        public List<NewProducts> GetAllNewProductsByid(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.NewProducts
                           where b.ProductPageCode == id
                           select b;

            var listNewProducts = empQuery.ToList();
            return listNewProducts;
        }

        //public List<NewProducts> GetAllNewProductsBySectionId(int Sectionid)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.NewProducts
        //                   where b.WebSectionID == Sectionid
        //                   select b;

        //    var listNewProducts = empQuery.ToList();
        //    return listNewProducts;
        //}

        //public List<NewProducts> GetAllNewProductsByGroupId(int groupid)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.NewProducts
        //                   where b.WebGroupID == groupid
        //                   select b;

        //    var listNewProducts = empQuery.ToList();
        //    return listNewProducts;
        //}

        public List<NewProducts> GetAllNewProductsListBySQL(string sql)
        {
            List<NewProducts> NewProductsList = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.NewProducts.SqlQuery(sql).ToList<NewProducts>();
                    NewProductsList = empQuery;
                }
                return NewProductsList;
        }
        
    }
}
