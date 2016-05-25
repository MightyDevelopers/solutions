using System;
using System.Net;
using Microsoft.AspNet.Mvc;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.Response;

namespace SolutionsAI.Utility
{
    public static class ControllerExtensions
    {
        public static GenericResponse<TResult> GetGenericResponse<TResult>(
            this Controller controller,
            Func<CommandResult<TResult>> executeCommand)
        {
            try
            {
                var commandResult = executeCommand();
                controller.Response.StatusCode = (int)ResponseUtility.GetStatusCode(commandResult.State);
                return ResponseUtility.Respond(commandResult);
            }
            catch (Exception)
            {
                controller.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return new GenericResponse<TResult>
                {
                    Success = false,
                    ErrorMessage = "Internal Server Error"
                };
            }
        }

        public static BaseResponse GetBasicSuccessResponse(
            this Controller controller)
        {
            controller.Response.StatusCode = (int) HttpStatusCode.OK;
            return new BaseResponse
            {
                Success = true
            };
        }

        public static BaseResponse GetBasicFailureResponse(this Controller controller, HttpStatusCode statusCode)
        {
            controller.Response.StatusCode = (int)statusCode;
            return new BaseResponse
            {
                Success = false
            };
        }
    }
}
