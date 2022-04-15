using System;
using System.Collections.Generic;
using System.Text;
using SO.BusinessLayer.Configuration;

namespace SO.BusinessLayer.Identity.Configurations
{
    public class IdentityConfig : IConfigSection
    {
        public const string ConfigurationSectionPath = "Identity";
        public string GetConfigurationSectionPath => ConfigurationSectionPath;
        public string IssuerSigningKey { get; set; }
        public bool ValidateAudience { get; set; }
        public string ValidAudience { get; set; }
        public bool ValidateIssuer { get; set; }
        public string ValidIssuer { get; set; }
    }
}




