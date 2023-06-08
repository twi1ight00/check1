using System.Collections;
using System.Collections.Generic;
using System.IO;
using ns276;

namespace ns62;

internal class Class2935 : Class2930
{
	private List<Class6751> list_0;

	public override byte[] Value
	{
		get
		{
			return base.Value;
		}
		protected set
		{
			base.Value = value;
			list_0 = null;
		}
	}

	public List<Class6751> ZipPreview
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<Class6751>();
				MemoryStream zipStream = new MemoryStream(Value);
				Class6752 @class = Class6752.Read(zipStream);
				foreach (Class6751 item in (IEnumerable)@class)
				{
					if (!item.IsDirectory)
					{
						list_0.Add(item);
					}
				}
			}
			return list_0;
		}
	}

	public Class2935(Enum426 id, int size)
		: base(id, size)
	{
	}
}
