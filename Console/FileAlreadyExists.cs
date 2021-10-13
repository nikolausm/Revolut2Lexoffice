using System;
using System.Runtime.Serialization;

namespace Console
{
	[Serializable]
	internal class FileAlreadyExists : Exception
	{
		public FileAlreadyExists()
		{
		}

		public FileAlreadyExists(string message) : base(message)
		{
		}

		public FileAlreadyExists(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected FileAlreadyExists(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}