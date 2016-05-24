﻿using System;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.Response;

namespace SolutionsAI.Utility
{
    public class ResponseUtility
    {
        public static GenericResponse<TResult> Respond<TCommandResult, TResult>(CommandResult<TCommandResult> commandResult, Func<TCommandResult, TResult> getResult)
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
    }
}
