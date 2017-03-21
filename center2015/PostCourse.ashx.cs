using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL;
using System.Data;
using System.Web.SessionState;

namespace center2015
{
    /// <summary>
    /// PostCourse 的摘要说明
    /// </summary>
    public class PostCourse : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string LessonCode = context.Request.Form["lessonCode"].ToString();
            if (context.Session["id"] != null)
            {
                student Student = new student();
                stuMgr StuMgr = new stuMgr();
                Student.ID = context.Session["id"].ToString();
                DataTable dt = StuMgr.GetDetail(Student);
                DataRow[] datarow = dt.Select();
                //获取Name
                Student.Name = datarow[0]["stuName"].ToString();
                //提交，数据库操作
                bool ret = StuMgr.postCourse(Student, LessonCode);
                if(ret == true)
                {
                    context.Response.Write("success");
                }
                else
                {
                    context.Response.Write("fail");
                }
            }
            else
            {
                context.Response.Write("账户已过期，请重新登陆账户");
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