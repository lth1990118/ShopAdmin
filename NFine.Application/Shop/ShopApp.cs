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
    #region STAppSysApp
    public class STAppSysApp
    {
        private ISTAppSysRepository service = new STAppSysRepository();

        public List<STAppSysEntity> GetList()
        {
           return  service.IQueryable().OrderBy(t => t.SysCode).ToList();
        }
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
    #endregion

    #region CategoryApp  
    public class CategoryApp
    {
        private ICategoryRepository service = new CategoryRepository();

        public List<CategoryEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<CategoryEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_Name.Contains(keyword));
                expression = expression.Or(t => t.F_Code.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public CategoryEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void SubmitForm(CategoryEntity entity, string keyValue)
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


        public void DeleteForm(int keyValue)
        {
            service.Delete(t => t.F_ID == keyValue);
        }

        public List<CategoryEntity> GetList(string keyword)
        {
            return service.IQueryable().Where(t => string.IsNullOrEmpty(keyword) || t.F_Name.Contains(keyword) || t.F_Code.Contains(keyword)).OrderBy(t => t.F_ID).ToList();
        }
    }
    #endregion

}