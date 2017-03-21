using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL;
using System.Web.SessionState;

namespace center2015
{
    /// <summary>
    /// getLogin 的摘要说明
    /// </summary>
    public class getLogin : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string stuID = context.Request.Form["id"].ToString();
            string stuPassword = context.Request.Form["pass"].ToString();
            student Student = new student();
            Student.ID = stuID;
            Student.Password = stuPassword;
            stuMgr StuMgr = new stuMgr();
            bool ret = StuMgr.getLogin(Student);
            if (ret == true)
            {
                context.Session["id"] = Student.ID;
                context.Response.Write("Success");
            }
            else
            {
                context.Response.Write("Fail");
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