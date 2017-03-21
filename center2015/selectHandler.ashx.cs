using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL;
using System.Data;

namespace center2015
{
    /// <summary>
    /// selectHandler 的摘要说明
    /// </summary>
    public class selectHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string QueryKey = context.Request.Form["key"].ToString();
            string QueryValue = context.Request.Form["value"].ToString();

            //获取结果
            stuMgr StuMgr = new stuMgr();
            DataTable dt = StuMgr.GetCourseList(QueryKey, QueryValue);
            int rows = dt.Rows.Count;
            DataRow[] dataRows = dt.Select();
            string strhtml = "<tr><td>课程名</td><td>授课老师</td><td>授课时间</td><td>授课地点</td><td>选择</td></tr>";
            for (int i = 0; i < dataRows.Length; i++)
            {
                strhtml += "<tr id='tr"+dataRows[i]["lessonCode"]+"'><td>" + dataRows[i]["lessonName"] + "</td><td>" + dataRows[i]["lessonTeacher"] + "</td><td>" + dataRows[i]["lessonStartTime"] + "~" + dataRows[i]["lessonEndTime"] + "</td><td>" + dataRows[i]["lessonAddress"] + "</td><td><input type='button' id='btn" + dataRows[i]["lessonCode"] + "' class='add' value='添加'/></td></tr>";
            }
            //foreach (DataRow datarow in dataRows)
            //{
            //    strhtml += "<tr><td><button>添加</button></td>" + datarow["lessonName"] + "<td></td><td>" + datarow["lessonTeacher"] + "</td><td>" + datarow["lessonStartTime"] + "~" + datarow["lessonEndTime"] + "</td><td>" + datarow["lessonAddress"] + "</td></tr>";
            //}
            context.Response.Write(strhtml);

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