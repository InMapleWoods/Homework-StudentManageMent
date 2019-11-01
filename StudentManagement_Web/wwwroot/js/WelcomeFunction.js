window.onload = function () {
    if (getCookie('islogin') == 'false' || !isExistCookie('islogin')) {
        location = '../';
    } else {
        deleteCookie('times');
    }
    UserName();
}

function closePageForm() {
    if (confirm("确定要退出吗？")) {
        location = "http://jw.ncepu.edu.cn/jiaowuchu";
    }
}

function UserName() {
    var User = getJSONCookie('User');
    $("#option_drop").append(User.UserName + '<b class="caret"></b>');
}

function ReLogin() {
    deleteCookie("islogin");
    deleteCookie("User");
    location = "../"
}

function ChangeLabel(name) {
    if (name == 'Apply') {
        $("#AdminFrame").attr('src', '../Admin/UserApply');
        $("#ApplyTab").attr('class', 'nav-link active');
        $("#ExamApplyTab").attr('class', 'nav-link');
        $("#StudentTab").attr('class', 'nav-link');
        $("#TeacherTab").attr('class', 'nav-link');
        $("#CourseTab").attr('class', 'nav-link');
    }
    else if (name == 'Student') {
        $("#AdminFrame").attr('src', '../Admin/GetStudent');
        $("#ApplyTab").attr('class', 'nav-link');
        $("#ExamApplyTab").attr('class', 'nav-link');
        $("#StudentTab").attr('class', 'nav-link active');
        $("#TeacherTab").attr('class', 'nav-link');
        $("#CourseTab").attr('class', 'nav-link');
    }
}