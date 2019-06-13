
# Homework-StudentManageMent
UML课程设计，一个简单的学生信息管理系统
## 系统组成
```
StudentManageMent┬StudentManageMentWinform┬MainForm┬StudentForm┬CourseChooseForm
                 │                        │        │           │
                 │                        │        │           └GradeViewForm
                 │                        │        │               
                 │                        │        ├TeacherForm┬CourseAddForm
                 │                        │        │           │
                 │                        │        │           └GradeChangeForm
                 │                        │        │
                 │                        │        └AdminForm┬UserChangeForm
                 │                        │                  │
                 │                        │                  └UserCheckForm
                 │                        │
                 │                        │
                 │                        ├LoginForm
                 │                        │
                 │                        │
                 │                        │
                 │                        └RegisterForm
                 │
                 │
                 └StudentManageMentWeb┬
                                          
```
