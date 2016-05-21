using System;
using System.Collections.Generic;

namespace ZK.SchoolManagerPro.Model
{
    /// <summary>
    /// 实体类 t_user_authority
    /// </summary>
    public partial class t_user_authority
    {

      public int T_UaID { set; get; }

      public int T_UserID { set; get; }

      public string T_UserName { set; get; }

      public int T_AuthorityID { set; get; }

      public string T_AuthorityName { set; get; }

      public string T_Creater { set; get; }

      public DateTime T_CreateTime { set; get; }

     
      public DateTime T_UpdateTime { set; get; }


    }
}