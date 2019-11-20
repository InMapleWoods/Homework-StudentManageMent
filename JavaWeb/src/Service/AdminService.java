package Service;


import Dao.AdminDao;

public class AdminService {
    private AdminDao adminDao = new AdminDao();


    public boolean AcceptLog(String number) throws Exception {
        number = number == null ? "" : number;
        boolean result = adminDao.AcceptLog(number);
        return result;
    }

    public boolean RejectApply(String number) throws Exception {
        number = number == null ? "" : number;
        boolean result = adminDao.RejectApply(number);
        return result;
    }

}
