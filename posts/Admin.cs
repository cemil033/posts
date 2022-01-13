using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostN;
using NotificationN;


namespace AdminN
{
    public class Admin
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Posts> posts;
        public List<Notf> notfs;
        public void Addpost(Posts t)
        {
            posts.Add(t);
        }
        public void AddNotf(Notf t)
        {
            notfs.Add(t);
        }
    }
}
