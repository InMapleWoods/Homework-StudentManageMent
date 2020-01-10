var student_page = 1;
var student_size = 10;
var student_index = 1;
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
        student_size = 5;
    } else if (sqls[1].matches) {
        student_size = 9;
    } else if (sqls[2].matches) {
        student_size = 10;
    } else if (sqls[3].matches) {
        student_size = 11;
    } else {
        student_size = 12;
    }
    onloadViewStudent(student_index, dataTypeChoose, Id);
}

mediaMatches(); //页面首次加载
onclickStudentTab('courseView');

function onclickStudentTab(name) {
    if (getCookie('islogin') == 'false' || !isExistCookie('islogin')) {
        location = '../';
        return;
    }
    if (name == 'courseView') {
        $('#StudentFrame').attr('src', '../Student/GetCourseView');
    } else if (name == 'chooseCourse') {
        $('#StudentFrame').attr('src', '../Student/ChooseCourse');
    } else if (name == 'gradeView') {
        $('#StudentFrame').attr('src', '../Student/GetGradeView');
    } else if (name == 'Exam') {
        $('#StudentFrame').attr('src', '../Student/GetExam');
    }
}

for (var i = 0; i < sqls.length; i++) {
    sqls[i].addListener(mediaMatches);
}

function onloadViewStudent(index, choose, userId) {
    if (choose == 1)
        onloadCourseView(index, userId);
    else if (choose == 2)
        onloadChooseCourseView(index, userId);
    else if (choose == 3) {
        onloadCourseSelectList(userId);
        onloadExamSelectList();
        onloadGradeView();
    }
    else if (choose == 4)
        onloadExamView(index, userId);
    $("#index").text(student_index);
}

function GetPageNumStudent(choose) {
    if (choose == 1) {
        $.ajax({
            type: "Get",
            async: false,
            url: '../api/ApiCourse/GetStudentAllCoursePageNum/' + Id + '?size=' + student_size,
            success: function (data) {
                student_page = data;
                $("#page").text(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
                location.reload();
            }
        });
    } else if (choose == 2) {
        $.ajax({
            type: "Get",
            async: false,
            url: '../api/ApiCourse/GetStudentNoChooseCoursePageNum/' + Id + '?size=' + student_size,
            success: function (data) {
                student_page = data;
                $("#page").text(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
                location.reload();
            }
        });

    } else if (choose == 4) {
        $.ajax({
            type: "Get",
            async: false,
            url: '../api/ApiExamination/GetAllPageNum/' + Id + '?size=' + student_size,
            success: function (data) {
                student_page = data;
                $("#page").text(data);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
                location.reload();
            }
        });
    }
}

function onloadCourseView(index, userId) {
    $("#index").text(student_index);
    $.ajax({
        type: "Get",
        async: false,
        url: '../api/ApiCourse/GetStudentAllCourseArray/' + userId + '?index=' + index + '&size=' + student_size,
        success: function (data) {
            var applyList = data;
            $('#apply_list_student_1').html("");
            for (i = 0; i < applyList.length; i++) {
                var Id = applyList[i][0];
                var Name = applyList[i][1];
                $('#apply_list_student_1').append("<tr><td>" + Id + "</td><td>" + Name + "</td><td><button class='btn btn-block btn-danger' onclick=DeleteCourse('" + Id + "','" + userId + "')>删除已选课程</button></td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function DeleteCourse(courseId, studentId) {
    $.ajax({
        type: "Delete",
        url: '../api/ApiCourse/DeleteStudentCourse?UserId=' + studentId + '&CourseId=' + courseId,
        success: function (data) {
            if (data == true) {
                alert('成功');
            } else {
                alert('失败');
            }
            onloadViewStudent(student_index, dataTypeChoose, studentId);
            onloadChooseCourseView(student_index, studentId);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });

}

function onloadChooseCourseView(index, userId) {
    $("#index").text(student_index);
    $.ajax({
        type: "Get",
        async: false,
        url: '../api/ApiCourse/GetStudentNoChooseCourseArray/' + userId + '?index=' + index + '&size=' + student_size,
        success: function (data) {
            var applyList = data;
            $('#apply_list_student_2').html("");
            for (i = 0; i < applyList.length; i++) {
                var Id = applyList[i][0];
                var Name = applyList[i][1];
                var TeacherName = applyList[i][2];
                $('#apply_list_student_2').append("<tr><td>" + Id + "</td><td>" + Name + "</td><td>" + TeacherName + "</td><td><button class='btn btn-block btn-danger' onclick=ChooseCourse('" + Id + "','" + userId + "')>选择</button></td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function ChooseCourse(courseId, studentId) {
    $.ajax({
        type: "Put",
        url: '../api/ApiCourse/ChooseCourse?UserId=' + studentId + '&CourseId=' + courseId,
        success: function (data) {
            if (data == true) {
                alert('成功');
            } else {
                alert('失败');
            }
            onloadViewStudent(student_index, dataTypeChoose, studentId);
            onloadCourseView(student_index, studentId);
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
        async: false,
        url: '../api/ApiCourse/GetStudentAllCourseArray/' + userId + '?index=1&size=200',
        success: function (data) {
            var courselist = data;
            $('#courseSelect').html("");
            for (i = 0; i < courselist.length; i++) {
                var Id = courselist[i][0];
                var Name = courselist[i][1];
                $('#courseSelect').append("<option value='" + Id + "'>" + Name + "</option>");
            }
            $("#courseSelect").val(courselist[0][0]);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function onloadExamSelectList() {
    var courseId = $("#courseSelect").val();
    if ((courseId == '') || (courseId == null))
        return;
    $.ajax({
        type: "Get",
        async: false,
        url: '../api/ApiExamination/GetExaminationByCourseId/' + courseId,
        success: function (data) {
            var examlist = data;
            $('#examSelect').html("<option value='0'>总成绩</option>");
            for (i = 0; i < examlist.length; i++) {
                var Id = examlist[i].id;
                var Name = examlist[i].name;
                $('#examSelect').append("<option value='" + Id + "'>" + Name + "</option>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }

    });
}

function onloadGradeView() {
    var courseId = $("#courseSelect").val();
    if ((courseId == '') || (courseId == null))
        return;
    var examId = $("#examSelect").val();
    if ((examId == '') || (examId == '0') || examId == null) {
        examId = '0';
        $('#examName').text('总成绩');
    } else {
        $('#examName').text('考试名称');
    }
    $.ajax({
        type: "Get",
        async: false,
        url: '../api/ApiGrade/GetStudentGradeArray/' + Id + '?courseId=' + courseId + '&examId=' + examId,
        success: function (data) {
            var applyList = data;
            $('#apply_list_student_3').html("");
            for (i = 0; i < applyList.length; i++) {
                var CourseName = applyList[i][0];
                var ExamName = applyList[i][1];
                var Score = applyList[i][2];
                $('#apply_list_student_3').append("<tr><td>" + CourseName + "</td><td>" + ExamName + "</td><td>" + Score + "</td></tr>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function onloadExamView(index, userId) {
    $("#index").text(student_index);
    $.ajax({
        type: "Get",
        url: '../api/ApiCourse/GetStudentAllCourseArray/' + userId + '?index=1&size=500',
        success: function (data) {
            var applyList = data;
            $('#apply_list_student_4').html("");
            for (i = 0; i < applyList.length; i++) {
                var Id = applyList[i][0];
                $.ajax({
                    type: "Get",
                    url: '../api/ApiExamination/GetExam/' + Id + '?index=' + index + '&size=' + student_size,
                    success: function (data) {
                        var applyList = data;
                        for (i = 0; i < applyList.length; i++) {
                            var Id = applyList[i][0];
                            var CourseName = applyList[i][1];
                            var ExamTime = new Date(applyList[i][2]).toLocaleString();
                            var ExamName = applyList[i][3];
                            var ExamDuration = applyList[i][4];
                            var isPassed = applyList[i][5];
                            var tempStr = "<td><button class='btn btn-block btn-danger' onclick=TakeExam('" + Id + "')>参加考试</button></td>";
                            if (!isPassed) {
                                tempStr = "<td><button class='btn btn-block btn-info disabled'>参加考试</button></td>";
                            }
                            $('#apply_list_student_4').append("<tr><td>" + Id + "</td><td>" + CourseName + "</td><td>" + ExamName + "</td><td>" + ExamTime + "</td><td>" + ExamDuration + "</td>" + tempStr + "</tr>");
                        }
                    },
                });
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
}

function TakeExam(examId) {
    location = '../Student/ExamView/' + examId;
}

function onloadExamQuestions(examid) {
    var ChoiceQue = [];
    var GapFillQue = [];
    var TOFQue = [];
    var ShortAnsQue = [];
    $.ajax({
        type: "Get",
        async: false,
        url: '../../api/ApiQuestion/GetExamAllQuestions?examid=' + examid,
        success: function (data) {
            var Questions = data;
            for (var i = 0; i < Questions.length; i++) {
                var questionText = Questions[i].questionText;
                if (questionText.indexOf("\"choiceRightAnswer\":") != -1) {
                    ChoiceQue.push(Questions[i]);
                } else if (questionText.indexOf("\"gapFillRightAnswer\":") != -1) {
                    GapFillQue.push(Questions[i]);
                } else if (questionText.indexOf("\"TOFRightAnswer\":") != -1) {
                    TOFQue.push(Questions[i]);
                } else if (questionText.indexOf("\"shortAnsRightAnswer\":") != -1) {
                    ShortAnsQue.push(Questions[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
            location.reload();
        }
    });
    var tempStr = "";
    var questionCount = 0;
    tempStr += "<table class='col-12'><thead class='text-center'><tr><td colspan=\"10\">选择题</td></tr></thead><tbody>";
    for (var i in ChoiceQue) {
        questionCount = questionCount + 1;
        tempStr += "<tr><td colspan='" + JSON.parse(ChoiceQue[i].questionText).options.length + "'>" + questionCount + ". " + JSON.parse(ChoiceQue[i].questionText).Stem + "</td></tr><tr>";
        for (var j = 0; j < JSON.parse(ChoiceQue[i].questionText).options.length; j++) {
            tempStr += "<td>" + String.fromCharCode('A'.charCodeAt() + j) + "." + JSON.parse(ChoiceQue[i].questionText).options[j] + "</td>";
        }
        tempStr += "</tr>";
    }
    tempStr += "</tbody></table><table class='col-12'><thead class='text-center'><tr><td>填空题</td></tr></thead><tbody>";
    for (var i in GapFillQue) {
        questionCount = questionCount + 1;
        tempStr += "<tr><td>" + questionCount + ". " + JSON.parse(GapFillQue[i].questionText).Stem + "__________</td></tr>";
    }
    tempStr += "</tbody></table><table class='col-12'><thead class='text-center'><tr><td>判断题</td></tr></thead><tbody>";
    for (var i in TOFQue) {
        questionCount = questionCount + 1;
        tempStr += "<tr><td>" + questionCount + ". " + JSON.parse(TOFQue[i].questionText).Stem + "(&emsp;&emsp;)</td></tr>";
    }
    tempStr += "</tbody></table><table class='col-12'><thead class='text-center'><tr><td>简答题</td></tr></thead><tbody>";
    for (var i in ShortAnsQue) {
        questionCount = questionCount + 1;
        tempStr += "<tr><td>" + questionCount + ". " + JSON.parse(ShortAnsQue[i].questionText).Stem + "</td></tr><tr><td><textarea rows=\"4\" class=\"form-control\"></textarea></td></tr>";
    }
    tempStr += "</tbody></table>";
    $('#ExamQuestions').append(tempStr);
}
function LeftIndex() {
    if (student_index - 1 > 1)
        student_index = student_index - 1;
    else
        student_index = 1;
    onloadViewStudent(student_index, dataTypeChoose, Id);
}

function RightIndex() {
    if (student_index + 1 < student_page)
        student_index = student_index + 1;
    else
        student_index = student_page;
    onloadViewStudent(student_index, dataTypeChoose, Id);
}

$(document).ready(function () {
    $("#courseSelect").change(function () {
        $("#examSelect").empty();
        onloadExamSelectList();
        onloadGradeView();
    });
    $("#examSelect").change(function () {
        onloadGradeView();
    });
    $("#courseSelect").click(function () {
        $("#examSelect").empty();
        onloadExamSelectList();
        onloadGradeView();
    });
    $("#examSelect").click(function () {
        onloadGradeView();
    });
})