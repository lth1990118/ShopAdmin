using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.Shop
{
   
    public class STAppSysEntity : IEntity<STAppSysEntity>//, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public string SysCode { get; set; }

        public string LngCode { get; set; }
        public string SysName { get; set; }
        public string SysNameCN { get; set; }
        public decimal ExchRate { get; set; }

        //public string F_Id { get ; set; }
        //public string F_CreatorUserId { get; set; }
        //public DateTime? F_CreatorTime { get; set; }
        //public bool? F_DeleteMark { get; set; }
        //public string F_DeleteUserId { get; set; }
        //public DateTime? F_DeleteTime { get; set; }
        //public string F_LastModifyUserId { get; set; }
        //public DateTime? F_LastModifyTime { get; set; }
    }
    public class CategoryEntity : IEntity<CategoryEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int F_ID { get; set; }

        public string F_Code { get; set; }

        public string F_Name { get; set; }
        
        public int? F_CreatorUserId { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        [DefaultValue(false)]
        public bool? F_DeleteMark { get; set; }
        public int? F_DeleteUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public int? F_LastModifyUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
    }
}
