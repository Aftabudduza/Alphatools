using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class WhatIsNewDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public WhatIsNewDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public WhatIsNewDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        
        public List<WhatIsNew> GetAllWhatIsNew()
        {
            var empQuery = from b in _obAlphaToolEntities.WhatIsNew
                           //where b.ProductPageCode > 0
                select b;

            var listWhatIsNew = empQuery.ToList();
            return listWhatIsNew;
        }

        

        public List<WhatIsNew> GetAllWhatIsNewListBySQL(string sql)
        {
            List<WhatIsNew> WhatIsNewList = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.WhatIsNew.SqlQuery(sql).ToList<WhatIsNew>();
                    WhatIsNewList = empQuery;
                }
                return WhatIsNewList;
        }
        
    }
}
