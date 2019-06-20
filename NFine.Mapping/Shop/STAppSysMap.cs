using NFine.Domain._03_Entity.Shop;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.Shop
{
    public class STAppSysMap : EntityTypeConfiguration<STAppSysEntity>
    {
        public STAppSysMap()
        {
            this.ToTable("STAppSys");
            this.HasKey(t => t.SysCode);
        }
    }
}
