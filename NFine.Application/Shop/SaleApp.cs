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
    public class SaleApp
    {
        private ISaleRepository service = new SaleRepository();

        public List<SaleEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<SaleEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.SellID.ToString().Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public SaleEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void SubmitForm(SaleEntity saleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                
                saleEntity.Modify(keyValue);
                service.Update(saleEntity);
            }
            else
            {
                saleEntity.CreateTime = DateTime.Now;
                saleEntity.F_CreatorTime = DateTime.Now;

                saleEntity.Create();
                service.Insert(saleEntity);
            }
        }


        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.F_Id == keyValue);            
        }
        //public void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        //{
        //    if (!string.IsNullOrEmpty(keyValue))
        //    {
        //        userEntity.Modify(keyValue);
        //    }
        //    else
        //    {
        //        userEntity.Create();
        //    }
        //    service.SubmitForm(userEntity, userLogOnEntity, keyValue);
        //}
        //public void UpdateForm(UserEntity userEntity)
        //{
        //    service.Update(userEntity);
        //}
        //public UserEntity CheckLogin(string username, string password)
        //{
        //    UserEntity userEntity = service.FindEntity(t => t.F_Account == username);
        //    if (userEntity != null)
        //    {
        //        if (userEntity.F_EnabledMark == true)
        //        {
        //            UserLogOnEntity userLogOnEntity = userLogOnApp.GetForm(userEntity.F_Id);
        //            string dbPassword = Md5.md5(DESEncrypt.Encrypt(password.ToLower(), userLogOnEntity.F_UserSecretkey).ToLower(), 32).ToLower();
        //            if (dbPassword == userLogOnEntity.F_UserPassword)
        //            {
        //                DateTime lastVisitTime = DateTime.Now;
        //                int LogOnCount = (userLogOnEntity.F_LogOnCount).ToInt() + 1;
        //                if (userLogOnEntity.F_LastVisitTime != null)
        //                {
        //                    userLogOnEntity.F_PreviousVisitTime = userLogOnEntity.F_LastVisitTime.ToDate();
        //                }
        //                userLogOnEntity.F_LastVisitTime = lastVisitTime;
        //                userLogOnEntity.F_LogOnCount = LogOnCount;
        //                userLogOnApp.UpdateForm(userLogOnEntity);
        //                return userEntity;
        //            }
        //            else
        //            {
        //                throw new Exception("密码不正确，请重新输入");
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("账户被系统锁定,请联系管理员");
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("账户不存在，请重新输入");
        //    }
        //}
    }
}
