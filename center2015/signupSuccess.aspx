<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signupSuccess.aspx.cs" Inherits="center2015.signupSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link rel="stylesheet" href="style.css" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <div class="signUpSuccess">
        <h3>你的信息已经注册成功</h3>
        <h4>你的学号为<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h4>
        <h4>以后使用学号和密码进行登陆</h4>
        <a href="Home.html">进入系统</a>
    </div>
    </div>
    </form>
</body>
</html>
