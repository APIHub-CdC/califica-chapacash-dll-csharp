using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Extensions;


namespace Swagger.Client
{
    public class ApiClient
    {
        private readonly Dictionary<String, String> _defaultHeaderMap = new Dictionary<String, String>();

        public ApiClient(String basePath)
        {
            BasePath = basePath;
            RestClient = new RestClient(BasePath);
        }

        public string BasePath { get; set; }

        public RestClient RestClient { get; set; }

        public Dictionary<String, String> DefaultHeader
        {
            get { return _defaultHeaderMap; }
        }

        public Object CallApi(String path, RestSharp.Method method, Dictionary<String, String> headerParams, String postBody)
        {
            var request = new RestRequest(path, method);

            foreach (var param in headerParams)
                request.AddHeader(param.Key, param.Value);

            if (postBody != null)
                request.AddParameter("application/json", postBody, ParameterType.RequestBody);

            return (Object)RestClient.Execute(request);
        }

        public string EscapeString(string str)
        {
            return RestSharp.Contrib.HttpUtility.UrlEncode(str);
        }

        public FileParameter ParameterToFile(string name, Stream stream)
        {
            if (stream is FileStream)
                return FileParameter.Create(name, stream.ReadAsBytes(), Path.GetFileName(((FileStream)stream).Name));
            else
                return FileParameter.Create(name, stream.ReadAsBytes(), "no_file_name_provided");
        }

        public string ParameterToString(object obj)
        {
            if (obj is DateTime)
                return ((DateTime)obj).ToString (Configuration.DateTimeFormat);
            else if (obj is List<string>)
                return String.Join(",", (obj as List<string>).ToArray());
            else
                return Convert.ToString (obj);
        }

        public object Deserialize(string content, Type type, IList<Parameter> headers=null)
        {
            if (type == typeof(Object))
            {
                return content;
            }

            if (type == typeof(Stream))
            {
                var filePath = String.IsNullOrEmpty(Configuration.TempFolderPath)
                    ? Path.GetTempPath()
                    : Configuration.TempFolderPath;

                var fileName = filePath + Guid.NewGuid();
                if (headers != null)
                {
                    var regex = new Regex(@"Content-Disposition:.*filename=['""]?([^'""\s]+)['""]?$");
                    var match = regex.Match(headers.ToString());
                    if (match.Success)
                        fileName = filePath + match.Value.Replace("\"", "").Replace("'", "");
                }
                File.WriteAllText(fileName, content);
                return new FileStream(fileName, FileMode.Open);
            }
            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime"))
            {
                return DateTime.Parse(content,  null, System.Globalization.DateTimeStyles.RoundtripKind);
            }
            if (type == typeof(String) || type.Name.StartsWith("System.Nullable"))
            {
                return ConvertType(content, type); 
            }

            try
            {
                return JsonConvert.DeserializeObject(content, type);
            }
            catch (IOException e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        public string Serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj) : null;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        public string GetApiKeyWithPrefix (string apiKeyIdentifier)
        {
            var apiKeyValue = "";
            Configuration.ApiKey.TryGetValue (apiKeyIdentifier, out apiKeyValue);
            var apiKeyPrefix = "";
            if (Configuration.ApiKeyPrefix.TryGetValue (apiKeyIdentifier, out apiKeyPrefix))
                return apiKeyPrefix + " " + apiKeyValue;
            else
                return apiKeyValue;
        }

        public void UpdateParamsForAuth(Dictionary<String, String> queryParams, Dictionary<String, String> headerParams, string[] authSettings)
        {
            if (authSettings == null || authSettings.Length == 0)
                return;

            foreach (string auth in authSettings)
            {
                switch(auth)
                {
                    default:
                        break;
                }
            }
        }

        public static string Base64Encode(string text)
        {
            var textByte = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(textByte);
        }

        public static Object ConvertType(Object fromObject, Type toObject) {
            return Convert.ChangeType(fromObject, toObject);
        }
    }
}
