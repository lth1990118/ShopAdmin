using NFine.Application.Shop;
using NFine.Code;
using NFine.Domain._02_ViewModel;
using NFine.Domain._03_Entity.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.Shop.Controllers
{
    public class ItemMasterController : ControllerBase
    {
        private ItemMasterApp business = new ItemMasterApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = business.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = business.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        public ActionResult SubmitForm( string keyValue)
        {
            //ItemMasterViewModel entity, List< string > listPic, List<AttrInfo> listAttrInfo,
            var bytes = new byte[Request.InputStream.Length];
            Request.InputStream.Position = 0;
            Request.InputStream.Read(bytes, 0, bytes.Length);
            string str = Encoding.UTF8.GetString(bytes);
            ItemMasterViewModel entity = str.ToObject<ItemMasterViewModel>();
              business.SubmitForm(entity, keyValue);
            return Success("操作成功。");
        }

        public ActionResult FormAttr()
        {            
            return View();
        }
    }
}
