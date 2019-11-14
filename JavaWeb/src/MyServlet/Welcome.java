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
import java.net.URLDecoder;
import java.util.ArrayList;

public class Welcome extends HttpServlet {
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String header = request.getHeader("Cookie").trim();
        String[] temp = header.split(";");
        ArrayList<Cookie> cookies = new ArrayList<Cookie>() {
        };
        for (String s : temp) {
            s=s.trim();
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
                if (name.equals("User")) {
                    Gson gson = new Gson();
                    User user=gson.fromJson(cookie.getValue(),User.class);
                    user.setUserName(EscapeUnescape.unescape(user.getUserName()));
                    String[] roles=new String[]{"未注册","学生","老师","管理员"};
                    response.getWriter().println("你的角色是" + roles[user.getRole()]);
                    response.getWriter().println("你的名称是" + user.getUserName());
                }
            }
        }

    }
}
