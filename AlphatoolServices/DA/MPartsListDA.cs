using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MPartsListDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MPartsListDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MPartsListDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MPartsList GetMPartsListbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MPartsList
                           where b.MPartsListID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MPartsList objUser)
        {
            _obAlphaToolEntities.MPartsList.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MPartsList obj)
        {
            MPartsList existing = _obAlphaToolEntities.MPartsList.Find(obj.MPartsListID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MPartsList.Remove(GetMPartsListbyId(id));
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

        public List<MPartsList> GetAllMPartsList()
        {
            var empQuery = from b in _obAlphaToolEntities.MPartsList
                           where b.MPartsListID > 0
                select b;

            var listMPartsList = empQuery.ToList();
            return listMPartsList;
        }

        public List<MPartsList> GetAllMPartsListById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.MPartsList
                           where b.MPartsListID == groupId
                           select b;

            var listMPartsList = empQuery.ToList();
            return listMPartsList;
        }
    }
}
