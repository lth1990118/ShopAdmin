using NFine.Code;
using NFine.Domain._02_ViewModel;
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

        public void SubmitForm(ItemMasterViewModel entity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {

                //entity.Modify(keyValue);
                //service.Update(entity);
            }
            else
            {
                
                ItemMasterEntity itemMasterEntity = new ItemMasterEntity() {
                    F_Code=entity.F_Code,
                    F_Name=entity.F_Name,
                    F_Desc = entity.F_Desc,
                    F_IsEnable = entity.F_IsEnable,
                    F_OwerOrg = entity.F_OwerOrg,
                    F_POPrice= entity.F_POPrice
                };
                itemMasterEntity.F_DeleteMark = false;
                itemMasterEntity.Create();
                
                int i = 0;
                List<ItemMasterPicEntity> listPic = new List<ItemMasterPicEntity>();
                foreach (var item in entity.listPic)
                {
                    ItemMasterPicEntity picEntity = new ItemMasterPicEntity()
                    {
                        F_IsMainPic = i == 0,
                        F_ItemMaster = itemMasterEntity.F_Id,
                        F_Path = item
                    };
                    picEntity.F_DeleteMark = false;
                    picEntity.Create();
                    listPic.Add(picEntity);
                    i++;
                }
                service.SubmitForm(itemMasterEntity, listPic, keyValue);
                //foreach (var item in entity.listAttrInfo)
                //{
                //    ItemMasterPicEntity picEntity = new ItemMasterPicEntity()
                //    {
                //        F_IsMainPic = i == 0,
                //        F_ItemMaster = itemMasterEntity.F_ID,
                //        F_Path = item
                //    };
                //    picEntity.Create();
                //    i++;
                //}

                //entity.Create();
                //service.Insert(entity);
            }
        }


        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.F_Id == keyValue.ToInt());
        }
    }
}
