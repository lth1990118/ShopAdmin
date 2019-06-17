using NFine.Domain._03_Entity.Shop;
using System;
using System.Collections.Generic;
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
            this.HasKey(t => t.F_Id);
        }
    }
}
