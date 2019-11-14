package Model;

public class User {
    private int UserID;
    private String UserName;
    private String PassWord;
    private int Role;
    private String Number;

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

    public String toString(){
        return "{\"userID\":"+UserID+",\"number\":\""+Number+"\",\"userName\":\""+UserName+"\",\"password\":\"******\",\"role\":"+Role+"}";
    }

    public int getUserID()
    {
        return UserID;
    }

    public void setUserID(int userID)
    {
        UserID=userID;
    }

    public int getRole()
    {
        return Role;
    }

    public void setRole(int role)
    {
        Role=role;
    }

    public String getUserName()
    {
        return UserName;
    }

    public void setUserName(String userName)
    {
        UserName=userName;
    }

    public String getNumber()
    {
        return Number;
    }

    public void setNumber(String number)
    {
        Number=number;
    }

    public String getPassWord()
    {
        return PassWord;
    }

    public void setPassWord(String passWord)
    {
        PassWord=passWord;
    }
}
