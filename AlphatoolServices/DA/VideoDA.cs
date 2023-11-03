using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class VideoDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public VideoDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public VideoDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public Video GetVideobyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.Video
                where b.VideoID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(Video objUser)
        {
            _obAlphaToolEntities.Video.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(Video obj)
        {
            Video existing = _obAlphaToolEntities.Video.Find(obj.VideoID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.Video.Remove(GetVideobyId(id));
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

        public List<Video> GetAllVideo()
        {
            var empQuery = from b in _obAlphaToolEntities.Video
                           where b.VideoID > 0
                select b;

            var listVideo = empQuery.ToList();
            return listVideo;
        }

        public List<Video> GetAllVideoById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.Video
                           where b.VideoID == groupId
                           select b;

            var listVideo = empQuery.ToList();
            return listVideo;
        }
    }
}
