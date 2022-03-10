using Newtonsoft.Json;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities;

internal class DynamicValuesCapabilityModel : IOpenApiExtension {
    [JsonProperty("capability")]
    internal string Capability { get; }
    [JsonProperty("value-path")]
    internal string ValuePath { get; }
    [JsonProperty("value-title")]
    internal string? ValueTitle { get; }
    [JsonProperty("parameters")]
    internal IDictionary<string, IOpenApiExtension> Parameters { get; }

    internal DynamicValuesCapabilityModel (
        string capability, 
        string valuePath, 
        string? valueTitle, 
        IDictionary<string, IOpenApiExtension> parameters)
    {
        Capability = capability;
        ValuePath = valuePath;
        ValueTitle = valueTitle;
        Parameters = parameters;
    }

    public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion) {
#warning TODO
        throw new NotImplementedException();
    }
}
