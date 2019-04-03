using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger
{
    /// <summary>
    /// REGISTERING this class to swagger introduces a REQUIRED AUTHORIZATION HEADER field in SWAGGER UI.
    /// </summary>
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "Authorization",
                In = "header",
                Description = "string",
                Required = true,
                Type = "string"
            });
        }
    }
}
