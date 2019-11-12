package Bll;

import Dal.UserDal;
import Model.User;

public class UserBll {

    UserDal userDal = new UserDal();

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
