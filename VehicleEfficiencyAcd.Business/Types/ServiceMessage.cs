using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Business.Types
{
    public class ServiceMessage // -> I created this for communication and checking status
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
    }
    public class ServiceMessage<T>
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; } // -> Sometimes I will need data for return so I defined generic version as well
    }
}
