using System;
using System.Threading;

namespace MowChat
{
	public class SessionPinger : IDisposable
	{
		/// <summary>
		/// Instance of the session pinger.
		/// </summary>
		private static SessionPinger _instance;

		/// <summary>
		/// Start the session pinger, if it's not running yet.
		/// </summary>
		public static void StartPinging()
		{
			if (_instance != null) return;

			_instance = new SessionPinger();
		}

		/// <summary>
		/// Stop the session pinger, if it's running.
		/// </summary>
		public static void StopPinging()
		{
			if (_instance == null) return;

			_instance.Dispose();
			_instance = null;
		}

		/// <summary>
		/// The thread that's pinging to keep the session alive.
		/// </summary>
		private readonly Thread _thread;

		/// <summary>
		/// Used for locking to be able to abort the thread safely.
		/// </summary>
		private readonly object _padlock = new object();

		/// <summary>
		/// Whether we should stop pinging.
		/// </summary>
		private bool _continuePinging = true;

		/// <summary>
		/// Constructor.
		/// </summary>
		public SessionPinger()
		{
			_thread = new Thread(TimedPing);
			_thread.Start();
		}

		/// <summary>
		/// Dispose of the thread.
		/// </summary>
		public void Dispose()
		{
			if (_thread == null || !_thread.IsAlive) return;

			_continuePinging = false;
			lock (_padlock)
			{
				Monitor.Pulse(_padlock);
			}
		}

		/// <summary>
		/// Every 10 minutes, until we should stop, ping the API to keep the session alive.
		/// </summary>
		private void TimedPing()
		{
			while (_continuePinging)
			{
				Ping();

				// Wait 10 minutes or until the padlock is cancelled.
				lock (_padlock)
				{
					Monitor.Wait(_padlock, TimeSpan.FromMinutes(1));
				}
			}
		}

		/// <summary>
		/// Ping the API to keep the session alive.
		/// </summary>
		private static void Ping()
		{
			API.Instance.Post<object>(null, "auth/ping");
		}
	}
}
