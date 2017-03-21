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
    /// confirm 的摘要说明
    /// </summary>
    public class confirm : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strId = context.Request.Form["id"].ToString();
            string strName = context.Request.Form["name"].ToString();
            //封装实例
            student Student = new student();
            Student.ID = strId;
            Student.Name = strName;

            stuMgr StuMgr = new stuMgr();
            bool res = StuMgr.confirm(Student);
            if(res==true)
            {
                context.Session["confirm"] = Student.ID;
                context.Response.Write("success");
            }
            else
            {
                context.Response.Write("验证失败！");
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