namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions;

/// <summary>
/// Swagger generation opetions extensions
/// </summary>
public static class SwashbuckleExtension {
    /// <summary>
    /// Enables microsoft extension generation
    /// </summary>
    /// <param name="filePicker">File picker capability used for microsoft extension generation</param>
    public static void GenerateMicrosoftExtensions(this SwaggerGenOptions options, FilePickerCapabilityModel? filePicker = null) {
#warning TODO
        // options.OperationFilter<OperationFilter>();
        // options.SchemaFilter<SchemaFilter>();

        if (filePicker != null) {
            //options.DocumentFilter<CapabilityFilter>(filePicker);
            //options.DocumentFilterDescriptors.Add(filePicker);
            throw new NotImplementedException("TODO");
        }
    }
}
