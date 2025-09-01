using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Bank_System
{
    public class clsUpdateUserScreen : clsScreen
    {

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

        public static void ShowUpdateUserScreen()
        {

            _DrawScreenHeader("\t   Update User Screen");

            Console.Write("\nPlease enter User Name? ");
            string userName = clsInputValidate.ReadString();

            while (!clsUser.IsUserExist(userName))
            {

                Console.Write("\nUser name is not found, choose another one: ");
                userName = clsInputValidate.ReadString();

            }

            clsUser user1 = clsUser.Find(userName);
            _PrintUser(user1);

            bool confirm = clsInputValidate.ReadYesOrNo("\nAre you sure you want to update this user? (Y/N)? ");

            if (confirm)
            {

                Console.WriteLine("\nUpdate User Info:");
                Console.WriteLine("________________________");

                _ReadUserInfo(ref user1);

                clsUser.enSaveResults saveResult;
                saveResult = user1.Save();

                switch (saveResult)
                {

                    case clsUser.enSaveResults.svSucceded:
                        Console.WriteLine("\nUser Updated Successfully :-)");
                        _PrintUser(user1);
                        break;

                    case clsUser.enSaveResults.svFailedEmptyObject:
                        Console.WriteLine("\nError: User is not saved because it's Empty");
                        break;

                }

            }

        }

    }
}
