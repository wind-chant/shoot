using MySqlConnector;
using shootModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootDAL
{
    public class UserService
    {
        public static User register(User user)
        {
            string sql = "INSERT user (name,password)" +
                "VALUES (@id, @password)";
            sql += " ; SELECT @@IDENTITY";
            MySqlParameter[] para = new MySqlParameter[]
           {
                new MySqlParameter("@id", user.name), //FK
				new MySqlParameter("@password", user.password), //FK
           };
            int newId = DBHelper.GetScalar(sql, para);
            return GetUserById(newId);
        }

        public static void modify(User user)
        {
            string sql =
                "UPDATE user " +
                "SET " +
                    "data = @data " + //FK
                    "point = @point " +
                "WHERE id = @id";
            MySqlParameter[] para = new MySqlParameter[]
              {
                new MySqlParameter("@id", user.id),
                new MySqlParameter("@data", user.data), //FK
                
                new MySqlParameter("@point", user.point), //FK

              };

            DBHelper.ExecuteCommand(sql, para);
        }


        public static User login(User user)
        {
            User user2 = GetUserByname(user.name);
            if (user2 != null && user.password == user2.password)
            {

                return user2;
            }
            else
            {
                return null;
            }
        }

        public static User GetUserById(int id)
        {
            string sql = "SELET * FROM user WHERE id = @id";
            using (MySqlDataReader reader = DBHelper.GetReader(sql, new MySqlParameter("@id", id)))//使用Using语句，资源可以得到及时释放
            {
                if (reader.Read())
                {
                    User user  = new User();
                    user.id = (int)reader["id"];
                    user.name = (string)reader["name"];
                    user.password = (string)reader["password"];
                    if (reader["data"] == DBNull.Value)
                        user.data = null;
                    else
                        user.data = (string)reader["data"];
                    if (reader["point"] == DBNull.Value)
                        user.point = 0;
                    else
                        user.point = (int)reader["point"];
                    return user;
                }
                else
                {
                    reader.Close();//没有记录时，也需要关闭reader
                    return null;
                }
            }
        }

        public static User GetUserByname(string name)
        {
            string sql = "SELECT * FROM user WHERE name = @name";
            using (MySqlDataReader reader = DBHelper.GetReader(sql, new MySqlParameter("@name", name)))//使用Using语句，资源可以得到及时释放
            {
                if (reader.Read())
                {
                    User user = new User();
                    user.id = (int)reader["id"];
                    user.name = (string)reader["name"];
                    user.password = (string)reader["password"];
                    if (reader["data"] == DBNull.Value)
                        user.data = null;
                    else
                        user.data = (string)reader["data"];
                    if (reader["point"] == DBNull.Value)
                        user.point = 0;
                    else
                        user.point = (int)reader["point"];
                    return user;
                }
                else
                {
                    reader.Close();//没有记录时，也需要关闭reader
                    return null;
                }
            }
        }
    }
}
