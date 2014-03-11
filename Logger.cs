using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MowChat
{
	class Logger
	{
		private static Logger _instance;
		private static string _fileName;
		private static bool _loggingEnabled;
		private static FileStream _stream;

		[Conditional("DEBUG")]
		public static void Print(string msg)
		{
			if (_instance == null) _instance = new Logger();

			_instance.WriteToLog(msg);
		}

		/// <summary>
		/// Constructor. Attaches the file stream.
		/// </summary>
		private Logger()
		{
			_loggingEnabled = false;

			// Determine where to log to.
			var processName = Process.GetCurrentProcess().MainModule.FileName;
			_fileName = Path.ChangeExtension(processName, "log");

			// If it's not writable, can't log.
			_stream = new FileStream(_fileName, FileMode.Create, FileAccess.Write);
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
		~Logger()
		{
			if (_stream == null) return;

			WriteToLog("Ok doei");
			lock (_stream)
			{
				_stream.Close();
			}
		}

		/// <summary>
		/// Print a message to the log file.
		/// </summary>
		/// <param name="msg">The message to write.</param>
		public void WriteToLog(string msg)
		{
			if (!_loggingEnabled) return;

			// Add timestamp.
			msg = "[" + DateTime.UtcNow.ToLongDateString() + "] " + msg + Environment.NewLine;

			// Write the text.
			var info = Encoding.UTF8.GetBytes(msg);
			lock (_stream)
			{
				if (!_stream.CanWrite) return;

				_stream.Write(info, 0, info.Length);
				_stream.Flush(true);
			}
		}
	}
}
