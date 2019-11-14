package Login;

import Bll.UserBll;
import Model.User;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet(value = "/Login", name = "登录页面")
public class Login extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        String account = request.getParameter("account");
        String password = request.getParameter("password");
        UserBll userBll = new UserBll();
        User user = null;
        response.setCharacterEncoding("unicode");
        try {
            boolean result = userBll.Login(account, password, user);
            response.getWriter().append(String.valueOf(result));
        } catch (Exception e) {
            response.setStatus(404);
            response.getWriter().append(e.getMessage());
        }
    }
}
