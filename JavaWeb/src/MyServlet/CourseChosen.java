package MyServlet;

import Bll.CourseBll;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public class CourseChosen extends HttpServlet {
    CourseBll courseBll=new CourseBll();


    public CourseChosen() {
        super();
        // TODO Auto-generated constructor stub
    }

    /**
     * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
     * response)
     */
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        String id = request.getParameter("id");
        int index = Integer.parseInt(request.getParameter("index"));
        int size = Integer.parseInt(request.getParameter("size"));
        String result= null;
        try {
            result = courseBll.GetStudentNoChooseCourse(id,index,size);
        } catch (Exception e) {
            e.printStackTrace();
        }
        response.getWriter().append(result);
        //URL url = new URL("http://152.136.73.240:7723/api/ApiLogin?account=" + account);
        //transRequest.GetRequest(response, url);
    }
}
