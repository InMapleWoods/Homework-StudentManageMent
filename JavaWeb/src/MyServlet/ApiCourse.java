package MyServlet;

import Service.CourseService;
import Tools.TranRequest;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.net.URL;

public class ApiCourse extends HttpServlet {
    CourseService courseService = new CourseService();
    TranRequest transRequest = new TranRequest();

    protected void doPut(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String baseUri = request.getRequestURI();//这个位置进行url判别，看到底是请求什么功能的
        if (baseUri.endsWith("/ChooseCourse")) {
            ChooseCourse(request, response);
            return;
        }
        //请求了一个没有的接口，返回404
        response.getWriter().println("Error: 404");
        response.getWriter().flush();
        return;
    }

    private void ChooseCourse(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String UserId = request.getParameter("UserId");
        String CourseId = request.getParameter("CourseId");
        URL url = new URL("http://152.136.73.240:7723/api/ApiCourse/ChooseCourse?UserId=" + UserId + "&CourseId=" + CourseId);
        transRequest.PutRequest(response, "", url);
    }

    protected void doDelete(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String baseUri = request.getRequestURI();//这个位置进行url判别，看到底是请求什么功能的
        if (baseUri.endsWith("/DeleteStudentCourse")) {
            DeleteStudentCourse(request, response);
            return;
        }
        //请求了一个没有的接口，返回404
        response.getWriter().println("Error: 404");
        response.getWriter().flush();
    }

    private void DeleteStudentCourse(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String UserId = request.getParameter("UserId");
        String CourseId = request.getParameter("CourseId");
        URL url = new URL("http://152.136.73.240:7723/api/ApiCourse/DeleteStudentCourse?UserId=" + UserId + "&CourseId=" + CourseId);
        transRequest.DeleteRequest(response, "", url);
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String baseUri = request.getRequestURI();//这个位置进行url判别，看到底是请求什么功能的
        if (baseUri.endsWith("/ChosenCourse")) {
            CourseChosen(request, response);
            return;
        }
        if (baseUri.endsWith("/NoChooseCourse")) {
            CourseNoChoose(request, response);
            return;
        }
        if (baseUri.endsWith("/GetStudentAllCoursePageNum")) {
            GetStudentAllCoursePageNum(request, response);
            return;
        }
        if (baseUri.endsWith("/GetStudentNoChooseCoursePageNum")) {
            GetStudentNoChooseCoursePageNum(request, response);
            return;
        }
        //请求了一个没有的接口，返回404
        response.getWriter().println("Error: 404");
        response.getWriter().flush();
    }

    private void CourseNoChoose(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String id = request.getParameter("id");
        int index = Integer.parseInt(request.getParameter("index"));
        int size = Integer.parseInt(request.getParameter("size"));
        String result = null;
        try {
            result = courseService.GetStudentNoChooseCourse(id, index, size);
        } catch (Exception e) {
            e.printStackTrace();
        }
        response.setCharacterEncoding("unicode");
        response.getWriter().append(result);
    }

    private void CourseChosen(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String id = request.getParameter("id");
        int index = Integer.parseInt(request.getParameter("index"));
        int size = Integer.parseInt(request.getParameter("size"));
        String result = null;
        try {
            result = courseService.GetStudentChosenCourse(id, index, size);
        } catch (Exception e) {
            e.printStackTrace();
        }
        response.setCharacterEncoding("unicode");
        response.getWriter().append(result);
    }

    private void GetStudentAllCoursePageNum(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String id = request.getParameter("id");
        String sizeStr = request.getParameter("size");
        int size = Integer.parseInt(sizeStr);
        URL url = new URL("http://152.136.73.240:7723/api/ApiCourse/GetStudentAllCoursePageNum/" + id + "?size=" + size);
        transRequest.GetRequest(response, url);
       /* String result= null;
        try {
            result = courseBll.GetStudentChosenCourse(id,size);
        } catch (Exception e) {
            e.printStackTrace();
        }
        response.setCharacterEncoding("unicode");
        response.getWriter().append(result);*/
    }

    private void GetStudentNoChooseCoursePageNum(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String id = request.getParameter("id");
        String sizeStr = request.getParameter("size");
        int size = Integer.parseInt(sizeStr);
        URL url = new URL("http://152.136.73.240:7723/api/ApiCourse/GetStudentNoChooseCoursePageNum/" + id + "?size=" + size);
        transRequest.GetRequest(response, url);
       /* String result= null;
        try {
            result = courseBll.GetStudentChosenCourse(id,size);
        } catch (Exception e) {
            e.printStackTrace();
        }
        response.setCharacterEncoding("unicode");
        response.getWriter().append(result);*/
    }
}
