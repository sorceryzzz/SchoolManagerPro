using System;
using System.Collections.Generic;

namespace ZK.SchoolManagerPro.Model
{
    /// <summary>
    /// 实体类 t_role_authority
    /// </summary>
    public partial class t_role_authority
    {
        public int T_Ra_ID { set; get; }

        public int T_RoleID { set; get; }

        public string T_RoleName { set; get; }

        public int T_AuthorityID { set; get; }

        public string T_AuthorityName { set; get; }


        public string T_Creater { set; get; }

        public DateTime T_CreateTime { set; get; }

        public DateTime T_UpdateTime { set; get; }

    }
}