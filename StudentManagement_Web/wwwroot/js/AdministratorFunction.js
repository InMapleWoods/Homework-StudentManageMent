var admin_page = 1;
var admin_size = 10;
var admin_index = 1;
var dataTypeChoose = 3;
function onloadView(index, choose) {
    if (choose == 3)
        onloadUserApplyView(index);
    else if (choose == 2)
        onloadStudentView(index);
    else if (choose == 1)
        onloadTeacherView(index);
    else if (choose == 4)
        onloadExamApplyView(index);
    else if (choose == 5)
        onloadCourseView(index);
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
            location.reload();
        }
    });
}
function AccpetApply(num) {
    $.ajax({
        type: "put",
        url: '../api/ApiAdmin/AcceptLog?number=' + num,
        success: function (data) {
            if (data == true) {
                alert('成功');
            }
            else {
                alert('失败');
            }
            onloadView(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
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
            onloadView(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
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
            location.reload();
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
            onloadView(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}
function onloadTeacherView(index) {
    $("#index").text(admin_index);
    GetPageNum(dataTypeChoose);
    $.ajax({
        type: "Get",
        url: '../api/ApiAdmin/GetPaperUsersArray?index=' + index + '&size=' + admin_size + '&&choose=1',
        success: function (data) {
            var applyList = data;
            $('#apply_list').html("");
            for (i = 0; i < applyList.length; i++) {
                var Number = applyList[i].number;
                var Name = applyList[i].name;
                $('#apply_list').append("<tr><td>" + Number + "</td><td>" + Name + "</td><td><button class='btn btn-block btn-danger' onclick=DeleteTeacher('" + Number + "')>删除</button></td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}
function DeleteTeacher(num) {

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
            onloadView(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}
function onloadCourseView(index) {
    $("#index").text(admin_index);
    GetPageNum(dataTypeChoose);
    $.ajax({
        type: "Get",
        url: '../api/ApiCourse/GetPaperCourseArray?index=' + index + '&size=' + admin_size,
        success: function (data) {
            var applyList = data;
            $('#apply_list').html("");
            for (i = 0; i < applyList.length; i++) {
                var Number = applyList[i].id;
                var Name = applyList[i].courseName;
                var TName = applyList[i].teacherName;
                $('#apply_list').append("<tr><td>" + Number + "</td><td>" + Name + "</td><td>" + TName + "</td><td><button class='btn btn-block btn-danger' onclick=DeleteCourse('" + Number + "')>删除</button></td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}
function DeleteCourse(num) {

    $.ajax({
        type: "DELETE",
        url: '../api/ApiCourse/DeleteCourse?CourseId=' + num,
        success: function (data) {
            if (data == true) {
                alert('成功');
            }
            else {
                alert('失败');
            }
            onloadView(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}
function onloadExamApplyView(index) {
    $("#index").text(admin_index);
    GetPageNum(dataTypeChoose);
    $.ajax({
        type: "Get",
        url: '../api/ApiExamination/GetExamApply?index=' + index + '&size=' + admin_size,
        success: function (data) {
            var applyList = data;
            $('#apply_list').html("");
            for (i = 0; i < applyList.length; i++) {
                var Id = applyList[i].id;
                var TeacherName = applyList[i].teacherName;
                var CourseName = applyList[i].courseName;
                var Time = applyList[i].time;
                var ExamName = applyList[i].examName;
                $('#apply_list').append("<tr><td>" + Id + "</td><td>" + TeacherName + "</td><td>" + CourseName + "</td><td>" + Time + "</td><td>" + ExamName + "</td><td><button class='btn btn-block btn-danger' onclick=AccpetExamApply('" + Id + "')>通过</button></td><td><button class='btn btn-block btn-danger' onclick=RejectExamApply('" + Id + "')>拒绝</button></td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}
function AccpetExamApply(num) {
    $.ajax({
        type: "put",
        url: '../api/ApiExamination/Accpet/' + num,
        success: function (data) {
            if (data == true) {
                alert('成功');
            }
            else {
                alert('失败');
            }
            onloadView(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}
function RejectExamApply(num) {
    $.ajax({
        type: "PUT",
        url: '../api/ApiExamination/Reject/' + num,
        success: function (data) {
            if (data == true) {
                alert('成功');
            }
            else {
                alert('失败');
            }
            onloadView(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
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
    if ((choose == 1) || (choose == 2) || (choose == 3)) {
        $.ajax({
            type: "Get",
            url: '../api/ApiAdmin/GetAllPageNum?size=' + admin_size + '&choose=' + choose,
            success: function (data) {
                admin_page = data;
                $("#page").text(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
                location.reload();
            }
        });
    }
    else if (choose == 4) {
        $.ajax({
            type: "Get",
            url: '../api/ApiExamination/GetAllPageNum?size=' + admin_size,
            success: function (data) {
                admin_page = data;
                $("#page").text(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
                location.reload();
            }
        });
    }
    else if (choose == 5) {
        $.ajax({
            type: "Get",
            url: '../api/ApiCourse/GetAllPageNum?size=' + admin_size,
            success: function (data) {
                admin_page = data;
                $("#page").text(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
                location.reload();
            }
        });
    }
}