using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace XMLPayload
{
    /// <summary>
    /// XMLPayloadService için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class XMLPayloadService : System.Web.Services.WebService
    {

        [WebMethod]
        public string Payload(String xmlDocument)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlDocument);

            XmlNode declarationHeaderNode = doc.SelectSingleNode("/InputDocument/DeclarationList/Declaration");

            var command = declarationHeaderNode.Attributes["Command"].InnerText;

            if (command != "DEFAULT")
            {
                return "-1";
            }

            XmlNode siteIdNode = doc.SelectSingleNode("/InputDocument/DeclarationList/Declaration/DeclarationHeader/SiteID");

            var siteIdValue = siteIdNode.InnerText;

            if (siteIdValue != "DUB")
            {
                return "-2";
            }

            return "0";
        }
    }
}

