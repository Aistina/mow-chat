using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace MowChat
{
	class Logger : IDisposable
	{
		/// <summary>
		/// The logger singleton instance.
		/// </summary>
		private static Logger _instance;

		/// <summary>
		/// Print a message to the log file.
		/// </summary>
		/// <param name="msg">The message to write.</param>
		[Conditional("DEBUG")]
		public static void Print(string msg)
        {
            // Write to VS Output window.
            Debug.WriteLine(msg);

			if (_instance == null) _instance = new Logger();

			ThreadPool.QueueUserWorkItem(delegate
				{
					_instance.WriteToLog(msg);
				}, null);
		}

	    /// <summary>
		/// Whether we should log to the file (set to false when file is not writeable).
		/// </summary>
		private readonly bool _loggingEnabled;

		/// <summary>
		/// The file stream to write to.
		/// </summary>
		private readonly FileStream _stream;

        /// <summary>
        /// For thread safety.
        /// </summary>
	    private readonly object _padlock = new object();

		/// <summary>
		/// Constructor. Attaches the file stream.
		/// </summary>
		private Logger()
		{
		    _loggingEnabled = false;

			// Determine where to log to.
			var processName = Process.GetCurrentProcess().MainModule.FileName;
			var fileName = Path.ChangeExtension(processName, "log");

			// If it's not writable, can't log.
			_stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			if (!_stream.CanWrite)
			{
				_loggingEnabled = false;
				_stream.Close();
				return;
			}

			// Otherwise, start!
			_loggingEnabled = true;
			WriteToLog("Logger Initialised");
		}

        /// <summary>
        /// Close the file stream if it's there.
        /// </summary>
	    public void Dispose()
        {
            if (_stream == null) return;

            lock (_padlock)
            {
                _stream.Close();
            }
	    }

	    /// <summary>
		/// Print a message to the log file.
		/// </summary>
		/// <param name="msg">The message to write.</param>
		private void WriteToLog(string msg)
		{
			if (!_loggingEnabled) return;

			// Add timestamp.
			msg = "[" + DateTime.UtcNow + "] " + msg + Environment.NewLine;

			// Write the text.
			var info = Encoding.UTF8.GetBytes(msg);
            lock (_padlock)
			{
				if (!_stream.CanWrite) return;

				_stream.Write(info, 0, info.Length);
				_stream.Flush(true);
			}
		}
	}
}
