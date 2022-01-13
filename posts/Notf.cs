using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostN;
using UserN;

namespace NotificationN
{
    public class Notf
    {
        public int id { get; set; }
        public string Text  { get; set; }
        public string Datetime { get; set; }
        public string FrmUser { get; set; }
        public Posts post { get; set; }
    }
}
