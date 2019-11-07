package MySystem;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.*;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLConnection;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

@WebServlet(value = "/api/ApiLogin",name ="登录")
public class ApiLogin extends HttpServlet {
    public ApiLogin() {
        super();
        // TODO Auto-generated constructor stub
    }

    /**
     * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
     *      response)
     */
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        // TODO Auto-generated method stub

        String account = request.getParameter("account");
        URL url = new URL("http://152.136.73.240:7723/api/ApiLogin?account=" + account);

        URLConnection connection = url.openConnection();
        HttpURLConnection httpURLConnection = (HttpURLConnection) connection;

        httpURLConnection.setRequestProperty("Accept-Charset", "utf-8");
        httpURLConnection.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

        InputStream inputStream = null;
        InputStreamReader inputStreamReader = null;
        BufferedReader reader = null;
        StringBuffer resultBuffer = new StringBuffer();
        String tempLine = null;
        // 响应失败
        inputStream = httpURLConnection.getInputStream();
        inputStreamReader = new InputStreamReader(inputStream);
        reader = new BufferedReader(inputStreamReader);

        while ((tempLine = reader.readLine()) != null) {
            resultBuffer.append(tempLine);
        }
        response.getWriter().append(resultBuffer.toString());
    }

    /**
     * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
     *      response)
     */
    protected void doPost(HttpServletRequest request, HttpServletResponse response)

            throws ServletException, IOException {
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
        URL url = new URL("http://152.136.73.240:7723/api/ApiLogin/Login");
        HttpURLConnection connection = (HttpURLConnection) url.openConnection();
        connection.setRequestMethod("POST");
        // 设置Content-Type
        connection.setRequestProperty("Content-Type", "application/json");
        // 设置是否向httpUrlConnection输出，post请求设置为true，默认是false
        connection.setDoOutput(true);

        // 设置RequestBody
        PrintWriter printWriter = new PrintWriter(connection.getOutputStream());
        printWriter.write(jsonresult);
        printWriter.flush();

        // 返回结果-字节输入流转换成字符输入流，控制台输出字符
        BufferedReader br = new BufferedReader(new InputStreamReader(connection.getInputStream()));
        StringBuilder sb = new StringBuilder();
        String line;
        while ((line = br.readLine()) != null) {
            sb.append(line);
        }
        response.getWriter().append(sb.toString());
    }

}
@WebServlet(value="/api/ApiLogin/Register",name="注册")
class Register extends HttpServlet {
    /**
     * @see HttpServlet#HttpServlet()
     */
    public Register() {
        super();
        // TODO Auto-generated constructor stub
    }

    /**
     * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
     *      response)
     */
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        String jsonresult = request.getQueryString();
        URL url = new URL("http://152.136.73.240:7723/api/ApiLogin/Register?" + jsonresult);
        // 根据拼凑的URL，打开连接，URL.openConnection函数会根据URL的类型，
        // 返回不同的URLConnection子类的对象，这里URL是一个http，因此实际返回的是HttpURLConnection
        HttpURLConnection connection = (HttpURLConnection) url.openConnection();
        connection.setDoOutput(true);
        // Read from the connection. Default is true.
        connection.setDoInput(true);
        // Set the post method. Default is GET
        connection.setRequestMethod("POST");
        // Post cannot use caches
        // Post 请求不能使用缓存
        connection.setUseCaches(false);

        connection.setRequestMethod("POST");
        connection.setRequestProperty("Content-Length", "0");
        // 进行连接，但是实际上get request要在下一句的connection.getInputStream()函数中才会真正发到服务器
        connection.connect();
        // 取得输入流，并使用Reader读取 /*解决411*/

        /* 解决411 */
        DataOutputStream out = new DataOutputStream(connection.getOutputStream());
        // The URL-encoded contend
        // 正文，正文内容其实跟get的URL中'?'后的参数字符串一致
        // DataOutputStream.writeBytes将字符串中的16位的unicode字符以8位的字符形式写道流里面
        out.flush();
        out.close();// flush and close
        BufferedReader reader = new BufferedReader(new InputStreamReader(connection.getInputStream(), "utf-8"));// 设置编码,否则中文乱码
        StringBuilder sb = new StringBuilder();
        String line;
        while ((line = reader.readLine()) != null) {
            sb.append(line);
        }
        System.out.println(sb.toString());
        response.getWriter().append(sb.toString());
        reader.close();
        // 断开连接
        connection.disconnect();

    }
}

@WebServlet(value="/api/ApiLogin/Validate",name="验证码")
class Validate extends HttpServlet {
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

        URLConnection connection = url.openConnection();
        HttpURLConnection httpURLConnection = (HttpURLConnection) connection;

        httpURLConnection.setRequestProperty("Accept-Charset", "utf-8");
        httpURLConnection.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");

        InputStream inputStream = null;
        InputStreamReader inputStreamReader = null;
        BufferedReader reader = null;
        StringBuffer resultBuffer = new StringBuffer();
        String tempLine = null;
        // 响应失败
        inputStream = httpURLConnection.getInputStream();
        inputStreamReader = new InputStreamReader(inputStream);
        reader = new BufferedReader(inputStreamReader);

        while ((tempLine = reader.readLine()) != null) {
            resultBuffer.append(tempLine);
        }
        String result=resultBuffer.toString();
        response.getWriter().append(result);
    }

}
