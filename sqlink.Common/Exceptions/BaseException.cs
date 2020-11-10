using System;
using System.Collections.Generic;
using System.Text;

namespace sqlink.Common.Exceptions
{
    public class BaseException : System.Exception
    {
        #region Properties

        public string UserMessage { get; set; }        
        public string LogMessage { get; set; }         


        #endregion

        #region Constructor

        public BaseException(string UserMessage, string LogMessage = null) : base(UserMessage)
        {
            this.UserMessage = UserMessage;
            this.LogMessage = LogMessage == null ? UserMessage : LogMessage;
        }

        public BaseException(System.Exception inner, string UserMessage = null, string LogMessage = null) :
        base(UserMessage, inner)
        {
            this.UserMessage = UserMessage;
            this.LogMessage = LogMessage == null ? UserMessage : LogMessage;
        }

        #endregion

       
    }
}
