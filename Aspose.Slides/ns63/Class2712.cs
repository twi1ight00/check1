namespace ns63;

internal class Class2712 : Class2639
{
	internal const int int_0 = 1041;

	public string NamedShowName
	{
		get
		{
			return method_5(0);
		}
		set
		{
			Class2843 @class = null;
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2843 && ((Class2843)base.Records[i]).Header.Instance == 0)
				{
					@class = (Class2843)base.Records[i];
					break;
				}
			}
			if (@class != null && (value == null || value.Length == 0))
			{
				base.Records.Remove(@class);
			}
			else if (@class == null)
			{
				base.Records.Insert(0, new Class2843(value, 0));
			}
			else
			{
				@class.String = value;
			}
		}
	}

	public uint[] SlideIdRefs
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < base.Records.Count)
				{
					if (base.Records[num] is Class2883)
					{
						break;
					}
					num++;
					continue;
				}
				return new uint[0];
			}
			return (uint[])((Class2883)base.Records[num]).RgSlideIdRef.Clone();
		}
		set
		{
			Class2883 @class = null;
			for (int i = 0; i < base.Records.Count; i++)
			{
				if (base.Records[i] is Class2883)
				{
					@class = (Class2883)base.Records[i];
					break;
				}
			}
			if (@class == null)
			{
				@class = new Class2883();
				base.Records.Add(@class);
			}
			@class.RgSlideIdRef = (uint[])value.Clone();
		}
	}

	public Class2712()
	{
		base.Header.Type = 1041;
	}

	public string method_5(short instance)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num] is Class2843 && ((Class2843)base.Records[num]).Header.Instance == instance)
				{
					break;
				}
				num++;
				continue;
			}
			return "";
		}
		return ((Class2843)base.Records[num]).String;
	}
}
