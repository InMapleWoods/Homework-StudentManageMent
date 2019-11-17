var student_page = 1;
var student_size = 10;
var student_index = 1;
var dataTypeChoose = -1;
window.onload = function () {
    if (getCookie('islogin') == 'false' || !isExistCookie('islogin')) {
        location = '../';
    } else {
        deleteCookie('times');
    }
}
var Id = getJSONCookie('User').UserID;
var sqls = [
    window.matchMedia('(max-width:418px)'), //和CSS一样，也要注意顺序！
    window.matchMedia('(max-width:768px)'),
    window.matchMedia('(max-width:992px)'),
    window.matchMedia('(max-width:1200px)')
]

window.onload = function () {
    if (getCookie('islogin') == 'false' || !isExistCookie('islogin')) {
        location = '../';
    } else {
        deleteCookie('times');
    }
}

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
        $('#StudentFrame').attr('src', '../Student/GetCourseView.html');
    } else if (name == 'chooseCourse') {
        $('#StudentFrame').attr('src', '../Student/ChooseCourse.html');
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
}

function GetPageNumStudent(choose) {
    if (choose == 1) {
        $.ajax({
            type: "Get",
            url: '../api/ApiCourse/GetStudentAllCoursePageNum?id=' + Id + '&size=' + student_size,
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
            url: '../api/ApiCourse/GetStudentNoChooseCoursePageNum?id=' + Id + '&size=' + student_size,
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
        url: '../api/ApiCourse/ChosenCourse?id=' + userId + '&index=' + index + '&size=' + student_size,
        success: function (data) {
            var applyList = eval(data);
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
            if (data == 'true') {
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
        url: '../api/ApiCourse/NoChooseCourse?id=' + userId + '&index=' + index + '&size=' + student_size,
        success: function (data) {
            var applyList = eval(data);
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
            if (data == 'true') {
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