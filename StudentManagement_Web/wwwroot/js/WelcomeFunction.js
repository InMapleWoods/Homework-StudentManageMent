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