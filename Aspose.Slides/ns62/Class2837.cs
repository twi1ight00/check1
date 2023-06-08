using System.IO;
using ns60;

namespace ns62;

internal class Class2837 : Class2623
{
	public const int int_0 = 61730;

	private int[] int_1;

	private readonly Class2944 class2944_0 = new Class2944();

	public Class2944 Properties => class2944_0;

	public int[] RowHeights
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value != null)
			{
				int_1 = value;
			}
			else
			{
				int_1 = new int[0];
			}
		}
	}

	public bool IsTable
	{
		get
		{
			if (Properties[Enum426.const_45] is Class2929 @class)
			{
				return @class.AfIsTable;
			}
			return false;
		}
	}

	public Class2837()
	{
		base.Header.Type = 61730;
		base.Header.Version = 3;
		RowHeights = null;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2944_0.Clear();
		class2944_0.Read(reader, base.Header.Length, base.Header.Instance);
		if (Properties[Enum426.const_46] is Class2934 @class)
		{
			int nElems = @class.NElems;
			int_1 = new int[nElems];
			for (int i = 0; i < nElems; i++)
			{
				int_1[i] = (int)@class[i];
			}
		}
	}

	private void method_1()
	{
		int num = int_1.Length;
		Class2934 @class = new Class2934(Enum426.const_46, (ushort)num, 4);
		for (int i = 0; i < num; i++)
		{
			@class[i] = (uint)int_1[i];
		}
		Properties[Enum426.const_46] = @class;
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		if (int_1 != null && int_1.Length > 0)
		{
			method_1();
		}
		base.Header.Instance = (short)class2944_0.Count;
		class2944_0.Write(writer);
	}

	public override int vmethod_2()
	{
		if (int_1 != null && int_1.Length > 0)
		{
			method_1();
		}
		return class2944_0.vmethod_0();
	}
}
