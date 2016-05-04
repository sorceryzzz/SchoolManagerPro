using Dinlun.GatewaySite.Common;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ZK.SchoolManagerPro.Bll;
using ZK.SchoolManagerPro.Model;

namespace ZK.SchoolManagerPro.WebPoint.Controllers
{
    public class StudentsController : Controller
    {
        StudentBll bll = new StudentBll();
        //
        // GET: /Students/
        public ActionResult Index(int? pageIndex, string Name, string number, string Class, string department)
        {
            if (pageIndex == null || pageIndex <= 0) pageIndex = 1;
            ViewBag.RedirectTo = "/Students/Index/";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = 5;
            
            #region 筛选条件

            string sqlWhere = " user_category=2";
            if (!string.IsNullOrEmpty(Name))
            {
                sqlWhere += string.Format(" AND user_name LIKE '%{0}%' ", Name);
            }
            if (!string.IsNullOrEmpty(number))
            {
                sqlWhere += string.Format(" AND user_num LIKE '%{0}%' ", number);
            }
            if (!string.IsNullOrEmpty(Class) && Class.Trim() != "请选择")
            {
                sqlWhere += string.Format(" AND class LIKE '%{0}%' ", Class);
            }
            if (!string.IsNullOrEmpty(department) && department != "请选择")
            {
                sqlWhere += string.Format(" AND department LIKE '%{0}%' ", department);
            }
            #endregion

            #region 绑定下拉框
            List<SelectListItem> departmentList = new List<SelectListItem>();
            departmentList.Add(new SelectListItem() { Text = "请选择", Value = "请选择", Selected = true });
            departmentList.Add(new SelectListItem() { Text = "计算机工程系", Value = "计算机工程系" });
            departmentList.Add(new SelectListItem() { Text = "机械工程系", Value = "机械工程系" });
            departmentList.Add(new SelectListItem() { Text = "设计艺术系", Value = "设计艺术系" });

            if (!string.IsNullOrEmpty(department) && department != "请选择")
            {
                for (int i = 0; i < departmentList.Count; i++)
                {
                    if (departmentList[i].Value == department)
                    {
                        departmentList[i].Selected = true;
                    }
                    else
                    {
                        departmentList[i].Selected = false;
                    }
                }
            }

            List<SelectListItem> classList = new List<SelectListItem>();
            classList.Add(new SelectListItem() { Text = "请选择", Value = "请选择", Selected = true });
            classList.Add(new SelectListItem() { Text = "班级一", Value = "班级一" });
            classList.Add(new SelectListItem() { Text = "班级二", Value = "班级二" });
            classList.Add(new SelectListItem() { Text = "班级三", Value = "班级三" });

            if (!string.IsNullOrEmpty(Class) && Class != "请选择")
            {
                for (int i = 0; i < classList.Count; i++)
                {
                    if (classList[i].Value == Class)
                    {
                        classList[i].Selected = true;
                    }
                    else
                    {
                        classList[i].Selected = false;
                    }
                }
            }

            #endregion

            var count = bll.GetTotalCount(sqlWhere);//总条数
            DataTable dt = bll.GetStudetnsList(pageIndex.Value, ViewBag.PageSize, sqlWhere, "user_Id,user_name,user_num,user_sex,teacherName,department,class", "user_Id");
            ViewBag.departmentList = departmentList;
            ViewBag.classList = classList;
            ViewBag.Class = Class;
            ViewBag.Department = department;
            ViewBag.TotalCount = count;
            ViewBag.Name = Name;
            ViewBag.number = number;
            return View(dt);
        }


        public ActionResult IndexTeacher(int? pageIndex, string Name, string number,string department)
        {
            if (pageIndex == null || pageIndex <= 0) pageIndex = 1;
            ViewBag.RedirectTo = "/Students/IndexTeacher/";
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = 5;

            #region 筛选条件

            string sqlWhere = " user_category=1";
            if (!string.IsNullOrEmpty(Name))
            {
                sqlWhere += string.Format(" AND user_name LIKE '%{0}%' ", Name);
            }
            if (!string.IsNullOrEmpty(number))
            {
                sqlWhere += string.Format(" AND user_num LIKE '%{0}%' ", number);
            }
            if (!string.IsNullOrEmpty(department) && department != "请选择")
            {
                sqlWhere += string.Format(" AND department LIKE '%{0}%' ", department);
            }
            #endregion

            #region 绑定下拉框
            List<SelectListItem> departmentList = new List<SelectListItem>();
            departmentList.Add(new SelectListItem() { Text = "请选择", Value = "请选择", Selected = true });
            departmentList.Add(new SelectListItem() { Text = "计算机工程系", Value = "计算机工程系" });
            departmentList.Add(new SelectListItem() { Text = "机械工程系", Value = "机械工程系" });
            departmentList.Add(new SelectListItem() { Text = "设计艺术系", Value = "设计艺术系" });

            if (!string.IsNullOrEmpty(department) && department != "请选择")
            {
                for (int i = 0; i < departmentList.Count; i++)
                {
                    if (departmentList[i].Value == department)
                    {
                        departmentList[i].Selected = true;
                    }
                    else
                    {
                        departmentList[i].Selected = false;
                    }
                }
            }

            #endregion

            var count = bll.GetTotalCount(sqlWhere);//总条数
            DataTable dt = bll.GetStudetnsList(pageIndex.Value, ViewBag.PageSize, sqlWhere, "user_Id,user_name,user_num,user_sex,teacherName,department,age,position", "user_Id");
            ViewBag.departmentList = departmentList;
            ViewBag.Department = department;
            ViewBag.Class = "班级三";
            ViewBag.TotalCount = count;
            ViewBag.Name = Name;
            ViewBag.number = number;
            return View(dt);
        }

        public ActionResult UploadPage()
        {
            return View();
        }
        public ActionResult SaveFile()
        {
            //string data = Request.Form["data"];
            //return Content(data);
            try
            {
                HttpPostedFileBase file = Request.Files["filePath"];
                string FileName = string.Empty;
                string strConn = string.Empty;
                string savePath;
                if (file == null || file.ContentLength <= 0)
                {
                    ViewBag.error = "文件不能为空";
                    string data = Request.Form["data"];
                    return Content("文件不能为空" + data);
                }
                else
                {
                    string filename = Path.GetFileName(file.FileName);
                    int filesize = file.ContentLength;     //获取上传文件的大小单位为字节byte
                    string fileEx = Path.GetExtension(filename); //获取上传文件的扩展名
                    string noFileName = Path.GetFileNameWithoutExtension(filename);//获取无扩展名的文件名
                    int Maxsize = 4000 * 1024;//定义上传文件的最大空间大小为4M
                    string FileType = ".xls,.xlsx";//定义上传文件的类型字符串

                    FileName = noFileName + DateTime.Now.ToString("yyyyMMddhhmmss") + fileEx;
                    if (!FileType.Contains(fileEx))
                    {
                        ViewBag.error = "文件类型不对，只能导入xls和xlsx格式的文件";
                        return Content("文件类型不对，只能导入xls和xlsx格式的文件");
                    }
                    if (filesize >= Maxsize)
                    {
                        ViewBag.error = "上传文件超过4M，不能上传";
                        return Content("上传文件超过4M，不能上传");
                    }
                    string path = AppDomain.CurrentDomain.BaseDirectory + "uploads/excel/";
                    savePath = Path.Combine(path, FileName);
                    file.SaveAs(savePath);

                    if (fileEx.Equals(".xlsx"))
                        strConn = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=" + savePath + ";Extended Properties='Excel 12.0 Xml; HDR=YES; IMEX=1'";
                    else if (fileEx.Equals(".xls"))
                        strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + savePath + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
                }
                var conn = new OleDbConnection(strConn);
                conn.Open();
                var myCommand = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn);
                var myDataSet = new DataSet();
                try
                {
                    myCommand.Fill(myDataSet, "ExcelInfo");
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.Message;
                    return Content(ex.Message);
                }
                DataTable table = myDataSet.Tables["ExcelInfo"].DefaultView.ToTable();

                DataTable dt = new DataTable();
                dt.Columns.Add("user_name", Type.GetType("System.String")); dt.Columns.Add("user_num", Type.GetType("System.String")); dt.Columns.Add("user_sex", Type.GetType("System.Int32")); dt.Columns.Add("department", Type.GetType("System.String")); dt.Columns.Add("class", Type.GetType("System.String")); dt.Columns.Add("mobile", Type.GetType("System.String"));

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = dt.NewRow();
                    row["user_name"] = table.Rows[i][0].ToString();
                    row["user_num"] = (table.Rows[i][1]).ToString();
                    if (table.Rows[i][2].ToString().Equals("男"))
                    {
                        row["user_sex"] = 0;
                    }
                    else
                    {
                        row["user_sex"] = 1;
                    }
                    row["department"] = table.Rows[i][3].ToString();
                    row["class"] = table.Rows[i][4].ToString();
                    row["mobile"] = table.Rows[i][5].ToString();
                    dt.Rows.Add(row);
                }

                // ImportMySQL(dt);
                List<string> cmdSqlList = CreateSqlList(dt);
                bool isSucceed = true;
                if (cmdSqlList.Count > 0)
                {
                    isSucceed = DbHelperMySql.ExecuteTransactionNew(DbHelperMySql.connectionStringManager, CommandType.Text, cmdSqlList.ToArray(), null);
                }
                if (isSucceed)
                {
                    return Content("导入成功");
                }
                else
                {
                    return Content("导入失败,请确认格式是否正确！");
                }
            }
            catch (Exception ex)
            {

                return Content("批量导入失败：" + ex.Message);
            }
            

        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult ResetPassWord(int Id,string userNumber)
        {
            if (Id <= 0)
                return Content("请先选择要重置密码的用户！");
            int result = bll.ResetPassword(Id, userNumber + "123456");
            if (result > 0)
            {
                return Content("修改成功！");
            }
            else
            {
                return Content("修改失败！");
            }
        }
        public ActionResult EditStudent()
        {
            return View();
        }
        public ActionResult Edit(Students student)
        {
            Students model = new Students();
            model.ID = student.ID;
            model.UserNum = student.UserNum;
            model.UserName = student.UserName;
            model.Sex = student.Sex;
            model.TeacherName = student.TeacherName;
            model.Class = student.Class;
            model.Department = student.Department;
            int result = bll.Edit(model);
            if (result > 0)
            {
                return Content("ok");
            }
            else
            {
                return Content("修改失败");
            }
        }

        public ActionResult Add(Students student)
        {
            #region 数据验证
            if (string.IsNullOrEmpty(student.UserNum))
            {
                return Content("请输入学生编号！");
            }
            if (string.IsNullOrEmpty(student.UserName))
            {
                return Content("请输入学生姓名！");
            }
            if (string.IsNullOrEmpty(student.Class))
            {
                return Content("请选择学生班级！");
            }
            if (string.IsNullOrEmpty(student.Department))
            {
                return Content("请选择学生院系！");
            }
            #endregion
            Students model = new Students();           
            model.UserNum = student.UserNum;
            model.UserName = student.UserName;
            model.Sex = student.Sex;
            model.User_Category = 2;
            model.TeacherName = student.TeacherName;
            model.Class = student.Class;
            model.Department = student.Department;
            model.state = 0;
            int result = bll.Add(model);
            if (result > 0)
            {
                return Content("添加成功");
            }
            else
            {
                return Content("添加失败");
            }
        }

        public ActionResult GetModel(int id)
        {
            Students model = bll.GetModel(id);
            string jsonModel = JsonConvert.SerializeObject(model);
            return Content(jsonModel);
        }

        public ActionResult DeleteUser(int id)
        {
            int result = bll.DeleteStudent(id);
            if (result > 0)
            {
                return Content("删除成功！");
            }
            else
            {
                return Content("删除失败！");
            }
            
        }
        
        public List<string> CreateSqlList(DataTable dt)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(string.Format("INSERT INTO t_users(user_name,user_num,user_sex,department,class,mobile,user_category,state) VALUES('{0}','{1}',{2},'{3}','{4}','{5}',{6},{7})", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), Convert.ToInt32(dt.Rows[i][2]), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), 2, 0));
            }
            return list;
        }

        private string ImportMySQL(DataTable dt)
        {
            string strFile = "/TempFolder/MySQL" + DateTime.Now.Ticks.ToString() + ".csv";       //Create directory if not exist... Make sure directory has required rights..    
            if (!Directory.Exists(Server.MapPath("~/TempFolder/")))
                Directory.CreateDirectory(Server.MapPath("~/TempFolder/"));       //If file does not exist then create it and right data into it..     
            if (!System.IO.File.Exists(Server.MapPath(strFile)))
            {
                FileStream fs = new FileStream(Server.MapPath(strFile), FileMode.Create, FileAccess.Write);
                fs.Close();
                fs.Dispose();
            }
           // DbHelperMySql.ExecuteTransaction()
            CreateCSVfile(dt, Server.MapPath(strFile));
            MySqlBulkLoader bcp1 = new MySqlBulkLoader(new MySqlConnection(DbHelperMySql.connectionStringManager));
            bcp1.TableName = "users";
            bcp1.FieldTerminator = ",";
            bcp1.LineTerminator = "\r\n";
            bcp1.FileName = Server.MapPath(strFile);
            bcp1.NumberOfLinesToSkip = 0;
            bcp1.Load();

            string strReturn = string.Empty;
            try
            {
                //System.IO.File.Delete(Server.MapPath(strFile));
                strReturn = "成功";
            }
            catch (Exception ex)
            {
                strReturn = ex.Message;
            }

            
            ////Generate csv file from where data read 
            //CreateCSVfile(orderDetail, Server.MapPath(strFile));
            //using (MySqlConnection cn1 = new MySqlConnection(connectMySQL))
            //{
            //    cn1.Open();
            //    MySqlBulkLoader bcp1 = new MySqlBulkLoader(cn1);
            //    bcp1.TableName = "productorder"; //Create ProductOrder table into MYSQL database...     
            //    bcp1.FieldTerminator = ",";
            //    bcp1.LineTerminator = "\r\n";
            //    bcp1.FileName = Server.MapPath(strFile);
            //    bcp1.NumberOfLinesToSkip = 0;
            //    bcp1.Load();       //Once data write into db then delete file..    
            //    try
            //    {
            //        File.Delete(Server.MapPath(strFile));
            //    }
            //    catch (Exception ex)
            //    {
            //        string str = ex.Message;
            //    }
            //}
            return strReturn;
        }            
        public static void CreateCSVfile(DataTable dtable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
            int icolcount = dtable.Columns.Count;
            foreach (DataRow drow in dtable.Rows)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    if (!Convert.IsDBNull(drow[i]))
                    {
                        sw.Write(drow[i].ToString());
                    }
                    if (i < icolcount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
            sw.Dispose();
        }


	}
}