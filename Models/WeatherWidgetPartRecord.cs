using Orchard.ContentManagement.Records;

namespace WeatherDotCom.Models
{
    public class WeatherPartRecord : ContentPartRecord
    {
        public virtual string webServiceUrl { get; set; }
        public virtual string searchString { get; set; }
        public virtual string partnerId { get; set; }
        public virtual string licenseKey { get; set; }
        public virtual int minutesToCache { get; set; }
    }
}