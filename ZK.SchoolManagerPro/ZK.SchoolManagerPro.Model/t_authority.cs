using System;
using System.Collections.Generic;

namespace ZK.SchoolManagerPro.Model
{
    /// <summary>
    /// 实体类 t_authority
    /// </summary>
    public partial class t_authority
    {

        public int AH_ID { set; get; }

        public string AH_Name { set; get; }

        public string AH_ControllerURL { set; get; }

        public string AH_ActionUrl { set; get; }

        public string AH_Creater { set; get; }

        public DateTime AH_CreateTime { set; get; }

        public DateTime AH_UpdateTime { set; get; }
     }
}