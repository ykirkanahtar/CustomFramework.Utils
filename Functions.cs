using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;

namespace CustomFramework.Utils
{
    public static class Functions
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static List<Variance> DetailedCompare<T>(this T val1, T val2)
        {
            var variances = new List<Variance>();
            var fi = val1.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var f in fi)
            {
                var v = new Variance();
                v.Prop = f.Name;
                v.FirstObjectValue = f.GetValue(val1);
                v.SecondObjectValue = f.GetValue(val2);
                if (!v.FirstObjectValue.Equals(v.SecondObjectValue))
                    variances.Add(v);
            }
            return variances;
        }

        public static IEnumerable<string> Split(string str, int charCount)
        {
            while (str.Length > 0)
            {
                yield return new string(str.Take(charCount).ToArray());
                str = new string(str.Skip(charCount).ToArray());
            }
        }
    }
}