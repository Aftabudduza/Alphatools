using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class ProductVideoDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public ProductVideoDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public ProductVideoDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public ProductVideo GetProductVideobyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductVideo
                where b.VideoID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(ProductVideo objUser)
        {
            _obAlphaToolEntities.ProductVideo.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(ProductVideo obj)
        {
            ProductVideo existing = _obAlphaToolEntities.ProductVideo.Find(obj.VideoID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.ProductVideo.Remove(GetProductVideobyId(id));
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

        public ProductVideo GetProductVideobyProductId(int productid)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductVideo
                           where b.ProductPageCode == productid
                           select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public List<ProductVideo> GetAllProductVideo()
        {
            var empQuery = from b in _obAlphaToolEntities.ProductVideo
                           where b.VideoID > 0
                select b;

            var listProductVideo = empQuery.ToList();
            return listProductVideo;
        }

        public List<ProductVideo> GetAllProductVideoById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductVideo
                           where b.VideoID == groupId
                           select b;

            var listProductVideo = empQuery.ToList();
            return listProductVideo;
        }

        public List<ProductVideo> GetAllProductVideoByProductId(int productid)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductVideo
                           where b.ProductPageCode == productid
                           select b;

            var listProductVideo = empQuery.ToList().OrderBy(x=>x.Vorder).ToList();
            return listProductVideo;
        }
    }
}
