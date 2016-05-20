using System;
using SolutionsAI.DataInterface.Commands.Base;

namespace SolutionsAI.DataInterface.Commands.Errors
{
    public class CommandError
    {
        public CommandState LastState { get; set; }
        public Exception Exception { get; set; }
        public CommandErrorLogSource LogSource { get; set; }
    }
}
