using System;
using System.Linq;
using VSBlog_Backend.Model;

namespace VSBlog_Backend.Biz
{
    public class UserBiz
    {
        public static object GetUser(int Id, string Token)
        {
            using (var context = new BlogContext())
            {
                var selfQuery = from user in context.Users
                    where user.Id == Id && user.Token == Token
                    select new
                    {
                        user.Id,
                        user.Email,
                        user.Name,
                        user.Token,
                        user.Phonenumber,
                        user.RegisterTime,
                        user.Birthday,
                        user.Gender
                    };
                if (selfQuery.Any())
                    return selfQuery.SingleOrDefault();

                return (from user in context.Users
                    where user.Id == Id
                    select new
                    {
                        user.Id,
                        user.Name,
                        user.RegisterTime,
                    }).SingleOrDefault();
            }
        }

        public static object CreateUser(object json)
        {
            using (var context = new BlogContext())
            {
                var body = Helper.Decode(json);
                var Email = body["Email"];
                var Password = body["Password"];
                if ((from user in context.Users
                    where user.Email == Email
                    select user).Any())
                    return "Already regiested";
                context.Users.Add(new User()
                {
                    Email = Email,
                    Password = Password,
                    RegisterTime = DateTime.Now
                });
                //todo genToken and id &return
                return context.SaveChanges();
            }
        }

        public static object ModifyUser(object json)
        {
            using (var context = new BlogContext())
            {
                var body = Helper.Decode(json);
                var Id = int.Parse(body["Id"]);
                var Token = body["Token"];

                var query = from user in context.Users
                    where user.Id == Id && user.Token == Token
                    select user;
                if (!query.Any())
                    return "Auth Wrong!";

                var userToModify = query.Single();
                if (body.ContainsKey("Name"))
                    userToModify.Name = body["Name"];
                if (body.ContainsKey("Phonenumber"))
                    userToModify.Phonenumber = body["Phonenumber"];
                if (body.ContainsKey("Address"))
                    userToModify.Address = body["Address"];
                if (body.ContainsKey("Birthday"))
                    userToModify.Birthday = Helper.ParseDateTime(body["Birthday"]);
                if (body.ContainsKey("Gender"))
                    userToModify.Gender = Helper.ParseBool(body["Gender"]);
                context.SaveChanges();

                return userToModify.GetPersonalInfo();
            }
        }

        public static object ChangePassword(object json)
        {
            using (var context = new BlogContext())
            {
                var body = Helper.Decode(json);
                var Id = int.Parse(body["Id"]);
                var PasswordFrom = body["PasswordFrom"];
                var PasswordTo = body["PasswordTo"];

                if (!(from user in context.Users
                    where user.Id == Id
                    select user).Any())
                    return "Invalid User Id!";
                var query = from user in context.Users
                    where user.Id == Id && user.Password == PasswordFrom
                    select user;
                if (!query.Any())
                    return "Wrong PWD!";

                var userToModify = query.Single();
                userToModify.Password = PasswordTo;
                //todo reGenToken and return
                context.SaveChanges();
                return PasswordTo;
            }
        }

        public static object DeleteUser(object json)
        {
            using (var context = new BlogContext())
            {
                var body = Helper.Decode(json);
                var Id = int.Parse(body["Id"]);
                var Password = body["Password"];

                if (!(from user in context.Users
                    where user.Id == Id
                    select user).Any())
                    return "Invalid User Id!";
                var query = from user in context.Users
                    where user.Id == Id && user.Password == Password
                    select user;
                if (!query.Any())
                    return "Wrong PWD!";
                context.Users.Remove(query.Single());
                context.SaveChanges();
                return "success";
            }
        }
    }
}