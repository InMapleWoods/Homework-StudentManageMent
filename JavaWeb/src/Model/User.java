package Model;

public class User {
    public int UserID;
    public String UserName;
    public String PassWord;
    public int Role;
    public String Number;

    public User() {
        UserID = 0;
        UserName = "";
        PassWord = "";
        Role = 0;
        Number = "00000000";
    }

    public User(int userID, String userName, String passWord, int role, String number) {
        UserID = userID;
        UserName = userName;
        PassWord = passWord;
        Role = role;
        Number = number;
    }
}
