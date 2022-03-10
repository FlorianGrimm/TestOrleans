using Newtonsoft.Json;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities;
internal class DynamicSchemaModel : IOpenApiExtension {
    [JsonProperty("operationId")]
    internal string OperationId { get; }
    [JsonProperty("value-path")]
    internal string ValuePath { get; }
    [JsonProperty("parameters")]
    internal IDictionary<string, IOpenApiExtension> Parameters { get; }

    internal DynamicSchemaModel(string operationId, string valuePath, IDictionary<string, IOpenApiExtension> parameters) {
        OperationId = operationId;
        ValuePath = valuePath;
        Parameters = parameters;
    }

    public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion) {
#warning TODO
        throw new NotImplementedException();
    }
}
