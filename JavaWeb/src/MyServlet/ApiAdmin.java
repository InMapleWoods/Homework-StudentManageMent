package MyServlet;

import Tools.TranRequest;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.net.URL;

public class ApiAdmin extends HttpServlet {
    private TranRequest transRequest = new TranRequest();

    protected void doPut(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String baseUri = request.getRequestURI();//这个位置进行url判别，看到底是请求什么功能的
        if (baseUri.endsWith("/AcceptLog")) {
            AcceptLog(request, response);
            return;
        }
        if (baseUri.endsWith("/RejectApply")) {
            RejectApply(request, response);
            return;
        }
        if (baseUri.endsWith("/UpdateSettings")) {
            UpdateSettings(request, response);
            return;
        }
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }

    protected void doDelete(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String baseUri = request.getRequestURI();//这个位置进行url判别，看到底是请求什么功能的
        if (baseUri.endsWith("/DeleteStudent")) {
            DeleteStudent(request, response);
            return;
        }

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String baseUri = request.getRequestURI();//这个位置进行url判别，看到底是请求什么功能的
        if (baseUri.endsWith("/GetAllPageNum")) {
            GetPageNumAdmin(request, response);
            return;
        }
        if (baseUri.endsWith("/GetPaperUsersArray")) {
            GetPaperUsersArray(request, response);
            return;
        }
        if (baseUri.endsWith("/GetSettings")) {
            GetSettings(request, response);
            return;
        }
    }

    private void GetPageNumAdmin(HttpServletRequest request, HttpServletResponse response) throws IOException {
        response.setCharacterEncoding("unicode");
        String UserId = request.getParameter("size");
        String CourseId = request.getParameter("choose");
        URL url = new URL("http://152.136.73.240:7723/api/ApiAdmin/GetAllPageNum?size=" + UserId + "&choose=" + CourseId);
        transRequest.GetRequest(response, url);
    }

    private void GetPaperUsersArray(HttpServletRequest request, HttpServletResponse response) throws IOException {
        response.setCharacterEncoding("unicode");
        String index = request.getParameter("index");
        String size = request.getParameter("size");
        String choose = request.getParameter("choose");
        URL url = new URL("http://152.136.73.240:7723/api/ApiAdmin/GetPaperUsersArray?index=" + index + "&size=" + size + "&choose=" + choose);
        transRequest.GetRequest(response, url);
    }

    private void GetSettings(HttpServletRequest request, HttpServletResponse response) throws IOException {
        response.setCharacterEncoding("unicode");
        URL url = new URL("http://152.136.73.240:7723/api/ApiAdmin/GetSettings");
        transRequest.GetRequest(response, url);
    }

    private void AcceptLog(HttpServletRequest request, HttpServletResponse response) throws IOException {
        response.setCharacterEncoding("unicode");
        String number = request.getParameter("number");
        URL url = new URL("http://152.136.73.240:7723/api/ApiAdmin/AcceptLog?number=" + number);
        transRequest.PutRequest(response, "", url);
    }

    private void RejectApply(HttpServletRequest request, HttpServletResponse response) throws IOException {
        response.setCharacterEncoding("unicode");
        String number = request.getParameter("number");
        URL url = new URL("http://152.136.73.240:7723/api/ApiAdmin/RejectApply?number=" + number);
        transRequest.PutRequest(response, "", url);
    }

    private void DeleteStudent(HttpServletRequest request, HttpServletResponse response) throws IOException {
        response.setCharacterEncoding("unicode");
        String number = request.getParameter("number");
        URL url = new URL("http://152.136.73.240:7723/api/ApiAdmin?number=" + number);
        transRequest.DeleteRequest(response, "", url);
    }

    private void UpdateSettings(HttpServletRequest request, HttpServletResponse response) throws IOException {
        response.setCharacterEncoding("unicode");
        String name = request.getParameter("name");
        String value = request.getParameter("value");
        URL url = new URL("http://152.136.73.240:7723/api/ApiAdmin/UpdateSettings?name=" + name + "&value=" + value);
        transRequest.PutRequest(response, "", url);
    }
}
