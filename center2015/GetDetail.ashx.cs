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
    /// GetDetail 的摘要说明
    /// </summary>
    public class GetDetail : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            student Student = new student();
            if(context.Session["id"]!=null)
            {
                Student.ID = context.Session["id"].ToString();
                stuMgr StuMgr = new stuMgr();
                DataTable dt = StuMgr.GetDetail(Student);
                DataRow[] datarow = dt.Select();
                string strHtml = string.Empty;
                foreach (DataRow dr in datarow)
                {
                    strHtml = dr["stuId"].ToString() + "@" + dr["stuName"].ToString() + "@" + dr["stuSex"].ToString() + "@" + dr["stuTelephoneNum"].ToString() + "@" + dr["stuBirth"].ToString() + "@" + dr["stuHomeAddress"].ToString();
                }
                context.Response.Write(strHtml);
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