namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Filters; 

internal class SchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema model, SchemaFilterContext context)
    {
        if(model is null || context is null)
        {
            return;
        }

        model.Extensions.AddRange(GetClassExtensions(context));

#warning TODO
        //if(context.JsonContract is JsonObjectContract objectContract)
        //{
        //    model.Properties.ExtendProperties(objectContract.Properties);
        //}
    }

    private IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetClassExtensions(SchemaFilterContext context)
    {
        //var attribute = context.SystemType.GetTypeInfo().GetCustomAttribute<DynamicSchemaLookupAttribute>();
        var attribute = context.Type.GetTypeInfo().GetCustomAttribute<DynamicSchemaLookupAttribute>();
        return attribute?.GetSwaggerExtensions() ?? Array.Empty<KeyValuePair<string, IOpenApiExtension>>();
    }
}
