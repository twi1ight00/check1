using System.IO;
using ns60;

namespace ns62;

internal class Class2834 : Class2623
{
	internal const int int_0 = 61451;

	private readonly Class2944 class2944_0 = new Class2944();

	public Class2944 Properties => class2944_0;

	public Class2834()
		: base(61451, 3)
	{
	}

	public void method_1(Enum452 queryType, int index)
	{
		class2944_0.Clear();
		switch (queryType)
		{
		case Enum452.const_0:
			if (index == 0)
			{
				class2944_0.Add(new Class2911(Enum426.const_82, isBid: false, 134217732u));
				class2944_0.Add(new Class2911(Enum426.const_84, isBid: false, 134217728u));
				class2944_0.Add(new Class2911(Enum426.const_119, isBid: false, 1048592u));
				class2944_0.Add(new Class2911(Enum426.const_120, isBid: false, 134217729u));
				class2944_0.Add(new Class2911(Enum426.const_154, isBid: false, 524296u));
				class2944_0.Add(new Class2911(Enum426.const_296, isBid: false, 134217730u));
			}
			break;
		case Enum452.const_1:
			switch (index)
			{
			case 0:
				class2944_0.Add(new Class2911(Enum426.const_82, isBid: false, 134217728u));
				class2944_0.Add(new Class2911(Enum426.const_84, isBid: false, 134217733u));
				class2944_0.Add(new Class2911(Enum426.const_100, isBid: false, 9150350u));
				class2944_0.Add(new Class2911(Enum426.const_101, isBid: false, 6864350u));
				class2944_0.Add(new Class2911(Enum426.const_119, isBid: false, 1179666u));
				class2944_0.Add(new Class2911(Enum426.const_154, isBid: false, 524288u));
				class2944_0.Add(new Class2911(Enum426.const_2, isBid: false, 9u));
				class2944_0.Add(new Class2911(Enum426.const_10, isBid: false, 65537u));
				break;
			case 1:
				class2944_0.Add(new Class2911(Enum426.const_404, isBid: false, 327681u));
				class2944_0.Add(new Class2911(Enum426.const_405, isBid: false, 9908912u));
				class2944_0.Add(new Class2911(Enum426.const_412, isBid: false, 1u));
				class2944_0.Add(new Class2911(Enum426.const_82, isBid: false, 134217732u));
				class2944_0.Add(new Class2911(Enum426.const_84, isBid: false, 134217728u));
				class2944_0.Add(new Class2911(Enum426.const_119, isBid: false, 1114113u));
				class2944_0.Add(new Class2911(Enum426.const_120, isBid: false, 134217729u));
				class2944_0.Add(new Class2911(Enum426.const_154, isBid: false, 589825u));
				class2944_0.Add(new Class2911(Enum426.const_296, isBid: false, 134217730u));
				break;
			case 2:
				class2944_0.Add(new Class2911(Enum426.const_404, isBid: false, 327681u));
				class2944_0.Add(new Class2911(Enum426.const_405, isBid: false, 9910136u));
				class2944_0.Add(new Class2911(Enum426.const_82, isBid: false, 134217732u));
				class2944_0.Add(new Class2911(Enum426.const_84, isBid: false, 134217728u));
				class2944_0.Add(new Class2911(Enum426.const_119, isBid: false, 1114113u));
				class2944_0.Add(new Class2911(Enum426.const_120, isBid: false, 134217729u));
				class2944_0.Add(new Class2911(Enum426.const_154, isBid: false, 589825u));
				class2944_0.Add(new Class2911(Enum426.const_296, isBid: false, 134217730u));
				break;
			case 3:
				class2944_0.Add(new Class2911(Enum426.const_404, isBid: false, 327681u));
				class2944_0.Add(new Class2911(Enum426.const_405, isBid: false, 9912028u));
				class2944_0.Add(new Class2911(Enum426.const_82, isBid: false, 134217732u));
				class2944_0.Add(new Class2911(Enum426.const_84, isBid: false, 134217728u));
				class2944_0.Add(new Class2911(Enum426.const_119, isBid: false, 1114113u));
				class2944_0.Add(new Class2911(Enum426.const_120, isBid: false, 134217729u));
				class2944_0.Add(new Class2911(Enum426.const_154, isBid: false, 589825u));
				class2944_0.Add(new Class2911(Enum426.const_296, isBid: false, 134217730u));
				break;
			case 4:
				class2944_0.Add(new Class2911(Enum426.const_404, isBid: false, 327681u));
				class2944_0.Add(new Class2911(Enum426.const_405, isBid: false, 9912668u));
				class2944_0.Add(new Class2911(Enum426.const_82, isBid: false, 134217732u));
				class2944_0.Add(new Class2911(Enum426.const_84, isBid: false, 134217728u));
				class2944_0.Add(new Class2911(Enum426.const_119, isBid: false, 1114113u));
				class2944_0.Add(new Class2911(Enum426.const_120, isBid: false, 134217729u));
				class2944_0.Add(new Class2911(Enum426.const_154, isBid: false, 589825u));
				class2944_0.Add(new Class2911(Enum426.const_296, isBid: false, 134217730u));
				break;
			case 5:
				class2944_0.Add(new Class2911(Enum426.const_404, isBid: false, 327681u));
				class2944_0.Add(new Class2911(Enum426.const_405, isBid: false, 9915580u));
				class2944_0.Add(new Class2911(Enum426.const_82, isBid: false, 134217732u));
				class2944_0.Add(new Class2911(Enum426.const_84, isBid: false, 134217728u));
				class2944_0.Add(new Class2911(Enum426.const_119, isBid: false, 1114113u));
				class2944_0.Add(new Class2911(Enum426.const_120, isBid: false, 134217729u));
				class2944_0.Add(new Class2911(Enum426.const_154, isBid: false, 589825u));
				class2944_0.Add(new Class2911(Enum426.const_296, isBid: false, 134217730u));
				break;
			}
			break;
		case Enum452.const_2:
			switch (index)
			{
			case 0:
				class2944_0.Add(new Class2911(Enum426.const_82, isBid: false, 134217728u));
				class2944_0.Add(new Class2911(Enum426.const_84, isBid: false, 134217733u));
				class2944_0.Add(new Class2911(Enum426.const_100, isBid: false, 9150350u));
				class2944_0.Add(new Class2911(Enum426.const_101, isBid: false, 6864350u));
				class2944_0.Add(new Class2911(Enum426.const_119, isBid: false, 1179666u));
				class2944_0.Add(new Class2911(Enum426.const_154, isBid: false, 524288u));
				class2944_0.Add(new Class2911(Enum426.const_2, isBid: false, 9u));
				class2944_0.Add(new Class2911(Enum426.const_10, isBid: false, 65537u));
				break;
			case 1:
				class2944_0.Add(new Class2911(Enum426.const_404, isBid: false, 262144u));
				class2944_0.Add(new Class2911(Enum426.const_405, isBid: false, 9949428u));
				class2944_0.Add(new Class2911(Enum426.const_119, isBid: false, 65537u));
				class2944_0.Add(new Class2911(Enum426.const_154, isBid: false, 65537u));
				class2944_0.Add(new Class2911(Enum426.const_0, isBid: false, 1026u));
				break;
			case 2:
				class2944_0.Add(new Class2911(Enum426.const_404, isBid: false, 262144u));
				class2944_0.Add(new Class2911(Enum426.const_405, isBid: false, 9950316u));
				class2944_0.Add(new Class2911(Enum426.const_119, isBid: false, 65537u));
				class2944_0.Add(new Class2911(Enum426.const_154, isBid: false, 65537u));
				class2944_0.Add(new Class2911(Enum426.const_0, isBid: false, 1027u));
				break;
			}
			break;
		}
		base.Header.Instance = (short)class2944_0.Count;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2944_0.Clear();
		class2944_0.Read(reader, base.Header.Length, base.Header.Instance);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		base.Header.Instance = (short)class2944_0.Count;
		class2944_0.Write(writer);
	}

	public override int vmethod_2()
	{
		return class2944_0.vmethod_0();
	}
}
