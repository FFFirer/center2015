using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL;
using DAO;
using System.Data;
using System.Web.SessionState;

namespace center2015
{
    /// <summary>
    /// GetSelectSubjectState 的摘要说明
    /// </summary>
    public class GetSelectSubjectState : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            student Student = new student();
            if (context.Session["id"] != null)
            {
                Student.ID = context.Session["id"].ToString();
                string sql = "select lessonCode from lessonTable where stuId='" + Student.ID + "'";
                databaseContorl dbs = new databaseContorl();
                DataTable dt = dbs.GetDataAdapter(sql);
                DataRow[] dr = dt.Select();
                if (dt.Rows.Count>0)
                {
                    string Course = dr[0]["lessoncode"].ToString();
                    string[] everyCourse = Course.Split('@');
                    lesson Lesson = new lesson();
                    string strCourse = string.Empty;
                    stuMgr StuMgr = new stuMgr();
                    foreach (string course in everyCourse)
                    {
                        Lesson.LessonCode = course;
                        DataRow[] dataRows = StuMgr.GetSubjectDetail(Lesson).Select();
                        foreach (DataRow dar in dataRows)
                        {
                            strCourse += "<tr><td>" + dar["lessonName"] + "</td><td>" + dar["lessonTeam"] + "</td><td>" + dar["lessonTeacher"] + "</td><td>" + dar["lessonStartTime"] + "~" + dar["lessonEndTime"] + "</td><td>" + dar["lessonAddress"] + "</td>/tr>";
                        }
                    }
                    context.Response.Write(strCourse);
                }
                else
                {
                    context.Response.Write("你还没有选课");
                }
            }
            else
            {
                context.Response.Write("fail");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}