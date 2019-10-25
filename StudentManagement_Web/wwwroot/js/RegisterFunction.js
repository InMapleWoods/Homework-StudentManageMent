window.onload = function () {
    $("#selectRole").find("option:selected")[0].selected = false;
    $('#txtUserName').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            $('#txtRegisterPwd').focus();
        }
    });
    $('#txtRegisterPwd').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            if (PasswordCheck()) {
                $('#txtRepwd').focus();
            }
        }
    });
    $('#txtRepwd').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            if (PasswordReCheck()) {
                $('#selectRole').focus();
            }
        }
    });
    $("select#selectRole").change(function () {
        $('#btnOK').focus();
    });
    $('#btnOK').bind('keyup', function (event) {
        if (event.keyCode == "13") {
            Register();
        }
    });
}

function PasswordCheck() {
    var pwd = $('#txtRegisterPwd').val();
    if (pwd.length >= 11) {
        $('#errortipdiv').text('密码过长');
        return false;
    } else if (pwd.length <= 5) {
        $('#errortipdiv').text('密码过短');
        return false;
    } else {
        $('#errortipdiv').text('');
        return true;
    }
}

function PasswordReCheck() {
    var pwd = $('#txtRegisterPwd').val();
    var repwd = $('#txtRepwd').val();
    var pwd = $('#txtRepwd').val();
    if (pwd.length >= 11) {
        $('#errortipdiv').text('密码过长');
        return false;
    } else if (pwd.length <= 5) {
        $('#errortipdiv').text('密码过短');
        return false;
    } else {
        if (pwd == repwd) {
            $('#errortipdiv').text('');
            return true;
        } else {
            $('#errortipdiv').text('两次密码输入不一致');
            return false;
        }
    }
}
function Register() {
    if (PasswordCheck() && PasswordReCheck()) {
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

function btnOK_Click() {
    Register();
}

function btnBack_Click() {
    location = '../';
}