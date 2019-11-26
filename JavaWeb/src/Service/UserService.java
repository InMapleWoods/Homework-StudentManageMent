package Service;

import Dao.*;
import Model.User;

public class UserService {

    private UserDao userDao = new UserDao();

    public User GetAccountisExist(String account) throws Exception {
        account = account == null ? "" : account;
        User result;
        try {
            result = userDao.GetAccountisExist(account);
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
            result = userDao.Login(account, password, user);
        } catch (Exception e) {
            throw e;
        }
        return result;
    }
}
