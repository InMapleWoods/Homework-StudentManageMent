var admin_page = 1;
var admin_size = 10;
var admin_index = 1;
var dataTypeChoose = -1;

var sqls = [
    window.matchMedia('(max-width:418px)'), //和CSS一样，也要注意顺序！
    window.matchMedia('(max-width:768px)'),
    window.matchMedia('(max-width:992px)'),
    window.matchMedia('(max-width:1200px)')
]

function mediaMatches() {
    if (sqls[0].matches) {
        admin_size = 5;
    } else if (sqls[1].matches) {
        admin_size = 9;
    } else if (sqls[2].matches) {
        admin_size = 10;
    } else if (sqls[3].matches) {
        admin_size = 11;
    } else {
        admin_size = 12;
    }
    onloadViewAdmin(admin_index, dataTypeChoose);
}
mediaMatches(); //页面首次加载

onclickAdminTab('ApplyTab');
function onclickAdminTab(name) {
    if (getCookie('islogin') == 'false' || !isExistCookie('islogin')) {
        location = '../';
        return;
    }
    if (name == 'ApplyTab') {
        $('#AdminFrame').attr('src', '../Admin/UserApply');
    }
    else if (name == 'ExamApply') {
        $('#AdminFrame').attr('src', '../Admin/ExamApply');
    }
    else if (name == 'Exam') {
        $('#AdminFrame').attr('src', '../Admin/GetExam');
    }
    else if (name == 'Student') {
        $('#AdminFrame').attr('src', '../Admin/GetStudent');
    }
    else if (name == 'Teacher') {
        $('#AdminFrame').attr('src', '../Admin/GetTeacher');
    }
    else if (name == 'Course') {
        $('#AdminFrame').attr('src', '../Admin/GetCourse');
    }
    else if (name == 'Setting') {
        $('#AdminFrame').attr('src', '../Admin/GetSettings');
    }
}
for (var i = 0; i < sqls.length; i++) {
    sqls[i].addListener(mediaMatches);
}
function onloadViewAdmin(index, choose) {
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
    else if (choose == 6)
        onloadExamView(index);
    else if (choose == 7)
        onloadSettingsView(index);
}

function GetPageNumAdmin(choose) {
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
            url: '../api/ApiExamination/GetAllPageApplyNum?size=' + admin_size,
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
    else if (choose == 6) {
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
}

function onloadUserApplyView(index) {
    $("#index").text(admin_index);
    GetPageNumAdmin(dataTypeChoose);
    $.ajax({
        type: "Get",
        url: '../api/ApiAdmin/GetPaperUsersArray?index=' + index + '&size=' + admin_size + '&choose=3',
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
            onloadViewAdmin(admin_index, dataTypeChoose);
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
            onloadViewAdmin(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function onloadExamView(index) {
    $("#index").text(admin_index);
    GetPageNumAdmin(dataTypeChoose);
    $.ajax({
        type: "Get",
        url: '../api/ApiExamination/GetExam?index=' + index + '&size=' + admin_size,
        success: function (data) {
            var applyList = data;
            $('#apply_list').html("");
            for (i = 0; i < applyList.length; i++) {
                var Id = applyList[i].id;
                var CourseName = applyList[i].courseName;
                var ExamName = applyList[i].examName;
                var ExamDuration = applyList[i].examDuration;
                var Time = new Date(applyList[i].time).toLocaleString();
                $('#apply_list').append("<tr><td>" + Id + "</td><td>" + CourseName + "</td><td>" + ExamName + "</td><td>" + Time + "</td><td>" + ExamDuration + "</td><td><button class='btn btn-block btn-danger' onclick=DeleteExam('" + Id + "')>删除</button></td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function DeleteExam(num) {

    $.ajax({
        type: "DELETE",
        url: '../api/ApiExamination/' + num,
        success: function (data) {
            if (data == true) {
                alert('成功');
            }
            else {
                alert('失败');
            }
            onloadViewAdmin(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function onloadStudentView(index) {
    $("#index").text(admin_index);
    GetPageNumAdmin(dataTypeChoose);
    $.ajax({
        type: "Get",
        url: '../api/ApiAdmin/GetPaperUsersArray?index=' + index + '&size=' + admin_size + '&choose=2',
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
            onloadViewAdmin(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function onloadTeacherView(index) {
    $("#index").text(admin_index);
    GetPageNumAdmin(dataTypeChoose);
    $.ajax({
        type: "Get",
        url: '../api/ApiAdmin/GetPaperUsersArray?index=' + index + '&size=' + admin_size + '&choose=1',
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
            onloadViewAdmin(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function onloadCourseView(index) {
    $("#index").text(admin_index);
    GetPageNumAdmin(dataTypeChoose);
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
            onloadViewAdmin(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function onloadExamApplyView(index) {
    $("#index").text(admin_index);
    GetPageNumAdmin(dataTypeChoose);
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
            onloadViewAdmin(admin_index, dataTypeChoose);
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
            onloadViewAdmin(admin_index, dataTypeChoose);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function onloadSettingsView(index) {
    $.ajax({
        type: "Get",
        url: '../api/ApiAdmin/GetSettings',
        success: function (data) {
            $('#settingList').html('');
            var applyList = data;
            for (i = 0; i < applyList.length; i++) {
                var Id = applyList[i][0];
                var SettingName = applyList[i][1];
                var SettingValue = applyList[i][2];
                if ((SettingValue == 'true') || (SettingValue == 'false')) {
                    if (SettingName == 'RegisterOpenState') {
                        Name = '注册功能是否开启';
                        Value = 'true' == SettingValue ?"已开启":"已关闭";
                    }
                    else if (SettingName == 'CourseChooseOpenState') {
                        Name = '选课功能是否开启';
                        Value = 'true' == SettingValue ?"已开启":"已关闭";
                    }
                    $('#settingList').append("<div class='col-6'>" + Name + "</div><div class='col-6'>" + Value + "</div><div class='col-12'><button class='btn btn-block btn-info' onclick=updateSettings('" + SettingName + "','" + SettingValue + "')>修改</button></div></div>");
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function updateSettings(name, value) {
    $.ajax({
        type: "put",
        url: '../api/ApiAdmin/UpdateSettings?name=' + name + '&value=' + value,
        success: function (data) {
            alert(data);
            onloadViewAdmin(admin_index, dataTypeChoose);
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
    onloadViewAdmin(admin_index, dataTypeChoose);
}

function RightIndex() {
    if (admin_index + 1 < admin_page)
        admin_index = admin_index + 1;
    else
        admin_index = admin_page;
    onloadViewAdmin(admin_index, dataTypeChoose);
}