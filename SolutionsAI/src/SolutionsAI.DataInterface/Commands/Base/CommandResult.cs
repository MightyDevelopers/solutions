using SolutionsAI.DataInterface.Commands.Errors;

namespace SolutionsAI.DataInterface.Commands.Base
{
    public class CommandResult<T>
    {
        public CommandResultState State { get; set; }

        public T Result { get; set; }

        public CommandError Error { get; set; }
    }
}
