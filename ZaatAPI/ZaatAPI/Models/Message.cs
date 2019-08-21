using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZaatAPI.Models
{
    public class Message
    {
        private int mID;
        private string mContent;
        private string mDate;
        private string uID;

        public Message(int mID,string mContent, string mDate, string uID)
        {
            this.mID = mID;
            this.mContent = mContent;
            this.mDate = mDate;
            this.uID = uID;
        }

        public int MID
        {
            get
            {
                return mID;
            }

            set
            {
                mID = value;
            }
        }
        public string MContent
        {
            get
            {
                return mContent;
            }

            set
            {
                mContent = value;
            }
        }
        public string MDate
        {
            get
            {
                return mDate;
            }

            set
            {
                mDate = value;
            }
        }
        public string UID
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

    }
}