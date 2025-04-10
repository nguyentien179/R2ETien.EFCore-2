using System;

namespace R2ETien.EFCore.Presentation;

public static class EndpointRegistration
{
    public static void MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        var apiGroup = app.MapGroup("/api").WithOpenApi();

        apiGroup.MapDepartmentEndpoints();
        apiGroup.MapEmployeeEndpoints();
        apiGroup.MapSalaryEndpoints();
        apiGroup.MapProjectEndpoints();
        apiGroup.MapProjectEmployeeEndpoints();
    }
}
