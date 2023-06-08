namespace ns56;

internal class Class2474
{
	public static Class2163 smethod_0(Class2163[] cnxList, string srcId, int srcOrd, int destOrd, Enum330 type)
	{
		int num = 0;
		Class2163 @class;
		while (true)
		{
			if (num < cnxList.Length)
			{
				@class = cnxList[num];
				if (!(srcId != @class.SrcId) && @class.Type == type && (srcOrd == -1 || srcOrd == @class.SrcOrd) && (destOrd == -1 || destOrd == @class.DestOrd))
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
