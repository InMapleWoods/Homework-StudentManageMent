window.onload = function () {
    if (getCookie('islogin') == 'false' || !isExistCookie('islogin')) {
        location = '../';
    } else {
        deleteCookie('times');
    }
};

function closePageForm() {
    if (confirm("确定要退出吗？")) {
        location = "http://jw.ncepu.edu.cn/jiaowuchu";
    }
}

function ReLogin() {
    deleteCookie("islogin");
    deleteCookie("User");
    location = "../"
}
