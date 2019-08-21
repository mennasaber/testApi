using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZaatAPI.Models
{
    public class User
    {
        private int uID;
        private string uName;
        private string uPassword;
        private string uGender;
        private string uStatue;
        private Boolean uInChat;
        private int cID;
        public User(int uID,string uName,string uPassword,string uGender,string uStatue,Boolean uInChat,int cID)
        {
            this.uID = uID;
            this.uName = uName;
            this.uPassword = uPassword;
            this.uGender = uGender;
            this.uStatue = uStatue;
            this.uInChat = uInChat;
            this.cID = cID;
        }
        public int UID
        {
            get
            {
                return uID;
            }

            set
            {
                uID = value;
            }
        }

        public string UName
        {
            get
            {
                return uName;
            }

            set
            {
                uName = value;
            }
        }
        public string UPassword
        {
            get
            {
                return uPassword;
            }

            set
            {
                uPassword = value;
            }
        }

        public string UGender
        {
            get
            {
                return uGender;
            }

            set
            {
                uGender = value;
            }
        }

        public string UStatue
        {
            get
            {
                return uStatue;
            }

            set
            {
                uStatue = value;
            }
        }

        public Boolean UInChat
        {
            get
            {
                return uInChat;
            }

            set
            {
                uInChat = value;
            }
        }

        public int CID
        {
            get
            {
                return cID;
            }

            set
            {
                cID = value;
            }
        }

       
    }
}