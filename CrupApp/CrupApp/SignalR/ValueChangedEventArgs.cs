using System;
using System.Collections.Generic;
using System.Text;

namespace CrupApp.SignalR
{
    public class ValueChangedEventArgs : EventArgs
    {

        public string User { get; private set; }

        public string Message { get; private set; }

        public ValueChangedEventArgs(string user, string message)
        {
            User = user;
            Message = message;
        }
    }
}

