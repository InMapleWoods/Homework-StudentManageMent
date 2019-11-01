var admin_page = 1;
var admin_size = 10;
var admin_index = 1;
var dataTypeChoose = 3;
function onloadView(index, choose) {
    if (choose == 3)
        onloadUserApplyView(index);
    else if (choose == 2)
        onloadStudentView(index);
}
function onloadUserApplyView(index) {
    $("#index").text(admin_index);
    GetPageNum(dataTypeChoose);
    $.ajax({
        type: "Get",
        url: '../api/ApiAdmin/GetPaperUsersArray?index=' + index + '&size=' + admin_size + '&&choose=3',
        success: function (data) {
            var applyList = data;
            $('#apply_list').html("");
            for (i = 0; i < applyList.length; i++) {
                var Number = applyList[i].number;
                var Name = applyList[i].name;
                var Role = applyList[i].role;
                $('#apply_list').append("<tr><td>" + Number + "</td><td>" + Name + "</td><td>" + Role + "</td><td><button class='btn btn-block btn-danger' onclick=AccpetApply('" + Number + "')>通过</button></td><td><button class='btn btn-block btn-danger' onclick=RejectApply('" + Number + "')>拒绝</button></td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location = '../Welcome';
        }
    });
}
function AccpetApply(num) {
    $.ajax({
        type: "put",
        url: '../api/ApiAdmin/AcceptLog?number='+num,
        success: function (data) {
            if (data == true) {
                alert('成功');
            }
            else {
                alert('失败');
            }
            onloadUserApplyView(admin_index);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location = '../Welcome';
        }
    });
}
function RejectApply(num) {
    $.ajax({
        type: "PUT",
        url: '../api/ApiAdmin/RejectionLog?number=' + num,
        success: function (data) {
            if (data == true) {
                alert('成功');
            }
            else {
                alert('失败');
            }
            onloadUserApplyView(admin_index);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location = '../Welcome';
        }
    });
}
function onloadStudentView(index) {
    $("#index").text(admin_index);
    GetPageNum(dataTypeChoose);
    $.ajax({
        type: "Get",
        url: '../api/ApiAdmin/GetPaperUsersArray?index=' + index + '&size=' + admin_size + '&&choose=2',
        success: function (data) {
            var applyList = data;
            $('#apply_list').html("");
            for (i = 0; i < applyList.length; i++) {
                var Number = applyList[i].number;
                var Name = applyList[i].name;
                $('#apply_list').append("<tr><td>" + Number + "</td><td>" + Name + "</td><td><button class='btn btn-block btn-danger' onclick=DeleteStudent('" + Number + "')>删除</button></td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location = '../Welcome';
        }
    });
}
function DeleteStudent(num) {

    $.ajax({
        type: "DELETE",
        url: '../api/ApiAdmin?number=' + num,
        success: function (data) {
            if (data == true) {
                alert('成功');
            }
            else {
                alert('失败');
            }
            onloadUserApplyView(admin_index);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location = '../Welcome';
        }
    });
}
function LeftIndex() {
    if (admin_index - 1 > 1)
        admin_index = admin_index - 1;
    else
        admin_index = 1;
    onloadView(admin_index, dataTypeChoose);
}
function RightIndex() {
    if (admin_index + 1 < admin_page)
        admin_index = admin_index + 1;
    else
        admin_index = admin_page;
    onloadView(admin_index, dataTypeChoose);
}

function GetPageNum(choose) {

    $.ajax({
        type: "Get",
        url: '../api/ApiAdmin/GetAllPageNum?size=' + admin_size + '&choose=' + choose,
        success: function (data) {
            admin_page = data;
            $("#page").text(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location = '../Welcome';
        }
    });
}