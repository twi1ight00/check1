using ns65;

namespace ns63;

internal class Class2699 : Class2639
{
	public const int int_0 = 1033;

	public Class2873 ExObjListAtom => (Class2873)method_1(1034);

	public Class2699()
	{
		base.Header.Type = 1033;
	}

	public Interface46 method_5(uint id)
	{
		int num = 0;
		Interface46 @interface;
		while (true)
		{
			if (num < base.Records.Count)
			{
				@interface = base.Records[num] as Interface46;
				if (@interface != null && @interface.ExOleObjAtom != null && @interface.ExOleObjAtom.ExObjId == id)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @interface;
	}

	public Class2703 method_6(uint id)
	{
		int num = 0;
		Class2703 @class;
		while (true)
		{
			if (num < base.Records.Count)
			{
				@class = null;
				if (base.Records[num] is Class2697 || base.Records[num] is Class2700 || base.Records[num] is Class2690)
				{
					if (base.Records[num] is Class2697)
					{
						@class = ((Class2697)base.Records[num]).ExVideo;
					}
					else if (base.Records[num] is Class2700)
					{
						@class = ((Class2700)base.Records[num]).ExVideo;
					}
					else if (base.Records[num] is Class2690)
					{
						@class = ((Class2690)base.Records[num]).ExVideo;
					}
					if (@class != null)
					{
						Class2872 exMediaAtom = @class.ExMediaAtom;
						if (exMediaAtom != null && exMediaAtom.ExObjId == id)
						{
							break;
						}
					}
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}

	public Class2639 method_7(uint id)
	{
		int num = 0;
		Class2704 class2;
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num] is Class2705)
				{
					Class2705 @class = (Class2705)base.Records[num];
					Class2872 exMedia = @class.ExMedia;
					if (exMedia != null && exMedia.ExObjId == id)
					{
						return @class;
					}
				}
				else if (base.Records[num] is Class2704)
				{
					class2 = (Class2704)base.Records[num];
					Class2872 exMedia2 = class2.ExMedia;
					if (exMedia2 != null && exMedia2.ExObjId == id)
					{
						break;
					}
				}
				num++;
				continue;
			}
			return null;
		}
		return class2;
	}

	public Class2639 method_8(uint id)
	{
		int num = 0;
		Class2698 @class;
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num] is Class2698)
				{
					@class = (Class2698)base.Records[num];
					Class2872 exMediaAtom = @class.ExMediaAtom;
					if (exMediaAtom != null && exMediaAtom.ExObjId == id)
					{
						break;
					}
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}

	public Class2639 method_9(uint id)
	{
		int num = 0;
		Class2691 @class;
		while (true)
		{
			if (num < base.Records.Count)
			{
				if (base.Records[num] is Class2691)
				{
					@class = (Class2691)base.Records[num];
					Class2872 exMediaAtom = @class.ExMediaAtom;
					if (exMediaAtom != null && exMediaAtom.ExObjId == id)
					{
						break;
					}
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}

	public Class2694 method_10(uint id)
	{
		int num = 0;
		Class2694 @class;
		while (true)
		{
			if (num < base.Records.Count)
			{
				@class = base.Records[num] as Class2694;
				if (@class != null && @class.ExHyperlinkAtom != null && @class.ExHyperlinkAtom.ExHyperlinkId == id)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}
}
