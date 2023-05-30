using System.Linq;
using AlphatoolServices;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using System;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class ProductSearchDa 
    {
         readonly AlphatoolEntities _obAlphaToolEntities;

        public ProductSearchDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public ProductSearchDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        public bool Insert(ProductSearch objUser)
        {
            _obAlphaToolEntities.ProductSearch.Add(objUser);
            _obAlphaToolEntities.SaveChanges();
            return true;
        }

        public List<ProductSearch> GetProductSearchBySearch(string search)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductSearch
                           where b.Keywords.Contains(search)
                select b;

            var listProductText = empQuery.ToList();
            return listProductText;
        }

        public ProductSearch GetBySearch(string search)
        {
            var empQuery = from b in _obAlphaToolEntities.ProductSearch
                           where b.Keywords == search
                           select b;

            var objUser = empQuery.ToList().FirstOrDefault();

            return objUser;
        }
      
    }
}
