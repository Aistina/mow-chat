using System.Net;
using System.Text.RegularExpressions;
using MowChat.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MowChat
{
	public class API
	{
        /// <summary>
        /// The base URL to prepend to all API calls.
        /// </summary>
		private const string BaseUrl = "https://marchofwar.isotx.com/api/v4/";

        /// <summary>
        /// The instance of the API singleton.
        /// </summary>
		private static API _instance;

        /// <summary>
        /// The instance of the API singleton.
        /// </summary>
		public static API Instance
		{
			get { return _instance ?? (_instance = new API()); }
		}

        /// <summary>
        /// The RestSharp client used to send the requests.
        /// </summary>
		private readonly RestClient _restClient;

        /// <summary>
        /// The latest recorded value of the session cookie.
        /// </summary>
		private string _cookieValue;

        /// <summary>
        /// The currently logged in user, if any.
        /// </summary>
		public User CurrentUser { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
	    private API()
		{
			_restClient = new RestClient(BaseUrl);
		}

        /// <summary>
        /// Send a GET API request.
        /// </summary>
        /// <typeparam name="T">The expected response type.</typeparam>
        /// <param name="callback">The function to call when the API call completes.</param>
        /// <param name="endpoint">The API request to send.</param>
        /// <param name="args">A dictionary of arguments to passs.</param>
		public void Get<T>(Action<T> callback, string endpoint, Dictionary<string, string> args = null) where T : new()
		{
			Call(callback, Method.GET, endpoint, args);
		}

        /// <summary>
        /// Send a POST API request.
        /// </summary>
        /// <typeparam name="T">The expected response type.</typeparam>
        /// <param name="callback">The function to call when the API call completes.</param>
        /// <param name="endpoint">The API request to send.</param>
        /// <param name="args">A dictionary of arguments to passs.</param>
		public void Post<T>(Action<T> callback, string endpoint, Dictionary<string, string> args = null) where T : new()
		{
			Call(callback, Method.POST, endpoint, args);
		}

        /// <summary>
        /// Send an API request.
        /// </summary>
        /// <typeparam name="T">The expected response type.</typeparam>
        /// <param name="callback">The function to call when the API call completes.</param>
        /// <param name="method">The HTTP method to use for this request.</param>
        /// <param name="endpoint">The API request to send.</param>
        /// <param name="args">A dictionary of arguments to passs.</param>
		private void Call<T>(Action<T> callback, Method method, string endpoint, Dictionary<string, string> args) where T : new()
		{
			var request = new RestRequest(endpoint, method);
			if (args != null)
			{
				foreach (var kvp in args.Where(kvp => kvp.Key != null && kvp.Value != null))
				{
					request.AddParameter(kvp.Key, kvp.Value);
				}
			}

			if (!string.IsNullOrEmpty(_cookieValue))
			{
				request.AddCookie("mow_session", _cookieValue);
			}

	        Logger.Print(string.Format("Request to API, {0} {1}, {2}", method, endpoint,
	                                   args != null
		                                   ? string.Join(",", args.Select(x => x.Key + "=" + x.Value))
		                                   : "(no params)"));
			_restClient.ExecuteAsync<T>(request, response => OnCallCompleted(response, callback));
		}

        /// <summary>
        /// Handle a response from the API.
        /// </summary>
        /// <typeparam name="T">The expected response type.</typeparam>
        /// <param name="response">The API response.</param>
        /// <param name="callback">The function to call when the API call completes.</param>
		private void OnCallCompleted<T>(IRestResponse<T> response, Action<T> callback)
        {
	        Logger.Print(string.Format("Response from API, {0} {1}, {2} {3}, {4}", response.Request.Method,
	                                   response.Request.Resource, response.ResponseStatus, response.StatusCode,
	                                   response.Content));

			foreach (var cookie in response.Cookies.Where(cookie => cookie.Name == "mow_session"))
			{
				_cookieValue = cookie.Value;
			}
			
			// Don't call callback if unauthorized, connectivity issues, or in maintenance
			if (CheckLogin<T>(response) || CheckConnectiviy(response) || CheckMaintenance(response) || CheckError<T>(response)) return;

			if (response.Request.Resource == "auth/current" || response.Request.Resource == "auth/consume")
			{
				CurrentUser = response.Data as User;
			}
			else if (Regex.IsMatch(response.Request.Resource, "players/[0-9]+/select") && CurrentUser != null)
			{
				CurrentUser.SelectedCharacter = response.Data as Character;
			}

			callback(response.Data);
		}

        /// <summary>
        /// Check that the response status is not unauthorized, unless that's expected.
        /// </summary>
        /// <typeparam name="T">The type of response.</typeparam>
        /// <param name="response">The API response.</param>
        /// <returns>True if the response code is unauthorized.</returns>
		private static bool CheckLogin<T>(IRestResponse response)
		{
			return response.ResponseStatus == ResponseStatus.Completed &&
			       response.StatusCode == HttpStatusCode.Unauthorized &&
				   typeof(T) != typeof(AuthToken);
		}

        /// <summary>
        /// Checks that the response status is completed.
        /// </summary>
        /// <param name="response">The API response.</param>
        /// <returns>True if the response status is not completed.</returns>
		private static bool CheckConnectiviy(IRestResponse response)
		{
			return response.ResponseStatus != ResponseStatus.Completed;
		}

        /// <summary>
        /// Checks that the response does not indicate the server is down for maintenance.
        /// </summary>
        /// <param name="response">The API response.</param>
        /// <returns>True if the server is in maintenance.</returns>
		private static bool CheckMaintenance(IRestResponse response)
		{
			return response.ResponseStatus == ResponseStatus.Completed &&
				   response.StatusCode == HttpStatusCode.ServiceUnavailable;
		}

        /// <summary>
        /// Checks that the response status code is not okay.
        /// </summary>
        /// <typeparam name="T">The type of response.</typeparam>
        /// <param name="response">The API response.</param>
        /// <returns>True if the response status is not okay.</returns>
		private static bool CheckError<T>(IRestResponse response)
		{
			return response.StatusCode != HttpStatusCode.OK &&
				   typeof(T) != typeof(AuthToken);
		}
	}
}
