# Homework-StudentManageMent

简单的学生信息管理系统

## 系统组成

```
StudentManageMent┬dotnet┬StudentManageMentWPF┬MainForm┬StudentForm┬CourseChooseForm
                 │      │                    │        │           │
                 │      │                    │        │           ├ExamQuestionAnswerForm
                 │      │                    │        │           │
                 │      │                    │        │           └GradeViewForm
                 │      │                    │        │
                 │      │                    │        ├TeacherForm┬CourseAddForm
                 │      │                    │        │           │
                 │      │                    │        │           ├ExamAddForm
                 │      │                    │        │           │
                 │      │                    │        │           ├ExamQuestionAddForm
                 │      │                    │        │           │
                 │      │                    │        │           └GradeChangeForm
                 │      │                    │        │
                 │      │                    │        └AdminForm┬UserChangeForm
                 │      │                    │                  │
                 │      │                    │                  ├ExamCheckForm
                 │      │                    │                  │
                 │      │                    │                  └UserCheckForm
                 │      │                    │
                 │      │                    ├LoginForm
                 │      │                    │
                 │      │                    └RegisterForm
                 │      │
                 │      └StudentManageMentWeb┬Welcome┬Student
                 │                           │       │
                 │                           │       ├Teacher
                 │                           │       │
                 │                           │       └Administrator
                 │                           │
                 │                           ├Login
                 │                           │
                 │                           └Register
                 │
                 └javaweb┬Welcome┬Student
                         │       │
                         │       └Administrator
                         │
                         ├Login
                         │
                         └Register
```
