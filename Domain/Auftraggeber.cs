using Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Revolut2LexOffice
{
	internal class Auftraggeber : ITarget
	{

		private IRevolutRecord _record;
		private readonly ISettings _settings;

		public Auftraggeber(ISettings settings, IRevolutRecord record)
		{
			_record = record;
			_settings = settings;
		}

		public IEnumerable<IField> Fields()
		{
			string description = _record.Description;

			if (_settings.FromIdentifier.Any(identifer => description.StartsWith(identifer)))
			{
				return new List<IField>{
					new Field(
						description.RemovePrefix(
							_settings.FromIdentifier
						)
					)
				};
			}

			if (String.IsNullOrWhiteSpace(_record.Payer))
			{
				return new List<IField>{
					new Field("Revolut")
				};
			}

			return new List<IField>{
				new Field(_record.Payer)
			};
		}
	}
}