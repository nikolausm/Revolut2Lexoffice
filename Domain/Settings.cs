using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Revolut2LexOffice
{
	[Serializable]
	public class Settings : ISettings
	{
		[JsonConstructor]
		public Settings(string owner, string iBAN, string bIC, IReadOnlyList<string>? receiverPrefixes = null, IReadOnlyList<string>? fromPrefixes = null)
		{
			Owner = owner ?? throw new System.ArgumentNullException(nameof(owner));
			IBAN = iBAN ?? throw new System.ArgumentNullException(nameof(iBAN));
			BIC = bIC ?? throw new System.ArgumentNullException(nameof(bIC));
			ReceiverPrefixes = receiverPrefixes ?? new List<string>
			{
				"Überweisung an ",
				"An ",
				"Kartenzahlung an "
			};
			FromIdentifier = fromPrefixes ?? new List<string> { "From ", "Refund from ", "Payment from ", "Zahlung von ", "Gutschrift von " };
		}

		public string IBAN { get; }
		public string BIC { get; }
		public string Owner { get; }
		/// <summary>
		/// The prefixed that will be removed.
		/// </summary>
		public IReadOnlyList<string> ReceiverPrefixes { get; }
		public IReadOnlyList<string> FromIdentifier { get; }

	}
}
