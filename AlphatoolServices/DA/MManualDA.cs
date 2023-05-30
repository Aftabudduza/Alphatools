using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MManualDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MManualDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MManualDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MManual GetMManualbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MManual
                           where b.ManualID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MManual objUser)
        {
            _obAlphaToolEntities.MManual.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MManual obj)
        {
            MManual existing = _obAlphaToolEntities.MManual.Find(obj.ManualID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MManual.Remove(GetMManualbyId(id));
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

        public List<MManual> GetAllMManual()
        {
            var empQuery = from b in _obAlphaToolEntities.MManual
                           where b.ManualID > 0
                select b;

            var listMManual = empQuery.ToList();
            return listMManual;
        }

        public List<MManual> GetAllMManualById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.MManual
                           where b.ManualID == groupId
                           select b;

            var listMManual = empQuery.ToList();
            return listMManual;
        }
    }
}
