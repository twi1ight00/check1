using System.Collections.Generic;
using System.IO;
using ns108;

namespace ns114;

internal class Class4450
{
	private List<int> list_0 = new List<int>();

	private MemoryStream memoryStream_0;

	private int int_0;

	private byte byte_0;

	public Class4439 ResultIndex
	{
		get
		{
			Class4439 @class = new Class4439();
			memoryStream_0.Close();
			@class.IndexData = memoryStream_0.ToArray();
			@class.ObjectsCount = list_0.Count - 1;
			@class.Offsets = list_0.ToArray();
			@class.OffsetSize = byte_0;
			return @class;
		}
	}

	public Class4450(byte offsetSize)
	{
		memoryStream_0 = new MemoryStream();
		byte_0 = offsetSize;
	}

	public void method_0(byte[] item)
	{
		if (list_0.Count == 0)
		{
			list_0.Add(0);
		}
		memoryStream_0.Write(item, 0, item.Length);
		int_0 += item.Length;
		list_0.Add(int_0);
	}
}
