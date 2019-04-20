using System.Configuration;

namespace Sustainsys.Saml2.Configuration
{
    public class ExtensionsElement : ConfigurationElement
    {
        const string requestedAttributes = "requestedAttributes";
        /// <summary>
        /// Requested attributes of the service provider.
        /// </summary>
        [ConfigurationProperty(requestedAttributes)]
        [ConfigurationCollection(typeof(RequestedAttributesCollection))]
        public RequestedAttributesCollection RequestedAttributes => (RequestedAttributesCollection)base[requestedAttributes];
    }
}
