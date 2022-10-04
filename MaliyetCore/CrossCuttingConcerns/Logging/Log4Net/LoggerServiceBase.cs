﻿using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MaliyetCore.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerServiceBase
    {
        private ILog _log;
        public LoggerServiceBase(string name) //name xml dosyasındaki filelogger bilgileri
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(inStream:File.OpenRead(path:"log4Net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), repositoryType: typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);

            _log = LogManager.GetLogger(loggerRepository.Name, name);
        }

        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
  
            
        public void Info(object logMessage)
        {
            if(IsInfoEnabled)
            _log.Info(logMessage);
        }
        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
                _log.Warn(logMessage);
        }
        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
                _log.Debug(logMessage);
        }
        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
                _log.Fatal(logMessage);
        }
        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
                _log.Error(logMessage);
        }

    }
}
