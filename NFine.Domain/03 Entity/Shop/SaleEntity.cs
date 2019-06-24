using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.Shop
{
    public class SaleEntity : IEntity<SaleEntity>//, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public int? UserID { get; set; }
        public int? SellTy { get; set; }
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int SellID { get; set; }
        public int? ULevel { get; set; }
        public decimal SellPrice { get; set; }
        public int? SellNum { get; set; }
        public int? UpLevel { get; set; }
        public int? CreateID { get; set; }
        public DateTime? CreateTime { get; set; }
        public int BonusFlag { get; set; }

        //public string F_Id { get ; set; }
        //public string F_CreatorUserId { get; set; }
        //public DateTime? F_CreatorTime { get; set; }
        //public bool? F_DeleteMark { get; set; }
        //public string F_DeleteUserId { get; set; }
        //public DateTime? F_DeleteTime { get; set; }
        //public string F_LastModifyUserId { get; set; }
        //public DateTime? F_LastModifyTime { get; set; }
    }
}
