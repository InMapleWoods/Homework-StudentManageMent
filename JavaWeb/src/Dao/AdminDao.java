package Dao;


import java.sql.SQLException;

public class AdminDao {
    SqlHelper sqlHelper = new SqlHelper();

    public boolean AcceptLog(String number) throws SQLException {
        String str = "Execute AcceptLog ? ;";
        Object[] para = new Object[]{
                number
        };
        int result = sqlHelper.ExecuteNonQuery(str, para);
        if (result > 0) {
            return true;
        } else {
            return false;
        }
    }

    public boolean RejectApply(String number) throws SQLException {
        String str = "Execute RejectionLog ? ;";
        Object[] para = new Object[]{
                number
        };
        int result = sqlHelper.ExecuteNonQuery(str, para);
        if (result > 0) {
            return true;
        } else {
            return false;
        }
    }


}
