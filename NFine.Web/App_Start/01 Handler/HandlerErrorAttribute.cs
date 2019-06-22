using NFine.Application.SystemSecurity;
using NFine.Code;
using NFine.Domain.Entity.SystemSecurity;
using System.Text;
using System.Web.Mvc;

namespace NFine.Web
{
    public class HandlerErrorAttribute : HandleErrorAttribute
    {
       
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            try
            {
                WriteLog(context);
            }
            catch { }
            context.Result = new ContentResult { Content = new AjaxResult { state = ResultType.error.ToString(), message = context.Exception.Message }.ToJson() };
        }
        private void WriteLog(ExceptionContext context)
        {
            if (context == null)
                return;
            var log = LogFactory.GetLogger(context.Controller.ToString());
            
            try
            {
                log.LogAll(() => { log.Error(context.Exception); }, () =>
                {
                    LogApp logApp = new LogApp();
                    LogEntity logEntity = new LogEntity();
                    logEntity.F_ModuleName = context.HttpContext.Request.Url.AbsoluteUri;
                    logEntity.F_Type = context.HttpContext.Request.Path;
                    logEntity.F_Result = false;
                    StringBuilder description = new StringBuilder();
                    foreach (string item in context.HttpContext.Request.QueryString.Keys)
                    {
                        description.Append(",");
                        description.Append("\"" + item + "\"");
                        description.Append(":");
                        description.Append("\"" + context.HttpContext.Request.QueryString[item] + "\"");
                    }
                    if (description.Length > 0)
                    {
                        description.Remove(0, 1);
                    }
                    foreach (string item in context.HttpContext.Request.Form.Keys)
                    {
                        description.Append(",");
                        description.Append("\"" + item + "\"");
                        description.Append(":");
                        description.Append("\"" + context.HttpContext.Request.Form[item] + "\"");
                    }
                    if (description.Length > 0)
                    {
                        description.Remove(0, 1);
                    }
                    description.Append("}");
                    description.Insert(0, "{");
                    logEntity.F_Description = description.ToString();
                    logApp.WriteDbLog(logEntity);
                });
            }
            catch { }
        }
    }
}