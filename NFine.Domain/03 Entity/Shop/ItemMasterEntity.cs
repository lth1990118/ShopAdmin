using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.Shop
{
    public class ItemMasterEntity : IEntity<SaleEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int F_ID { get; set; }
        public string F_OwerOrg { get; set; }
        public string F_Name { get; set; }
        public string F_Code { get; set; }
        public string F_Desc { get; set; }
        public bool F_IsEnable { get; set; }
        public decimal F_POPrice { get; set; }

        public List<ItemMasterPicEntity> listPic { get; set; }

        public string F_CreatorUserId { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public bool? F_DeleteMark { get; set; }
        public string F_DeleteUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
    }
}
