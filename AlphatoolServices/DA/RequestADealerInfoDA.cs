using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using System;

namespace AlphatoolServices.DA
{
    public class RequestADealerInfoDa : BaseDa
    {
        public RequestADealerInfoDa(bool isNewNewContext = false, bool isLazyLoadingEnable = true)
            : base(isNewNewContext, isLazyLoadingEnable)
        {

        }
               
        public RequestADealerInfo GetRequestADealerInfobyId(int id)
        {
            var empQuery = from b in ObAlphaToolEntities.RequestADealerInfo
                where b.Id == id
                select b;

            var objRequestADealerInfo = empQuery.ToList().FirstOrDefault();
            return objRequestADealerInfo;
        }

        public bool Insert(RequestADealerInfo obj)
        {
            ObAlphaToolEntities.RequestADealerInfo.Add(obj);
            ObAlphaToolEntities.SaveChanges();
            return true;
        }       

        public bool Update(RequestADealerInfo obj)
        {
            RequestADealerInfo existing = ObAlphaToolEntities.RequestADealerInfo.Find(obj.Id);
            ((IObjectContextAdapter)ObAlphaToolEntities).ObjectContext.Detach(existing);
            ObAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            ObAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            ObAlphaToolEntities.RequestADealerInfo.Remove(GetRequestADealerInfobyId(id));
            ObAlphaToolEntities.SaveChanges();
            return true;
        }

        public List<RequestADealerInfo> GetAllRequestADealerInfo()
        {
            var empQuery = from b in ObAlphaToolEntities.RequestADealerInfo
                select b;

            var listRequestADealerInfos = empQuery.ToList();
            return listRequestADealerInfos;
        }        

        public List<RequestADealerInfo> GetRequestADealerInfoList_By_Email(string email)
        {
            var empQuery = from b in ObAlphaToolEntities.RequestADealerInfo
                where b.Email == email
                select b;

            var listRequestADealerInfos = empQuery.ToList();
            return listRequestADealerInfos;
        }          

        public List<RequestADealerInfo> GetRequestADealerInfoListBySql(string sql)
        {
            List<RequestADealerInfo> userList = null;
            if (sql != "")
            {
                var empQuery = ObAlphaToolEntities.RequestADealerInfo.SqlQuery(sql).ToList();
                userList = empQuery;
            }
            return userList;
        }
        
        public RequestADealerInfo CheckEmailAddressExist(string emailAdd)
        {
            var empQuery = from b in ObAlphaToolEntities.RequestADealerInfo
                           where b.Email == emailAdd
                           select b;

            var objRequestADealerInfo = empQuery.ToList().FirstOrDefault();

            return objRequestADealerInfo;
        }

        public List<RequestADealerInfo> InsertList(List<RequestADealerInfo> objUpdate, List<RequestADealerInfo> objinsertlist)
        {
            List<RequestADealerInfo> returnList = new List<RequestADealerInfo>();
            try
            {
                if (objUpdate.Count > 0)
                {
                    foreach (RequestADealerInfo u in objUpdate)
                    {
                        RequestADealerInfo existing = ObAlphaToolEntities.RequestADealerInfo.Find(u.Id);
                        ((IObjectContextAdapter)ObAlphaToolEntities).ObjectContext.Detach(existing);
                        ObAlphaToolEntities.Entry(u).State = EntityState.Modified;
                        ObAlphaToolEntities.SaveChanges();
                    }
                }

            }
            catch
            {
                // ignored
            }
            try
            {
                if (objinsertlist.Count > 0)
                {
                    foreach (RequestADealerInfo newRequestADealerInfo in objinsertlist)
                    {
                        ObAlphaToolEntities.RequestADealerInfo.Add(newRequestADealerInfo);
                        ObAlphaToolEntities.SaveChanges();
                        returnList.Add(newRequestADealerInfo);
                    }
                }
            }
            catch
            {
                // ignored
            }
            return returnList;
        }
        
    }
}
