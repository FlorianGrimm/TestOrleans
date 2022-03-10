using System.Collections.Generic;

using Microsoft.OpenApi.Interfaces;

using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions
{
    internal static class MetadataAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerExtensions(this MetadataAttribute attribute)
        {
            if (attribute is null)
                yield break;
            
            if (attribute.Visibility != VisibilityType.Default)
                yield return OpenApiExtensionString.Create(Constants.XMsVisibility, attribute.Visibility.ToString().ToLowerInvariant());
            if (attribute.Summary != null)
                yield return OpenApiExtensionString.Create(Constants.XMsSummary, attribute.Summary);
            if (attribute.Description != null)
                yield return OpenApiExtensionString.Create(Constants.Description, attribute.Description);
        }

        internal static IEnumerable<KeyValuePair<string, IOpenApiExtension>> GetSwaggerOperationExtensions (this MetadataAttribute attribute)
        {
            if (attribute is null)
                yield break;

            if (attribute.Visibility != VisibilityType.Default)
                yield return OpenApiExtensionString.Create(Constants.XMsVisibility, attribute.Visibility.ToString().ToLowerInvariant());
            if (attribute.Summary != null)
                yield return OpenApiExtensionString.Create(Constants.Summary, attribute.Summary);
            if (attribute.Description != null)
                yield return OpenApiExtensionString.Create(Constants.Description, attribute.Description);
        }
    }
}