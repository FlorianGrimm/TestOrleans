namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Helpers;

internal class ParameterParser {
    internal static IDictionary<string, IOpenApiExtension> Parse(string? s) {
        var parameters = QueryHelpers.ParseQuery(s ?? string.Empty);
        return parameters.Select(ParseParameter).ToDictionary(x => x.Key, x => x.Value);
    }

    private static KeyValuePair<string, IOpenApiExtension> ParseParameter(KeyValuePair<string, StringValues> parameter) {
        var matches = Regex.Match(parameter.Value, @"^{(.+)}$");
        if (matches.Success) {
            return OpenApiExtensionObject.Create(parameter.Key,
                OpenApiExtensionString.Create(Constants.Parameter, matches.Groups[1].Value));
        }

        // parse true/false values as bools
        switch (parameter.Value[0]) {
            case "true":
                return OpenApiExtensionBool.Create(parameter.Key, true);
            case "false":
                return OpenApiExtensionBool.Create(parameter.Key, false);
            default:
                return OpenApiExtensionString.Create(parameter.Key, parameter.Value[0]);
        }
    }
}
