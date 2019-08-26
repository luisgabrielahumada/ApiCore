using System.Collections.Generic;
using Users.Rules.Model;

namespace Users.Rules.Interface
{
    public interface IUser
    {
        IList<User> Get();
    }
}
