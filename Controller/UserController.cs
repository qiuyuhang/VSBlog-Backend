using System.Web.Http;
using VSBlog_Backend.Biz;

namespace VSBlog_Backend.Controller
{
    public class UserController : ApiController
    {
        [HttpGet]
        public object GetUser(int Id, string Token)
        {
            return UserBiz.GetUser(Id, Token);
        }
        
        [HttpPost]
        public object CreateUser(object json)
        {
            return UserBiz.CreateUser(json);
        }
        
        [HttpPut]
        public object ModifyUser(object json)
        {
            return UserBiz.ModifyUser(json);
        }
        
        [HttpPatch]
        public object ChangePassword(object json)
        {
            return UserBiz.ChangePassword(json);
        }
        
        [HttpDelete]
        public object DeleteUser(object json)
        {
            return UserBiz.DeleteUser(json);
        }
    }
}