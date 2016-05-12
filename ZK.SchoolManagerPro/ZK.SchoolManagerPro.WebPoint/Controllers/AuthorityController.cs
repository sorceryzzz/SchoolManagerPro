using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
        BLL.AuthorityBll authorityBll = new BLL.AuthorityBll();
        BLL.RoleBll roleBll = new BLL.RoleBll();


        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleList(int? pageIndex)
        {
            if (pageIndex == null || pageIndex <= 0) pageIndex = 1;
            ViewBag.RedirectTo = "/Authority/RoleList/";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = 5;


            var count = roleBll.GetCount();//总条数

            ViewBag.Name = string.Empty;
            ViewBag.number = string.Empty;
            ViewBag.Department = string.Empty;
            ViewBag.TotalCount = count;
            DataTable dt = roleBll.GetRoleList(pageIndex.Value, 5);

            return View(dt);
        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <returns></returns>
        public ContentResult AddRoleInfo()
        {
            var r_name = Request["r_name"];

            var t_creater = "00000000000";

            if (string.IsNullOrEmpty(r_name))
            {
                return Content("请输入角色名称！");
            }

            Model.t_role tModel = new Model.t_role();
            tModel.R_Name = r_name;
            tModel.R_Creater = t_creater;
            tModel.R_CreateTime = DateTime.Now;
            tModel.R_UpdateTime = DateTime.Now;
            //add
            int rltInt = roleBll.Add(tModel);

            if (rltInt > -1)
            {
                return Content("添加成功");
            }
            else
            {
                return Content("添加失败");
            }
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <returns></returns>
        public ContentResult DeleteRoleInfo(int ah_id)
        {
            int result = roleBll.Delete(ah_id);
            if (result > 0)
            {
                return Content("删除成功！");
            }
            else
            {
                return Content("删除失败！");
            }
        }
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetRoleModel(int? id)
        {
            var model = roleBll.GetModel(id);
            string jsonModel = JsonConvert.SerializeObject(model);
            return Content(jsonModel);
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditRoleInfo(int? id)
        {
            var r_name = Request["r_name"];

            var t_creater = "00000000000";

            if (string.IsNullOrEmpty(r_name))
            {
                return Content("请输入角色名称！");
            }

            Model.t_role tModel = new Model.t_role();
            tModel.R_ID = id.Value;
            tModel.R_Name = r_name;
            tModel.R_Creater = t_creater;
            tModel.R_UpdateTime = DateTime.Now;
            //add
            int rltInt = roleBll.Update(tModel);

            if (rltInt > -1)
            {
                return Content("修改成功");
            }
            else
            {
                return Content("修改失败");
            }
        }


        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns></returns>
        public ActionResult AuthorityList(int?pageIndex)
        {
            if (pageIndex == null || pageIndex <= 0) pageIndex = 1;
            ViewBag.RedirectTo = "/Authority/AuthorityList/";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = 5;


            var count = authorityBll.GetCount();//总条数

            ViewBag.Name = string.Empty;
            ViewBag.number = string.Empty;
            ViewBag.Department = string.Empty;
            ViewBag.TotalCount = count;
            DataTable dt = authorityBll.GetAuthorityList(pageIndex.Value, 5);

            return View(dt); 
        }
        public ActionResult GetModel(int? id)
        {
            var model = authorityBll.GetModel(id);
            string jsonModel = JsonConvert.SerializeObject(model);
            return Content(jsonModel);
        }
        public ActionResult EditAuthorityInfo(int? id)
        {
            var ah_name = Request["ah_name"];
            var ah_controller_url = Request["ah_controller_url"];
            var ah_action_url = Request["ah_action_url"];
       
            var t_creater = "00000000000";


            if (string.IsNullOrEmpty(ah_name))
            {
                return Content("请输入权限名称！");
            }
            if (string.IsNullOrEmpty(ah_controller_url))
            {
                return Content("请输入控制器URL！");
            }
            if (string.IsNullOrEmpty(ah_action_url))
            {
                return Content("请选择ActionUrl！");
            }


            Model.t_authority tModel = new Model.t_authority();
            tModel.AH_ID = id.Value;
            tModel.AH_Name = ah_name;
            tModel.AH_ControllerURL = ah_controller_url;
            tModel.AH_ActionUrl = ah_action_url;
            tModel.AH_Creater = t_creater;
            tModel.AH_UpdateTime = DateTime.Now;

            int result = authorityBll.Update(tModel);
            if (result > 0)
            {
                return Content("修改成功");
            }
            else
            {
                return Content("修改失败");
            }
        }


        /// <summary>
        /// 添加权限
        /// </summary>
        /// <returns></returns>
        public ContentResult AddAuthorityInfo()
        {

            var ah_name = Request["ah_name"];
            var ah_controller_url = Request["ah_controller_url"];
            var ah_action_url = Request["ah_action_url"];
            var t_creater = "00000000000";


            if (string.IsNullOrEmpty(ah_name))
            {
                return Content("请输入权限名称！");
            }
            if (string.IsNullOrEmpty(ah_controller_url))
            {
                return Content("请输入控制器URL！");
            }
            if (string.IsNullOrEmpty(ah_action_url))
            {
                return Content("请选择ActionUrl！");
            }


            Model.t_authority tModel = new Model.t_authority();
            tModel.AH_Name = ah_name;
            tModel.AH_ControllerURL = ah_controller_url;
            tModel.AH_ActionUrl = ah_action_url;
            tModel.AH_Creater = t_creater;
            tModel.AH_CreateTime = DateTime.Now;
            tModel.AH_UpdateTime = DateTime.Now;

            //add
            int rltInt = authorityBll.Add(tModel);

            if (rltInt > -1)
            {
                return Content("添加成功");
            }
            else
            {
                return Content("添加失败");
            }
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <returns></returns>
        public ContentResult DeleteAuthorityInfo(int ah_id)
        {
            int result = authorityBll.Delete(ah_id);
            if (result > 0)
            {
                return Content("删除成功！");
            }
            else
            {
                return Content("删除失败！");
            }
        }
        /// <summary>
        /// 添加用户和角色信息
        /// </summary>
        /// <returns></returns>
        public ContentResult AddUserRole()
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

            int rltBool = userRoleBll.Add(userRoleModel);

            return Content(rltBool > 0 ? "true" : "false");
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
            var t_urid = Request["t_urid"] == null ? -1 : int.Parse(Request["t_urid"]);

            //执行 
            int rltBool = userRoleBll.Delete(t_urid);

            return Content(rltBool > 0 ? "true" : "false");
        }


    }
}