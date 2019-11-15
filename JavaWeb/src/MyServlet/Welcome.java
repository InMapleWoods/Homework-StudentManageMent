package MyServlet;

import Model.User;
import Tools.EscapeUnescape;
import com.google.gson.Gson;

import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.ArrayList;

public class Welcome extends HttpServlet {
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String header = request.getHeader("Cookie");
        if (header != null)
            header = header.trim();
        else
            return;
        String[] temp = header.split(";");
        ArrayList<Cookie> cookies = new ArrayList<Cookie>() {
        };
        for (String s : temp) {
            s = s.trim();
            String name = s.split("=")[0];
            String value = s.split("=")[1];
            Cookie cookie = new Cookie(name, value);
            cookies.add(cookie);
        }
        if (cookies != null) {
            //3 遍历Request对象中的所有Cookie
            for (Cookie cookie : cookies) {
                //4 获取每一个Cookie的名称
                String name = cookie.getName();
                //5 判断Cookie的名称是否存在是id
                if (name.equals("islogin")) {
                    if ("true".equals(cookie.getValue().toString())) {
                        if (cookies != null) {
                            //3 遍历Request对象中的所有Cookie
                            for (Cookie _cookie : cookies) {
                                //4 获取每一个Cookie的名称
                                String _name = _cookie.getName();
                                //5 判断Cookie的名称是否存在是id
                                if (_name.equals("User")) {
                                    Gson gson = new Gson();
                                    User user = gson.fromJson(_cookie.getValue(), User.class);
                                    user.setUserName(EscapeUnescape.unescape(user.getUserName()));
                                    switch (user.getRole()) {
                                        case 1:
                                            response.sendRedirect("Student.html");
                                            return;
                                        case 3:
                                            response.sendRedirect("Administrator.html");
                                            return;
                                    }
                   /* String[] roles=new String[]{"未注册","学生","老师","管理员"};
                    response.setCharacterEncoding("unicode");
                    response.getWriter().append("你的角色是" + roles[user.getRole()]);
                    response.getWriter().append("你的名称是" + user.getUserName());*/
                                }
                            }
                        }
                    }
                    else {
                        response.sendRedirect("/#");
                    }
                }
            }
            response.sendRedirect("/#");
        }

    }
}
