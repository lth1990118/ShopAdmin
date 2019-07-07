/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using System;

namespace NFine.Domain
{
    public interface IModificationAudited
    {
        int? F_LastModifyUserId { get; set; }
        DateTime? F_LastModifyTime { get; set; }
    }
}