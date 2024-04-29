using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public int UserPhone { get; set; }
        public string UserAddress {  get; set; }
        public byte[] UserImage { get; set; }

        public User(int UserID, string UserName, string UserPassword, string UserType
            , int UserPhone, string UserAddress, byte[] UserImage)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.UserPassword = UserPassword;
            this.UserType = UserType;
            this.UserPhone = UserPhone;
            this.UserAddress = UserAddress;
            this.UserImage = UserImage;
        }

        public User(string userName, string userPassword, string userType)
        {
            UserName = userName;
            UserPassword = userPassword;
            UserType = userType;
        }
        public User() { }

    }
}
