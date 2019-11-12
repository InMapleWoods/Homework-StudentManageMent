package Dal;

import Model.User;

import java.sql.ResultSet;
import java.util.regex.*;

public class UserDal {
    SqlHelper sqlHelper = new SqlHelper("jdbc:sqlserver://152.136.73.240:1433;databaseName=db_StudentManage;user=Lsa;password=llfllf");

    public boolean Login(String account, String password, User user) throws Exception {
        try {
            String matchPattern = "(^\\d{8,40}$)";
            Pattern r = Pattern.compile(matchPattern);
            Matcher resultGet = r.matcher(account);
            if (!resultGet.find())
                throw new Exception("账号格式不正确");
        } catch (Exception e) {
            e.printStackTrace();
            throw e;
        }
        //MD5加密密码
        String pwd = sqlHelper.GetMD5(password);
        //编写SQL语句
        String sqlstr = "SELECT * FROM tb_Users where Number=? AND Password=?";
        String[] paras = new String[]{account, pwd};
        //将返回的结果保存在datatable中
        ResultSet dataTable = sqlHelper.ExecuteQuery(sqlstr, paras);
        ResultSet rs;
        dataTable.last(); //移到最后一行
        int rowCount = dataTable.getRow(); //得到当前行号，也就是记录数
        dataTable.beforeFirst(); //如果还要用结果集，就把指针再移到初始化的位置
        if (rowCount == 1)//如果返回一个结果
        {
            while (dataTable.next()) {
                int UserID = dataTable.getInt("Id");
                String UserName = dataTable.getString("Name");
                String PassWord = dataTable.getString("Password");
                int Role = dataTable.getInt("Role");
                String Number = dataTable.getString("Number");
                if (Role == 0)//未审核人员无法访问
                {
                    throw new Exception("注册未审核，请联系管理员");
                }
                user.Number = Number;
                user.Role = Role;
                user.PassWord = PassWord;
                user.UserName = UserName;
                user.UserID = UserID;
            }
            return true;
        } else if (rowCount > 1)//返回结果不止一个
        {
            throw new Exception("未知用户重复错误，请联系管理员");
        } else//返回结果为0个
        {
            throw new Exception("用户名或密码不正确，请重新输入");
        }
    }
}
