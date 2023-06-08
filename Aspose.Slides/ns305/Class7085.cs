using System.Collections.Generic;

namespace ns305;

internal class Class7085 : Class7075
{
	private Class6976 class6976_0;

	public override Class6976 this[int index]
	{
		get
		{
			if (index >= 0)
			{
				Class6976 @class = class6976_0.FirstChild;
				while (@class != null)
				{
					if (index != 0)
					{
						@class = @class.NextSibling;
						index--;
						continue;
					}
					return @class;
				}
			}
			return null;
		}
	}

	public override int Length
	{
		get
		{
			int num = 0;
			for (Class6976 @class = class6976_0.FirstChild; @class != null; @class = @class.NextSibling)
			{
				num++;
			}
			return num;
		}
	}

	public Class7085(Class6976 owner)
	{
		class6976_0 = owner;
	}

	public override IEnumerator<Class6976> GetEnumerator()
	{
		return new Class7100(class6976_0);
	}
}
