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
    /// signupHandler 的摘要说明
    /// </summary>
    public class signupHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
                context.Response.ContentType = "text/plain";
                student Stu = new student();
                //封装学生实体对象
                Stu.ID = DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Day.ToString()+ DateTime.Now.Hour.ToString()+ DateTime.Now.Minute.ToString();
                Stu.Name = context.Request.Form["name"];
                Stu.Password = context.Request.Form["password"];
                Stu.Sex = context.Request.Form["sex"];
                Stu.Birth = context.Request.Form["birth"];
                Stu.HomeAddress = context.Request.Form["address"];
                Stu.TelephoneNum = context.Request.Form["tel"];
                Stu.EntranceYear = "2017";
                Stu.ClassName = "none";
                Stu.MajorName = "none";
                Stu.HomeTown = "none";

                //进行存储
                stuMgr StuMgr = new stuMgr();
                bool res = StuMgr.getSignUp(Stu);
                if (res == true)
                {
                    context.Session["id"] = Stu.ID;
                    context.Response.Write("success@"+Stu.ID);
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