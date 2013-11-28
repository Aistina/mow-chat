using System.Net;
using MowChat.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MowChat
{
	class API
	{
		private const string BaseUrl = "https://marchofwar.isotx.com/api/v4/";

		private static API _instance;
		public static API Instance
		{
			get { return _instance ?? (_instance = new API()); }
		}

		private readonly RestClient _restClient;
		private string _cookieValue;

		public User CurrentUser { get; private set; }

		public API()
		{
			_restClient = new RestClient(BaseUrl);
		}

		public void Get<T>(Action<T> callback, string endpoint, Dictionary<string, string> args = null) where T : new()
		{
			Call(callback, Method.GET, endpoint, args);
		}

		public void Post<T>(Action<T> callback, string endpoint, Dictionary<string, string> args = null) where T : new()
		{
			Call(callback, Method.POST, endpoint, args);
		}

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

			_restClient.ExecuteAsync<T>(request, response => OnCallCompleted(response, callback));
		}

		private void OnCallCompleted<T>(IRestResponse<T> response, Action<T> callback)
		{
			foreach (var cookie in response.Cookies.Where(cookie => cookie.Name == "mow_session"))
			{
				_cookieValue = cookie.Value;
			}
            
			// Don't call callback if unauthorized, connectivity issues, or in maintenance
			if (CheckLogin<T>(response) || CheckConnectiviy(response) || CheckMaintenance(response) || CheckError<T>(response)) return;

			if (response.Request.Resource == "auth/current")
			{
				CurrentUser = response.Data as User;
			}

			callback(response.Data);
		}

		private static bool CheckLogin<T>(IRestResponse response)
		{
			return response.ResponseStatus == ResponseStatus.Completed &&
			       response.StatusCode == HttpStatusCode.Unauthorized &&
			       typeof (T) != typeof (AuthToken);
		}

		private static bool CheckConnectiviy(IRestResponse response)
		{
			return response.ResponseStatus != ResponseStatus.Completed;
		}

		private static bool CheckMaintenance(IRestResponse response)
		{
			return response.ResponseStatus == ResponseStatus.Completed &&
			       response.StatusCode == HttpStatusCode.ServiceUnavailable;
		}

        private static bool CheckError<T>(IRestResponse response)
        {
            return response.StatusCode != HttpStatusCode.OK &&
                   typeof(T) != typeof(AuthToken);
        }
	}
}
