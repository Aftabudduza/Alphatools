using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class MMaintenanceCardDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public MMaintenanceCardDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public MMaintenanceCardDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public MMaintenanceCard GetMMaintenanceCardbyId(int id)
        {
            var empQuery = from b in _obAlphaToolEntities.MMaintenanceCard
                where b.MaintenanceCardID == id
                select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }

        public bool Insert(MMaintenanceCard objUser)
        {
            _obAlphaToolEntities.MMaintenanceCard.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        //public bool InsertChild(SubCategory objUser)
        //{
        //    _obAlphaToolEntities.SubCategory.Add(objUser);
        //    _obAlphaToolEntities.SaveChanges();
        //    return true;
        //}

        public bool Update(MMaintenanceCard obj)
        {
            MMaintenanceCard existing = _obAlphaToolEntities.MMaintenanceCard.Find(obj.MaintenanceCardID);
            ((IObjectContextAdapter)_obAlphaToolEntities).ObjectContext.Detach(existing);
            _obAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            _obAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            _obAlphaToolEntities.MMaintenanceCard.Remove(GetMMaintenanceCardbyId(id));
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

        public List<MMaintenanceCard> GetAllMMaintenanceCard()
        {
            var empQuery = from b in _obAlphaToolEntities.MMaintenanceCard
                           where b.MaintenanceCardID > 0
                select b;

            var listMMaintenanceCard = empQuery.ToList();
            return listMMaintenanceCard;
        }

        public List<MMaintenanceCard> GetAllMMaintenanceCardById(int groupId)
        {
            var empQuery = from b in _obAlphaToolEntities.MMaintenanceCard
                           where b.MaintenanceCardID == groupId
                           select b;

            var listMMaintenanceCard = empQuery.ToList();
            return listMMaintenanceCard;
        }
    }
}
