using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using System;

namespace AlphatoolServices.DA
{
    public class EmailSignupDa : BaseDa
    {
        public EmailSignupDa(bool isNewNewContext = false, bool isLazyLoadingEnable = true)
            : base(isNewNewContext, isLazyLoadingEnable)
        {

        }
               
        public EmailSignup GetEmailSignupbyId(int id)
        {
            var empQuery = from b in ObAlphaToolEntities.EmailSignup
                where b.Id == id
                select b;

            var objEmailSignup = empQuery.ToList().FirstOrDefault();
            return objEmailSignup;
        }

        public bool Insert(EmailSignup obj)
        {
            ObAlphaToolEntities.EmailSignup.Add(obj);
            ObAlphaToolEntities.SaveChanges();
            return true;
        }       

        public bool Update(EmailSignup obj)
        {
            EmailSignup existing = ObAlphaToolEntities.EmailSignup.Find(obj.Id);
            ((IObjectContextAdapter)ObAlphaToolEntities).ObjectContext.Detach(existing);
            ObAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            ObAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            ObAlphaToolEntities.EmailSignup.Remove(GetEmailSignupbyId(id));
            ObAlphaToolEntities.SaveChanges();
            return true;
        }

        public List<EmailSignup> GetAllEmailSignup()
        {
            var empQuery = from b in ObAlphaToolEntities.EmailSignup
                select b;

            var listEmailSignups = empQuery.ToList();
            return listEmailSignups;
        }        

        public List<EmailSignup> GetEmailSignupList_By_Email(string email)
        {
            var empQuery = from b in ObAlphaToolEntities.EmailSignup
                where b.Email == email
                select b;

            var listEmailSignups = empQuery.ToList();
            return listEmailSignups;
        }          

        public List<EmailSignup> GetEmailSignupListBySql(string sql)
        {
            List<EmailSignup> userList = null;
            if (sql != "")
            {
                var empQuery = ObAlphaToolEntities.EmailSignup.SqlQuery(sql).ToList();
                userList = empQuery;
            }
            return userList;
        }
        
        public EmailSignup CheckEmailAddressExist(string emailAdd)
        {
            var empQuery = from b in ObAlphaToolEntities.EmailSignup
                           where b.Email == emailAdd
                           select b;

            var objEmailSignup = empQuery.ToList().FirstOrDefault();

            return objEmailSignup;
        }

        public List<EmailSignup> InsertList(List<EmailSignup> objUpdate, List<EmailSignup> objinsertlist)
        {
            List<EmailSignup> returnList = new List<EmailSignup>();
            try
            {
                if (objUpdate.Count > 0)
                {
                    foreach (EmailSignup u in objUpdate)
                    {
                        EmailSignup existing = ObAlphaToolEntities.EmailSignup.Find(u.Id);
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
                    foreach (EmailSignup newEmailSignup in objinsertlist)
                    {
                        ObAlphaToolEntities.EmailSignup.Add(newEmailSignup);
                        ObAlphaToolEntities.SaveChanges();
                        returnList.Add(newEmailSignup);
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
