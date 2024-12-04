using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleEfficiencyAcd.Business.Operations.User.Dtos;
using VehicleEfficiencyAcd.Business.Types;

namespace VehicleEfficiencyAcd.Business.Operations.User
{
    public interface IUserService // -> Service interface for I will use User operations
    {
        Task<ServiceMessage> AddUser(AddUserDto userDto); // -> 'ServiceMessage' is object I defined FOR communication and checking status
        Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto userDto); // -> I used generic service message here ( include data ) cause I will use logined user infos which I use this with data transfer object I created
        UserInfoDto GetUser(int id);
    }
}
