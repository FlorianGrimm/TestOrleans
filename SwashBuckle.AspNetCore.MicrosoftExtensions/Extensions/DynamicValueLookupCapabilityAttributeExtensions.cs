namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions; 

internal static class DynamicValueLookupCapabilityAttributeExtensions
{
    internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerExtensions(this DynamicValueLookupCapabilityAttribute attribute)
    {
        if (attribute is null)
            yield break;

        yield return new KeyValuePair<string, IOpenApiExtension>
        (
            Constants.XMsDynamicValueLookup,
            new DynamicValuesCapabilityModel
            (
                attribute.Capability,
                attribute.ValuePath,
                attribute.ValueTitle,
                ParameterParser.Parse(attribute.Parameters)
            )
        );
    }
}
