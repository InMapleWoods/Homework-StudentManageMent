package MyServlet;

import Tools.TranRequest;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.net.URL;


public class Validate extends HttpServlet {

    TranRequest transRequest = new TranRequest();

    /**
     * @see HttpServlet#HttpServlet()
     */
    public Validate() {
        super();
        // TODO Auto-generated constructor stub
    }

    /**
     * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
     */
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        // TODO Auto-generated method stub
        // TODO Auto-generated method stub
        URL url = new URL("http://152.136.73.240:7723/api/ApiLogin/validate");
        transRequest.GetRequest(response, url);
    }

}
