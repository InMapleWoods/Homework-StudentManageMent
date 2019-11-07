package Login;

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

public class ApiLogin extends HttpServlet {
    public ApiLogin() {
        super();
        // TODO Auto-generated constructor stub
    }

    /**
     * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
     * response)
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
     * response)
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
        InputStream inputStream;
        int statusCode = connection.getResponseCode();
        if (statusCode != 200 /* or statusCode >= 200 && statusCode < 300 */) {
            inputStream = connection.getErrorStream();
        } else {
            inputStream = connection.getInputStream();
        }
        // 返回结果-字节输入流转换成字符输入流，控制台输出字符
        BufferedReader br = new BufferedReader(new InputStreamReader(inputStream, "utf-8"));
        StringBuilder sb = new StringBuilder();
        String line;
        while ((line = br.readLine()) != null) {
            sb.append(line);
        }
        String result = sb.toString();
        response.setCharacterEncoding("unicode");
        if (statusCode != 200 /* or statusCode >= 200 && statusCode < 300 */) {
            response.sendError(404, result);
        } else {
            response.getWriter().append(result);
        }
    }

}

