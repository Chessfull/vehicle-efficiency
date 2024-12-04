using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Business.DataProtection
{
    public class DataProtection: IDataProtection // -> I will manage password crypt security processes here
    {
        private readonly IDataProtector _protector; // -> This is coming from a asp.net protection package

        public DataProtection(IDataProtectionProvider provider) // -> dependency injection of above
        {
            _protector = provider.CreateProtector("VehicleEfficiency-Security-v1"); // string part not consist can be everything
        }
        public string Crypt(string key)
        {
            return _protector.Protect(key); // -> This is a asp.net protection method for crypt
        }

        public string Encrypt(string key)
        {
            return _protector.Unprotect(key); // -> This is a asp.net protection method for encrypt
        }

    }
}
