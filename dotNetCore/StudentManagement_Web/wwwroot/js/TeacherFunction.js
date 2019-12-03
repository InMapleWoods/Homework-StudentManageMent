var teacher_page = 1;
var teacher_size = 10;
var teacher_index = 1;
var dataTypeChoose = -1;
var Id = getJSONCookie('User').UserID;
var sqls = [
    window.matchMedia('(max-width:418px)'), //和CSS一样，也要注意顺序！
    window.matchMedia('(max-width:768px)'),
    window.matchMedia('(max-width:992px)'),
    window.matchMedia('(max-width:1200px)')
]

function mediaMatches() {
    if (sqls[0].matches) {
        teacher_size = 5;
    } else if (sqls[1].matches) {
        teacher_size = 9;
    } else if (sqls[2].matches) {
        teacher_size = 10;
    } else if (sqls[3].matches) {
        teacher_size = 11;
    } else {
        teacher_size = 12;
    }
    onloadViewTeacher(teacher_index, dataTypeChoose, Id);
}

mediaMatches(); //页面首次加载
onclickTeacherTab('addCourse');

function onclickTeacherTab(name) {
    if (getCookie('islogin') == 'false' || !isExistCookie('islogin')) {
        location = '../';
        return;
    }
    if (name == 'addCourse') {
        $('#TeacherFrame').attr('src', '../Teacher/AddCourse');
    } else if (name == 'applyExam') {
        $('#TeacherFrame').attr('src', '../Teacher/ApplyExam');
    } else if (name == 'gradeView') {
        $('#TeacherFrame').attr('src', '../Teacher/ManageGrade');
    }
}

for (var i = 0; i < sqls.length; i++) {
    sqls[i].addListener(mediaMatches);
}

function onloadViewTeacher(index, choose, userId) {
    if (choose == 1)
        onloadAddCourseView(index, userId);
    else if (choose == 2)
        onloadApplyExamView(index, userId);
    else if (choose == 3) {
        onloadCourseSelectList(userId);
        onloadExamSelectList();
        onloadManageGradeView(index, userId);
    }
}

function GetPageNumTeacher(choose) {
    if (choose == 1) {
        $.ajax({
            type: "Get",
            url: '../api/ApiCourse/GetAllPageNum?size=' + teacher_size,
            success: function (data) {
                admin_page = data;
                $("#page").text(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
                location.reload();
            }
        });
    } else if (choose == 3) {
        $.ajax({
            type: "Get",
            url: '../api/ApiExamination/GetAllPageNum/' + Id + '?size=' + teacher_size,
            success: function (data) {
                teacher_page = data;
                $("#page").text(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
                location.reload();
            }
        });
    }
}

function onloadAddCourseView(index, userId) {
    $("#index").text(teacher_index);
    $.ajax({
        type: "Get",
        url: '../api/ApiCourse/GetPaperCourseArray?index=' + index + '&size=' + teacher_size,
        success: function (data) {
            var applyList = data;
            $('#apply_list').html("");
            for (i = 0; i < applyList.length; i++) {
                var Number = applyList[i].id;
                var Name = applyList[i].courseName;
                var TName = applyList[i].teacherName;
                $('#apply_list').append("<tr><td>" + Number + "</td><td>" + Name + "</td><td>" + TName + "</td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function AddCourse() {
    var name = $('#CourseName').val();
    if (name == "") {
        alert('课程名不能为空');
        return;
    }
    $.ajax({
        type: "Put",
        url: '../api/ApiCourse/AddCourse?name=' + name + '&teacherId=' + Id,
        success: function (data) {
            if (data == true) {
                alert('成功');
            } else {
                alert('失败');
            }
            onloadViewTeacher(teacher_index, dataTypeChoose, Id);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });

}

function onloadCourseSelectList(userId) {
    $.ajax({
        type: "Get",
        url: '../api/ApiCourse/GetTeacherAllCourseArray/' + userId + '?index=1&size=500',
        success: function (data) {
            var courselist = data;
            $('#selectCourse').html("");
            for (i = 0; i < courselist.length; i++) {
                var Id = courselist[i][0];
                var Name = courselist[i][1];
                $('#selectCourse').append("<option value='" + Id + "'>" + Name + "</option>");
            }
            $("#selectCourse").val(courselist[0][0]);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function onloadExamSelectList() {
    var courseId = $("#selectCourse").val();
    if ((courseId == '') || (courseId == null))
        return;
    $.ajax({
        type: "Get",
        url: '../api/ApiExamination/GetExaminationByCourseId/' + courseId,
        success: function (data) {
            var examlist = data;
            $('#selectExam').html("<option value='0'>总成绩</option>");
            for (i = 0; i < examlist.length; i++) {
                var Id = examlist[i].id;
                var Name = examlist[i].name;
                $('#selectExam').append("<option value='" + Id + "'>" + Name + "</option>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }

    });
}

function onloadManageGradeView() {
    var courseId = $("#selectCourse").val();
    if ((courseId == '') || (courseId == null))
        return;
    var examId = $("#selectExam").val();
    var str = '';
    if ((examId == '') || (examId == '0') || examId == null) {
        str = '../api/ApiGrade/GetCourseGradeArray/' + courseId;
    } else {
        str = '../api/ApiGrade/GetExamGradeArray/' + examId;
    }
    $.ajax({
        type: "Get",
        url: str,
        success: function (data) {
            var applyList = data;
            $('#apply_list').html("");
            for (i = 0; i < applyList.length; i++) {
                var Number = applyList[i][0];
                var Name = applyList[i][1];
                var Score = applyList[i][2];
                $('#apply_list').append("<tr><td>" + Number + "</td><td>" + Name + "</td><td>" + Score + "</td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}


function LeftIndex() {
    if (teacher_index - 1 > 1)
        teacher_index = teacher_index - 1;
    else
        teacher_index = 1;
    onloadViewTeacher(teacher_index, dataTypeChoose, Id);
}

function RightIndex() {
    if (teacher_index + 1 < teacher_page)
        teacher_index = teacher_index + 1;
    else
        teacher_index = teacher_page;
    onloadViewTeacher(teacher_index, dataTypeChoose, Id);
}

$(document).ready(function () {
    $("#selectCourse").change(function () {
        $("#selectExam").empty();
        onloadExamSelectList();
        onloadGradeView();
    });
    $("#selectExam").change(function () {
        onloadGradeView();
    });
    $("#selectCourse").click(function () {
        $("#selectExam").empty();
        onloadExamSelectList();
        onloadGradeView();
    });
    $("#selectExam").click(function () {
        onloadGradeView();
    });
})