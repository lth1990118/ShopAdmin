using NFine.Application.SystemSecurity;
using NFine.Code;
using NFine.Domain.Entity.SystemSecurity;
using System;
using System.Collections.Specialized;
using System.Text;
using System.Web.Mvc;

namespace NFine.Web
{
    [HandlerLogin]
    public abstract class ControllerBase : Controller
    {
        public Log FileLog
        {
            get { return LogFactory.GetLogger(this.GetType().ToString()); }
        }
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Form()
        {
            return View();
        }
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Details()
        {
            return View();
        }
        protected virtual ActionResult Success(string message)
        {

            FileLog.LogAll(new System.Threading.Tasks.Task(() => { FileLog.Info(message); }), new System.Threading.Tasks.Task(() =>
            {
                LogApp logApp = new LogApp();
                LogEntity logEntity = new LogEntity();
                logEntity.F_ModuleName = this.HttpContext.Request.Url.AbsoluteUri;
                logEntity.F_Type = this.HttpContext.Request.Path;
                logEntity.F_Result = true;
                StringBuilder description = new StringBuilder();
                foreach (string item in this.HttpContext.Request.QueryString.Keys)
                {
                    description.Append(",");
                    description.Append("\"" + item + "\"");
                    description.Append(":");
                    description.Append("\"" + this.HttpContext.Request.QueryString[item] + "\"");
                }
                if (description.Length > 0)
                {
                    description.Remove(0, 1);
                }
                foreach (string item in this.HttpContext.Request.Form.Keys)
                {
                    description.Append(",");
                    description.Append("\"" + item + "\"");
                    description.Append(":");
                    description.Append("\"" + this.HttpContext.Request.Form[item] + "\"");
                }
                if (description.Length > 0)
                {
                    description.Remove(0, 1);
                }
                description.Append("}");
                description.Insert(0, "{");
                logEntity.F_Description = description.ToString();
                logApp.WriteDbLog(logEntity);
            }));
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = message }.ToJson());
        }
        protected virtual ActionResult Success(string message, object data)
        {
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = message, data = data }.ToJson());
        }
        protected virtual ActionResult Error(string message)
        {
            return Content(new AjaxResult { state = ResultType.error.ToString(), message = message }.ToJson());
        }
    }
}
