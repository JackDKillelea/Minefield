namespace Minefield_Game
{
    public class Helpers
    {
        private Helpers() { }

        /// <summary>
        /// Double lock singleton pattern for left on board helper
        /// </summary>
        private static readonly Lazy<Helpers> _helpers = new Lazy<Helpers>(() => new Helpers(), true);

        /// <summary>
        /// Left on Board signleton instance
        /// </summary>
        public static Helpers Instance => _helpers.Value;

        public bool HardModeEnabled = false;
        /// <summary>
        /// Sends a message using a selected colour then changes the text colour back to white.
        /// </summary>
        /// <param name="message">The message you want to send</param>
        /// <param name="textColour">The colour you want to send your message in</param>
        public void SendColouredMessage(string message, ConsoleColor textColour)
        {
            Console.ForegroundColor = textColour;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Sends a two part multicoloured message.
        /// </summary>
        /// <param name="message1">The first part of the message</param>
        /// <param name="message2">The second part of the message</param>
        /// <param name="textColour1">The colour of the first part of the message</param>
        /// <param name="textColour2">The colour of the second part of the message</param>
        public void SendMulticolouredMessage(string message1, string message2, ConsoleColor textColour1, ConsoleColor textColour2)
        {
            Console.ForegroundColor = textColour1;
            Console.Write(message1);
            Console.ForegroundColor = textColour2;
            Console.WriteLine(message2);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
