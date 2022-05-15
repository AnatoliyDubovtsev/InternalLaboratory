using System;
using System.Threading;

namespace Module9.Task3
{
    public class Countdown
    {
        public delegate void MessageHandler(string message);
        private event MessageHandler SendMessage;

        /// <summary>
        /// Sending message to subscribers
        /// </summary>
        /// <param name="waitingTime">Number of seconds to wait</param>
        /// <param name="message">Message for subscribers</param>
        public void SendMessages(int waitingTime, string message)
        {
            Console.WriteLine("Message is preparing...");
            Thread.Sleep(TimeSpan.FromSeconds(waitingTime));
            SendMessage?.Invoke(message);
        }

        public void Subscribe(MessageHandler method)
        {
            SendMessage += method;
        }

        public void Unsubscribe(MessageHandler method)
        {
            SendMessage -= method;
        }
    }
}
