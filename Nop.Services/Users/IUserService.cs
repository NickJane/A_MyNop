using Nop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Users
{
    public interface IUserService: IBaseService<Nop.Core.Domain.UserAccount,int>
    {
        IList<UserAccount> GetAllUsers();
    }
}
