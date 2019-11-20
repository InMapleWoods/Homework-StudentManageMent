package Dao;

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

    public SqlHelper() {
        String connnectionString = "jdbc:sqlserver://152.136.73.240:1733;databaseName=db_StudentManage;user=Lsa;password=llfllf";
        try {
            ConnectionConfigStrings = connnectionString.split(",");
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            ct = DriverManager.getConnection(connnectionString);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    public ResultSet ExecuteQuery(String cmdText, Object[] parameter) {
        ResultSet resultSet = null;
        try {
            PreparedStatement ps = ct.prepareStatement(cmdText, ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
            int paraCount = parameter.length;
            for (int i = 1; i <= paraCount; i++) {
                String type = parameter[i - 1].getClass().getName();
                switch (type) {
                    case "java.lang.String":
                        ps.setString(i, (String) parameter[i - 1]);
                        break;
                    case "java.lang.Integer":
                        ps.setInt(i, (int) parameter[i - 1]);
                        break;
                    case "java.lang.Boolean":
                        ps.setBoolean(i, (boolean) parameter[i - 1]);
                        break;
                    case "java.lang.Double":
                        ps.setDouble(i, (double) parameter[i - 1]);
                        break;
                    default:
                        break;
                }
            }
            resultSet = ps.executeQuery();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return resultSet;
    }

    public int ExecuteNonQuery(String cmdText, Object[] parameter) throws SQLException {
        int result = -1;
        try {
            PreparedStatement ps = ct.prepareStatement(cmdText, ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
            int paraCount = parameter.length;
            for (int i = 1; i <= paraCount; i++) {
                String type = parameter[i - 1].getClass().getName();
                switch (type) {
                    case "java.lang.String":
                        ps.setString(i, (String) parameter[i - 1]);
                        break;
                    case "java.lang.Integer":
                        ps.setInt(i, (int) parameter[i - 1]);
                        break;
                    case "java.lang.Boolean":
                        ps.setBoolean(i, (boolean) parameter[i - 1]);
                        break;
                    case "java.lang.Double":
                        ps.setDouble(i, (double) parameter[i - 1]);
                        break;
                    default:
                        break;
                }
            }
            result = ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return result;
    }
   /* public int ExecuteProcedureNoQuery(String cmdText, Object[] parameter) throws SQLException {
        int result = -1;
        try {
            CallableStatement cs = ct.prepareCall(cmdText, ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
            int paraCount = parameter.length;
            for (int i = 1; i <= paraCount; i++) {
                String type = parameter[i-1].getClass().getName();
                switch (type) {
                    case "java.lang.String":
                        cs.setString(i, (String) parameter[i-1]);
                        break;
                    case "java.lang.Integer":
                        cs.setInt(i, (int) parameter[i-1]);
                        break;
                    case "java.lang.Boolean":
                        cs.setBoolean(i, (boolean) parameter[i-1]);
                        break;
                    case "java.lang.Double":
                        cs.setDouble(i, (double) parameter[i - 1]);
                        break;
                    default:break;
                }
            }
            result = cs.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return result;
    }*/

    public String GetMD5(String input) {
        try {
            MessageDigest md = MessageDigest.getInstance("MD5");
            md.update(input.getBytes());
            byte[] b = md.digest();
            StringBuffer buf = new StringBuffer();
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
