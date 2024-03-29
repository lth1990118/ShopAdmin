﻿using NFine.Application.Shop;
using NFine.Code;
using NFine.Domain._03_Entity.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.Shop.Controllers
{
    public class SaleController : ControllerBase
    {
        private SaleApp saleApp = new SaleApp();
        
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = saleApp.GetList(pagination, keyword),
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
            var data = saleApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SaleEntity userEntity,string keyValue)
        {
            saleApp.SubmitForm(userEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            saleApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}
