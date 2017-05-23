using System.Web.Http;
using VSBlog_Backend.Biz;

namespace VSBlog_Backend.Controller
{
    public class SessionController:ApiController
    {
        [HttpPost]
        public object Login(object json)
        {
            return SessionBiz.Login(json);
        }
        
        [HttpGet]
        public object Authenticate(string Token)
        {
            return SessionBiz.Authenticate(Token);
        }
        
        [HttpDelete]
        public object Logout(object json)
        {
            return SessionBiz.Logout(json);
        }
    }
}