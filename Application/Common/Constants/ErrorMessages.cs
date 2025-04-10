using System;

namespace R2ETien.EFCore.Application.Common.Constants;

public static class ErrorMessages
{   
    public const string NotFound = "The requested resource was not found.";
    public const string ValidationFailed = "Validation failed. Please check the input data.";
    public const string Conflict = "The resource already exists or has a conflict.";
    public const string Unauthorized = "You are not authorized to perform this action.";
    public const string Forbidden = "Access to this resource is forbidden.";
    public const string ServerError = "An internal server error occurred.";
}
