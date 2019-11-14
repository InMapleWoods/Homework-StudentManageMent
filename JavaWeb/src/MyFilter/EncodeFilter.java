package MyFilter;

import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import java.io.IOException;

@WebFilter(filterName = "EncodeFilter")
public class EncodeFilter implements Filter {
    public void destroy() {
    }

    public void doFilter(ServletRequest req, ServletResponse resp, FilterChain chain) throws ServletException, IOException {
        req.setCharacterEncoding("unicode");
        resp.setCharacterEncoding("unicode");
        chain.doFilter(req, resp);
        req.setCharacterEncoding("unicode");
        resp.setCharacterEncoding("unicode");
    }

    public void init(FilterConfig config) throws ServletException {

    }

}
