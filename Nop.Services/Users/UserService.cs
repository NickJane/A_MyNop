using Nop.Core.Data;
using Nop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain;

namespace Nop.Services.Users
{
    public class UserService : BaseService<Nop.Core.Domain.UserAccount, int>, IUserService
    {
        public IList<UserAccount> GetAllUsers() {

            /*
             var Name = "xpy0928";

            var Age = 5;

            var sql = "select ID, Name, Age from Student where Name = @Name and Age = @Age";

            ctx.Database.SqlQuery<Student>(
                sql, 
                new SqlParameter("@Name", Name),
                new SqlParameter("@Age", Age));
             
             */
            return this._repository.Database.SqlQuery<UserAccount>("select * from UserAccount").ToList();
        }
    }
}
