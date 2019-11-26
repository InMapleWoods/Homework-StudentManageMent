package Service;

import Dao.CourseDao;

import java.util.ArrayList;

public class CourseService {
    private CourseDao courseDao = new CourseDao();

    public String GetStudentChosenCourse(String studentId, int index, int size) throws Exception {
        studentId = studentId == null ? "0" : studentId;
        String str;
        try {
            ArrayList<String[]> temp = courseDao.GetStudentChosenCourse(studentId, index, size);
            str = ConvertArrayList(temp);
        } catch (Exception e) {
            throw e;
        }
        return str;
    }

    public String GetStudentNoChooseCourse(String studentId, int index, int size) throws Exception {
        studentId = studentId == null ? "0" : studentId;
        String result;
        try {
            result = ConvertArrayList(courseDao.GetStudentNoChooseCourse(studentId, index, size));
        } catch (Exception e) {
            throw e;
        }
        return result;
    }

    private String ConvertArrayList(ArrayList<String[]> temp) {
        String str = "[";
        for (int i = 0; i < temp.size() - 1; i++) {
            str += "[";
            String[] course = temp.get(i);
            for (int j = 0; j < course.length - 1; j++) {
                str += "\"" + course[j] + "\",";
            }
            str += "\"" + course[course.length - 1] + "\"";
            str += "],";
        }
        str += "[";
        if (temp.size() - 1 >= 0) {
            for (int j = 0; j < temp.get(temp.size() - 1).length - 1; j++) {
                str += "\"" + temp.get(temp.size() - 1)[j] + "\",";
            }
            str += "\"" + temp.get(temp.size() - 1)[temp.get(temp.size() - 1).length - 1] + "\"";
        }
        str += "]]";
        return str;
    }
}
