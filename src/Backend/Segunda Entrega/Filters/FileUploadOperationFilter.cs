using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

public class FileUploadOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Verifica se a operação contém um parâmetro do tipo IFormFile
        var fileParams = operation.Parameters
            .Where(p => p.Schema?.Type == "string" && p.Schema?.Format == "binary")
            .ToList();

        foreach (var fileParam in fileParams)
        {
            // Altera o local para FormData
            fileParam.In = ParameterLocation.Query;  // Atualize para "Query" ou "FormData" conforme necessário
            fileParam.Description = "Foto do produto";
            fileParam.Required = false;
        }
    }
}
