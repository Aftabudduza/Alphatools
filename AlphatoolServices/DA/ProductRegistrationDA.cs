using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using System;

namespace AlphatoolServices.DA
{
    public class ProductRegistrationDa : BaseDa
    {
        public ProductRegistrationDa(bool isNewNewContext = false, bool isLazyLoadingEnable = true)
            : base(isNewNewContext, isLazyLoadingEnable)
        {

        }

       
        public ProductRegistration GetProductRegistrationbyId(int id)
        {
            var empQuery = from b in ObAlphaToolEntities.ProductRegistration
                where b.PRid == id
                select b;

            var objProductRegistration = empQuery.ToList().FirstOrDefault();
            return objProductRegistration;
        }

        public bool Insert(ProductRegistration obj)
        {
            ObAlphaToolEntities.ProductRegistration.Add(obj);
            ObAlphaToolEntities.SaveChanges();
            return true;
        }       

        public bool Update(ProductRegistration obj)
        {
            ProductRegistration existing = ObAlphaToolEntities.ProductRegistration.Find(obj.PRid);
            ((IObjectContextAdapter)ObAlphaToolEntities).ObjectContext.Detach(existing);
            ObAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            ObAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            ObAlphaToolEntities.ProductRegistration.Remove(GetProductRegistrationbyId(id));
            ObAlphaToolEntities.SaveChanges();
            return true;
        }

        public List<ProductRegistration> GetAllProductRegistration()
        {
            var empQuery = from b in ObAlphaToolEntities.ProductRegistration
                select b;

            var listProductRegistrations = empQuery.ToList();
            return listProductRegistrations;
        }        

        public List<ProductRegistration> GetProductRegistrationList_By_Email(string email)
        {
            var empQuery = from b in ObAlphaToolEntities.ProductRegistration
                where b.Email == email
                select b;

            var listProductRegistrations = empQuery.ToList();
            return listProductRegistrations;
        }          

        public List<ProductRegistration> GetProductRegistrationListBySql(string sql)
        {
            List<ProductRegistration> userList = null;
            if (sql != "")
            {
                var empQuery = ObAlphaToolEntities.ProductRegistration.SqlQuery(sql).ToList();
                userList = empQuery;
            }
            return userList;
        }
        
        public ProductRegistration CheckEmailAddressExist(string emailAdd)
        {
            var empQuery = from b in ObAlphaToolEntities.ProductRegistration
                           where b.Email == emailAdd
                           select b;

            var objProductRegistration = empQuery.ToList().FirstOrDefault();

            return objProductRegistration;
        }

        public List<ProductRegistration> InsertList(List<ProductRegistration> objUpdate, List<ProductRegistration> objinsertlist)
        {
            List<ProductRegistration> returnList = new List<ProductRegistration>();
            try
            {
                if (objUpdate.Count > 0)
                {
                    foreach (ProductRegistration u in objUpdate)
                    {

                        ProductRegistration existing = ObAlphaToolEntities.ProductRegistration.Find(u.PRid);
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
                    foreach (ProductRegistration newProductRegistration in objinsertlist)
                    {
                        ObAlphaToolEntities.ProductRegistration.Add(newProductRegistration);
                        ObAlphaToolEntities.SaveChanges();
                        returnList.Add(newProductRegistration);

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
