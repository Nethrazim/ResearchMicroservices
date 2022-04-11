using System;
using System.Collections.Generic;
using System.Text;
using SO.BusinessLayer.Configuration;

namespace SO.BusinessLayer.Identity.Configurations
{
    public class IdentityConfigSection : IConfigSection
    {
        public const string ConfigurationSectionPath = "Identity";
        public string GetConfigurationSectionPath => ConfigurationSectionPath;
    }
}




