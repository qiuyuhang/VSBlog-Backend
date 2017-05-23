using System;
using System.Web.Http;
using VSBlog_Backend.Biz;

namespace VSBlog_Backend.Controller
{
    public class DebugModelController : ApiController
    {
        [HttpPost]
        public object Get(object json)
        {
            return DebugModelBiz.DebugModel(json);
        }
    }
}