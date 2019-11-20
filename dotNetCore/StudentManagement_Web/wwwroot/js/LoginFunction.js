var validatestring = "";
window.onload = function () {
    if (getCookie('islogin') == 'true') {
        location = '../Welcome';
    } else {
        if ((isExistCookie('times')) && (getCookie('times') != 'NaN')) {
            if (getCookie('times') >= 5) {
                $('#ValidateNum1').css('display', 'block');
                $('#ValidateNum2').css('display', 'block');
                getRandom();
            }
        } else {
            setCookie('times', 0);
            $('#ValidateNum1').css('display', 'none');
            $('#ValidateNum2').css('display', 'none');
        }
    }
    $('#txtAccount').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            $('#txtPwd').focus();
        }
    });
    $('#txtPwd').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            if ($('#ValidateNum1').css('display') != 'none') {
                $('#txtValidateNum').focus();
            } else {
                Login();
            }
        }
    });
    $('#txtValidateNum').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            Login();
        }
    });


}

function getRandom() {
    var pic = $('#NumImage');
    $.ajax({
        type: "get",
        url: "../api/ApiLogin/validate",
        success: function (sdata) {
            validatestring = sdata[0];
            var img = sdata[1];
            pic.attr("src", "data:image/jpg;base64," + img);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            var temp = parseInt(getCookie('times')) + 1;
            deleteCookie('times');
            setCookie('times', temp);
            location = '../';
        }
    });
}

function Login() {
    if ($('#ValidateNum1').css('display') == 'none') {
        validate = validatestring;
    } else {
        validate = $('#txtValidateNum').val();
    }
    if (validatestring == $('#txtValidateNum').val().toUpperCase() || $('#ValidateNum1').css('display') == 'none') {
        LoginWithValidate();
    } else {
        alert('验证码输入错误');
        getRandom();
    }
}

function LoginWithValidate() {
    var UserRoleArray = ["学生", "老师", "管理员"];
    var temp = parseInt(getCookie('times')) + 1;
    var stringAccount = $('#txtAccount').val() != '' ? $('#txtAccount').val() : '""';
    var stringPassword = $('#txtPwd').val() != '' ? $('#txtPwd').val() : '""';

    $.ajax({
        type: "get",
        url: '../api/ApiLogin?account=' + stringAccount,
        success: function (data) {
            var t = data;
            if (data == null) {
                alert('用户名不存在');
                location = '../';
                return;
            }
            var list = {
                account: stringAccount,
                password: stringPassword,
            };

            $.ajax({
                type: "post",
                accepts: "application/json",
                url: "../api/ApiLogin/Login",
                contentType: "application/json",
                data: JSON.stringify(list),
                success: function (data) {
                    if (data == true) {
                        alert('登陆成功');
                        deleteCookie('times');
                        var UserArray = {
                            'UserID': t.userID,
                            'Role': t.role,
                            'UserName': escape(t.userName),
                            'Number': t.number
                        };
                        alert(UserRoleArray[t.role - 1] + "你好，欢迎登录");
                        resetJSONCookieExpires('User', UserArray, 3);
                        resetCookieExpires('islogin', 'true', 3);
                        location = '../Welcome';
                    } else {
                        resetCookie('times', temp);
                        alert('登录失败');
                        getRandom();
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    ajaxError(XMLHttpRequest, textStatus);
                    resetCookie('times', temp);
                    location = '../';
                }
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            resetCookie('times', temp);
            location = '../';
        }
    });
}

function Register() {
    location = "Login/Register";
}