using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Business.DataProtection
{
    public interface IDataProtection // -> Interface of dprotection
    {
        string Crypt(string key);
        string Encrypt(string key);
    }
}
