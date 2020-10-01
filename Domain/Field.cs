namespace Revolut2LexOffice
{

	public class Field : IField
	{
		public Field(string value)
		: this(null, value)
		{ }

		public Field(string label, string value)
		{
			Label = label;
			Value = value;
		}

		public string Label { get; }
		public string Value { get; }
	}

}
