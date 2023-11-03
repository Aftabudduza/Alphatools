using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MMsdsDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MMsdsDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MMsdsDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MMsds GetMMsdsbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MMsds
                where b.MSDSID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MMsds objUser)
        {
            _obAlphaToolEntities.MMsds.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MMsds obj)
        {
            MMsds existing = _obAlphaToolEntities.MMsds.Find(obj.MSDSID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MMsds.Remove(GetMMsdsbyId(id));
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

        public List<MMsds> GetAllMMsds()
        {
            var empQuery = from b in _obAlphaToolEntities.MMsds
                           where b.MSDSID > 0
                select b;

            var listMMsds = empQuery.ToList();
            return listMMsds;
        }

        public List<MMsds> GetAllMMsdsById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.MMsds
                           where b.MSDSID == groupId
                           select b;

            var listMMsds = empQuery.ToList();
            return listMMsds;
        }
    }
}
