using System.Xml.Linq;

namespace Sustainsys.Saml2
{
    public static class EidasNamespaces
    {
        /// <summary>
        /// Namespace of the eidas protocol.
        /// </summary>
        public const string EidasName = "http://eidas.europa.eu/saml-extensions";

        /// <summary>
        /// Namespace of the SAML2 protocol.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
        public static readonly XNamespace Eidas = XNamespace.Get(EidasName);
    }
}
