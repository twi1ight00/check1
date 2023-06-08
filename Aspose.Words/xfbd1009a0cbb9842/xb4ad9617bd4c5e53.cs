using System.Collections;
using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal class xb4ad9617bd4c5e53 : xe25d778fe9f1252a
{
	private readonly Hashtable xf4534a93f13f6ff3 = new Hashtable();

	internal Hashtable x84aa3570d857bec4 => xf4534a93f13f6ff3;

	protected override void OnFieldExtracted(Field field)
	{
		xf4534a93f13f6ff3[field.Start] = field;
	}
}
