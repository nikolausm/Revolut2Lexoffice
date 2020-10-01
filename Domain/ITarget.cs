using System.Collections.Generic;

namespace Revolut2LexOffice
{
	internal interface ITarget
	{
		IEnumerable<IField> Fields();
	}
}