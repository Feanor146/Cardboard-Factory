using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Картонная_фабрика.Classes
{
    public class User
    {
        public string Login;
        public string Password;
        public static DataTable Users = DataBaseWork.GetTable("Users");

    }
    abstract class AuthorizedUser : User
    {
        public static int ID;        
        public static new string Login;
        public static new string Password;        
    }
}
