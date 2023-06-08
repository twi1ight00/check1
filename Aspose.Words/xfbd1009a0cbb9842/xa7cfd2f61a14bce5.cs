using Aspose.Words.Fields;

namespace xfbd1009a0cbb9842;

internal class xa7cfd2f61a14bce5 : xe25d778fe9f1252a
{
	private readonly bool x0d85ab5f75b9fc80;

	private readonly x6435b7bbb0879a04 xf4534a93f13f6ff3 = new x6435b7bbb0879a04();

	internal x6435b7bbb0879a04 x84aa3570d857bec4 => xf4534a93f13f6ff3;

	internal xa7cfd2f61a14bce5()
		: this(isDeep: false)
	{
	}

	internal xa7cfd2f61a14bce5(bool isDeep)
		: this(isDeep, null)
	{
	}

	internal xa7cfd2f61a14bce5(bool isDeep, FieldType[] fieldTypes)
		: base(fieldTypes)
	{
		x0d85ab5f75b9fc80 = isDeep;
	}

	protected override void OnFieldExtracted(Field field)
	{
		if (x0d85ab5f75b9fc80 || !base.xf59e73287256d89e)
		{
			xf4534a93f13f6ff3.Add(field);
		}
	}
}
