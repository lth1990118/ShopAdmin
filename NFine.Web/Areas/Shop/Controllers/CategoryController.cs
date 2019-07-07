using NFine.Application.Shop;
using NFine.Code;
using NFine.Domain._03_Entity.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.Shop.Controllers
{
    public class CategoryController : ControllerBase
    {
        //
        // GET: /Shop/Category/
        private CategoryApp business = new CategoryApp();
        [HttpGet]
        //[HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson(string keyword)
        {
            var data = business.GetList(keyword);
            var treeList = new List<TreeSelectModel>();
            foreach (CategoryEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_ID.ToString();
                treeModel.text = item.F_Name;
                treeModel.data = item;
                treeList.Add(treeModel);
            }
            return Content(treeList.ToJson());
        }
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
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(CategoryEntity entity, string keyValue)
        {
            business.SubmitForm(entity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(int keyValue)
        {
            business.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}
