using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.SchoolManagerPro.Model
{
    public class Students
    {
        public int ID { set; get; }
        public string UserName { set; get; }
        public string UserNum { set; get; }
        public int User_Category { get; set; }
        public string TeacherName { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public int state { get; set; }
        public string user_password { get; set; }

    }
}
