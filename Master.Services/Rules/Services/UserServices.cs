using Insight.Database;
using Master.DataBase;
using System.Collections.Generic;
using Users.Rules.Interface;
using Users.Rules.Model;
namespace Users.Rules.Services
{
    public class UserServices : IUser
    {
        public UserServices(string connectionString) {
            Database.ConnectionString = connectionString;
        }
        public IList<User> Get()
        {
            return Database.CurrentCnn.QuerySql<User>("Select * from AppUsers");
        }
    }
}