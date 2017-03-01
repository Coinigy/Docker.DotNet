using System;
using Newtonsoft.Json;

namespace Docker.DotNet
{
    internal class RestartPolicyKindConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            var enumMemberValue = (Models.RestartPolicyKind)value;
            switch (enumMemberValue)
            {
                case Models.RestartPolicyKind.Undefined:
                    writer.WriteValue("");
                    break;
                case Models.RestartPolicyKind.No:
                    writer.WriteValue("no");
                    break;
                case Models.RestartPolicyKind.Always:
                    writer.WriteValue("always");
                    break;
                case Models.RestartPolicyKind.OnFailure:
                    writer.WriteValue("on-failure");
                    break;
                case Models.RestartPolicyKind.UnlessStopped:
                    writer.WriteValue("unless-stopped");
                    break;
            }
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            var enumString = reader.Value.ToString();
            var enumMemberValue = Models.RestartPolicyKind.Undefined;

            switch (enumString)
            {
                case "":
                    enumMemberValue = Models.RestartPolicyKind.Undefined;
                    break;
                case "no":
                    enumMemberValue = Models.RestartPolicyKind.No;
                    break;
                case "always":
                    enumMemberValue = Models.RestartPolicyKind.Always;
                    break;
                case "on-failure":
                    enumMemberValue = Models.RestartPolicyKind.OnFailure;
                    break;
                case "unless-stopped":
                    enumMemberValue = Models.RestartPolicyKind.UnlessStopped;
                    break;
            }

            return enumMemberValue;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (Version);
        }
    }
}