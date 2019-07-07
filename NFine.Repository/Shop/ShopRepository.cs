using NFine.Data;
using NFine.Domain._03_Entity.Shop;
using NFine.Domain.IRepository.Shop;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NFine.Repository.Shop
{

    public class SaleRepository : RepositoryBase<SaleEntity>, ISaleRepository
    {
       
    }
    public class STAppSysRepository : RepositoryBase<STAppSysEntity>, ISTAppSysRepository
    {

    }
    public class ItemMasterRepository : RepositoryBase<ItemMasterEntity>, IItemMasterRepository
    {
        public void SubmitForm(ItemMasterEntity itemMaster, List<ItemMasterPicEntity> itemMasterPic, string keyValue)
        {

            if (!string.IsNullOrEmpty(keyValue))
            {
                //db.Update(itemMaster);
            }
            else
            {
                using (NFineDbContext db = new NFineDbContext())
                {
                    using (TransactionScope trans = new TransactionScope())
                    {
                        db.Entry<ItemMasterEntity>(itemMaster).State = EntityState.Added;
                        db.SaveChanges();
                        foreach (ItemMasterPicEntity item in itemMasterPic)
                        {
                            item.F_ItemMaster = itemMaster.F_Id;
                            db.Entry<ItemMasterPicEntity>(item).State = EntityState.Added;                            
                        }
                        db.SaveChanges();
                        trans.Complete();
                    }
                }
            }
        }
    }

    public class CategoryRepository : RepositoryBase<CategoryEntity>, ICategoryRepository
    {

    }
}
