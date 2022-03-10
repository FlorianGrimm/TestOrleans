namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions;

internal static class DynamicValueLookupAttributeExtensions
{
    internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerExtensions (this DynamicValueLookupAttribute attribute)
    {
        if(attribute is null)
            yield break;

        yield return new KeyValuePair<string, IOpenApiExtension>
        (
            Constants.XMsDynamicValueLookup,
            new DynamicValuesModel
            (
                attribute.LookupOperation,
                attribute.ValuePath,
                attribute.ValueTitle,
                attribute.ValueCollection,
                ParameterParser.Parse(attribute.Parameters)
            )
        );

    }
}
