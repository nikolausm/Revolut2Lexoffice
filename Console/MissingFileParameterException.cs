using System;
using System.Runtime.Serialization;

namespace Console
{
	[Serializable]
	internal class MissingFileParameterException : Exception
	{
		public MissingFileParameterException()
		{
		}

		public MissingFileParameterException(string message) : base(message)
		{
		}

		public MissingFileParameterException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected MissingFileParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}