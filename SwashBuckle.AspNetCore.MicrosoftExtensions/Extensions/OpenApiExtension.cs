using Microsoft.OpenApi;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Writers;

using System.Collections.Generic;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions {
    public class OpenApiExtensionString : IOpenApiExtension {
        private readonly string _Value2;
        private readonly string _Value3;

        public OpenApiExtensionString(string value): this(value,value) {
        }
        public OpenApiExtensionString(string value2, string value3) {
            this._Value2 = value2;
            this._Value3 = value3;
        }
        public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion) {
            if (specVersion == OpenApiSpecVersion.OpenApi2_0) {
                writer.WriteValue(this._Value2);
            } else {
                writer.WriteValue(this._Value3);
            }
        }

        public static KeyValuePair<string, IOpenApiExtension> Create(string name, string value) { 
            return new KeyValuePair<string, IOpenApiExtension>(name, new OpenApiExtensionString(value));
        }

        public static KeyValuePair<string, IOpenApiExtension> Create(string name, string value2, string value3) {
            return new KeyValuePair<string, IOpenApiExtension>(name, new OpenApiExtensionString(value2, value3));
        }
    }

    public class OpenApiExtensionBool : IOpenApiExtension {
        private readonly bool _Value2;
        private readonly bool _Value3;

        public OpenApiExtensionBool(bool value) : this(value, value) {
        }
        public OpenApiExtensionBool(bool value2, bool value3) {
            this._Value2 = value2;
            this._Value3 = value3;
        }
        public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion) {
            if (specVersion == OpenApiSpecVersion.OpenApi2_0) {
                writer.WriteValue(this._Value2);
            } else {
                writer.WriteValue(this._Value3);
            }
        }

        public static KeyValuePair<string, IOpenApiExtension> Create(string name, bool value) {
            return new KeyValuePair<string, IOpenApiExtension>(name, new OpenApiExtensionBool(value));
        }

        public static KeyValuePair<string, IOpenApiExtension> Create(string name, bool value2, bool value3) {
            return new KeyValuePair<string, IOpenApiExtension>(name, new OpenApiExtensionBool(value2, value3));
        }
    }

    public class OpenApiExtensionObject : IOpenApiExtension {
        private readonly IEnumerable<KeyValuePair<string, IOpenApiExtension>> _Value2;
        private readonly IEnumerable<KeyValuePair<string, IOpenApiExtension>> _Value3;

        public OpenApiExtensionObject(IEnumerable<KeyValuePair<string, IOpenApiExtension>> value) : this(value, value) {
        }
        public OpenApiExtensionObject(IEnumerable<KeyValuePair<string, IOpenApiExtension>> value2, IEnumerable<KeyValuePair<string, IOpenApiExtension>> value3) {
            this._Value2 = value2;
            this._Value3 = value3;
        }
        public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion) {
            var value = (specVersion == OpenApiSpecVersion.OpenApi2_0) ? this._Value2 : this._Value3;
            writer.WriteStartObject();
            if (value is not null) {
                foreach (var kv in value) {
                    writer.WritePropertyName(kv.Key);
                    if (kv.Value is IOpenApiExtension openApiExtension) {
                        openApiExtension.Write(writer, specVersion);
                    } else { 
                        writer.WriteValue(kv.Value);
                    }
                }
            }
            writer.WriteEndObject();
        }

        public static KeyValuePair<string, IOpenApiExtension> Create(string name, params KeyValuePair<string, IOpenApiExtension>[] value) {
            return new KeyValuePair<string, IOpenApiExtension>(name, new OpenApiExtensionObject(value));
        }

        public static KeyValuePair<string, IOpenApiExtension> Create(string name, IEnumerable<KeyValuePair<string, IOpenApiExtension>> value) {
            return new KeyValuePair<string, IOpenApiExtension>(name, new OpenApiExtensionObject(value));
        }

        public static KeyValuePair<string, IOpenApiExtension> Create(string name, IEnumerable<KeyValuePair<string, IOpenApiExtension>> value2, IEnumerable<KeyValuePair<string, IOpenApiExtension>> value3) {
            return new KeyValuePair<string, IOpenApiExtension>(name, new OpenApiExtensionObject(value2, value3));
        }
    }

    public class OpenApiExtensionList : IOpenApiExtension {
        private readonly IEnumerable<IOpenApiExtension> _Value2;
        private readonly IEnumerable<IOpenApiExtension> _Value3;

        public OpenApiExtensionList(IEnumerable<IOpenApiExtension> value) : this(value, value) {
        }
        public OpenApiExtensionList(IEnumerable<IOpenApiExtension> value2, IEnumerable<IOpenApiExtension> value3) {
            this._Value2 = value2;
            this._Value3 = value3;
        }
        public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion) {
            var value = (specVersion == OpenApiSpecVersion.OpenApi2_0) ? this._Value2 : this._Value3;
            writer.WriteStartArray();
            if (value is not null) {
                foreach (var item in value) {
                    if (item is IOpenApiExtension openApiExtension) {
                        openApiExtension.Write(writer, specVersion);
                    } else {
                        writer.WriteValue(item);
                    }
                }
            }
            writer.WriteEndArray();
        }
        public static KeyValuePair<string, IOpenApiExtension> Create(string name, params IOpenApiExtension[] value) {
            return new KeyValuePair<string, IOpenApiExtension>(name, new OpenApiExtensionList(value));
        }

        public static KeyValuePair<string, IOpenApiExtension> Create(string name, IEnumerable<IOpenApiExtension> value) {
            return new KeyValuePair<string, IOpenApiExtension>(name, new OpenApiExtensionList(value));
        }

        public static KeyValuePair<string, IOpenApiExtension> Create(string name, IEnumerable<IOpenApiExtension> value2, IEnumerable<IOpenApiExtension> value3) {
            return new KeyValuePair<string, IOpenApiExtension>(name, new OpenApiExtensionList(value2, value3));
        }
    }
}
