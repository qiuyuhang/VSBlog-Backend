using System;
using System.Linq;
using VSBlog_Backend.Model;

namespace VSBlog_Backend.Biz
{
    public class SessionBiz
    {
        public static object Login(object json)
        {
            using (var context = new BlogContext())
            {
                var body = Helper.Decode(json);
                var Email = body["Email"];
                var Password = body["Password"];

                if (!(from user in context.Users
                    where user.Email == Email
                    select user).Any())
                    return "Invalid User Id!";
                var query = from user in context.Users
                    where user.Email == Email && user.Password == Password
                    select user;
                if (!query.Any())
                    return "Wrong PWD!";

                var loginUser = query.Single();
                loginUser.GenerateToken();
                context.SaveChanges();
                return loginUser.GetInfoWithToken();
            }
        }

        public static object Logout(object json)
        {
            using (var context = new BlogContext())
            {
                var body = Helper.Decode(json);
                var Token = body["Token"];

                if (string.IsNullOrEmpty(Token))
                    return "Empty Token";
                var query = from user in context.Users
                    where user.Token == Token
                    select user;

                if (!query.Any())
                    return "Unknown Token";

                query.Single().GenerateToken();
                context.SaveChanges();

                return "success";
            }
        }

        public static object Authenticate(string Token)
        {
            using (var context = new BlogContext())
            {
                Console.WriteLine(Token);
                if (string.IsNullOrEmpty(Token))
                    return "Empty Token";
                var query = from user in context.Users
                    where user.Token == Token
                    select user;

                return query.Any() ? query.Single().GetPersonalInfo() : "Unknown Token";
            }
        }
    }
}