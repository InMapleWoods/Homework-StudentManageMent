package MyServlet;

import Model.User;
import Service.*;
import Tools.TranRequest;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.BufferedReader;
import java.io.IOException;
import java.net.URL;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class ApiLogin extends HttpServlet {
    TranRequest transRequest = new TranRequest();

    public ApiLogin() {
        super();
        // TODO Auto-generated constructor stub
    }


    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        // TODO Auto-generated method stub
        String baseUri = request.getRequestURI();//这个位置进行url判别，看到底是请求什么功能的
        if (baseUri.endsWith("/Validate")) {
            GetValidate(response);
            return;
        }
        if (baseUri.endsWith("")) {
            GetLoginUser(request, response);
            return;
        }

        //请求了一个没有的接口，返回404
        response.getWriter().println("Error: 404");
        response.getWriter().flush();
        return;
    }

    private void GetLoginUser(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String account = request.getParameter("account");
        UserService userService = new UserService();
        response.setCharacterEncoding("unicode");
        try {
            User user = userService.GetAccountisExist(account);
            response.getWriter().append(String.valueOf(user));
        } catch (Exception e) {
            response.setStatus(404);
            response.getWriter().append(e.getMessage());
            e.printStackTrace();
        }
        //URL url = new URL("http://152.136.73.240:7723/api/ApiLogin?account=" + account);
        //transRequest.GetRequest(response, url);
    }

    private void GetValidate(HttpServletResponse response) throws IOException {
        URL url = new URL("http://152.136.73.240:7723/api/ApiLogin/validate");
        transRequest.GetRequest(response, url);
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String baseUri = request.getRequestURI();//这个位置进行url判别，看到底是请求什么功能的
        if (baseUri.endsWith("/Register")) {
            Register(request, response);
            return;
        }
        if (baseUri.endsWith("")) {
            LoginwithAcountandPassword(request, response);
            return;
        }
        //请求了一个没有的接口，返回404
        response.getWriter().println("Error: 404");
        response.getWriter().flush();
        return;
    }

    private void LoginwithAcountandPassword(HttpServletRequest request, HttpServletResponse response) throws IOException {
        HttpSession session = request.getSession();
        // TODO Auto-generated method stub
        StringBuffer json = new StringBuffer();
        String lineString = null;
        try {
            BufferedReader reader = request.getReader();
            while ((lineString = reader.readLine()) != null) {
                json.append(lineString);
            }
        } catch (Exception e) {
            System.out.println(e.toString());
        }
        String jsonresult = json.toString();
        String pattern = "\\{\"account\":\"(.*?)\",\"password\":\"(.*?)\"}";

        // 创建 Pattern 对象
        Pattern r = Pattern.compile(pattern);

        // 现在创建 matcher 对象
        Matcher m = r.matcher(jsonresult);
        String account = "";
        String password = "";
        if (m.find()) {
            account = m.group(1);
            password = m.group(2);
        } else {
            System.out.println("NO MATCH");
        }
        User user = new User();
        UserService userService = new UserService();
        response.setCharacterEncoding("unicode");
        try {
            boolean result = userService.Login(account, password, user);
            response.getWriter().println(result);
            session.setAttribute("User", user);
        } catch (Exception e) {
            response.setStatus(404);
            response.getWriter().append(e.getMessage());
            e.printStackTrace();
        }
        //transRequest.PostRequest(response, jsonresult, new URL("http://152.136.73.240:7723/api/ApiLogin/Login"));
    }

    private void Register(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String jsonresult = request.getQueryString();
        URL url = new URL("http://152.136.73.240:7723/api/ApiLogin/Register?" + jsonresult);
        transRequest.PostRequest(response, "", url);
    }

}

