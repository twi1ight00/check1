using System;
using System.Collections.Generic;
using System.IO;

namespace ns63;

internal class Class2856 : Class2845
{
	public const int int_0 = 4001;

	private Class2984[] class2984_0 = new Class2984[1]
	{
		new Class2984()
	};

	private Class2983[] class2983_0 = new Class2983[1]
	{
		new Class2983()
	};

	public Class2984[] RgTextPFRun
	{
		get
		{
			return class2984_0;
		}
		set
		{
			class2984_0 = value;
		}
	}

	public Class2983[] RgTextCFRun
	{
		get
		{
			return class2983_0;
		}
		set
		{
			class2983_0 = value;
		}
	}

	public bool IsEmpty
	{
		get
		{
			if (class2984_0 != null && class2983_0 != null)
			{
				if (class2984_0.Length >= 1 && class2983_0.Length >= 1)
				{
					int num = 0;
					while (true)
					{
						if (num < class2984_0.Length)
						{
							if (!class2984_0[num].ParagraphFormat.IsEmpty || class2984_0[num].IndentLevel != 0)
							{
								break;
							}
							num++;
							continue;
						}
						int num2 = 0;
						while (true)
						{
							if (num2 < class2983_0.Length)
							{
								if (!class2983_0[num2].CharFormat.IsEmpty)
								{
									break;
								}
								num2++;
								continue;
							}
							return true;
						}
						return false;
					}
					return false;
				}
				return true;
			}
			return true;
		}
	}

	public Class2856(Class2951 stf)
		: base(stf)
	{
		base.Header.Type = 4001;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		_ = base.Header.Length;
		long position = reader.BaseStream.Position;
		int num = base.ParentFrame.ChildTextLength + 1;
		List<Class2984> list = new List<Class2984>();
		int num2 = num;
		while (num2 > 0)
		{
			Class2984 @class = new Class2984();
			@class.method_0(reader);
			num2 -= (int)@class.Count;
			list.Add(@class);
		}
		if (num2 != 0)
		{
			throw new Exception("Chars count mismatch [" + num2 + "] in StyleTextProAtom.TextPFRuns!!! Text \"" + base.ParentFrame.ChildText.Replace("\r", "\\r") + "\"");
		}
		class2984_0 = list.ToArray();
		List<Class2983> list2 = new List<Class2983>();
		num2 = num;
		while (num2 > 0)
		{
			Class2983 class2 = new Class2983();
			class2.method_0(reader);
			num2 -= (int)class2.Count;
			list2.Add(class2);
			if (reader.BaseStream.Position - position == base.Header.Length && num2 == 1)
			{
				num2 = 0;
			}
		}
		if (num2 != 0)
		{
			throw new Exception("Chars count mismatch [" + num2 + "] in StyleTextProAtom.TextCFRuns!!!");
		}
		class2983_0 = list2.ToArray();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		for (int i = 0; i < class2984_0.Length; i++)
		{
			class2984_0[i].method_1(writer);
		}
		for (int j = 0; j < class2983_0.Length; j++)
		{
			class2983_0[j].method_1(writer);
		}
	}

	public override int vmethod_2()
	{
		int num = 0;
		for (int i = 0; i < class2984_0.Length; i++)
		{
			num += class2984_0[i].method_2();
		}
		for (int j = 0; j < class2983_0.Length; j++)
		{
			num += class2983_0[j].method_2();
		}
		return num;
	}

	public void method_1()
	{
		method_2();
		method_3();
	}

	private void method_2()
	{
		if (class2984_0 == null || class2984_0.Length < 2)
		{
			return;
		}
		List<Class2984> list = new List<Class2984>();
		Class2984 @class = class2984_0[0];
		list.Add(@class);
		for (int i = 1; i < class2984_0.Length; i++)
		{
			if (class2984_0[i].method_3(@class))
			{
				@class.Count += class2984_0[i].Count;
				continue;
			}
			@class = class2984_0[i];
			list.Add(@class);
		}
		class2984_0 = list.ToArray();
	}

	private void method_3()
	{
		if (class2983_0 == null || class2983_0.Length < 2)
		{
			return;
		}
		List<Class2983> list = new List<Class2983>();
		Class2983 @class = class2983_0[0];
		list.Add(@class);
		for (int i = 1; i < class2983_0.Length; i++)
		{
			if (class2983_0[i].method_3(@class))
			{
				@class.Count += class2983_0[i].Count;
				continue;
			}
			@class = class2983_0[i];
			list.Add(@class);
		}
		class2983_0 = list.ToArray();
	}
}
