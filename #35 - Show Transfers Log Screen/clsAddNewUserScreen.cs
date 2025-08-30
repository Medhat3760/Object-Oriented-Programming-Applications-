using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsAddNewUserScreen : clsScreen
    {

        private static int _ReadPermissionsToSet()
        {
            Console.WriteLine("\nEnter Permissions: ");

            if (clsInputValidate.ReadYesOrNo("\nDo you want to give full access? (Y/N)? "))
                return -1;

            int permissions = 0;

            Console.WriteLine("\nDo you want to give access to: ");

            if (clsInputValidate.ReadYesOrNo("\nShow Client List? (Y/N)? "))
                permissions |= (int)clsUser.enPermissions.pShowClientList;

            if (clsInputValidate.ReadYesOrNo("\nAdd New Client? (Y/N)? "))
                permissions |= (int)clsUser.enPermissions.pAddNewClient;

            if (clsInputValidate.ReadYesOrNo("\nDelete Client? (Y/N)? "))
                permissions |= (int)clsUser.enPermissions.pDeleteClient;

            if (clsInputValidate.ReadYesOrNo("\nUpdate Client? (Y/N)? "))
                permissions |= (int)clsUser.enPermissions.pUpdateClients;

            if (clsInputValidate.ReadYesOrNo("\nFind Client? (Y/N)? "))
                permissions |= (int)clsUser.enPermissions.pFindClient;

            if (clsInputValidate.ReadYesOrNo("\nTransactions? (Y/N)? "))
                permissions |= (int)clsUser.enPermissions.pTranactions;

            if (clsInputValidate.ReadYesOrNo("\nManage Users? (Y/N)? "))
                permissions |= (int)clsUser.enPermissions.pManageUsers;

            if (clsInputValidate.ReadYesOrNo("\nLogin Register? (Y/N)? "))
                permissions |= (int)clsUser.enPermissions.pShowLogRegister;

            return permissions;
        }

        private static void _ReadUserInfo(ref clsUser user)
        {

            Console.Write("\nPlease enter First Name? ");
            user.FirstName = clsInputValidate.ReadString();

            Console.Write("\nPlease enter Last Name? ");
            user.LastName = clsInputValidate.ReadString();

            Console.Write("\nPlease enter Email? ");
            user.Email = clsInputValidate.ReadString();

            Console.Write("\nPlease enter Phone? ");
            user.Phone = clsInputValidate.ReadString();

            Console.Write("\nPlease enter Password? ");
            user.Password = clsInputValidate.ReadString();

            user.Permissions = _ReadPermissionsToSet();

        }

        private static void _PrintUser(clsUser user)
        {

            Console.WriteLine("\nUser Card:");
            Console.WriteLine("________________________________");
            Console.WriteLine($"First Name  : {user.FirstName}");
            Console.WriteLine($"Last Name   : {user.LastName}");
            Console.WriteLine($"Full Name   : {user.getFullName}");
            Console.WriteLine($"Email       : {user.Email}");
            Console.WriteLine($"Phone       : {user.Phone}");
            Console.WriteLine($"User Name   : {user.UserName}");
            Console.WriteLine($"Password    : {user.Password}");
            Console.WriteLine($"Permissions : {user.Permissions}");
            Console.WriteLine("________________________________");

        }

        public static void ShowAddNewUserScreen()
        {

            _DrawScreenHeader("\t  Add New User Screen");

            Console.Write("\nPlease enter a UserName? ");
            string userName = clsInputValidate.ReadString();

            while (clsUser.IsUserExist(userName))
            {

                Console.Write("\nUserName is Already Used, Choose another one: ");
                userName = clsInputValidate.ReadString();

            }

            clsUser newUser = clsUser.GetAddNewUserObject(userName);

            _ReadUserInfo(ref newUser);

            clsUser.enSaveResults saveResult;
            saveResult = newUser.Save();

            switch (saveResult)
            {

                case clsUser.enSaveResults.svSucceded:
                    Console.WriteLine("\nUser Added Successfully :-)");
                    _PrintUser(newUser);
                    break;

                case clsUser.enSaveResults.svFailedEmptyObject:
                    Console.WriteLine("\nError: User is not saved because it's Empty");
                    break;

                case clsUser.enSaveResults.svFailedUserExists:
                    Console.WriteLine("\nError: User was not saved because UserName is used!");
                    break;

            }

        }

    }
}
