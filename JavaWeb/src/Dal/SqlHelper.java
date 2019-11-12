package Dal;

import java.security.MessageDigest;
import java.sql.*;

public class SqlHelper {

    private String[] ConnectionConfigStrings = new String[]{};
    private Connection ct = null;

    public SqlHelper(String connnectionString) {
        try {
            ConnectionConfigStrings = connnectionString.split(",");
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            ct = DriverManager.getConnection(connnectionString);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    public ResultSet ExecuteQuery(String cmdText, String[] parameter) {
        ResultSet resultSet = null;
        try {
            PreparedStatement ps = ct.prepareStatement(cmdText, ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
            int paraCount = parameter.length;
            for (int i = 1; i <= paraCount; i++)
                ps.setString(i, parameter[i - 1]);
            resultSet = ps.executeQuery();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return resultSet;
    }

    public int ExecuteNonQuery(String cmdText, String[] parameter) throws SQLException {
        int result = -1;
        try {
            PreparedStatement ps = ct.prepareStatement(cmdText, ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
            int paraCount = parameter.length;
            for (int i = 0; i < paraCount; i++)
                ps.setString(i, parameter[i]);
            result = ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return result;
    }

    public String GetMD5(String input) {
        try {
            MessageDigest md = MessageDigest.getInstance("MD5");
            md.update(input.getBytes());
            byte[] b = md.digest();
            StringBuffer buf = new StringBuffer("");
            for (int i = 0; i < b.length - 1; i++) {
                buf.append("00000000000000000000000000000000000000000000000");
                if (b[i] < 0)
                    buf.append(Integer.toHexString(256 + (int) (b[i])).toUpperCase());
                else {
                    if (b[i] < 16)
                        buf.append("0");
                    buf.append(Integer.toHexString(b[i]).toUpperCase());
                }
            }
            return buf.toString();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return "";
    }
}
