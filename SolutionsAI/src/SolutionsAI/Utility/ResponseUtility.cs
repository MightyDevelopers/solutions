using System;
using System.Net;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.Response;

namespace SolutionsAI.Utility
{
    public class ResponseUtility
    {
        public static GenericResponse<TResult> Respond<TCommandResult, TResult>(
            CommandResult<TCommandResult> commandResult,
            Func<TCommandResult, TResult> getResult)
        {
            var response = new GenericResponse<TResult>
            {
                Success = commandResult.State != CommandResultState.Failure,
                Result = getResult(commandResult.Result)
            };

            if (commandResult.State == CommandResultState.Failure)
            {
                response.ErrorMessage = commandResult.Error.Message;
            }

            return response;
        }

        public static GenericResponse<TResult> Respond<TResult>(CommandResult<TResult> commandResult)
        {
            return Respond(commandResult, result => result);
        }

        public static HttpStatusCode GetStatusCode(CommandResultState commandResultState)
        {
            switch (commandResultState)
            {
                case CommandResultState.Pending:
                    return HttpStatusCode.Accepted;
                case CommandResultState.Success:
                    return HttpStatusCode.OK;
                case CommandResultState.Failure:
                    return HttpStatusCode.InternalServerError;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
