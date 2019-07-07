using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._02_ViewModel
{
    public class ItemMasterViewModel
    {
        public int F_ID { get; set; }
        public string F_OwerOrg { get; set; }
        public string F_Name { get; set; }
        public string F_Code { get; set; }
        public string F_Desc { get; set; }
        public bool F_IsEnable { get; set; }
        public decimal F_POPrice { get; set; }

        public string Path { get; set; }

        public List<string> listPic { get; set; }

        public List<AttrInfo> listAttrInfo { get; set; }
    }

    public class AttrInfo
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public List<string> Son { get; set; }
    }

}
