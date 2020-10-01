using System.Collections.Generic;

namespace Revolut2LexOffice
{
	internal class Verwendungszweck : ITarget
	{
		private IRevolutRecord record;

		public Verwendungszweck(IRevolutRecord record)
		{
			this.record = record;
		}

		public IEnumerable<IField> Fields()
		{
			return new List<Field>
			{
				new Field("Reference", record.Reference),
				new Field("Type", record.Type),
			};
		}
	}
}