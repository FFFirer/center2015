<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectSubject.aspx.cs" Inherits="center2015.selectSubject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" type="text/css" />
    <script src="jquery-3.1.1.js" type="text/javascript"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>  
    <div>
        <nav>
            <a href="Home.html">首页</a>
            学生选课
            <a href="selectLessonState.html">选课情况查询</a>
            <a href="detail.html">学生信息</a>
            <button>退出登陆</button>
            <a href="Login.html">退出登陆</a>
            <a href="#"></a>
            <a href="#"></a>
        </nav>
    </div>
    <hr />
    <div>
        <fieldset>
            <legend>筛选条件</legend>
                课程名：<select id="kc"></select>&nbsp;学期：<select id="xq"></select>&nbsp;老师：<select id="ls"></select>&nbsp;授课地点：<select id="dd"></select> &nbsp;&nbsp;&nbsp;<button>筛选</button>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </fieldset>
    </div>
    <br />
    <div>
        <fieldset>
            <legend>可选课程</legend>
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:BoundField DataField="lessonName" HeaderText="课程名称" />
                    <asp:BoundField DataField="lessonTeam" HeaderText="上课学期" />
                    <asp:BoundField DataField="lessonTeacher" HeaderText="授课教师" />
                    <asp:BoundField DataField="lessonAddress" HeaderText="授课地点" />
                    <asp:BoundField DataField="majorName" HeaderText="所属专业" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
    <br />
    <div>
        <fieldset>
            <legend>已选课程</legend>
                <table>
                     <tr>
                        <td>选择</td>
                        <td>课程名</td>
                        <td>授课老师</td>
                        <td>授课时间</td>
                        <td>授课地点</td>
                      </tr>
                </table>
                <button type="submit">提交</button>
        </fieldset>
    </div>
    </div>
    </form>
</body>
</html>
