package MyServlet;

import Bll.CourseBll;
import Bll.UserBll;
import Model.User;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public class CourseNoChoose extends HttpServlet {
    CourseBll courseBll=new CourseBll();


    public CourseNoChoose() {
        super();
        // TODO Auto-generated constructor stub
    }

    /**
     * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
     * response)
     */
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        String result= null;
        try {
            result = courseBll.GetStudentNoChooseCourse("320",1,100);
        } catch (Exception e) {
            e.printStackTrace();
        }
        response.setCharacterEncoding("unicode");
        response.getWriter().append(result);
        //URL url = new URL("http://152.136.73.240:7723/api/ApiLogin?account=" + account);
        //transRequest.GetRequest(response, url);
    }
}
