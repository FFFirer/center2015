using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BLL;

namespace center2015
{
    /// <summary>
    /// getList 的摘要说明
    /// </summary>
    public class getList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strkc = context.Request.Form["kc"].ToString();
            string strxq = context.Request.Form["xq"].ToString();
            string strls = context.Request.Form["ls"].ToString();
            string strdd = context.Request.Form["dd"].ToString();
            stuMgr StuMgr = new stuMgr();
            //kc
            DataTable tempdt = StuMgr.GetDISTINCT(strkc);
            DataRow[] datarow = tempdt.Select();
            string strHtml = string.Empty;
            foreach(DataRow rows in datarow)
            {
                strHtml += "<option>" + rows["lessonName"] + "</option>";
            }
            strHtml += "@";
            //xq
            DataTable tempdt1 = StuMgr.GetDISTINCT(strxq);
            DataRow[] datarow1 = tempdt1.Select();
            foreach (DataRow rows in datarow1)
            {
                strHtml += "<option>" + rows["lessonTeam"] + "</option>";
            }
            strHtml += "@";
            //ls
            DataTable tempdt2 = StuMgr.GetDISTINCT(strls);
            DataRow[] datarow2 = tempdt2.Select();
            foreach (DataRow rows in datarow2)
            {
                strHtml += "<option>" + rows["lessonTeacher"] + "</option>";
            }
            strHtml += "@";
            //dd
            DataTable tempdt3 = StuMgr.GetDISTINCT(strdd);
            DataRow[] datarow3 = tempdt3.Select();
            foreach (DataRow rows in datarow3)
            {
                strHtml += "<option>" + rows["lessonAddress"] + "</option>";
            }
            context.Response.Write(strHtml);
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