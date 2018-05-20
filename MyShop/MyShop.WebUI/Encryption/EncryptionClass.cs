using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MyShop.WebUI.Encryption
{
    public class EncryptionClass
    {
        public void Encrypt()
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");

            ConnectionStringsSection connSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            connSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

            config.Save();
        }

        
    }
}