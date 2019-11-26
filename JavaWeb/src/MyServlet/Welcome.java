package MyServlet;

import Model.User;
import MyListener.HttpSessionCountListener;
import Tools.EscapeUnescape;
import com.google.gson.Gson;

import javax.servlet.ServletException;
import javax.servlet.http.*;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Enumeration;

public class Welcome extends HttpServlet {

    protected void doDelete(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        HttpSessionCountListener.decActiveSessions();
        User user = getCookieUser(request, response);
        HttpSessionCountListener.decActiveUsers(user.getUserName());
        request.getSession().invalidate();
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        if (!isEqual(request, response)) {
            Cookie cookie = new Cookie("User", "");
            cookie.setMaxAge(0);
            response.addCookie(cookie);
            Cookie cookie2 = new Cookie("islogin", "");
            cookie2.setMaxAge(0);
            response.addCookie(cookie2);
            response.sendRedirect("/#");
            return;
        }
        User user = getCookieUser(request, response);
        assert user != null;
        switch (user.getRole()) {
            case 1: {
                response.sendRedirect("Student.jsp");
                return;
            }
            case 3: {
                response.sendRedirect("Administrator.jsp");
                return;
            }
        }

    }

    private boolean isEqual(HttpServletRequest request, HttpServletResponse response) {
        User sessionUser = getSessionUser(request, response);
        User cookieUser = getCookieUser(request, response);
        if (cookieUser == null)
            return false;
        if (sessionUser == null) {
            HttpSession session = request.getSession();
            session.setAttribute("User", cookieUser);
            return false;
        }
        return sessionUser.equals(cookieUser);
    }

    private User getSessionUser(HttpServletRequest request, HttpServletResponse response) {
        HttpSession session = request.getSession();
        Enumeration<String> sessionAttributeNames = session.getAttributeNames();
        while (sessionAttributeNames.hasMoreElements()) {
            String key = sessionAttributeNames.nextElement();
            if (key.equals("User")) {
                User user = (User) session.getAttribute("User");
                return user;
            }
        }
        return null;
    }

    private User getCookieUser(HttpServletRequest request, HttpServletResponse response) {
        String header = request.getHeader("Cookie");
        if (header != null)
            header = header.trim();
        else
            return null;
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
                    if ("true".equals(cookie.getValue())) {
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
                                    return user;
                                }
                            }
                        }
                    }
                }
            }
        }
        return null;
    }
}