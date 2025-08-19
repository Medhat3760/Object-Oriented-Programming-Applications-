using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;
using static Bank_System.clsUser;

namespace Bank_System
{
    public class clsUser : clsPerson
    {

        public enum enMode { EmptyMode = 1, UpdateMode = 2, AddNewMode = 3 }

        private enMode _mode;
        private string _userName;
        private string _password;
        private int _permissions;

        private bool _markedForDelete = false;

        private static clsUser _ConvertLineToUserObject(string line, string separator = "#//#")
        {

            List<string> lUserData = clsString.Split(line, separator);

            return new clsUser(enMode.UpdateMode, lUserData[0], lUserData[1], lUserData[2], lUserData[3], lUserData[4], lUserData[5], int.Parse(lUserData[6]));

        }

        private static clsUser _GetEmptyUserObject()
        {
            return new clsUser(enMode.EmptyMode, "", "", "", "", "", "", 0);
        }

        private static List<clsUser> _LoadUsersFromFile()
        {

            List<clsUser> lUsers = new List<clsUser>();

            if (File.Exists("Users.txt"))
            {

                using (StreamReader myFile = new StreamReader("Users.txt"))
                {

                    string line;

                    while ((line = myFile.ReadLine()) != null)
                    {

                        clsUser user = _ConvertLineToUserObject(line);

                        lUsers.Add(user);

                    }

                }

            }

            return lUsers;

        }

        private static string _ConvertUserObjectToLine(clsUser user, string separator = "#//#")
        {

            string userRecord = user.FirstName + separator
                              + user.LastName + separator
                              + user.Email + separator
                              + user.Phone + separator
                              + user.UserName + separator
                              + user.Password + separator
                              + user.Permissions.ToString();

            return userRecord;

        }

        private static void _SaveUsersDataToFile(List<clsUser> lUsers)
        {

            if (File.Exists("Users.txt"))
            {


                using (StreamWriter myFile = new StreamWriter("Users.txt"))
                {

                    string dataLine;

                    foreach (clsUser u in lUsers)
                    {

                        if (!u.IsMarkedForDelete())
                        {

                            dataLine = _ConvertUserObjectToLine(u);

                            myFile.WriteLine(dataLine);

                        }

                    }

                }

            }

        }

        private void _Update()
        {

            List<clsUser> lUsers = _LoadUsersFromFile();

            for (int i = 0; i < lUsers.Count; i++)
            {

                if (lUsers[i].UserName == UserName)
                {

                    lUsers[i] = this;
                    break;

                }

            }

            _SaveUsersDataToFile(lUsers);

        }

        private void _AddDataLineToFile(string line)
        {

            if (File.Exists("Users.txt"))
            {

                using (StreamWriter myFile = new StreamWriter("Users.txt", append: true))
                {

                    myFile.WriteLine(line);

                }

            }

        }

        private void _AddNew()
        {

            _AddDataLineToFile(_ConvertUserObjectToLine(this));

        }

        private void _Clear()
        {

            FirstName = LastName = Email = Phone = UserName = Password = "";

            _mode = enMode.EmptyMode;
            _permissions = 0;
            _markedForDelete = false;

        }

        public clsUser(enMode mode, string firstName, string lastName, string email, string phone,
             string userName, string password, int permission) : base(firstName, lastName, email, phone)
        {

            _mode = mode;
            _userName = userName;
            _password = password;
            _permissions = permission;

        }

        public bool IsEmpty()
        {
            return _mode == enMode.EmptyMode;
        }

        public string UserName
        {

            get { return _userName; }
            set { _userName = value; }

        }

        public string Password
        {

            get { return _password; }
            set { _password = value; }

        }

        public int Permissions
        {

            get { return _permissions; }
            set { _permissions = value; }

        }

        public bool IsMarkedForDelete()
        {
            return _markedForDelete;
        }

        public static clsUser Find(string userName)
        {

            if (File.Exists("Users.txt"))
            {

                using (StreamReader myFile = new StreamReader("Users.txt"))
                {

                    string line;

                    while ((line = myFile.ReadLine()) != null)
                    {

                        clsUser user = _ConvertLineToUserObject(line);

                        if (user.UserName == userName)
                        {
                            return user;
                        }

                    }

                }

            }

            return _GetEmptyUserObject();

        }

        public static clsUser Find(string userName, string password)
        {

            if (File.Exists("Users.txt"))
            {

                using (StreamReader myFile = new StreamReader("Users.txt"))
                {

                    string line;

                    while ((line = myFile.ReadLine()) != null)
                    {

                        clsUser user = _ConvertLineToUserObject(line);

                        if (user.UserName == userName && user.Password == password)
                        {
                            return user;
                        }

                    }

                }

            }

            return _GetEmptyUserObject();

        }

        public static bool IsUserExist(string userName)
        {

            clsUser user = Find(userName);

            return !user.IsEmpty();

        }

        public enum enSaveResults { svFailedEmptyObject = 0, svSucceded = 1, svFailedUserExists = 2 }

        public enSaveResults Save()
        {

            switch (_mode)
            {

                case enMode.EmptyMode:
                    if (IsEmpty())
                    {
                        return enSaveResults.svFailedEmptyObject;
                    }
                    goto case enMode.UpdateMode;

                case enMode.UpdateMode:
                    _Update();
                    return enSaveResults.svSucceded;

                case enMode.AddNewMode:
                    if (IsUserExist(UserName))
                    {
                        return enSaveResults.svFailedUserExists;
                    }
                    else
                    {

                        _AddNew();

                        _mode = enMode.UpdateMode;

                        return enSaveResults.svSucceded;

                    }

                default:
                    return enSaveResults.svFailedEmptyObject;

            }

        }

        public static List<clsUser> GetUsersList()
        {
            return _LoadUsersFromFile();
        }

        public static clsUser GetAddNewUserObject(string userName)
        {

            return new clsUser(enMode.AddNewMode, "", "", "", "", userName, "", 0);

        }

        public bool Delete()
        {

            List<clsUser> lUsers = GetUsersList();

            for (int i = 0; i < lUsers.Count; i++)
            {

                if (lUsers[i].UserName == UserName)
                {
                    _markedForDelete = true;
                    break;
                }

            }

            _SaveUsersDataToFile(lUsers);

            _Clear();

            return true;

        }


    }
}
