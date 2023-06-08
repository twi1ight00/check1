namespace ns56;

internal class Class2473
{
	public static Class2162 smethod_0(Class2139 colorsDefElementData, string nameLabel)
	{
		if (nameLabel == "")
		{
			nameLabel = "node1";
		}
		Class2162[] styleLblList = colorsDefElementData.StyleLblList;
		Class2162[] array = styleLblList;
		int num = 0;
		Class2162 @class;
		while (true)
		{
			if (num < array.Length)
			{
				@class = array[num];
				if (@class.Name == nameLabel)
				{
					break;
				}
				num++;
				continue;
			}
			return styleLblList[0];
		}
		return @class;
	}
}
