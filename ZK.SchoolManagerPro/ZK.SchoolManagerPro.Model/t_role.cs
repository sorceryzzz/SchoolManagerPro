using System;
using System.Collections.Generic;

namespace ZK.SchoolManagerPro.Model
{
    /// <summary>
    /// 实体类 t_role
    /// </summary>
    public partial class t_role
    {
        public int R_ID { set; get; }
        public string R_Name { set; get; }

        public string R_Creater { set; get; }

        public DateTime R_CreateTime { set; get; }

        public DateTime R_UpdateTime { set; get; }

    }
}