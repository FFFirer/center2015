    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class stuMgr
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="STD">student对象的实例</param>
        /// <returns>登陆</returns>
        public bool getLogin(student Student)
        {
            string sql = "select * from stuInfo where stuId ='" + Student.ID + "' and Password='"+ Student.Password+"'";
            databaseContorl dbs = new databaseContorl();
            DataTable dt = dbs.GetDataAdapter(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="Student"></param>
        /// <returns></returns>
        public bool getSignUp(student Student)
        {
            string sql = "insert into stuInfo(stuId,stuName,Password,stuSex,stuTelephoneNum,stuBirth,stuHometown,majorName,className,stuEntranceYear,stuHomeAddress)values(@stuId,@stuName,@Password,@stuSex,@stuTelephoneNum,@stuBirth,@stuHometown,@majorName,@className,@stuEntranceYear,@stuHomeAddress)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@stuId",Student.ID),
                new SqlParameter("@stuName",Student.Name),
                new SqlParameter("@Password",Student.Password),
                new SqlParameter("@stuSex",Student.Sex),
                new SqlParameter("@stuTelephoneNum",Student.TelephoneNum),
                new SqlParameter("@stuBirth",Student.Birth),
                new SqlParameter("@stuHometown",Student.HomeTown),
                new SqlParameter("@majorName",Student.MajorName),
                new SqlParameter("@className",Student.ClassName),
                new SqlParameter("@stuEntranceYear",Student.EntranceYear),
                new SqlParameter("@stuHomeAddress",Student.HomeAddress),
            };
            int ret = DAO.databaseContorl.ExecuteSql(sql, parameters);
            if(ret>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取学生详细信息
        /// </summary>
        /// <param name="Student"></param>
        /// <returns></returns>
        public DataTable GetDetail(student Student)
        {
            string sql = "select stuId,stuName,stuSex,stuTelephoneNum,stuBirth,stuHometown,majorName,className,stuEntranceYear,stuHomeAddress from stuInfo where stuId=@stuId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@stuId",Student.ID),
            };
            DataTable dt = DAO.databaseContorl.GetDataSet(sql, parameters);
            return dt;
        }

        /// <summary>
        /// 取得满足条件的结果
        /// </summary>
        /// <param name="Lesson"></param>
        /// <returns></returns>
        public DataTable GetCourseList(string key,string value)
        {
            string sql = "select * from lesson where " + key + "='" + value+"'";
            databaseContorl dbs = new databaseContorl();
            DataTable dt = dbs.GetDataAdapter(sql);
            return dt;
        }

        /// <summary>
        /// 获取单列
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public DataTable GetDISTINCT(string para)
        {
            string sql = "select DISTINCT " + para + " from lesson";
            databaseContorl dbs = new databaseContorl();
            DataTable dt = dbs.GetDataAdapter(sql);
            return dt;
        }

        /// <summary>
        /// 提交课程
        /// </summary>
        /// <param name="Stu"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool postCourse(student Stu, string code)
        {
            string sql = "insert into lessonTable(stuId,stuName,lessonCode)values(@stuId,@stuName,@lessonCode)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@stuId",Stu.ID),
                new SqlParameter("@stuName",Stu.Name),
                new SqlParameter("@lessonCode",code),
            };
            int ret = databaseContorl.ExecuteSql(sql, parameters);
            if(ret > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查询，根据课程代码查详细信息
        /// </summary>
        /// <param name="Lesson"></param>
        /// <returns></returns>
        public DataTable GetSubjectDetail(lesson Lesson)
        {
            string QuerySql = "select * from lesson where lessonCode=@lessonCode";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@lessonCode",Lesson.LessonCode),
                
            };
            DataTable dt = DAO.databaseContorl.GetDataSet(QuerySql, parameters);
            return dt;
        }

        /// <summary>
        /// 更新，修改密码
        /// </summary>
        /// <param name="Student"></param>
        /// <returns></returns>
        public bool changePassword(student Student)
        {
            string updateSql = "update stuInfo set Password=@Password where stuId=@stuId;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Password",Student.Password),
                new SqlParameter("@stuId", Student.ID),
            };
            int ret = DAO.databaseContorl.ExecuteSql(updateSql,parameters);
            if(ret>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool confirm(student Student)
        {
            string confirmSql = "select * from stuInfo where stuId=@stuId and stuName=@stuName";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@stuId", Student.ID),
                new SqlParameter("@stuName",Student.Name)
            };
            DataTable ret = databaseContorl.GetDataSet(confirmSql, parameters);
            if(ret.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
