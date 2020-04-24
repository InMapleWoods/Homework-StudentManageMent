var validatestring = "";
var login_register_height = 0;
var errorMessage = "";
window.onload = function () {
    if (getCookie('islogin') == 'true') {
        location = '../Welcome';
    } else {
        if ((isExistCookie('times')) && (getCookie('times') != 'NaN')) {
            if (getCookie('times') >= 5) {
                $("#captcha").css('display', 'block');
                $('.login_register')[0].style.height = 390 + 'px';
                login_register_height = 390;
                getRandom();
            }
            else {
                $('.login_register')[0].style.height = 320 + 'px';
                login_register_height = 320;
            }
        } else {
            setCookie('times', 0);
            $("#captcha").css('display', 'none');
            $('.login_register')[0].style.height = 320 + 'px';
            login_register_height = 320;
        }
    }
    $('#txtAccount').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            $('#txtPwd').focus();
        }
    });
    $('#txtPwd').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            if ($('#captcha').css('display') != 'none') {
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
    var loginTab = $(".login_info")[0];
    var registerTab = $(".register_info")[0];
    loginTab.onclick = function () {
        $(".register_list")[0].style.display = 'none';
        $(".login_list")[0].style.display = 'block';
        $('.login_register')[0].style.height = login_register_height + 'px';
    }
    registerTab.onclick = function () {
        $(".login_list")[0].style.display = 'none';
        $(".register_list")[0].style.display = 'block';
        $('.login_register')[0].style.height = 470 + 'px';
    }

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
    if ($('#captcha').css('display') == 'none') {
        validate = validatestring;
    } else {
        validate = $('#txtValidateNum').val();
    }
    if (validatestring == $('#txtValidateNum').val().toUpperCase() || $('#captcha').css('display') == 'none') {
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

function PasswordCheck() {
    var pwd = $('#txtRegisterPwd').val();
    if (pwd.length >= 11) {
        errorMessage = '密码过长';
        return false;
    } else if (pwd.length <= 5) {
        errorMessage = '密码过短';
        return false;
    } else {
        errorMessage = "";
        return true;
    }
}

function PasswordReCheck() {
    var pwd = $('#txtRegisterPwd').val();
    var repwd = $('#txtRepwd').val();
    if (repwd.length >= 11) {
        errorMessage = "密码过长";
        return false;
    } else if (repwd.length <= 5) {
        errorMessage = "密码过短";
        return false;
    } else {
        if (pwd == repwd) {
            errorMessage = "";
            return true;
        } else {
            errorMessage = "两次密码输入不一致";
            return false;
        }
    }
}

function Register() {
    var password_check = PasswordCheck();
    var repeat_password_check = PasswordReCheck();
    if (errorMessage == "") {
        $('.login_register')[0].style.height = '470px';
    }
    else {
        $('.login_register')[0].style.height = '500px';
    }
    setTimeout(()=>{$('#errortipdiv').text(errorMessage);}, "200")
    if (password_check && repeat_password_check ) {       
        $.ajax({
            type: "post",
            url: '../api/ApiLogin/Register?name=' + $('#txtUserName').val() + '&password=' + $('#txtRegisterPwd').val() +
                '&repeat=' + $('#txtRepwd').val() + '&role=' + $('#selectRole').val(),
            success: function (data) {
                if (data[0]) {
                    alert('注册成功');
                    var id = data[1];
                    alert('请牢记登录账号为:' + id)
                    location = '../';
                } else {
                    alert('注册失败');
                    location = '../Login/Register';
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
                location = '../Login/Register';
            }
        });
    }
}

function btnBack_Click() {
    location = '../';
}