namespace Revolut2LexOffice
{
	public interface ISettings
	{
		string BIC { get; }
		string IBAN { get; }
		string Owner { get; }
	}
}