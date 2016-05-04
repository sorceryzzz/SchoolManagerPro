using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZK.SchoolManagerPro.BLL;
using ZK.SchoolManagerPro.Model;

namespace ZK.SchoolManagerPro.WebPoint.Controllers
{
    public class AuthorityController : Controller
    {

        UserRoleBll userRoleBll = new UserRoleBll();


        /// <summary>
        /// 添加用户和角色信息
        /// </summary>
        /// <returns></returns>
        public ContentResult AddUserRole()
        {
         t_user_role userRoleModel = new t_user_role();

          var t_urid =  Request["t_urid"];
          var t_userid = Request["t_userid"];
          var t_roleid = Request["t_roleid"];
          var t_creater = Request["t_creater"];

          userRoleModel.T_UsrID = int.Parse(t_urid);
          userRoleModel.T_UserID = int.Parse(t_userid); 
          userRoleModel.T_RoleID = int.Parse(t_roleid);

           //创建人
          userRoleModel.T_Creater = "";

          userRoleModel.T_CreateTime = DateTime.Now;
          userRoleModel.T_UpdateTime = DateTime.Now;

            int rltBool= userRoleBll.Add(userRoleModel);

            return Content(rltBool>0?"true":"false");
        }
        /// <summary>
        /// 更新用户角色信息
        /// </summary>
        /// <returns></returns>
        public ContentResult UpdateUserRole()
        {
            t_user_role userRoleModel = new t_user_role();
            var t_urid = Request["t_urid"];
            var t_userid = Request["t_userid"];
            var t_roleid = Request["t_roleid"];
            var t_creater = Request["t_creater"];
            userRoleModel.T_UsrID = int.Parse(t_urid);
            userRoleModel.T_UserID = int.Parse(t_userid);
            userRoleModel.T_RoleID = int.Parse(t_roleid);
            //创建人
            userRoleModel.T_Creater = "";
            userRoleModel.T_CreateTime = DateTime.Now;
            userRoleModel.T_UpdateTime = DateTime.Now;
            //执行
            int rltBool = userRoleBll.Update(userRoleModel);

            return Content(rltBool > 0 ? "true" : "false");
        }
        /// <summary>
        /// 删除用户和角色信息
        /// </summary>
        /// <returns></returns>
        public ContentResult DeleteUserRoleByID()
        {
            var t_urid = Request["t_urid"] == null ? -1 : int.Parse(Request["t_urid"]) ;

            //执行 
            int rltBool = userRoleBll.Delete(t_urid);

            return Content(rltBool > 0 ? "true" : "false");
        }


    }
}