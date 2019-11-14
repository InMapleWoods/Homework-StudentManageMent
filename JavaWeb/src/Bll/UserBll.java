package Bll;

import Dal.UserDal;
import Model.User;

public class UserBll {

    UserDal userDal = new UserDal();

    public User GetAccountisExist(String account) throws Exception {
        account = account == null ? "" : account;
        User result;
        try {
            result = userDal.GetAccountisExist(account);
        } catch (Exception e) {
            throw e;
        }
        return result;
    }
    public boolean Login(String account, String password, User user) throws Exception {
        account = account == null ? "" : account;
        password = password == null ? "" : password;
        boolean result;
        try {
            result = userDal.Login(account, password, user);
        } catch (Exception e) {
            throw e;
        }
        return result;
    }
}
