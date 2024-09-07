using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trashure
{
    public class Chat
    {
        private int _chatID;
        private int _senderID;
        private int _receiverID;
        private string _message;
        private DateTime _timeSent;

        public Chat(int chatID, int senderID, int receiverID, string message, DateTime time)
        {
            _chatID = chatID;
            _senderID = senderID;
            _receiverID = receiverID;
            _message = message;
            _timeSent = time;
        }

        public void addMessage(string message)
        {
            _message = message;
        }
    }
}