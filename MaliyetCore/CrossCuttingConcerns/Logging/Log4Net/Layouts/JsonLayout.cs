using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetCore.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
            
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logevent = new SerializableLogEvent(loggingEvent); //burada loglanacak datayı ve usernamei gönderiyoruz.
            var json = JsonConvert.SerializeObject(logevent, Formatting.Indented);
            writer.WriteLine(json);
        }
    }
}
