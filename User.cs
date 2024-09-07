using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trashure
{
    class User
    {
        private int _userID;
        private string _userName;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _phoneNumber;

        public Boolean signIn(string userName, string password)
        {
            if(userName == "Rama" && password == "rama1234")
            {
                _userID = 1;
                _firstName = "Rama";
                _lastName = "Nurcahyo";
                return true;
            }
            return false;
        }
        public void changePassword(string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                throw new Exception("The password is not matching!");
            }
            _password = newPassword;
        }
        public void deleteUser()
        {
            _userID = 0;
            _userName = null;
            _password = null;
            _firstName = null;
            _lastName = null;
            _address = null;
            _phoneNumber = null;
        }
    }
}
