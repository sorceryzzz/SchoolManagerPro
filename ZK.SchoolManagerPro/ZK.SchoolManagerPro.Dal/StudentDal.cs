using Dinlun.GatewaySite.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZK.SchoolManagerPro.Model;

namespace ZK.SchoolManagerPro.Dal
{
    public class StudentDal
    {
        public DataSet GetStudetnsList(int pageIndex, int pageSize, string strWhere, string columns, string sort)
        {

            string cmdText = string.Empty;
            cmdText = string.Format("SELECT {0} FROM t_users WHERE {1} ORDER BY {2} LIMIT {3},{4}", columns, strWhere, sort, (pageIndex - 1) * pageSize, pageSize);
            DataSet ds = DbHelperMySql.GetDataSet(DbHelperMySql.connectionStringManager, cmdText);
            return ds;
        }
        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public int GetTotalCount(string sqlWhere)
        {
            string cmdText = string.Format("SELECT COUNT(*) FROM t_users WHERE {0}", sqlWhere);
            return Convert.ToInt32(DbHelperMySql.ExecuteScalar(DbHelperMySql.connectionStringManager, CommandType.Text, cmdText));
        }

        public int Edit(Students model)
        {
            string cmdText = string.Format("UPDATE t_users SET user_name=@name,user_num=@num,teacherName=@teacher,user_sex=@sex,department=@department,class=@class WHERE user_Id=@Id");
            MySqlParameter[] parms ={
                                    new MySqlParameter("@name",MySqlDbType.VarChar),
                                    new MySqlParameter("@num",MySqlDbType.VarChar),
                                    new MySqlParameter("@teacher",MySqlDbType.VarChar),
                                    new MySqlParameter("@sex",MySqlDbType.Int32),
                                    new MySqlParameter("@department",MySqlDbType.VarChar),
                                    new MySqlParameter("@class",MySqlDbType.VarChar),
                                    new MySqlParameter("@Id",MySqlDbType.Int32)
                                   };
            parms[0].Value = model.UserName;
            parms[1].Value = model.UserNum;
            parms[2].Value = model.TeacherName;
            parms[3].Value = model.Sex;
            parms[4].Value = model.Department;
            parms[5].Value = model.Class;
            parms[6].Value = model.ID;
            return DbHelperMySql.ExecuteNonQuery(DbHelperMySql.ConnectionStringManager, CommandType.Text, cmdText, parms);
        }

        public int Add(Students model)
        {
            string cmdText = string.Format("INSERT INTO  t_users (user_name,user_num,teacherName,user_sex,department,class,user_category,state,position) VALUES(@name,@num,@teacher,@sex,@department,@class,@category,@state,@position)");
            MySqlParameter[] parms ={
                                    new MySqlParameter("@name",MySqlDbType.VarChar),
                                    new MySqlParameter("@num",MySqlDbType.VarChar),
                                    new MySqlParameter("@teacher",MySqlDbType.VarChar),
                                    new MySqlParameter("@sex",MySqlDbType.Int32),
                                    new MySqlParameter("@department",MySqlDbType.VarChar),
                                    new MySqlParameter("@class",MySqlDbType.VarChar),
                                    new MySqlParameter("@category",MySqlDbType.Int32),
                                    new MySqlParameter("@state",MySqlDbType.Int32),
                                    new MySqlParameter("@position",MySqlDbType.VarChar)
                                   };
            parms[0].Value = model.UserName;
            parms[1].Value = model.UserNum;
            parms[2].Value = model.TeacherName;
            parms[3].Value = model.Sex;
            parms[4].Value = model.Department;
            parms[5].Value = model.Class;
            parms[6].Value = model.User_Category;
            parms[7].Value = model.state;
            parms[8].Value = model.Position;
            return DbHelperMySql.ExecuteNonQuery(DbHelperMySql.ConnectionStringManager, CommandType.Text, cmdText, parms);
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int ResetPassword(int Id,string password)
        {
            string cmdText = "UPDATE t_users SET user_password=@password WHERE user_Id=@Id";
            MySqlParameter[] parms ={
                                  new MySqlParameter("@password",MySqlDbType.VarChar),
                                  new MySqlParameter("@Id",MySqlDbType.Int32)
                                  };
            parms[0].Value = password;
            parms[1].Value = Id;
            return DbHelperMySql.ExecuteNonQuery(DbHelperMySql.ConnectionStringManager, CommandType.Text, cmdText, parms);

        }

        public Students GetModel(int Id)
        {
            string cmdText = "SELECT user_Id,user_name,user_num,user_sex,teacherName,department,class FROM t_users WHERE user_Id=@user_Id";
            MySqlParameter[] parms =
            {
                new MySqlParameter("@user_Id",MySqlDbType.Int32)
            };
            parms[0].Value = Id;
            MySqlDataReader reader = DbHelperMySql.ExecuteReader(DbHelperMySql.connectionStringManager, CommandType.Text, cmdText, parms);
            List<Students> list = ExecuteList(reader);
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        public List<Students> ExecuteList(MySqlDataReader reader)
        {
            List<Students> list = new List<Students>();
            try
            {
                while (reader.Read())
                {
                    Students model = new Students();
                    model.ID = Convert.ToInt32(reader["user_Id"]);
                    model.UserName = reader["user_name"].ToString();
                    model.UserNum = reader["user_num"].ToString();
                    model.Sex = Convert.ToInt32(reader["user_sex"]);
                    model.TeacherName = reader["teacherName"].ToString();
                    model.Department = reader["department"].ToString();
                    model.Class = reader["class"].ToString();
                    list.Add(model);
                } 
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public int DeleteStudent(int Id)
        {
            string cmdText = string.Empty;
            cmdText = string.Format("DELETE FROM t_users WHERE user_Id={0}", "@Id");
            MySqlParameter[] parms = { new MySqlParameter("@Id", MySqlDbType.Int32) };
            parms[0].Value = Id;
            return DbHelperMySql.ExecuteNonQuery(DbHelperMySql.connectionStringManager, CommandType.Text, cmdText, parms);
        }

        public void Insert(string file)
        {
            MySqlBulkLoader bcp1 = new MySqlBulkLoader(new MySqlConnection(DbHelperMySql.connectionStringManager));
            bcp1.TableName = "students";
            bcp1.FieldTerminator = ",";
            bcp1.LineTerminator = "\r\n";
            bcp1.FileName = file;
            bcp1.NumberOfLinesToSkip = 0;
            bcp1.Load();
        }
    }
}
