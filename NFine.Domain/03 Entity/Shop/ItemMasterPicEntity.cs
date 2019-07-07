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
    public class ItemMasterPicEntity : IEntity<SaleEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int F_Id { get; set; }
        public int F_ItemMaster { get; set; }
        public string F_Path { get; set; }
        public bool F_IsMainPic { get; set; }

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
