package Tools;

import javax.servlet.http.HttpServletResponse;
import java.io.*;
import java.net.HttpURLConnection;
import java.net.URL;
import java.nio.charset.StandardCharsets;

public class TranRequest {

    public void GetRequest(HttpServletResponse response, URL url) throws IOException {
        HttpURLConnection connection = (HttpURLConnection) url.openConnection();

        connection.setRequestProperty("Accept-Charset", "utf-8");
        connection.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");


        InputStream inputStream;
        int statusCode = connection.getResponseCode();
        if (statusCode >= 200 && statusCode < 300) {
            inputStream = connection.getInputStream();
        } else {
            inputStream = connection.getErrorStream();
        }
        // 返回结果-字节输入流转换成字符输入流，控制台输出字符
        if (inputStream != null) {
            BufferedReader br = new BufferedReader(new InputStreamReader(inputStream, StandardCharsets.UTF_8));
            StringBuilder sb = new StringBuilder();
            String line;
            while ((line = br.readLine()) != null) {
                sb.append(line);
            }
            String result = sb.toString();
            response.setCharacterEncoding("unicode");
            if (statusCode < 200 || statusCode >= 300) {
                response.setStatus(404);
            }
            response.getWriter().append(result);
        }
    }

    public void PostRequest(HttpServletResponse response, String data, URL url) throws IOException {
        HttpURLConnection connection = (HttpURLConnection) url.openConnection();
        connection.setRequestMethod("POST");
        // 设置Content-Type
        connection.setRequestProperty("Content-Type", "application/json");
        // 设置是否向httpUrlConnection输出，post请求设置为true，默认是false
        connection.setDoOutput(true);

        // 设置RequestBody
        PrintWriter printWriter = new PrintWriter(connection.getOutputStream());
        printWriter.write(data);
        printWriter.flush();
        InputStream inputStream;
        int statusCode = connection.getResponseCode();
        if (statusCode >= 200 && statusCode < 300) {
            inputStream = connection.getInputStream();
        } else {
            inputStream = connection.getErrorStream();
        }
        // 返回结果-字节输入流转换成字符输入流，控制台输出字符
        if (inputStream != null) {
            BufferedReader br = new BufferedReader(new InputStreamReader(inputStream, StandardCharsets.UTF_8));
            StringBuilder sb = new StringBuilder();
            String line;
            while ((line = br.readLine()) != null) {
                sb.append(line);
            }
            String result = sb.toString();
            response.setCharacterEncoding("unicode");
            if (statusCode < 200 || statusCode >= 300) {
                response.setStatus(404);
            }
            response.getWriter().append(result);
        }
    }

    public void PutRequest(HttpServletResponse response, String data, URL url) throws IOException {
        HttpURLConnection connection = (HttpURLConnection) url.openConnection();
        connection.setRequestMethod("PUT");
        // 设置Content-Type
        connection.setRequestProperty("Content-Type", "application/json");
        // 设置是否向httpUrlConnection输出，post请求设置为true，默认是false
        connection.setDoOutput(true);

        // 设置RequestBody
        PrintWriter printWriter = new PrintWriter(connection.getOutputStream());
        printWriter.write(data);
        printWriter.flush();
        InputStream inputStream;
        int statusCode = connection.getResponseCode();
        if (statusCode >= 200 && statusCode < 300) {
            inputStream = connection.getInputStream();
        } else {
            inputStream = connection.getErrorStream();
        }
        // 返回结果-字节输入流转换成字符输入流，控制台输出字符
        if (inputStream != null) {
            BufferedReader br = new BufferedReader(new InputStreamReader(inputStream, StandardCharsets.UTF_8));
            StringBuilder sb = new StringBuilder();
            String line;
            while ((line = br.readLine()) != null) {
                sb.append(line);
            }
            String result = sb.toString();
            response.setCharacterEncoding("unicode");
            if (statusCode < 200 || statusCode >= 300) {
                response.setStatus(404);
            }
            response.getWriter().append(result);
        }
    }

    public void DeleteRequest(HttpServletResponse response, String data, URL url) throws IOException {
        HttpURLConnection connection = (HttpURLConnection) url.openConnection();
        connection.setRequestMethod("DELETE");
        // 设置Content-Type
        connection.setRequestProperty("Content-Type", "application/json");
        // 设置是否向httpUrlConnection输出，post请求设置为true，默认是false
        connection.setDoOutput(true);

        // 设置RequestBody
        PrintWriter printWriter = new PrintWriter(connection.getOutputStream());
        printWriter.write(data);
        printWriter.flush();
        InputStream inputStream;
        int statusCode = connection.getResponseCode();
        if (statusCode >= 200 && statusCode < 300) {
            inputStream = connection.getInputStream();
        } else {
            inputStream = connection.getErrorStream();
        }
        // 返回结果-字节输入流转换成字符输入流，控制台输出字符
        if (inputStream != null) {
            BufferedReader br = new BufferedReader(new InputStreamReader(inputStream, StandardCharsets.UTF_8));
            StringBuilder sb = new StringBuilder();
            String line;
            while ((line = br.readLine()) != null) {
                sb.append(line);
            }
            String result = sb.toString();
            response.setCharacterEncoding("unicode");
            if (statusCode < 200 || statusCode >= 300) {
                response.setStatus(404);
            }
            response.getWriter().append(result);
        }
    }
}