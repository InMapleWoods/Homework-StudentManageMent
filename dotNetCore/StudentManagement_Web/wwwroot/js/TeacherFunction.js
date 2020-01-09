var teacher_page = 1;
var teacher_size = 10;
var teacher_index = 1;
var dataTypeChoose = -1;
var Id = getJSONCookie('User').UserID;
var changeStr = "";
var scoreVal = "";
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
    } else if (name == 'allGrade') {
        $('#TeacherFrame').attr('src', '../Teacher/AllGrade');
    }
}

for (var i = 0; i < sqls.length; i++) {
    sqls[i].addListener(mediaMatches);
}

function onloadViewTeacher(index, choose, userId) {
    GetPageNumTeacher(choose)
    if (choose == 1)
        onloadAddCourseView(index);
    else if (choose == 2) {
        onloadCourseSelectList(userId);
        onloadApplyExamView(index);
        onloadMyExamView();
    }
    else if (choose == 3) {
        onloadCourseSelectList(userId);
        onloadExamSelectList();
        onloadManageGradeView(index);
    }
    else if (choose == 4)
        onloadAllGradeView(index, userId);
}

function GetPageNumTeacher(choose) {
    if (choose == 1) {
        $.ajax({
            type: "Get",
            async: false,
            url: '../api/ApiCourse/GetAllPageNum?size=' + teacher_size,
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
    else if (choose == 2) {
        $.ajax({
            type: "Get",
            async: false,
            url: '../api/ApiExamination/GetAllPageApplyNum/' + Id + '?size=' + teacher_size,
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
    else if (choose == 3) {
        var courseId = $("#selectCourse").val();
        if ((courseId == '') || (courseId == null))
            return;
        var examId = $("#selectExam").val();
        var str = '';
        if ((examId == '') || (examId == '0') || examId == null) {
            str = '../api/ApiGrade/GetAllCoursePageNum/' + courseId + '?size=' + teacher_size;
        } else {
            str = '../api/ApiGrade/GetAllExamPageNum/' + examId + '?size=' + teacher_size;
        }
        $.ajax({
            type: "Get",
            url: str,
            async: false,
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
    else if (choose == 4) {
        $.ajax({
            type: "Get",
            async: false,
            url: '../api/ApiAdmin/GetAllPageNum?size=' + teacher_size + '&choose=2',
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

function onloadMyExamView() {
    $.ajax({
        type: "Get",
        async: false,
        url: '../api/ApiExamination/GetExaminationByTeacherId/' + Id,
        success: function (data) {
            var applyList = data;
            $('#exam_list').html("");
            for (i = 0; i < applyList.length; i++) {
                var Id = applyList[i][0];
                var CourseName = applyList[i][1];
                var ExamName = applyList[i][2];
                var Time = applyList[i][3];
                var ExamDuration = applyList[i][4];
                $('#exam_list').append("<tr><td>" + CourseName + "</td><td>" + ExamName + "</td><td>" + Time + "</td><td>" + ExamDuration + "</td><td><a class='btn btn-block btn-success' href='../Teacher/ManageExamQuestion/" + Id + "'>题目管理</a></td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function onloadApplyExamView(index) {
    $("#index").text(teacher_index);
    var mintime = new Date(new Date().setFullYear(new Date().getFullYear() - 1));
    var maxtime = new Date(new Date().setMonth(new Date().getMonth() + 6));
    $('#datetimeInput').attr('min', mintime.toJSON().split('.')[0]);
    $('#datetimeInput').attr('max', maxtime.toJSON().split('.')[0]);
    $.ajax({
        type: "Get",
        async: false,
        url: '../api/ApiExamination/GetExamApply/' + Id + '?index=' + index + '&size=' + teacher_size,
        success: function (data) {
            var applyList = data;
            $('#apply_list').html("");
            for (i = 0; i < applyList.length; i++) {
                var Id = applyList[i].id;
                var CourseName = applyList[i].courseName;
                var Time = applyList[i].time;
                var ExamName = applyList[i].examName;
                var ExamDuration = applyList[i].examDuration;
                $('#apply_list').append("<tr><td>" + Id + "</td><td>" + CourseName + "</td><td>" + Time + "</td><td>" + ExamName + "</td><td>" + ExamDuration + "</td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function applyExam() {
    var courseId = $("#selectCourse").val();
    if ((courseId == '') || (courseId == null)) {
        alert('请选择课程');
        return;
    }
    var datetime = $("#datetimeInput").val();
    if ((datetime == '') || (datetime == null)) {
        alert('请输入考试日期');
        return;
    }
    var duration = $("#durationInput").val();
    if ((duration == '') || (duration == null)) {
        alert('请输入考试时长');
        return;
    }
    var name = $("#nameInput").val();
    if ((name == '') || (name == null)) {
        alert('请输入考试名称');
        return;
    }
    var examApplyObj = {
        teacherId: Id,
        examination: {
            Id: 0,
            CourseId: courseId,
            Time: datetime,
            Name: name,
            Duration: duration
        }
    };
    $.ajax({
        type: "Post",
        async: false,
        url: '../api/ApiExamination/AddExamApply',
        accepts: "application/json",
        contentType: "application/json",
        data: JSON.stringify(examApplyObj),
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

function onloadAddCourseView(index) {
    $("#index").text(teacher_index);
    $.ajax({
        type: "Get",
        async: false,
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
        async: false,
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
    $('#message').text('');
    $.ajax({
        type: "Get",
        async: false,
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
    $('#message').text('');
    var courseId = $("#selectCourse").val();
    if ((courseId == '') || (courseId == null)) {
        $('#selectExam').html("<option value='0'>总成绩</option>");
        return;
    }
    $.ajax({
        type: "Get",
        async: false,
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

function onloadManageGradeView(index) {
    var courseId = $("#selectCourse").val();
    if ((courseId == '') || (courseId == null)) {
        return;
    }
    var examId = $("#selectExam").val();
    var str = '';
    if ((examId == '') || (examId == '0') || examId == null) {
        examId = '0';
        $('#examName').text('总成绩');
        str = '../api/ApiGrade/GetCourseGradeArray/' + courseId;
    } else {
        $('#examName').text('考试名称');
        str = '../api/ApiGrade/GetExamGradeArray/' + examId;
    }
    $.ajax({
        type: "Get",
        async: false,
        url: str + '?index=' + index + '&size=' + teacher_size,
        success: function (data) {
            var applyList = data;
            $('#apply_list').html("");
            for (var i = 0; i < applyList.length; i++) {
                var Number = applyList[i][0];
                var Name = applyList[i][1];
                var Score = applyList[i][2];
                $('#apply_list').append("<tr><td id='" + Number + "'>" + Number + "</td><td>" + Name + "</td><td onclick='FocusScore(this)'>" + Score + "</td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function FocusScore(focus) {
    var td = focus;
    var parent = td.parentNode;
    var input = document.createElement('input');
    input.setAttribute("onblur", "UnFocusScore(this)");
    input.setAttribute("class", "text-center");
    input.value = td.innerHTML;
    scoreVal = input.value;
    input.style.height = parseInt(td.offsetHeight) + "px";
    input.style.width = parseInt(td.offsetWidth) + "px";
    parent.removeChild(td);
    parent.appendChild(input);
    input.focus();
}

function UnFocusScore(blur) {
    var input = blur;
    var parent = input.parentNode;
    changeStr = parent.childNodes[0].id
    var td = document.createElement('td');
    td.setAttribute("onclick", "FocusScore(this)");
    td.innerHTML = input.value;
    td.style.height = parseInt(input.offsetHeight) + "px";
    td.style.width = parseInt(input.offsetWidth) + "px";
    parent.removeChild(input);
    parent.appendChild(td);
    if (scoreVal == td.innerHTML) {
        $('#message').text('');
        return;
    }
    var courseId = $("#selectCourse").val();
    if ((courseId == '') || (courseId == null)) {
        return;
    }
    var examId = $("#selectExam").val();
    var str = '';
    if ((examId == '') || (examId == '0') || examId == null) {
        examId = '0';
        str = '../api/ApiGrade/ChangeCourseGrade?score=' + input.value + '&studenid=' + changeStr + '&courseid=' + courseId;
    } else {
        str = '../api/ApiGrade/ChangeExamGrade?score=' + input.value + '&studenid=' + changeStr + '&examid=' + examId;
    }
    $.ajax({
        type: "put",
        async: false,
        url: str,
        success: function (data) {
            if (data == true) {
                $('#message').text('成功');
            } else {
                $('#message').text('失败');
            }
            onloadManageGradeView(teacher_index);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function onloadAllGradeView(index) {
    $("#index").text(teacher_index);
    $.ajax({
        type: "Get",
        async: false,
        url: '../api/ApiCourse/GetTeacherAllCourseArray/' + Id + '?index=1&size=500',
        success: function (data) {
            var courselist = data;
            $('#headGrade').html("<td>学号</td><td>姓名</td>");
            for (i = 0; i < courselist.length; i++) {
                var Name = courselist[i][1];
                $('#headGrade').append("<td>" + Name + "</td>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
    $.ajax({
        type: "Get",
        async: false,
        url: '../api/ApiGrade/GetAllStudentAllGrade/' + Id + '?index=' + index + '&size=' + teacher_size,
        success: function (data) {
            var applyList = data;
            $('#apply_list').html("");
            var strGrade = '';
            for (var i = 0; i < applyList.length; i++) {
                strGrade += '<tr>';
                for (var j = 0; j < applyList[i].length; j++) {
                    strGrade += '<td>';
                    strGrade += applyList[i][j];
                    strGrade += '</td>';
                }
                strGrade += '</tr>';
            }
            $('#apply_list').append(strGrade);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function onloadExamQuestions() {
    $.ajax({
        type: "Get",
        async: false,
        url: '../../api/ApiQuestion/GetExamAllQuestions?examid=' + examid,
        success: function (data) {
            var Questions = data;
            $('#ChoiceQuestions').html("");
            $('#GapFillQuestions').html("");
            $('#TrueOrFalseQuestions').html("");
            $('#ShortAnswerQuestions').html("");
            for (var i = 0; i < Questions.length; i++) {
                var Id = Questions[i].id;
                var questionText = Questions[i].questionText;
                var stem = JSON.parse(questionText).Stem.substring(0, 10);
                var count = 10 - stem.length;
                if (count >= 0) {
                    for (var j = 0; j < parseInt(count / 2); j++) {
                        stem = '&emsp;' + stem + '&emsp;';
                    }
                }
                var temp = "";
                if (questionText.indexOf("\"choiceRightAnswer\":") != -1) {
                    temp = '#ChoiceQuestions';
                } else if (questionText.indexOf("\"gapFillRightAnswer\":") != -1) {
                    temp = '#GapFillQuestions';
                } else if (questionText.indexOf("\"TOFRightAnswer\":") != -1) {
                    temp = '#TrueOrFalseQuestions';
                } else if (questionText.indexOf("\"shortAnsRightAnswer\":") != -1) {
                    temp = '#ShortAnswerQuestions';
                }
                $(temp).append("<tr><td>" + stem +
                    "</td><td><a class='btn btn-block btn-danger' href='../UpdateExamQuestion/" +
                    Id +
                    "'>修改</a></td><td><button class='btn btn-block btn-danger' onclick='DeleteQuestion(" + Id + ")'>删除</button></td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function DeleteQuestion(id) {
    if (confirm("是否删除?")) {
        $.ajax({
            type: "Delete",
            async: false,
            url: '../../api/ApiQuestion/DeleteExaminationQuestion/' + id,
            success: function (data) {
                if (data == true) {
                    alert('成功');
                } else {
                    alert('失败');
                }
                onloadExamQuestions();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
                location.reload();
            }
        });
    }
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
