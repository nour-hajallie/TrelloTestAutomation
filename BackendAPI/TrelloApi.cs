using log4net;
using log4net.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TrelloTestAutomation.DataEntities;

namespace TrelloTestAutomation.BackendAPI
{
    public class TrelloApi
    {
        private RestClient client;
        // Create a logger instance for the test class
        ILog log = LogManager.GetLogger(typeof(TrelloApi));

        public TrelloApi()
        {
            client = new RestClient("https://api.trello.com");

            // Load the Log4Net configuration file
            log4net.Util.LogLog.InternalDebugging = true;
            XmlConfigurator.Configure(new FileInfo("../../../Config/log4net.config"));
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            RestResponse<T> response = client.Execute<T>(request);
            log.Info("Execute the request and getting the response deserialized");

            if (response != null) 
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    log.Info("API call successful");
                    T data = default(T);

                    if (typeof(T) == typeof(List<Membership>))
                    {
                        List<Membership> membershipsList = JsonConvert.DeserializeObject<List<Membership>>(response.Content);
                        data = (T)(object)membershipsList;
                    }
                    else if (typeof(T) == typeof(List<Board>))
                    {
                        List<Board> boardsList = JsonConvert.DeserializeObject<List<Board>>(response.Content);
                        data = (T)(object)boardsList;
                    }
                    else
                    {
                        data = JsonConvert.DeserializeObject<T>(response.Content);
                    }

                    return data;
                }
                else
                {
                    log.Info($"API call failed with status code {response.StatusCode}");
                }
            }
            else
            {
                log.Info("API call failed with null response");
            }

            return default(T);
        }

        public InviteMemberResponse InviteMemberViaEmail(String boardId, String apiKey, String token, String emailUser2)
        {

            // Create a cancellation token source
            var cancellationTokenSource = new CancellationTokenSource();

            // Define the request endpoint and method
            var request = new RestRequest("/1/boards/{id}/members", Method.Put);
            log.Info("Running PUT /1/boards/{id}/members trello request to Invite a Member to a Board via their email address.");

            // Replace {id} with the actual board ID
            request.AddUrlSegment("id", boardId);

            // Add your Trello API key and token as query parameters
            request.AddParameter("key", apiKey);
            request.AddParameter("token", token);
            request.AddParameter("email", emailUser2);

            log.Info("Call Execute function with the request defined");
            return Execute<InviteMemberResponse>(request);
        }

        public List<Membership> GetMembershipsOfABoard(String boardId, String apiKey, String token, String filter)
        {

            // Create a cancellation token source
            var cancellationTokenSource = new CancellationTokenSource();

            // Define the request endpoint and method
            var request = new RestRequest("/1/boards/{id}/memberships", Method.Get);
            log.Info("Running Get /1/boards/{id}/memberships trello request to Get Memberships of a Board.");

            // Replace {id} with the actual board ID
            request.AddUrlSegment("id", boardId);

            // Add your Trello API key and token as query parameters
            request.AddParameter("key", apiKey);
            request.AddParameter("token", token);
            request.AddParameter("filter", filter);

            log.Info("Call Execute function with the request defined");
            return Execute<List<Membership>>(request);
        }

        public RestResponse DeleteBoard(String boardId, String apiKey, String token)
        {
            // Create a cancellation token source
            var cancellationTokenSource = new CancellationTokenSource();

            // Define the request endpoint and method
            var request = new RestRequest("/1/boards/{id}", Method.Delete);
            log.Info("Running Get /1/boards/{id} trello request to Delete a Board.");

            // Replace {id} with the actual board ID
            request.AddUrlSegment("id", boardId);

            // Add your Trello API key and token as query parameters
            request.AddParameter("key", apiKey);
            request.AddParameter("token", token);

            RestResponse response = client.Execute(request);

            return response;
        }

        public List<Board> GetBoardsByMember(String username,  String apiKey, String token)
        {
            // Create a cancellation token source
            var cancellationTokenSource = new CancellationTokenSource();

            // Define the request endpoint and method
            var request = new RestRequest("/1/members/{id}/boards", Method.Get);
            log.Info("Running Get /1/boards/{id} trello request to Delete a Board.");

            // Replace {id} with the actual board ID
            request.AddUrlSegment("id", username);

            // Add your Trello API key and token as query parameters
            request.AddParameter("key", apiKey);
            request.AddParameter("token", token);

            return Execute<List<Board>>(request);

        }
    }
}

