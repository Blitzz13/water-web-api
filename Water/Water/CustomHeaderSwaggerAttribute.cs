using NSwag;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace Water
{
	public class CustomHeader : IOperationProcessor
	{
		public bool Process(OperationProcessorContext context)
		{
			context.OperationDescription.Operation.Parameters.Add(
		   new OpenApiParameter
		   {
			   Name = "authorization",
			   Kind = OpenApiParameterKind.Header,
			   Type = NJsonSchema.JsonObjectType.String,
			   IsRequired = false,
			   Description = "This is a test header",
			   Default = $"Bearer "
		   });

			return true;
		}
	}
}
