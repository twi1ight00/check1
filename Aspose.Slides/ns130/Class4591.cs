using System.Collections;

namespace ns130;

internal class Class4591
{
	public const int int_0 = 12;

	public uint uint_0;

	public ushort ushort_0;

	public ushort ushort_1;

	public ushort ushort_2;

	public ushort ushort_3;

	public Class4592[] class4592_0;

	public Class4591(byte[] data)
	{
		Class4572 @class = new Class4572(data);
		uint_0 = @class.method_1();
		ushort_0 = @class.method_3();
		ushort_1 = @class.method_3();
		ushort_2 = @class.method_3();
		ushort_3 = @class.method_3();
		ArrayList arrayList = new ArrayList(ushort_0);
		for (int i = 0; i < ushort_0; i++)
		{
			Class4592 class2 = new Class4592
			{
				string_0 = Class4593.smethod_1(@class.method_1()),
				uint_0 = @class.method_1(),
				uint_1 = @class.method_1(),
				uint_2 = @class.method_1()
			};
			if (class2.string_0 != Class4593.string_24)
			{
				arrayList.Add(class2);
			}
		}
		ushort_0 = (ushort)arrayList.Count;
		class4592_0 = (Class4592[])arrayList.ToArray(typeof(Class4592));
	}
}
