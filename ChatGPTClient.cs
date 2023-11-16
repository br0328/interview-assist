
using System;
using RestSharp;
using Newtonsoft.Json;

namespace interview_assist { 
    public class ChatGPTClient {
        private readonly RestClient _client;

        public ChatGPTClient() {
            _client = new RestClient("https://api.openai.com/v1/engines/text-davinci-003/completions");
        }

        public string SendMessage(string message) {
            try { 
                var request = new RestRequest("", Method.Post);
        
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer " + G.apiKey);

                var requestBody = new {
                    prompt = message,
                    max_tokens = 2048,
                    n = 1,
                    stop = (string?) null,
                    temperature = 0.5,
                };
                request.AddJsonBody(JsonConvert.SerializeObject(requestBody));

                var response = _client.Execute(request);
                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content ?? string.Empty);

                return jsonResponse?.choices[0]?.text?.ToString()?.Trim() ?? string.Empty;
            } catch (Exception) {
                return "ChatGPT is in Peak Load! Purchase Premium Key!";
            }
        }
    }
}
