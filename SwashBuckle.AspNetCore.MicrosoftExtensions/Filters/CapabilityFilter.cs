namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Filters;

internal class CapabilityFilter : IDocumentFilter {
    private readonly FilePickerCapabilityModel m_filePickerCapability;

    public CapabilityFilter(FilePickerCapabilityModel capability) {
        m_filePickerCapability = capability;
    }

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context) {
        AddFilePickerCapabilityExtension(swaggerDoc);
    }

    private void AddFilePickerCapabilityExtension(OpenApiDocument swaggerDoc) {
        swaggerDoc.Extensions.Add(
            OpenApiExtensionObject.Create(Constants.XMsCapabilities,
                new KeyValuePair<string, IOpenApiExtension>(Constants.FilePicker, m_filePickerCapability)
                ));
    }
}
