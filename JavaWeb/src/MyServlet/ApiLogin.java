package Login;

import Bll.UserBll;
import Model.User;
import TransRequest.TranRequest;
import jdk.nashorn.internal.ir.debug.JSONWriter;
import jdk.nashorn.internal.parser.JSONParser;

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

    /**
     * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
     * response)
     */
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        // TODO Auto-generated method stub

        String account = request.getParameter("account");
        UserBll userBll=new UserBll();
        try {
            User user=userBll.GetAccountisExist(account);
            response.setCharacterEncoding("unicode");
            response.getWriter().append(String.valueOf(user));
        } catch (Exception e) {
            response.setStatus(404);
            response.getWriter().append(e.getMessage());
            e.printStackTrace();
        }
        //URL url = new URL("http://152.136.73.240:7723/api/ApiLogin?account=" + account);
        //transRequest.GetRequest(response, url);
    }

    /**
     * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
     * response)
     */
    protected void doPost(HttpServletRequest request, HttpServletResponse response)

            throws ServletException, IOException {
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
        UserBll userBll = new UserBll();
        try {
            response.setCharacterEncoding("unicode");
            boolean result = userBll.Login(account, password, user);
            response.getWriter().println(String.valueOf(result));
            session.setAttribute("User", user);
        } catch (Exception e) {
            response.setStatus(404);
            response.getWriter().append(e.getMessage());
            e.printStackTrace();
        }
        //transRequest.PostRequest(response, jsonresult, new URL("http://152.136.73.240:7723/api/ApiLogin/Login"));
    }


}

