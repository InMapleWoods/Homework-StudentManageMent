﻿window.onload = function () {
    document.title = "用户资料";
    GetUserNameAndNumber();
    UserName();
}


function GetUserNameAndNumber() {
    var user = getJSONCookie("User");
    $("#userName").text(user.UserName);
    $("#userNumber").text(user.Number);
}