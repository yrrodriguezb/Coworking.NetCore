using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Coworking.API.Filters
{
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var filterPipeLine = context.ApiDescription.ActionDescriptor.FilterDescriptors;

            var isAuthorized = filterPipeLine
                .Select(filterInfo => filterInfo.Filter)
                .Any(filter => filter is AuthorizeFilter);
            
            var allowAnomymous = filterPipeLine
                .Select(filterInfo => filterInfo.Filter)
                .Any(filter => filter is IAllowAnonymousFilter);

            if (isAuthorized && !allowAnomymous)
            {
                if (operation.Parameters is null)
                {
                    operation.Parameters = new List<IParameter>();
                }

                operation.Parameters.Add(new NonBodyParameter {
                    Name = "Authorization",
                    In = "header",
                    Description = "JWT Token usar Bearer {token}",
                    Required = true,
                    Type = "string"
                });
            }
        }
    }
}