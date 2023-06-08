using System.Collections.Generic;
using ns60;

namespace ns63;

internal class Class2713 : Class2639
{
	public const int int_0 = 1040;

	public List<Class2712> RgNamedShow
	{
		get
		{
			List<Class2712> list = new List<Class2712>();
			foreach (Class2623 record in base.Records)
			{
				if (record is Class2712 item)
				{
					list.Add(item);
				}
			}
			return list;
		}
		set
		{
			int num = 0;
			while (num < base.Records.Count)
			{
				if (base.Records[num].Type == 1041)
				{
					base.Records.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
			base.Records.AddRange(value.ToArray());
		}
	}

	public Class2713()
	{
		base.Header.Type = 1040;
	}
}
