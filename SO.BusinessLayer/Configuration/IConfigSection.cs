using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Configuration
{
    public interface IConfigSection
    {
        string GetConfigurationSectionPath { get; }
    }
}
