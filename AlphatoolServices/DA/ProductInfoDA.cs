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
    public class ProductInfoDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public ProductInfoDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public ProductInfoDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public ProductInfo GetProductInfobyPartNo(string id)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductInfo
                where b.PartNo == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(ProductInfo objUser)
        {
            _obAlphaToolEntities.ProductInfo.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        //public bool Update(ProductInfo obj)
        //{
        //    ProductInfo existing = _obAlphaToolEntities.ProductInfo.Find(obj.ProductInfoID);
        //    ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
        //    _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
        //    _obAlphaToolEntities.SaveChanges();

        //    return true;
        //}

        //public bool DeleteById(int id)
        //{
        //    _obAlphaToolEntities.ProductInfo.Remove(GetProductInfobyId(id));
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

        public List<ProductInfo> GetAllProductInfo()
        {
            var empQuery = from b in _obAlphaToolEntities.ProductInfo
                           //where b.ProductInfoID > 0
                select b;

            var listProductInfo = empQuery.ToList();
            return listProductInfo;
        }

        public List<ProductInfo> GetAllProductInfoByPartNo(string partno)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductInfo
                           where b.PartNo == partno
                           select b;

            var listProductInfo = empQuery.ToList();
            return listProductInfo;
        }

        public List<ProductInfo> GetAllProductInfoBySQL(string sql)
        {
            List<ProductInfo> productinfolist = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.ProductInfo.SqlQuery(sql).ToList<ProductInfo>();
                    productinfolist = empQuery;
                }
                return productinfolist;
            
        }

        //public List<ProductInfo> GetAllProductInfoByProductId(int productId)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.ProductInfo
        //                   where b.ProductPageCode == productId
        //                   select b;

        //    var listProductInfo = empQuery.ToList();
        //    return listProductInfo;
        //}
    }
}
