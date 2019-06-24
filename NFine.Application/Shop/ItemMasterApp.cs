using NFine.Code;
using NFine.Domain._03_Entity.Shop;
using NFine.Domain.IRepository.Shop;
using NFine.Repository.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.Shop
{
    public class ItemMasterApp
    {
        private IItemMasterRepository service = new ItemMasterRepository();

        public List<ItemMasterEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<ItemMasterEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_Code.Contains(keyword));
                expression = expression.Or(t => t.F_Name.Contains(keyword));
                expression = expression.Or(t => t.F_Desc.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public ItemMasterEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void SubmitForm(ItemMasterEntity entity, string keyValue)
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
            service.Delete(t => t.F_ID == keyValue.ToInt());
        }
    }
}
