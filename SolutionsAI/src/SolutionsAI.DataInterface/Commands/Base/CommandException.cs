using System;

namespace SolutionsAI.DataInterface.Commands.Base
{
    [Serializable]
    public class CommandException: Exception
    {
        public CommandException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
