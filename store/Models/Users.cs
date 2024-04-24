using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Models
{
    internal class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public int UserPhone { get; set; }
        public string UserAddress {  get; set; }
        public Object UserImage { get; set; }

        public Users(int UserID, string UserName, string UserPassword, string UserType
            , int UserPhone, string UserAddress, Object UserImage)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.UserPassword = UserPassword;
            this.UserType = UserType;
            this.UserPhone = UserPhone;
            this.UserAddress = UserAddress;
            this.UserImage = UserImage;
        }

        public int getUserID() {  return this.UserID; }
        public void setUserId(int UserID)
        {
            this.UserID = UserID;
        }

        public string getUserName() { return this.UserName; }
        public void setUserName(string UserName)
        {
            this.UserName = UserName;
        }

        public string getUserPassword() { return this.UserPassword; }
        public void setUserPassword(string UserPassword)
        {
            this.UserPassword = UserPassword;
        }

        public string getUserType() { return this.UserType; }
        public void setUserType(string UserType)
        {
            this.UserType = UserType;
        }

        public int getUserPhone() { return this.UserPhone; }
        public void setUserPhone(int UserPhone)
        {
            this.UserPhone = UserPhone;
        }

        public string getUserAddress() { return this.UserAddress; }
        public void setUserAddress(string UserAddress)
        {
            this.UserAddress = UserAddress;
        }

        public object getUserImage() { return this.UserImage; }
        public void setUserImage(object UserImage)
        {
            this.UserImage = UserImage;
        }

    }
}
