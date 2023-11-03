using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AlphatoolServices.Utility
{
    public class Utility
    {
        // Enum Related Functions....

        //public static IDictionary<int, string> GetAll<TEnum>() where TEnum : struct
        //{
        //    var enumerationType = typeof(TEnum);
        //    if (!enumerationType.IsEnum)
        //        throw new ArgumentException("Enumeration type is expected.");
        //    Array enumArry = Enum.GetValues(enumerationType);
        //    var dictionary = new Dictionary<int, string>();
        //    foreach (int value in enumArry)
        //    {
        //        object enumObj = Enum.Parse(enumerationType, value.ToString());

        //        string description = GetDescription((Enum)enumObj);
        //        var enumDescription = description ?? Enum.GetName(enumerationType, value);
        //        dictionary.Add(value, enumDescription);
        //    }
        //    return dictionary;
        //}

        //public static string GetDescription(Enum value)
        //{
        //    var type = value.GetType();
        //    var name = Enum.GetName(type, value);
        //    if (name != null)
        //    {
        //        var field = type.GetField(name);
        //        if (field != null)
        //        {
        //            DescriptionAttribute attr =
        //                   Attribute.GetCustomAttribute(field,
        //                     typeof(DescriptionAttribute)) as DescriptionAttribute;
        //            if (attr != null)
        //            {
        //                return attr.Description;
        //            }
        //        }
        //    }
        //    return null;
        //}

        public static string GetMd5Hash(string password)
        {
            var encoder = new UTF8Encoding();
            var md5Hasher = new MD5CryptoServiceProvider();
            var hashedpwd = md5Hasher.ComputeHash(encoder.GetBytes(password));
            var hashAsString = HttpUtility.UrlEncode(Convert.ToBase64String(hashedpwd));
            return hashAsString;
        }

        public static void CopyTo(object s, object T)
        {
            foreach (var pS in s.GetType().GetProperties())
            {
                foreach (var pT in T.GetType().GetProperties())
                {
                    if (pT.Name != pS.Name) continue;
                    (pT.GetSetMethod()).Invoke(T, new[] { pS.GetGetMethod().Invoke(s, null) });
                }
            }
        }

        public static bool IsNumeric(string strVal)
        {
            int n;
            var isNumeric = int.TryParse(strVal, out n);
            return isNumeric;
        }

        public static bool IsDecimal(string strVal)
        {

            decimal d;
            var value = decimal.TryParse(strVal, out d);
            return value;
        }

        public static bool IsNumericOrDecimal(string strVal)
        {

            decimal d;
            int n;
            var isNumeric = int.TryParse(strVal, out n);
            var value = decimal.TryParse(strVal, out d);
            if (isNumeric)
            {
                return true;
            }
            if (value)
            {
                return true;
            }
            return false;
        }

        //Enum Controlll

        //public static IDictionary<int, string> GetOperantListFromControlID(int controlID, List<ColumnControl> listAllControls)
        //{
        //    List<ColumnControl> allControl = listAllControls;

        //    ColumnControl selectedControl = allControl.Where(x => x.Id == controlID).FirstOrDefault();
        //    IDictionary<int, string> controlDictionary = null;

        //    if (selectedControl != null)
        //    {
        //        string controlTextType = "";
        //        if (selectedControl.ControlType == EnumControlType.NumberText)
        //        {
        //            controlDictionary = Utility.GetAll<EnumControlOptionForNumber>();
        //        }
        //        else if (selectedControl.ControlType == EnumControlType.Obj)
        //        {
        //            controlDictionary = Utility.GetAll<EnumControlOptionForObj>();
        //        }
        //        else if (selectedControl.ControlType == EnumControlType.Text)
        //        {
        //            controlDictionary = Utility.GetAll<EnumControlOptionForText>();
        //        }
        //        else if (selectedControl.ControlType == EnumControlType.Time)
        //        {
        //            controlDictionary = Utility.GetAll<EnumControlOptionForTime>();
        //        }
        //        else if (selectedControl.ControlType == EnumControlType.Boolean)
        //        {
        //            controlDictionary = Utility.GetAll<EnumControlOptionForBoolean>();
        //        }
        //        controlTextType = Enum.GetName(typeof(EnumControlType), selectedControl.ControlType);
        //    }

        //    return controlDictionary;
        //}
    
        public static string GetUniqueKey(int maxSize)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(maxSize);
            foreach (var b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
    }
}

