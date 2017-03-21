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
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if(context.Session["id"]!=null)
            {
                string strPwd = context.Request.Form["key"].ToString();
                string strStuId = context.Session["id"].ToString();
                student Student = new student();
                Student.ID = strStuId;
                Student.Password = strPwd;

                stuMgr StuMgr = new stuMgr();
                bool res = StuMgr.changePassword(Student);
                if (res == true)
                {
                    context.Response.Write("success");
                }
                else
                {
                    context.Response.Write("fail");
                }
            }
            else if(context.Session["confirm"]!=null)
            {
                string strPwd = context.Request.Form["key"].ToString();
                string strStuId = context.Session["confirm"].ToString();
                student Student = new student();
                Student.ID = strStuId;
                Student.Password = strPwd;

                stuMgr StuMgr = new stuMgr();
                bool res = StuMgr.changePassword(Student);
                if (res == true)
                {
                    context.Session["confirm"] = null;
                    context.Response.Write("success");
                }
                else
                {
                    context.Response.Write("fail");
                }
            }
            else
            {
                context.Response.Write("请先登陆！");
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