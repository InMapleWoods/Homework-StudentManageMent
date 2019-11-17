package MyListener;

import javax.servlet.http.HttpSessionEvent;
import javax.servlet.http.HttpSessionListener;

public class HttpSessionCountListener implements HttpSessionListener {

    private static int activeSessions = 0;

    //获取活动的session个数(在线人数)
    public static int getActiveSessions() {
        return activeSessions;
    }

    //session创建时执行
    public void sessionCreated(HttpSessionEvent se) {
        activeSessions++;
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
