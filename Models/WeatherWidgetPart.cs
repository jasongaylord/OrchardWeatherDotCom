using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;

namespace WeatherDotCom.Models
{
    public class WeatherPart : ContentPart<WeatherPartRecord>
    {
        [Required]
        [DefaultValue("http://xoap.weather.com/weather/local/{0}?cc=*&par={1}&key={2}")] 
        public string WebServiceUrl
        {
            get { return Record.webServiceUrl; }
            set { Record.webServiceUrl = value; }
        }

        [Required]
        [DefaultValue("18702")]
        public string SearchString
        {
            get { return Record.searchString; }
            set { Record.searchString = value; }
        }

        [Required]
        public string PartnerId
        {
            get { return Record.partnerId; }
            set { Record.partnerId = value; }
        }

        [Required]
        public string LicenseKey
        {
            get { return Record.licenseKey; }
            set { Record.licenseKey = value; }
        }

        [Required]
        [DefaultValue(15)]
        public int MinutesToCache
        {
            get { return Record.minutesToCache; }
            set { Record.minutesToCache = value; }
        }
    }
}