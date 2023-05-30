using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;
using AlphatoolServices.Utility;

namespace AlphatoolServices.DA
{
    public class EventCalendarDa
    {
        readonly AlphatoolEntities _obAlphaToolEntities;

        public EventCalendarDa()
        {
            _obAlphaToolEntities = MyEntity.GetEntity();
        }

        public EventCalendarDa(bool isNewContext)
        {
            _obAlphaToolEntities = MyEntity.GetFreshEntity();
        }

        //public EventCalendar GetEventCalendarbyId(int id)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.EventCalendar
        //        where b.ProductPageCode == id
        //        select b;

        //    var objUser = empQuery.ToList().FirstOrDefault();

        //    return objUser;
        //}

        public List<EventCalendar> GetAllEventCalendar()
        {
            var empQuery = from b in _obAlphaToolEntities.EventCalendar
                           //where b.ProductPageCode > 0
                select b;

            var listEventCalendar = empQuery.ToList();
            return listEventCalendar;
        }

        //public List<EventCalendar> GetAllEventCalendarByid(int id)
        //{
        //    var empQuery = from b in _obAlphaToolEntities.EventCalendar
        //                   where b.ProductPageCode == id
        //                   select b;

        //    var listEventCalendar = empQuery.ToList();
        //    return listEventCalendar;
        //}

        public List<EventCalendar> GetAllEventCalendarListBySQL(string sql)
        {
            List<EventCalendar> EventCalendarList = null;
            
                if (sql != "")
                {
                    var empQuery = _obAlphaToolEntities.EventCalendar.SqlQuery(sql).ToList<EventCalendar>();
                    EventCalendarList = empQuery;
                }
                return EventCalendarList;
        }
        
    }
}
