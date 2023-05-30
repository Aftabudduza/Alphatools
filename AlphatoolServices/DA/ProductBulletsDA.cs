using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class ProductBulletsDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public ProductBulletsDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public ProductBulletsDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public ProductBullets GetProductBulletsbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductBullets
                where b.ProductPageCode == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(ProductBullets objUser)
        {
            _obAlphaToolEntities.ProductBullets.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(ProductBullets obj)
        {
            ProductBullets existing = _obAlphaToolEntities.ProductBullets.Find(obj.ProductPageCode);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.ProductBullets.Remove(GetProductBulletsbyId(id));
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

        public List<ProductBullets> GetAllProductBullets()
        {
            var empQuery = from b in _obAlphaToolEntities.ProductBullets
                           where b.PBID > 0
                select b;

            var listProductBullets = empQuery.ToList();
            return listProductBullets;
        }

        //public List<ProductBullets> GetAllProductBulletsById(int groupId)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.ProductBullets
        //                   where b.VideoID == groupId
        //                   select b;

        //    var listProductBullets = empQuery.ToList();
        //    return listProductBullets;
        //}

        public List<ProductBullets> GetAllProductBulletsByProductId(int productid)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductBullets
                           where b.ProductPageCode == productid
                           select b;

            var listProductBullets = empQuery.ToList();
            return listProductBullets;
        }

        public List<ProductBullets> GetAllProductBulletsBySQL(string sql)
        {
            List<ProductBullets> ProductBulletslist = null;

            if (sql != "")
            {
                var empQuery = _obAlphaToolEntities.ProductBullets.SqlQuery(sql).ToList<ProductBullets>();
                ProductBulletslist = empQuery;
            }
            return ProductBulletslist;

        }
    }
}
