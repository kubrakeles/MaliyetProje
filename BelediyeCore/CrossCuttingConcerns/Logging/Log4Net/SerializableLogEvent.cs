using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeCore.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent //Loglanacak verinin kendisi
    {
        public LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }//Const injection

        //Loglama bilgisi olarak
        public string UserName => _loggingEvent.UserName; //ReadOnly olarak
        public object MessageObject => _loggingEvent.MessageObject;
    }
}
