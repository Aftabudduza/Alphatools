using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AlphatoolServices.BO;

namespace AlphatoolServices.DA
{
    public class MembersDa : BaseDa
    {
        public MembersDa(bool isNewNewContext = false, bool isLazyLoadingEnable = true)
            : base(isNewNewContext, isLazyLoadingEnable)
        {

        }

        public Members GetMembersbyId(string id)
        {
            var empQuery = from b in ObAlphaToolEntities.Members
                where b.Account == id
                select b;

            var objMembers = empQuery.ToList().FirstOrDefault();
            return objMembers;
        }

        public bool Insert(Members obj)
        {
            ObAlphaToolEntities.Members.Add(obj);
            ObAlphaToolEntities.SaveChanges();
            return true;
        }

        //public int InsertReturnId(Members obj)
        //{
        //    ObAlphaToolEntities.Members.Add(obj);
        //    ObAlphaToolEntities.SaveChanges();
        //    var lastinsertedId = obj.ID;

        //    return lastinsertedId;
        //}

        public bool Update(Members obj)
        {
            Members existing = ObAlphaToolEntities.Members.Find(obj.Account);
            //((IObjectContextAdapter)ObjPracticeDbEntities).ObjectContext.Detach(existing);
            ((IObjectContextAdapter)ObAlphaToolEntities).ObjectContext.Detach(existing);
            ObAlphaToolEntities.Entry(obj).State = EntityState.Modified;
            ObAlphaToolEntities.SaveChanges();

            return true;
        }

        public bool DeleteById(string id)
        {
            ObAlphaToolEntities.Members.Remove(GetMembersbyId(id));
            ObAlphaToolEntities.SaveChanges();
            return true;
        }

        public List<Members> GetAllMembers()
        {
            var empQuery = from b in ObAlphaToolEntities.Members
                select b;

            var listMemberss = empQuery.ToList();
            return listMemberss;
        }

        

        public List<Members> GetMembersList_By_Email(string email)
        {
            var empQuery = from b in ObAlphaToolEntities.Members
                where b.Email == email
                select b;

            var listMemberss = empQuery.ToList();
            return listMemberss;
        }

        

        

        //public List<Members> GetAllMembers_CommunicationMembers()
        //{
        //    var empQuery = from b in ObAlphaToolEntities.Members
        //        where b.SystemMembersType_ID == "Administrator"
        //        select b;

        //    var listMemberss = empQuery.ToList();
        //    return listMemberss;
        //}

        public List<Members> GetMembersListBySql(string sql)
        {
            List<Members> userList = null;
            if (sql != "")
            {
                var empQuery = ObAlphaToolEntities.Members.SqlQuery(sql).ToList();
                userList = empQuery;
            }
            return userList;
        }

        //public Members GetMembersByIdPassword(string userName, string password)
        //{
        //    string pass = password;
        //    var empQuery = from b in ObAlphaToolEntities.Members
        //        where b.MembersName == userName && b.Password == pass
        //        select b;
        //    var objMembers = empQuery.ToList().FirstOrDefault();
        //    return objMembers;
        //}

        public Members GetMembersByEmailPassword(string email, string password)
        {
            string pass = password;
            var empQuery = from b in ObAlphaToolEntities.Members
                           where b.Email == email && b.Password == pass
                           select b;
            var objMembers = empQuery.ToList().FirstOrDefault();
            return objMembers;
        }

        //public Members GetMembersBy_Question_Answer(string answer)
        //{
        //    var empQuery = from b in ObAlphaToolEntities.Members
        //        where b.SecurityAnswer == answer
        //        select b;

        //    var objMembers = empQuery.ToList().FirstOrDefault();
        //    return objMembers;
        //}

        //public Members GetMembersByIdPasswordValidationCode(string userName, string password, string code)
        //{
        //    //string pass = Utility.GetMD5Hash(password);
        //    string pass = password;
        //    var empQuery = from b in ObAlphaToolEntities.Members
        //        where b.MembersName == userName && b.Password == pass && b.ValidationCode == code
        //        select b;

        //    var objMembers = empQuery.ToList().FirstOrDefault();
        //    return objMembers;
        //}

        //public Members GetMembersByEmailPasswordValidationCode(string email, string password, string code)
        //{
        //    //string pass = Utility.GetMD5Hash(password);
        //    string pass = password;
        //    var empQuery = from b in ObAlphaToolEntities.Members
        //                   where b.Email == email && b.Password == pass && b.ValidationCode == code
        //                   select b;

        //    var objMembers = empQuery.ToList().FirstOrDefault();
        //    return objMembers;
        //}

        //public Members CheckMembersNameExit(string userName)
        //{
        //    var empQuery = from b in ObAlphaToolEntities.Members
        //        where b.MembersName == userName
        //        select b;

        //    var objMembers = empQuery.ToList().FirstOrDefault();

        //    return objMembers;
        //}
        public Members CheckEmailAddressExist(string emailAdd)
        {
            var empQuery = from b in ObAlphaToolEntities.Members
                           where b.Email == emailAdd
                           select b;

            var objMembers = empQuery.ToList().FirstOrDefault();

            return objMembers;
        }

        public List<Members> InsertList(List<Members> objUpdate, List<Members> objinsertlist)
        {
            List<Members> returnList = new List<Members>();
            try
            {
                if (objUpdate.Count > 0)
                {
                    foreach (Members u in objUpdate)
                    {

                        Members existing = ObAlphaToolEntities.Members.Find(u.Account);
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
                    foreach (Members newMembers in objinsertlist)
                    {
                        ObAlphaToolEntities.Members.Add(newMembers);
                        ObAlphaToolEntities.SaveChanges();
                        returnList.Add(newMembers);

                    }
                }
            }
            catch
            {
                // ignored
            }
            return returnList;
        }

        

        //public List<Members> GetMemberss(string FirstName, string LastName)
        //{
        //    try
        //    {
        //        List<Members> listMemberss = null;

        //        List<Filter> filters = new List<Filter>();

        //        Filter ft = null;
        //        if (FirstName != string.Empty)
        //        {
        //            ft = new Filter { PropertyName = "FirstName", Operation = EnumOp.Contains, Value = FirstName };
        //            filters.Add(ft);
        //        }
        //        if (LastName != string.Empty)
        //        {
        //            ft = new Filter { PropertyName = "LastName", Operation = EnumOp.Contains, Value = LastName };
        //            filters.Add(ft);
        //        }
        //        var deleg = ExpressionBuilder.GetExpression<Members>(filters).Compile();
        //        listMemberss = ObjPracticeDbEntities.Members.Where(deleg).ToList();


        //        return listMemberss;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<Members> GetMembersByMembersType(string userType)
        //{
        //    try
        //    {
        //        List<Members> listMemberss = null;

        //        List<Filter> filters = new List<Filter>();

        //        Filter ft = null;
        //        if (userType != string.Empty)
        //        {
        //            ft = new Filter { PropertyName = "SystemMembersType_ID", Operation = EnumOp.Equals, Value = userType };
        //            filters.Add(ft);
        //        }

        //        var deleg = ExpressionBuilder.GetExpression<Members>(filters).Compile();
        //        listMemberss = ObjPracticeDbEntities.Members.Where(deleg).ToList();


        //        return listMemberss;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Members GetMembersBySchoolID_MembersType(int schoolid, string userType)
        //{
        //    Members objMembers = null;
        //    try
        //    {

        //        string pass = Utility.GetMD5Hash(password);
        //        string uType = userType.ToString();
        //        var empQuery = from b in ObjPracticeDbEntities.Members
        //                       where b.School_ID == schoolid && b.SystemMembersType_ID == uType
        //                       select b;

        //        objMembers = empQuery.ToList().FirstOrDefault();

        //        return objMembers;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<Members> GetCommitteesByLINQSearch(List<ExpressionParam> listParams)
        //{
        //    List<Members> comList = null;
        //    try
        //    {
        //        List<Filter> filters = new List<Filter>();
        //        foreach (ExpressionParam objParam in listParams)
        //        {

        //            Filter ft = null;
        //            EnumANDOR andorValu = EnumANDOR.NONE;
        //            if (objParam.AndOr != EnumANDOR.NONE)
        //            {
        //                andorValu = objParam.AndOr;
        //            }

        //            if (objParam.ControlValue != string.Empty && objParam.Operand != EnumOp.None)
        //            {
        //                if (objParam.StrValue != null && objParam.StrValue != "")
        //                {
        //                    ft = new Filter { PropertyName = objParam.ControlValue, Operation = objParam.Operand, Value = objParam.StrValue, AndOR = andorValu };
        //                }
        //                else if (objParam.NumValue != null && objParam.NumValue >= 0)
        //                {
        //                    ft = new Filter { PropertyName = objParam.ControlValue, Operation = objParam.Operand, Value = objParam.NumValue, AndOR = andorValu };
        //                }
        //                else if (objParam.DateValueStart != null && objParam.DateValueEnd != DateTime.MaxValue)
        //                {
        //                    if (objParam.Operand == EnumOp.IsBetween)
        //                    {
        //                        ft = new Filter { PropertyName = objParam.ControlValue, Operation = EnumOp.GreaterThanOrEqual, Value = objParam.DateValueStart, AndOR = andorValu };
        //                        filters.Add(ft);
        //                        ft = new Filter { PropertyName = objParam.ControlValue, Operation = EnumOp.LessThanOrEqual, Value = objParam.DateValueEnd, AndOR = EnumANDOR.AND };
        //                    }
        //                    else
        //                    {
        //                        ft = new Filter { PropertyName = objParam.ControlValue, Operation = objParam.Operand, Value = objParam.DateValueStart, AndOR = andorValu };
        //                    }
        //                }

        //                filters.Add(ft);
        //            }
        //        }
        //        var deleg = ExpressionBuilder.GetExpression<Members>(filters).Compile();
        //        comList = ObjPracticeDbEntities.Members.Where(deleg).ToList();
        //        return comList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public List<Members> GetCommitteesByLINQSearch(string colName, EnumOp enumOp, string strValue = null, int? numValue = null, DateTime? firstDateTime = null, DateTime? secondDateTime = null,
        //    string colName2 = "", EnumOp enumOp2 = EnumOp.None, string strValue2 = null, int? numValue2 = null, DateTime? firstDateTime2 = null, DateTime? secondDateTime2 = null)
        //{
        //    List<Members> comList = null;
        //    try
        //    {
        //        List<Filter> filters = new List<Filter>();

        //        Filter ft = null;
        //        if (colName != string.Empty && enumOp != EnumOp.None)
        //        {
        //            if (strValue != null && strValue != "")
        //                ft = new Filter { PropertyName = colName, Operation = enumOp, Value = strValue };
        //            else if (numValue != null && numValue >= 0)
        //                ft = new Filter { PropertyName = colName, Operation = enumOp, Value = numValue };
        //            else if (firstDateTime != null && firstDateTime != DateTime.MaxValue)
        //            {
        //                if (enumOp == EnumOp.IsBetween)
        //                {
        //                    ft = new Filter { PropertyName = colName, Operation = EnumOp.GreaterThanOrEqual, Value = firstDateTime };
        //                    filters.Add(ft);
        //                    ft = new Filter { PropertyName = colName, Operation = EnumOp.LessThanOrEqual, Value = secondDateTime };

        //                }
        //                else
        //                {
        //                    ft = new Filter { PropertyName = colName, Operation = enumOp, Value = firstDateTime };

        //                }
        //            }

        //            filters.Add(ft);

        //        }

        //        ft = null;
        //        if (colName2 != string.Empty && enumOp2 != EnumOp.None)
        //        {
        //            if (strValue2 != null && strValue2 != "")
        //                ft = new Filter { PropertyName = colName2, Operation = enumOp2, Value = strValue2 };
        //            else if (numValue2 != null && numValue2 >= 0)
        //                ft = new Filter { PropertyName = colName2, Operation = enumOp2, Value = numValue2 };
        //            else if (firstDateTime2 != null && firstDateTime2 != DateTime.MaxValue)
        //            {
        //                if (enumOp2 == EnumOp.IsBetween)
        //                {
        //                    ft = new Filter { PropertyName = colName2, Operation = EnumOp.GreaterThanOrEqual, Value = firstDateTime2 };
        //                    filters.Add(ft);
        //                    ft = new Filter { PropertyName = colName2, Operation = EnumOp.LessThanOrEqual, Value = secondDateTime2 };

        //                }
        //                else
        //                {
        //                    ft = new Filter { PropertyName = colName2, Operation = enumOp2, Value = firstDateTime2 };

        //                }
        //            }

        //            filters.Add(ft);

        //        }




        //        var deleg = ExpressionBuilder.GetExpression<Members>(filters).Compile();
        //        comList = ObjPracticeDbEntities.Members.Where(deleg).ToList();



        //        return comList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
