using System.Collections;
using System.IO;
using Aspose.Cells;
using ns16;

namespace ns15;

internal class Class440
{
	private Class746 class746_0;

	private Workbook workbook_0;

	public Class440(Class746 class746_1, Workbook workbook_1)
	{
		class746_0 = class746_1;
		workbook_0 = workbook_1;
	}

	public void Read()
	{
		string value = "Basic/";
		IEnumerator enumerator = class746_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class744 @class = (Class744)enumerator.Current;
			if (@class.Name.StartsWith(value))
			{
				Stream stream_ = class746_0.method_39(@class);
				byte[] array = method_0(stream_);
				if (array.Length > 0)
				{
					workbook_0.method_33().Add(@class.Name, array);
				}
			}
		}
	}

	private byte[] method_0(Stream stream_0)
	{
		byte[] array = new byte[(int)stream_0.Length];
		stream_0.Read(array, 0, array.Length);
		return array;
	}
}
