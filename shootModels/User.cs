using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shootModels
{
    public class User
    {
        public int id;
        public string name;
        public string password;
        public string data;
        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public User()
        {
        }
    }
}
