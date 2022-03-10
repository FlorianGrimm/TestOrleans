using System.Collections.Generic;

using Microsoft.OpenApi;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Writers;

using Newtonsoft.Json;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities {
    internal class DynamicValuesModel : IOpenApiExtension {
        [JsonProperty("operationId")]
        internal string OperationId { get; }
        [JsonProperty("value-path")]
        internal string ValuePath { get; }
        [JsonProperty("value-title")]
        internal string ValueTitle { get; }
        [JsonProperty("value-collection")]
        internal string? ValueCollection { get; }
        [JsonProperty("parameters")]
        internal IDictionary<string, IOpenApiExtension> Parameters { get; }

        internal DynamicValuesModel(
            string operationId,
            string valuePath,
            string valueTitle,
            string? valueCollection,
            IDictionary<string, IOpenApiExtension> parameters) {
            OperationId = operationId;
            ValuePath = valuePath;
            ValueTitle = valueTitle;
            ValueCollection = valueCollection;
            Parameters = parameters;
        }

        public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion) {
            writer.WriteStartObject();

            if (this.OperationId != null) { writer.WriteProperty("operationId", this.OperationId); }
            if (this.ValuePath != null) { writer.WriteProperty("value-path", this.ValuePath); }
            if (this.ValueTitle != null) { writer.WriteProperty("value-title", this.ValueTitle); }
            if (this.ValueCollection != null) { writer.WriteProperty("value-collection", this.ValueCollection); }
            writer.WritePropertyName("parameters");
            foreach (var kv in this.Parameters) {
                writer.WritePropertyName(kv.Key);
                if (kv.Value is IOpenApiExtension openApiExtension) {
                    openApiExtension.Write(writer, specVersion);
                } else {
                    writer.WriteValue(kv.Value);
                }
            }
            writer.WriteEndObject();
        }
    }
}