using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VSBlog_Backend.Biz
{
    public class Helper
    {
        public static bool RebuildDb = false;

        public static Dictionary<string, string> Decode(object json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json.ToString());
        }

        public static List<object> DecodeToList(object json)
        {
            return JsonConvert.DeserializeObject<List<object>>(json.ToString());
        }

        public static DateTime? ParseDateTime(string dateTimeString)
        {
            if (dateTimeString == "") return null;
            try
            {
                return DateTime.Parse(dateTimeString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static bool? ParseBool(string boolString)
        {
            if (boolString == "") return null;
            try
            {
                return bool.Parse(boolString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}