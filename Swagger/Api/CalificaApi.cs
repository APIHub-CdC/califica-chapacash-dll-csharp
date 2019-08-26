using System;
using System.Collections.Generic;
using RestSharp;
using Swagger.Client;
using Swagger.Model;
using Newtonsoft.Json;
using System.Configuration;

namespace Swagger.Api
{
    public interface ICalificaApi
    {
        Respuesta Chapacash (Peticion request);
    }

    public class CalificaApi : ICalificaApi
    {
        public CalificaApi(ApiClient apiClient = null)
        {
            if (apiClient == null)
                this.ApiClient = Swagger.Client.Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        public ApiClient ApiClient {get; set;}
           
        public Respuesta Chapacash (Peticion request)
        {
            Respuesta respuesta = null;
            var headerParams = new Dictionary<String, String>();

            string xApiKey = ConfigurationManager.AppSettings["xApiKey"];
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];

            if (xApiKey == null) throw new ApiException(400, "\n\nFalta campo 'x-api-key'.\n\n");
            if (username == null) throw new ApiException(400, "\n\nFalta campo 'username'.\n\n");
            if (password == null) throw new ApiException(400, "\n\nFalta campo 'password'.\n\n");
            if (request == null) throw new ApiException(400, "\n\nCuerpo de la peticion nulo.\n\n");

            var path = "/";
            path = path.Replace("{format}", "json");
                
            String postBody = ApiClient.Serialize(request);

            string xSignature = Signer.GetPayloadSignature(postBody);

            if (xSignature != null) headerParams.Add("x-signature", ApiClient.ParameterToString(xSignature));
            else throw new ApiException(400, "\n\nFalta campo: 'x-signature'.\n\n");
            if (xApiKey != null) headerParams.Add("x-api-key", ApiClient.ParameterToString(xApiKey));
            if (username != null) headerParams.Add("username", ApiClient.ParameterToString(username));
            if (password != null) headerParams.Add("password", ApiClient.ParameterToString(password));

            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, headerParams, postBody);

            if ((((int)response.StatusCode) == 200) && (Signer.GetResponseVerification(response)))
            {
                respuesta = (Respuesta)ApiClient.Deserialize(response.Content, typeof(Respuesta), response.Headers);
            }
            else if ((((int)response.StatusCode) == 200) && (!Signer.GetResponseVerification(response)))
                throw new ApiException((int)response.StatusCode, "\n\nError al verificar la firma.\n\n");
            else if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "\n\nError al llamar al servicio.\n\n");
            
            return respuesta;
        }
    }
}
