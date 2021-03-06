﻿window.onload = function () {
    if (getCookie('islogin') == 'false' || !isExistCookie('islogin')) {
        location = '../';
    } else {
        deleteCookie('times');
    }
    UserName();
    setIframeHeight(document.getElementById('_iFrame'));
}

function closePageForm() {
    if (confirm("确定要退出吗？")) {
        location = "http://jw.ncepu.edu.cn/jiaowuchu";
    }
}

function ChangeUserPassword() {
    var User = getJSONCookie('User');
    var UserId = User.UserID;
    var Number = User.Number;
    var oldpwd = prompt("请输入原密码"); // 弹出input框
    if (oldpwd == null)
        return;
    var list = {
        account: Number,
        password: oldpwd,
    };
    $.ajax({
        type: "post",
        accepts: "application/json",
        async: true,
        url: "../api/ApiLogin/Login",
        contentType: "application/json",
        data: JSON.stringify(list),
        success: function (data) {
            resetJSONCookieExpires('User', User, 3);
            if (data == true) {
                var newpwd = prompt("请输入新密码"); // 弹出input框
                if (confirm("确定要修改密码为" + newpwd + "吗？")) {
                    $.ajax({
                        type: "PUT",
                        url: '../api/ApiUser/ChangePassword?opwd=' + oldpwd + '&npwd=' + newpwd + '&userid=' + Number,
                        success: function (data) {
                            if (data) {
                                alert('修改成功，密码已修改为' + newpwd);
                            } else {
                                alert('修改失败');
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ajaxError(XMLHttpRequest, textStatus);
                        }
                    });
                }
            } else {
                alert('旧密码不正确');
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (XMLHttpRequest.responseText == '用户名或密码不正确，请重新输入') {
                alert('旧密码不正确');
            }
        }
    });
    UserName();
}

function ChangeUserName() {
    var User = getJSONCookie('User');
    var UserId = User.Number;
    var name = prompt("请输入新名字"); // 弹出input框
    if (name == null)
        return;
    if (confirm("确定要修改为" + name + "吗？")) {
        $.ajax({
            type: "PUT",
            url: '../api/ApiUser/ChangedName?id=' + UserId + '&&changedName=' + name,
            success: function (data) {
                if (data) {
                    alert('修改成功，用户名已修改为' + name);
                } else {
                    alert('修改失败');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
                location = '../Login/Register';
            }
        });
        UserName();
    }
}

function UserName() {
    var User = getJSONCookie('User');
    var Number = User.Number;
    var Name = "";
    $.ajax({
        type: "get",
        url: '../api/ApiLogin?account=' + Number,
        success: function (data) {
            var t = data;
            Name = t.userName;
            var UserArray = {
                'UserID': t.userID,
                'UserName': escape(t.userName),
                'Role': t.role,
                'Number': t.number
            };
            resetJSONCookieExpires('User', UserArray, 3);
            $("#option_drop").html('');
            $("#option_drop").append(Name + '<b class="caret"></b>');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            resetCookie('times', temp);
            location = '../';
        }
    });
}

function ReLogin() {
    deleteCookie("islogin");
    deleteCookie("User");
    location = "../"
}
