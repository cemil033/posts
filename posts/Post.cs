using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostN
{
    public class Posts
    {
        public int id { get; set; }
        public string Content { get; set; }
        public string CreatingDateTime{ get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }

    }
}
