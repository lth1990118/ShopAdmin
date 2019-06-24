using NFine.Data;
using NFine.Domain._03_Entity.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.IRepository.Shop
{

    public interface ISaleRepository : IRepositoryBase<SaleEntity>
    {
       
    }
    public interface ISTAppSysRepository : IRepositoryBase<STAppSysEntity>
    {

    }
    public interface IItemMasterRepository : IRepositoryBase<ItemMasterEntity>
    {

    }
}
