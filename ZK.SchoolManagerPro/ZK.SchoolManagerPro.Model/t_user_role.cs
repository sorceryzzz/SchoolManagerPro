using System;
using System.Collections.Generic;

namespace ZK.SchoolManagerPro.Model
{
    /// <summary>
    /// 实体类 t_user_role
    /// </summary>
    public partial class t_user_role
    {

        #region - feild -
        private int t_urid;
        private int t_userid;
        private int t_roleid;
        private string t_creater;
        private DateTime t_createTime;
        private DateTime t_updateTime;
        #endregion

        #region - property -
        /// <summary>
        /// 主键
        /// </summary>
        public int T_UsrID { set { t_urid = value; } get { return t_urid; } }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int T_UserID { set { t_userid = value; } get { return t_userid; } }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int T_RoleID { set { t_roleid = value; } get { return t_roleid; } }
        /// <summary>
        /// 创建者
        /// </summary>
        public string T_Creater { set { t_creater = value; } get { return t_creater; } }
        /// <summary>
        /// 创建人
        /// </summary>
        public DateTime T_CreateTime { set { t_createTime = value; } get { return t_createTime; } }
        /// <summary>
        ///更新时间
        /// </summary>
        public DateTime T_UpdateTime { set { t_updateTime = value; } get { return t_updateTime; }

        #endregion


    }
}