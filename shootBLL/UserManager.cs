using shootDAL;
using shootModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootBLL
{
    public class UserManager
    {
        public static void ModifyUser(User user)
        {
            UserService.modify(user);
        }
        public static DataTable getRankTable()
        {
            return UserService.getRankTable();
        }

        public static User register(string name, string pwd)
        {
            User user = new User(name, pwd);
            return UserService.register(user);
        }
        public static User login(string name, string pwd)
        {

            User user = new User(name, pwd);
            User user2 = UserService.GetUserByname(user.name);
            if (user2 != null && user.password == user2.password)
            {

                return user2;
            }
            else
            {
                return null;
            }
        }
    }
}
