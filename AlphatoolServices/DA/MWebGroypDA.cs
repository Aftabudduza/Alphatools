using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MWebGroupDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MWebGroupDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MWebGroupDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MWebGroup GetMWebGroupbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MWebGroup
                where b.WebGroupID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MWebGroup objUser)
        {
            _obAlphaToolEntities.MWebGroup.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MWebGroup obj)
        {
            MWebGroup existing = _obAlphaToolEntities.MWebGroup.Find(obj.WebGroupID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MWebGroup.Remove(GetMWebGroupbyId(id));
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

        public List<MWebGroup> GetAllMWebGroup()
        {
            var empQuery = from b in _obAlphaToolEntities.MWebGroup
                           where b.WebGroupID > 0
                select b;

            var listMWebGroup = empQuery.ToList();
            return listMWebGroup;
        }

        public List<MWebGroup> GetAllMWebGroupById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.MWebGroup
                           where b.WebGroupID == groupId
                           select b;

            var listMWebGroup = empQuery.ToList();
            return listMWebGroup;
        }
    }
}
