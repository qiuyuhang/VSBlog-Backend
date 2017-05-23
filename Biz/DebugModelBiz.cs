using System;
using System.Globalization;
using VSBlog_Backend.Model;

namespace VSBlog_Backend.Biz
{
    public static class DebugModelBiz
    {
        public static object DebugModel(object json)
        {
            var body = Helper.Decode(json);
            Helper.RebuildDb = bool.Parse(body["RebuildDb"]);
            using (var context = new BlogContext())
            {
                if (!Helper.RebuildDb) return context.SaveChanges();
                var user = new User()
                {
                    Email = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    Password = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    RegisterTime = DateTime.Now
                };
                context.Users.Add(user);
                return context.SaveChanges();
            }
        }
    }
}