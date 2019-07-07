using NFine.Domain._03_Entity.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.Shop
{
    public class SaleMap : EntityTypeConfiguration<SaleEntity>
    {
        public SaleMap()
        {
            this.ToTable("BTSell");
            this.HasKey(t => t.SellID);
        }
    }
    public class STAppSysMap : EntityTypeConfiguration<STAppSysEntity>
    {
        public STAppSysMap()
        {
            this.ToTable("STAppSys");
            this.HasKey(t => t.SysCode);
        }
    }
    public class CategoryMap : EntityTypeConfiguration<CategoryEntity>
    {
        public CategoryMap()
        {
            this.ToTable("CBO_Category");
            this.HasKey(t => t.F_ID);
        }

    }
    public class ItemMasterMap : EntityTypeConfiguration<ItemMasterEntity>
    {
        public ItemMasterMap()
        {
            this.ToTable("CBO_ItemMaster");
            this.HasKey(t => t.F_Id);
        }
        
    }
    public class ItemMasterPicMap : EntityTypeConfiguration<ItemMasterPicEntity>
    {
        public ItemMasterPicMap()
        {
            this.ToTable("CBO_ItemMasterPic");
            this.HasKey(t => t.F_Id);
        }

    }
}
