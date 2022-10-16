using SO.BusinessLayer.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Identity.Configurations
{
    public class PublishEventsConfig : IConfigSection
    {
        public const string ConfigurationSectionPath = "PublishEvents";
        public string GetConfigurationSectionPath => ConfigurationSectionPath;
        public bool AutoStartPublishUserChangedEvents { get; set; }
    }
}
