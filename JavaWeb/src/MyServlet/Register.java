package Login;

import TransRequest.TranRequest;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.net.URL;

public class Register extends HttpServlet {
    TranRequest transRequest = new TranRequest();

    /**
     * @see HttpServlet#HttpServlet()
     */
    public Register() {
        super();
        // TODO Auto-generated constructor stub
    }

    /**
     * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
     * response)
     */
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        String jsonresult = request.getQueryString();
        URL url = new URL("http://152.136.73.240:7723/api/ApiLogin/Register?" + jsonresult);
        transRequest.PostRequest(response, "", url);
    }
}
