using System.Collections.Generic;

namespace Revolut2LexOffice
{
	public interface ISettings
	{
		string BIC { get; }
		string IBAN { get; }
		string Owner { get; }
		IReadOnlyList<string> ReceiverPrefixes { get; }
		IReadOnlyList<string> FromIdentifier { get; }

	}
}