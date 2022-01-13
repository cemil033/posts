using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminN;
using UserN;
using PostN;
using NotificationN;


namespace DatabaseN
{
    static public class staId{
        static public int Id=0;
        static public int RId()
        {
            Id++;
            return Id;
        }
    }
    public class AdminuserDB
    {
        public List<Admin> admins;
        public List<User> users;

        public AdminuserDB()
        {
            admins = new();
            users = new();
        }
        public void AddAdmin(Admin t)
        {
            admins.Add(t);
        }
        public void AddUser(User t)
        {
            users.Add(t);
        }
    }
}
