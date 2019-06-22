﻿/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using log4net;
using System;
using System.Threading.Tasks;
using System.Web;

namespace NFine.Code
{
    public class Log
    {
        public static HttpContext httpContext;
        private ILog logger;
        public Log(ILog log)
        {
            this.logger = log;
        }
        public void Debug(object message)
        {
            this.logger.Debug(message);
        }
        public void Error(object message)
        {
            this.logger.Error(message);
        }
        public void Info(object message)
        {
            this.logger.Info(message);
        }
        public void Warn(object message)
        {
            this.logger.Warn(message);
        }

        public void LogAll(Task actLogFile, Task action)
        {
            actLogFile.Start();
            action.Start();
        }
    }
}
