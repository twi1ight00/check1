using ns233;
using ns55;

namespace ns24;

internal class Class344 : Class278
{
	private byte[] byte_0;

	private Class1305 class1305_0;

	private uint uint_0;

	public byte[] data
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
			switch (Class6148.smethod_0(byte_0))
			{
			default:
				class1305_0 = new Class1313();
				break;
			case Enum788.const_1:
				class1305_0 = new Class1307();
				break;
			case Enum788.const_2:
				class1305_0 = new Class1314();
				break;
			case Enum788.const_3:
				class1305_0 = new Class1310();
				break;
			case Enum788.const_4:
				class1305_0 = new Class1309();
				break;
			case Enum788.const_5:
				class1305_0 = new Class1311();
				break;
			case Enum788.const_6:
				class1305_0 = new Class1306();
				break;
			case Enum788.const_7:
				class1305_0 = new Class1308();
				break;
			case Enum788.const_8:
				class1305_0 = new Class1312();
				break;
			}
			method_0();
		}
	}

	public Class1305 PartType => class1305_0;

	internal uint Version => uint_0;

	private void method_0()
	{
		uint_0++;
	}
}
