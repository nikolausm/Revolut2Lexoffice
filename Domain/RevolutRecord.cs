using System.Text;

namespace Domain
{
	public sealed class RevolutRecord : IRevolutRecord
	{
		public override string ToString()
		{

			var result = new StringBuilder();
			result.Append($"DateStartedUtc: \"{DateStartedUtc}\"");
			result.Append($", DateCompletedUtc: \"{DateCompletedUtc}\"");
			result.Append($", Type: \"{Type}\"");
			result.Append($", Description: \"{Description}\"");
			result.Append($", Reference: \"{Reference}\"");
			result.Append($", Payer: \"{Payer}\"");
			result.Append($", CardNumber: \"{CardNumber}\"");
			result.Append($", OrigCurrency: \"{OrigCurrency}\"");
			result.Append($", OrigAmount: \"{OrigAmount}\"");
			result.Append($", PaymentCurrency: \"{PaymentCurrency}\"");
			result.Append($", Amount: \"{Amount}\"");
			result.Append($", Fee: \"{Fee}\"");
			result.Append($", Balance: \"{Balance}\"");
			result.Append($", Account: \"{Account}\"");
			result.Append($", BeneficiaryAccountNumber: \"{BeneficiaryAccountNumber}\"");
			result.Append($", BeneficiarySortCodeOrRoutingNumber: \"{BeneficiarySortCodeOrRoutingNumber}\"");
			result.Append($", BeneficiaryIban: \"{BeneficiaryIban}\"");
			result.Append($", BeneficiaryBic: \"{BeneficiaryBic}\"");

			return result.ToString();

		}
		public string DateStartedUtc { get; set; }
		public string DateCompletedUtc { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }
		public string Reference { get; set; }
		public string Payer { get; set; }
		public string CardNumber { get; set; }
		public string OrigCurrency { get; set; }
		public string OrigAmount { get; set; }
		public string PaymentCurrency { get; set; }
		public string Amount { get; set; }
		public string Fee { get; set; }
		public string Balance { get; set; }
		public string Account { get; set; }
		public string BeneficiaryAccountNumber { get; set; }
		public string BeneficiarySortCodeOrRoutingNumber { get; set; }
		public string BeneficiaryIban { get; set; }
		public string BeneficiaryBic { get; set; }
	}
}