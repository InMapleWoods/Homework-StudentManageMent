package MyListener;

import javax.servlet.http.HttpSessionEvent;
import javax.servlet.http.HttpSessionListener;
import java.util.ArrayList;

public class HttpSessionCountListener implements HttpSessionListener {

    private static int activeSessions = 0;
    private static ArrayList<String> activeUsers = new ArrayList<String>();

    //获取活动的session个数(在线人数)
    public static int getActiveSessions() {
        return activeSessions;
    }

    public static void addActiveSessions() {
        activeSessions++;
    }

    public static void decActiveSessions() {
        if (activeSessions > 0) {
            activeSessions--;
        }
    }

    public static ArrayList<String> getActiveUsers() {
        return activeUsers;
    }

    public static void setActiveUsers(ArrayList<String> t) {
        activeUsers = t;
    }

    public static void addActiveUsers(String t) {
        if (t != null)
            activeUsers.add(t);
    }

    public static void decActiveUsers(String t) {
        for (int i = 0; i < activeUsers.size(); i++) {
            if (activeUsers.get(i).equals(t))
                activeUsers.remove(i);
        }
    }

    //session创建时执行
    public void sessionCreated(HttpSessionEvent se) {
        //重新在servletContext中保存userCounts
        se.getSession().getServletContext().setAttribute("userCounts", activeSessions);
    }

    //session销毁时执行
    public void sessionDestroyed(HttpSessionEvent se) {
        if (activeSessions > 0) {
            activeSessions--;
            //重新在servletContext中保存userCounts
            se.getSession().getServletContext().setAttribute("userCounts", activeSessions);
        }
    }
}
