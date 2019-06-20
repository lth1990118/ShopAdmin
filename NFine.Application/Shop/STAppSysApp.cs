using NFine.Code;
using NFine.Domain._03_Entity.Shop;
using NFine.Domain.IRepository.Shop;
using NFine.Repository.Shop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NFine.Application.Shop
{
    public class STAppSysApp
    {
        private ISTAppSysRepository service = new STAppSysRepository();

        public List<STAppSysEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<STAppSysEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.SysCode.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public STAppSysEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void SubmitForm(STAppSysEntity entity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {

                entity.Modify(keyValue);
                service.Update(entity);
            }
            else
            {


                entity.Create();
                service.Insert(entity);
            }
        }


        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.SysCode== keyValue);
        }
    }
}