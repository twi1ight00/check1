using System;
using System.Text;
using ns122;
using ns157;

namespace ns123;

internal class Class4539 : Class4521, Interface136
{
	private int int_1;

	private int int_2;

	private byte[] byte_3;

	private Class4551 class4551_0;

	private Class4728 class4728_0;

	public byte[] DecryptedBytes => byte_3;

	public int BytesCount
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int BytesLimit
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public Class4539(Class4700 context, Class4521 parent)
		: base(context, parent)
	{
		base.UseParentEndMarker = true;
		byte_1 = new byte[4][]
		{
			Encoding.ASCII.GetBytes("RD "),
			Encoding.ASCII.GetBytes("-| "),
			Encoding.ASCII.GetBytes("RD"),
			Encoding.ASCII.GetBytes("-|")
		};
		byte_0 = new byte[10][]
		{
			Encoding.ASCII.GetBytes(" ND\r"),
			Encoding.ASCII.GetBytes(" ND\n"),
			Encoding.ASCII.GetBytes(" |-\r"),
			Encoding.ASCII.GetBytes(" |-\n"),
			Encoding.ASCII.GetBytes("ND\r"),
			Encoding.ASCII.GetBytes("ND\n"),
			Encoding.ASCII.GetBytes("|-\r"),
			Encoding.ASCII.GetBytes("|-\n"),
			Encoding.ASCII.GetBytes(" noaccess def"),
			Encoding.ASCII.GetBytes("noaccess def")
		};
	}

	public override void vmethod_1()
	{
		byte_3 = null;
		class4551_0 = null;
		class4728_0 = new Class4728(Class4728.Enum667.const_1);
		base.vmethod_1();
	}

	protected override void vmethod_6(int currentPosition)
	{
		byte value = class4728_0.method_0(byte_2[currentPosition]);
		class4551_0.method_0(value);
		base.vmethod_6(currentPosition);
	}

	protected override void vmethod_4()
	{
		base.vmethod_4();
		class4551_0 = new Class4551(((Interface136)this).BytesLimit);
	}

	protected override void vmethod_5()
	{
		byte_3 = new byte[class4551_0.DataBytesCount - base.Context.LenIV];
		Array.Copy(class4551_0.Buffer, base.Context.LenIV, byte_3, 0, class4551_0.DataBytesCount - base.Context.LenIV);
		base.vmethod_5();
	}
}
