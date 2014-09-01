﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kentor.AuthServices
{
    /// <summary>
    /// Helper for loading SAML2 metadata
    /// </summary>
    public static class MetadataLoader
    {
        /// <summary>
        /// Load and parse metadata.
        /// </summary>
        /// <param name="metadataUri">Uri to metadata</param>
        /// <returns>EntityDescriptor containing metadata</returns>
        public static EntityDescriptor Load(Uri metadataUri)
        {
            if(metadataUri == null)
            {
                throw new ArgumentNullException("metadataUri");
            }

            var metaDataXml = XDocument.Load(metadataUri.ToString());

            return ParseEntityDescriptor(metaDataXml.Root);
        }

        /// <summary>
        /// Parse xml into an EntityDescriptor.
        /// </summary>
        /// <param name="metadataXml"></param>
        /// <returns>EntityDescriptor with parsed data.</returns>
        public static EntityDescriptor ParseEntityDescriptor(XElement metadataXml)
        {
            if(metadataXml == null)
            {
                throw new ArgumentNullException("metadataXml");
            }

            ValidateEntityDescriptor(metadataXml);

            var entityDescriptor = new EntityDescriptor();

            return entityDescriptor;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "tc")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "EntityDescriptor")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "protocolSupportEnumeration")]
        private static void ValidateEntityDescriptor(XElement metadataXml)
        {
            if (metadataXml.Name != Saml2Namespaces.Saml2Metadata + "EntityDescriptor")
            {
                var msg = string.Format(CultureInfo.InvariantCulture,
                    "Unexpected element \"{0}\", expected \"{{urn:oasis:names:tc:SAML:2.0:metadata}}EntityDescriptor\".",
                    metadataXml.Name);
                throw new InvalidMetadataException(msg);
            }
        }
    }
}
