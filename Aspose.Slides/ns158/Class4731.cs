using ns137;

namespace ns158;

internal class Class4731 : Interface140, Interface141
{
	private Class4609[] class4609_0;

	private Class4609[] class4609_1;

	public Class4609[] HGroups => class4609_0;

	public Class4609[] VGroups => class4609_1;

	public Class4731(double[][] hGroups, double[][] vGroups)
	{
		class4609_0 = new Class4609[hGroups.Length];
		class4609_1 = new Class4609[vGroups.Length];
		for (int i = 0; i < hGroups.Length; i++)
		{
			class4609_0[i] = new Class4609();
			int num;
			for (num = 0; num < hGroups[i].Length; num++)
			{
				class4609_0[i].Add(new Class4736(hGroups[i][num], hGroups[i][++num]));
			}
		}
		for (int j = 0; j < vGroups.Length; j++)
		{
			class4609_1[j] = new Class4609();
			int num2;
			for (num2 = 0; num2 < vGroups[j].Length; num2++)
			{
				class4609_1[j].Add(new Class4735(vGroups[j][num2], vGroups[j][++num2]));
			}
		}
	}

	public bool imethod_0(double coordinate)
	{
		Class4609[] array = class4609_0;
		foreach (Class4609 @class in array)
		{
			foreach (Class4736 item in @class)
			{
				if (item.imethod_0(coordinate))
				{
					return true;
				}
			}
		}
		Class4609[] array2 = class4609_1;
		foreach (Class4609 class3 in array2)
		{
			foreach (Class4736 item2 in class3)
			{
				if (item2.imethod_0(coordinate))
				{
					return true;
				}
			}
		}
		return false;
	}

	public double imethod_1(double coordinate)
	{
		Class4609[] array = class4609_0;
		foreach (Class4609 @class in array)
		{
			foreach (Class4736 item in @class)
			{
				if (item.imethod_0(coordinate))
				{
					return item.imethod_1(coordinate);
				}
			}
		}
		Class4609[] array2 = class4609_1;
		foreach (Class4609 class3 in array2)
		{
			foreach (Class4736 item2 in class3)
			{
				if (item2.imethod_0(coordinate))
				{
					return item2.imethod_1(coordinate);
				}
			}
		}
		return coordinate;
	}
}
