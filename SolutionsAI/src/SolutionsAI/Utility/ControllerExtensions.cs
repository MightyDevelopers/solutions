﻿using System;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNet.Mvc;
using SolutionsAI.DataInterface.Commands.Base;
using SolutionsAI.Response;
using SolutionsAI.Response.DTOs;

namespace SolutionsAI.Utility
{
    public static class ControllerExtensions
    {
        public static GenericResponse<TResult> GetGenericResponse<TResult>(
            this Controller controller,
            Func<CommandResult<TResult>> executeCommand,
            bool checkAuthority,
            string email = null)
        {
            return controller.CheckAuthority(() =>
            {
                try
                {
                    var commandResult = executeCommand();
                    controller.Response.StatusCode = (int) ResponseUtility.GetStatusCode(commandResult.State);
                    return ResponseUtility.Respond(commandResult);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    controller.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    return new GenericResponse<TResult>
                    {
                        Success = false,
                        ErrorMessage = "Internal Server Error"
                    };
                }
            }, checkAuthority, email);
        }

        public static GenericResponse<TResponseResult> GetGenericResponse<TResult, TResponseResult>(
            this Controller controller,
            Func<CommandResult<TResult>> executeCommand,
            bool checkAuthority,
            string email = null)where TResponseResult: BaseDTO<TResult>, new()
        {
            return controller.CheckAuthority(() =>
            {
                try
                {
                    var commandResult = executeCommand();
                    controller.Response.StatusCode = (int)ResponseUtility.GetStatusCode(commandResult.State);
                    return ResponseUtility.Respond(commandResult, result =>
                    {
                        var responseResult = new TResponseResult();
                        responseResult.FillFromEntity(result);
                        return responseResult;
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    controller.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return new GenericResponse<TResponseResult>
                    {
                        Success = false,
                        ErrorMessage = "Internal Server Error"
                    };
                }
            }, checkAuthority, email);
        }

        private static GenericResponse<TResult> CheckAuthority<TResult>(
            this Controller controller,
            Func<GenericResponse<TResult>> getResult,
            bool checkAuthority,
            string email = null)
        {
            if (!checkAuthority || 
                (!string.IsNullOrWhiteSpace(email)
                && controller.User.HasAuthority(email)))
            {
                return getResult();
            }
            controller.Response.StatusCode = (int) HttpStatusCode.Forbidden;
            return new GenericResponse<TResult>
            {
                Success = false,
                ErrorMessage = "You are not authorized to perform this operation"
            };
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

        public static BaseResponse GetBasicFailureResponse(this Controller controller, HttpStatusCode statusCode, string error)
        {
            controller.Response.StatusCode = (int)statusCode;
            return new BaseResponse
            {
                Success = false,
                ErrorMessage = error
            };
        }

        public static GenericResponse<TResult> GetGenericResponse<TResult>(
            this Controller controller,
            Func<int, CommandResult<TResult>> executeCommand,
            bool checkAuthority,
            string email = null)
        {
            return controller.GetGenericResponse(
                () => executeCommand(controller.User.GetUserId()), 
                checkAuthority,
                email);
        }

        public static GenericResponse<TResponseResult> GetGenericResponse<TResult, TResponseResult>(
            this Controller controller,
            Func<int, CommandResult<TResult>> executeCommand,
            bool checkAuthority,
            string email = null) where TResponseResult : BaseDTO<TResult>, new()
        {
            return controller.GetGenericResponse<TResult, TResponseResult>(
                () => executeCommand(controller.User.GetUserId()),
                checkAuthority,
                email);
        }

        public static GenericResponse<TResponseResult> GetGenericResponse<TResult, TResponseResult>(
            this Controller controller,
            Func<string, CommandResult<TResult>> executeCommand,
            bool checkAuthority,
            string email = null) where TResponseResult : BaseDTO<TResult>, new()
        {
            return controller.GetGenericResponse<TResult, TResponseResult>(
                () => executeCommand(controller.User.GetUserEmail()),
                checkAuthority,
                email);
        }
    }
}
