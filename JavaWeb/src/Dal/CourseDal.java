package Dal;


import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
public class CourseDal {
    SqlHelper sqlHelper=new SqlHelper("jdbc:sqlserver://152.136.73.240:1433;databaseName=db_StudentManage;user=Lsa;password=llfllf");
    public ArrayList<String[]> GetStudentChosenCourse(String studentId, int index, int size) throws SQLException {
        String str="select tb_Course.Id,tb_Course.Name " +
                "from tb_Course inner join tb_Grade " +
                "on tb_Grade.SId=? and tb_Grade.CId=tb_Course.Id and tb_Grade.EId = 0 " +
                "order by tb_Course.Id offset ((? - 1)* ? ) rows fetch next ? rows only";
        Object[] para=new Object[]{
                studentId,index,size,size
        };
        ArrayList<String[]> list=new ArrayList<String[]>() {};
        ResultSet resultSet=sqlHelper.ExecuteQuery(str,para);
        while (resultSet.next())
        {
            int Id=resultSet.getInt(1);
            String Name=resultSet.getString(2);
            String[] t=new String[]{String.valueOf(Id),Name};
            list.add(t);
        }
        return list;
    }

    public ArrayList<String[]> GetStudentNoChooseCourse(String studentId, int index, int size) throws SQLException {
        String str="select tb_Course.Id 课程ID, tb_Course.Name 课程名称, tb_Users.Name 教师名称 " +
                "from tb_Course, tb_Users " +
                "where tb_Course.TeacherId = tb_Users.Id and tb_Users.Role = 2 and tb_Course.Id " +
                "Not in (select tb_Grade.CId" +
                " from tb_Grade " +
                "where tb_Grade.SId = ? and tb_Grade.EId = 0) " +
                "order by tb_Course.Id offset ((? - 1)* ? ) rows fetch next ? rows only";
        Object[] para=new Object[]{
                studentId,index,size,size
        };
        ArrayList<String[]> list=new ArrayList<String[]>() {};
        ResultSet resultSet=sqlHelper.ExecuteQuery(str,para);
        while (resultSet.next())
        {
            int Id=resultSet.getInt(1);
            String Name=resultSet.getString(2);
            String TeacherName=resultSet.getString(3);
            String[] t=new String[]{String.valueOf(Id),Name,TeacherName};
            list.add(t);
        }
        return list;
    }
}
