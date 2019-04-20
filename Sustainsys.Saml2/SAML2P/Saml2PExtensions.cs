using System.Linq;
using System.Xml.Linq;
using Sustainsys.Saml2.Configuration;

namespace Sustainsys.Saml2.Saml2P
{
    public class Saml2PExtensions
    {
        public Saml2PExtensions(ExtensionsElement extensions)
        {
            if (extensions?.RequestedAttributes != null)
            {
                RequestedAttributes = extensions.RequestedAttributes;
            }
        }

        public RequestedAttributesCollection RequestedAttributes { get; }

        public XElement ToXElement()
        {
            var extensionElement = new XElement(Saml2Namespaces.Saml2P + "Extensions");

            if (RequestedAttributes != null && RequestedAttributes.Any())
            {
                extensionElement.Add(new XElement(
                    EidasNamespaces.Eidas + "RequestedAttributes",
                    RequestedAttributes.Select(x => new XElement(
                        EidasNamespaces.Eidas + "RequestedAttribute",
                        new XAttribute("Name", x.Name),
                        new XAttribute("NameFormat", x.NameFormat),
                        new XAttribute("IsRequired", x.IsRequired)))));
            }

            return extensionElement;
        }
    }
}
