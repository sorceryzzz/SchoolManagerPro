﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZK.SchoolManagerPro.Bll;
using ZK.SchoolManagerPro.BLL;
using ZK.SchoolManagerPro.Model;

namespace ZK.SchoolManagerPro.WebPoint.Controllers
{
    public class AuthorityController : Controller
    {

        UserRoleBll userRoleBll = new UserRoleBll();
        BLL.AuthorityBll authorityBll = new BLL.AuthorityBll();
        BLL.RoleBll roleBll = new BLL.RoleBll();
        Role_AuthorityBll roleAuthorityBll = new Role_AuthorityBll();
        User_AuthorityBll userAuthorityBll = new User_AuthorityBll();
        StudentBll studentBll = new StudentBll();



        #region - 用户和角色-

        /// <summary>
        /// 添加角色和权限关联
        /// </summary>
        /// <returns></returns>
        public ActionResult EditUserRoleList()
        {
            var id = Request["id"];

            if (string.IsNullOrEmpty(id))
            {
                return Content("输入参数有误!");
            }
            
            var userModel = studentBll.GetModel(int.Parse(id));
            var roleList = roleBll.GetRoleList();

            ViewBag.UserModel = userModel;
            ViewBag.RoleList = roleList;
  
            return View();
        }


        /// <summary>
        /// 删除用户与权限
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteUserRoleInfo(int? t_uaid)
        {
            int result = userRoleBll.Delete(t_uaid);
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
        /// 获取用户和角色关联列表
        /// </summary>
        /// <returns></returns>
        public ActionResult UserRoleList(int? pageIndex)
        {
            if (pageIndex == null || pageIndex <= 0) pageIndex = 1;
            ViewBag.RedirectTo = "/Authority/UserRoleList/";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = 5;

            var count = userRoleBll.GetCount();//总条数

            ViewBag.Name = string.Empty;
            ViewBag.number = string.Empty;
            ViewBag.Department = string.Empty;
            ViewBag.TotalCount = count;
            DataTable dt = userRoleBll.GetUserRoleList(pageIndex.Value, 5);

            return View(dt);
        }




        /// <summary>
        /// 添加用户和权限关联
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUserRoleListForm()
        {
            
                var userid = Request["userid"];
                var roleId = Request["roleId"];
                var urname = Request["urname"];
                var roleName = Request["roleName"];

                var t_creater = "00000000000";

                if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(roleId))
                {
                    return Content("请输入用户与权限！");
                }
                Model.t_user_role tuaModel = new t_user_role();

                tuaModel.T_UserID = int.Parse(userid);
                tuaModel.T_UserName = urname;
                tuaModel.T_RoleID = int.Parse(roleId);
                tuaModel.T_RoleName = roleName;
                tuaModel.T_Creater = t_creater;
                tuaModel.T_CreateTime = DateTime.Now;
                tuaModel.T_UpdateTime = DateTime.Now;

                int rltInt = userRoleBll.Add(tuaModel);

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
        /// 添加用户和权限关联
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUserRoleList()
        {
            //var roleList = roleBll.GetRoleList();
            var userId = Request["userId"];

            if (string.IsNullOrEmpty(userId))
            {
                return Content("用户ID不能为空");
            }

            var userModel = studentBll.GetModel(int.Parse(userId));
            var roleList = roleBll.GetRoleList();


            //ViewBag.RoleList = roleList;
            ViewBag.UserModel = userModel;
            ViewBag.RoleList = roleList;

            return View();
        }
       

        #endregion


        #region - 用户和权限 -
        /// <summary>
        /// 获取用户和权限关联列表
        /// </summary>
        /// <returns></returns>
        public ActionResult UserAuthorityList(int? pageIndex)
        {
            if (pageIndex == null || pageIndex <= 0) pageIndex = 1;
            ViewBag.RedirectTo = "/Authority/UserAuthorityList/";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize =5;


            var count = userAuthorityBll.GetCount();//总条数

            ViewBag.Name = string.Empty;
            ViewBag.number = string.Empty;
            ViewBag.Department = string.Empty;
            ViewBag.TotalCount = count;
            DataTable dt = userAuthorityBll.GetUserAuthorityList(pageIndex.Value, 5);

            return View(dt);
        }
        /// <summary>
        /// 添加用户和权限关联
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUserAuthorityList()
        {
            //var roleList = roleBll.GetRoleList();
            var  userId= Request["userId"];

            if (string.IsNullOrEmpty(userId))
            {
                return Content("用户ID不能为空");
            }

            var userModel= studentBll.GetModel(int.Parse(userId));
            var authorityList = authorityBll.GetAuthorityList();


            //ViewBag.RoleList = roleList;
            ViewBag.UserModel = userModel;
            ViewBag.AuthorityList = authorityList;

            return View();
        }
        /// <summary>
        /// 添加用户和权限关联
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUserAuthorityListForm()
        {
            var userid = Request["userid"];
            var authorityId = Request["authorityId"];
            var urname = Request["urname"];
            var authorityName = Request["authorityName"];

            var t_creater = "00000000000";

            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(authorityId))
            {
                return Content("请输入用户与权限！");
            }
            Model.t_user_authority tuaModel = new t_user_authority();

            tuaModel.T_UserID =int.Parse( userid);
            tuaModel.T_UserName = urname;
            tuaModel.T_AuthorityID = int.Parse(authorityId);
            tuaModel.T_AuthorityName = authorityName;
            tuaModel.T_Creater = t_creater;
            tuaModel.T_CreateTime = DateTime.Now;
            tuaModel.T_UpdateTime = DateTime.Now;

            int rltInt = userAuthorityBll.Add(tuaModel);

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
        /// 删除用户与权限
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteUserAuthorityInfo(int? t_uaid)
        {
            int result = userAuthorityBll.Delete(t_uaid);
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
        /// 添加角色和权限关联
        /// </summary>
        /// <returns></returns>
        public ActionResult EditUserAuthorityList()
        {
            var id = Request["id"];

            if (string.IsNullOrEmpty(id))
            {
                return Content("输入参数有误!");
            }

            //查询实体
            var uaModel = userAuthorityBll.GetModel(int.Parse(id));

            var authorityList = authorityBll.GetAuthorityList();
            ViewBag.UaModel = uaModel;
            ViewData.Model = authorityList;
            //ViewBag.AuthorityList = authorityList;

            return View();
        }    
        /// <summary>  
        /// 添加角色和权限关联
        /// </summary>
        /// <returns></returns>
        public ActionResult EditUserAuthorityListForm()
        {
            var tuid = Request["tuid"];
            var userid = Request["userid"];
            var authorityId = Request["authorityId"];
            var urname = Request["urname"];
            var authorityName = Request["authorityName"];


            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(authorityId))
            {
                return Content("请输入用户与权限！");
            }
            Model.t_user_authority tuaModel = new t_user_authority();
            tuaModel.T_UaID = int.Parse(tuid);
            tuaModel.T_UserID = int.Parse(userid);
            tuaModel.T_UserName = urname;
            tuaModel.T_AuthorityID = int.Parse(authorityId);
            tuaModel.T_AuthorityName = authorityName;
            tuaModel.T_UpdateTime = DateTime.Now;


            int rltInt = userAuthorityBll.Update(tuaModel);

            if (rltInt > -1)
            {
                return Content("修改成功");
            }
            else
            {
                return Content("修改失败");
            }
        }
        #endregion

            #region - 角色和权限 -

            /// <summary>
            /// 添加角色和权限关联
            /// </summary>
            /// <returns></returns>
        public ActionResult AddRoleAuthorityList()
        {
           var roleList= roleBll.GetRoleList();

            var authorityList = authorityBll.GetAuthorityList();

            ViewBag.RoleList = roleList;

            ViewBag.AuthorityList = authorityList;

            return View();
        }
        /// <summary>
        /// 添加角色和权限关联
        /// </summary>
        /// <returns></returns>
        public ActionResult EditRoleAuthorityList()
        {
            var  id = Request["id"];

            if (string.IsNullOrEmpty(id))
            {
                return Content("输入参数有误!");
            }

            //查询实体
            var raModel=roleAuthorityBll.GetModel(int.Parse(id));


            var roleList = roleBll.GetRoleList();
            var authorityList = authorityBll.GetAuthorityList();
            ViewBag.RaModel = raModel;
            ViewBag.RoleList = roleList;
            ViewBag.AuthorityList = authorityList;

            return View();
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditRoleAuthorityInfo(int? id)
        {
            var roleId = Request["roleId"];
            var authorityId = Request["authorityId"];
            var roleName = Request["roleName"];
            var authorityName = Request["authorityName"];

            var t_creater = "00000000000";

            if (string.IsNullOrEmpty(roleId) || string.IsNullOrEmpty(authorityId))
            {
                return Content("请输入角色名称！");
            }

            Model.t_role_authority tModel = new Model.t_role_authority();
            tModel.T_Ra_ID =id.Value;
            tModel.T_RoleID = int.Parse(roleId);
            tModel.T_AuthorityID = int.Parse(authorityId);
            tModel.T_RoleName = roleName;
            tModel.T_AuthorityName = authorityName;

            tModel.T_UpdateTime = DateTime.Now;

            //update
            int rltInt = roleAuthorityBll.Update(tModel);

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
        /// 获取角色和权限关联列表
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleAuthorityList(int? pageIndex)
        {
            if (pageIndex == null || pageIndex <= 0) pageIndex = 1;
            ViewBag.RedirectTo = "/Authority/RoleAuthorityList/";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = 5;


            var count = roleAuthorityBll.GetCount();//总条数

            ViewBag.Name = string.Empty;
            ViewBag.number = string.Empty;
            ViewBag.Department = string.Empty;
            ViewBag.TotalCount = count;
            DataTable dt = roleAuthorityBll.GetRoleAuthorityList(pageIndex.Value, 5);

            return View(dt);
        }
        
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <returns></returns>
        public ContentResult AddRoleAuthorityInfo()
        {
            var roleId = Request["roleId"];
            var authorityId = Request["authorityId"];
            var roleName = Request["roleName"];
            var authorityName = Request["authorityName"];

            var t_creater = "00000000000";

            if (string.IsNullOrEmpty(roleId) || string.IsNullOrEmpty(authorityId))
            {
                return Content("请输入角色名称！");
            }

            Model.t_role_authority tModel = new Model.t_role_authority();
            tModel.T_RoleID = int.Parse(roleId);
            tModel.T_AuthorityID = int.Parse(authorityId);
            tModel.T_RoleName = roleName;
            tModel.T_AuthorityName = authorityName;

            tModel.T_Creater = t_creater;
            tModel.T_CreateTime = DateTime.Now;
            tModel.T_UpdateTime = DateTime.Now;
            //add
            int rltInt = roleAuthorityBll.Add(tModel);

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
        public ContentResult DeleteRoleAuthorityInfo(int t_ra_id)
        {
            int result = roleAuthorityBll.Delete(t_ra_id);
            if (result > 0)
            {
                return Content("删除成功！");
            }
            else
            {
                return Content("删除失败！");
            }
        }
        #endregion


        #region - 权限 -

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
        #endregion


        #region - 角色 -
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

        #endregion

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