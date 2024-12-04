using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Business.Operations.User.Dtos
{
    public class AddUserDto // -> I created Data transfer object, controller to service on user register operations
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
