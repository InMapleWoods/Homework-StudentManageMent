<%--
  Created by IntelliJ IDEA.
  User: 96464
  Date: 2019/11/15
  Time: 14:56
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>

<head>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width"/>
    <title>欢迎，学生好！</title>
    <link rel="stylesheet" href="wwwroot/lib/Bootstrap/bootstrap.min.css"/>
    <link rel="stylesheet" href="wwwroot/css/WelcomeView.css"/>
    <script src="wwwroot/lib/jQuery/jquery-3.3.1.min.js"></script>
    <script src="wwwroot/lib/Bootstrap/bootstrap.min.js"></script>
    <script type="text/javascript" src="wwwroot/js/CookieAbout.js"></script>
    <script type="text/javascript" src="wwwroot/js/AjaxAbout.js"></script>
    <script type="text/javascript" src="wwwroot/js/StudentFunction.js"></script>
    <script type="text/javascript" src="wwwroot/js/WelcomeFunction.js"></script>
    <script>
        window.onbeforeunload = function (event) {
            $.ajax({
                type: "Delete",
                url: '../Welcome',
                success: function (data) {
                    console.log(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    ajaxError(XMLHttpRequest, textStatus);
                    location.reload();
                }
            });
        };
    </script>
</head>
<body>
<div class="container-fluid">
    <div class="divtrans row">
        <div class="col-8 col-md-8 col-sm-8">
            <div class="navbar-brand logobg">
                <a href="../Welcome">学生信息管理系统</a>
            </div>
        </div>
        <div class="col-4 col-md-4 col-sm-4">
            <a id="reLogin" onclick="ReLogin()" href="#">重新登录</a>
            <a id="exitSystem" onclick="closePageForm()" href="#">退出系统</a>
        </div>
    </div>
</div>
<div>
    <div>
        <nav>
            <div class="nav nav-tabs" id="nav-tab" role="tablist">
                <a class="nav-item nav-link active" id="nav-StudentView-tab" data-toggle="tab" href="#nav-StudentView"
                   role="tab" aria-controls="nav-StudentView" aria-selected="true"
                   onclick="onclickStudentTab('courseView')">课程查看</a>
                <a class="nav-item nav-link" id="nav-StudentView-tab" data-toggle="tab" href="#nav-StudentView"
                   role="tab" aria-controls="nav-StudentView" aria-selected="false"
                   onclick="onclickStudentTab('chooseCourse')">学生选课</a>
            </div>
        </nav>
        <div class="tab-content" id="nav-tabContent">
            <div class="tab-pane fade show active" id="nav-StudentView" role="tabpanel"
                 aria-labelledby="nav-StudentView-tab">
                <iframe id="StudentFrame" src="Student/GetCourseView.html"
                        style=" width: -webkit-fill-available; border: none; margin: auto;height: 70%;"></iframe>
            </div>
        </div>
    </div>
</div>
</body>
</html>
