var ChoiceQuelist = {};
var Choicecount = 0;

function addChoiceOptions() {
    var str = $('#txtChoiceOp').val();
    ChoiceQuelist["Choiceop" + Choicecount] = str;
    Choicecount = Choicecount + 1;
    showChoiceQue();
}

function removeChoiceQue(index) {
    $('#' + index).remove();
    delete (ChoiceQuelist[index]);
    showChoiceQue();
}

function showChoiceQue() {
    var Quelistindex = 0;
    $('#Choiceoptions').html("");
    $('#inputGroupChoiceQuelist').html("");
    for (var i in ChoiceQuelist) {
        var opstr = '<tr id="' + i + '"><td style="width:70%"><label>' + String.fromCharCode(Quelistindex + 65) +
            ':' +
            ChoiceQuelist[i] +
            '</label></td><td style="width:30%"><button class="btn btn-block btn-outline-danger align-content-between" onclick="removeChoiceQue(\'' +
            i +
            '\')">删除</button></td></tr>';
        $('#Choiceoptions').append(opstr);
        $('#inputGroupChoiceQuelist').append("<option value='" + Quelistindex + "'>" + String.fromCharCode(
            Quelistindex + 65) + "</option>")
        Quelistindex = Quelistindex + 1;
    }
}

function openWindow(htmlurl, tmpWidth, tmpHeight, itop, ileft) {
    if (!tmpWidth) {
        tmpWidth = 500;
    }
    if (!tmpHeight) {
        tmpHeight = 500;
    }
    var top = ((window.screen.availHeight - 30 - tmpHeight) / 2);
    if (itop != null && itop != "") {
        top = itop;
    }
    var left = ((window.screen.availWidth - 10 - tmpWidth) / 2);
    if (ileft != null && ileft != "") {
        left = ileft;
    }

    window.open(htmlurl, "_blank",
        "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no,top=" +
        top + ",left=" + left + ",width=" + tmpWidth + "px,height=" + tmpHeight + "px");
}

function onloadUpdateQuestion() {
    $('#nav-QuestionView-choice').css('display', 'none');
    $('#nav-QuestionView-gapFill').css('display', 'none');
    $('#nav-QuestionView-Truefalse').css('display', 'none');
    $('#nav-QuestionView-shortAnswer').css('display', 'none');
    $.ajax({
        type: "get",
        url: "../../api/ApiQuestion/GetExaminationQuestionById?questionId=" + questionid,
        async: false,
        success: function (data) {
            var Id = data.id;
            examid = data.examId;
            var questionText = data.questionText;            
            if (questionText.indexOf("\"choiceRightAnswer\":") != -1) {
                title = '选择';
                $('#nav-QuestionView-choice').css('display', '');
                var op = JSON.parse(questionText).options;
                Choicecount = op.length;
                for (var i = 0; i < op.length; i++) {
                    ChoiceQuelist["Choiceop" + i] = op[i];
                }
                showChoiceQue();
                $("#inputGroupChoiceQuelist").val(JSON.parse(questionText).choiceRightAnswer);
                $("#txtChoiceStem").val(JSON.parse(questionText).Stem);
            } else if (questionText.indexOf("\"gapFillRightAnswer\":") != -1) {
                title = '填空';
                $('#nav-QuestionView-gapFill').css('display', '');
                $("#inputGapFillAns").val(JSON.parse(questionText).gapFillRightAnswer);
                $("#txtGapFillStem").val(JSON.parse(questionText).Stem);
            } else if (questionText.indexOf("\"TOFRightAnswer\":") != -1) {
                title = '判断';
                $('#nav-QuestionView-Truefalse').css('display', '');
                $("#txtTruefalseStem").val(JSON.parse(questionText).Stem);
                if (JSON.parse(questionText).TOFRightAnswer) {
                    $("#inputTruefalseAns").val('1');
                }
                else {
                    $("#inputTruefalseAns").val('0');
                }
            } else if (questionText.indexOf("\"shortAnsRightAnswer\":") != -1) {
                title = '简答';
                $('#nav-QuestionView-shortAnswer').css('display', '');
                $("#txtshortAnswer").val(JSON.parse(questionText).shortAnsRightAnswer);
                $("#txtshortAnswerStem").val(JSON.parse(questionText).Stem);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            ajaxError(XMLHttpRequest, textStatus);
        }
    });
}

function updateQuestion() {
    if (title === '选择') {
        var ChoiceQueArray = []
        for (var i in ChoiceQuelist) {
            ChoiceQueArray.push(ChoiceQuelist[i])
        }
        var list = [$("#inputGroupChoiceQuelist").val(), ChoiceQueArray];
        $.ajax({
            type: "put",
            accepts: "application/json",
            url: "../../api/ApiQuestion/UpdateExamQuestion/" + questionid + "?type=0&examid=" + examid + "&stem=" + $("#txtChoiceStem").val(),
            contentType: "application/json",
            data: JSON.stringify(list),
            success: function (data) {
                if (data == true) {
                    alert('修改成功');
                } else {
                    alert('修改失败');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
            }
        });

    } else if (title === '填空') {
        var list = [$("#inputGapFillAns").val()];
        $.ajax({
            type: "put",
            accepts: "application/json",
            url: "../../api/ApiQuestion/UpdateExamQuestion/" + questionid + "?type=3&examid=" + examid + "&stem=" + $("#txtGapFillStem").val(),
            contentType: "application/json",
            data: JSON.stringify(list),
            success: function (data) {
                if (data == true) {
                    alert('修改成功');
                } else {
                    alert('修改失败');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
            }
        });
    } else if (title === '判断') {
        var list = [($("#inputTruefalseAns").val() == '1')];
        $.ajax({
            type: "put",
            accepts: "application/json",
            url: "../../api/ApiQuestion/UpdateExamQuestion/" + questionid + "?type=1&examid=" + examid + "&stem=" + $("#txtTruefalseStem").val(),
            contentType: "application/json",
            data: JSON.stringify(list),
            success: function (data) {
                if (data == true) {
                    alert('修改成功');
                } else {
                    alert('修改失败');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
            }
        });
    } else if (title === '简答') {
        var list = [$("#txtshortAnswer").val()];
        $.ajax({
            type: "put",
            accepts: "application/json",
            url: "../../api/ApiQuestion/UpdateExamQuestion/" + questionid + "?type=2&examid=" + examid + "&stem=" + $("#txtshortAnswerStem").val(),
            contentType: "application/json",
            data: JSON.stringify(list),
            success: function (data) {
                if (data == true) {
                    alert('修改成功');
                } else {
                    alert('修改失败');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
            }
        });
    }
}

function addQuestion() {
    var title = $("div button.nav-item.nav-link.active").text();
    title = title.trim();
    if (title === '选择') {
        var ChoiceQueArray = []
        for (var i in ChoiceQuelist) {
            ChoiceQueArray.push(ChoiceQuelist[i])
        }
        var list = [$("#inputGroupChoiceQuelist").val(), ChoiceQueArray];
        $.ajax({
            type: "post",
            accepts: "application/json",
            url: "../../api/ApiQuestion/AddExamQuestion?type=0&examid=" + examid + "&stem=" + $("#txtChoiceStem").val(),
            contentType: "application/json",
            data: JSON.stringify(list),
            success: function (data) {
                if (data == true) {
                    alert('增加成功');
                } else {
                    alert('增加失败');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
            }
        });

    } else if (title === '填空') {
        var list = [$("#inputGapFillAns").val()];
        $.ajax({
            type: "post",
            accepts: "application/json",
            url: "../../api/ApiQuestion/AddExamQuestion?type=3&examid=" + examid + "&stem=" + $("#txtGapFillStem").val(),
            contentType: "application/json",
            data: JSON.stringify(list),
            success: function (data) {
                if (data == true) {
                    alert('增加成功');
                } else {
                    alert('增加失败');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
            }
        });
    } else if (title === '判断') {
        var list = [($("#inputTruefalseAns").val() == '1')];
        $.ajax({
            type: "post",
            accepts: "application/json",
            url: "../../api/ApiQuestion/AddExamQuestion?type=1&examid=" + examid + "&stem=" + $("#txtTruefalseStem").val(),
            contentType: "application/json",
            data: JSON.stringify(list),
            success: function (data) {
                if (data == true) {
                    alert('增加成功');
                } else {
                    alert('增加失败');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
            }
        });
    } else if (title === '简答') {
        var list = [$("#txtshortAnswer").val()];
        $.ajax({
            type: "post",
            accepts: "application/json",
            url: "../../api/ApiQuestion/AddExamQuestion?type=2&examid=" + examid + "&stem=" + $("#txtshortAnswerStem").val(),
            contentType: "application/json",
            data: JSON.stringify(list),
            success: function (data) {
                if (data == true) {
                    alert('增加成功');
                } else {
                    alert('增加失败');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ajaxError(XMLHttpRequest, textStatus);
            }
        });
    }
}