using System;
using System.Collections.Generic;
using System.Drawing;
using ns224;
using ns235;
using ns243;
using ns246;

namespace ns242;

internal class Class6239
{
	private readonly Class6241 class6241_0;

	private Class6240 class6240_0;

	private readonly Class6238 class6238_0;

	private readonly Class6252 class6252_0;

	private readonly Class6233 class6233_0;

	private Class6250 class6250_0;

	public Class6240 NodesFactory
	{
		get
		{
			if (class6240_0 == null)
			{
				throw new ArgumentNullException("NodesFactory", "Set NodesFactory");
			}
			return class6240_0;
		}
	}

	public Class6238 DocumentComposer => class6238_0;

	public Class6252 TextComposer => class6252_0;

	public Class6250 StyleProcessor => class6250_0;

	public Class6241 NodesHolder => class6241_0;

	public Class6239(Class5999 font, Class5998 color, Class6238 composer, Class6252 textComposer, SizeF pageSize, Struct220 pageMargin)
	{
		class6241_0 = new Class6241(this);
		class6238_0 = composer;
		class6238_0.vmethod_0(this);
		class6252_0 = textComposer;
		class6233_0 = new Class6233(pageSize, pageMargin, this);
		class6240_0 = new Class6240(font, color, this);
		class6250_0 = new Class6250(this);
	}

	public virtual void vmethod_0(Class6240 factory)
	{
		class6240_0 = factory;
	}

	public Class6216[] method_0()
	{
		List<Class6216> list = new List<Class6216>();
		Class6233 @class;
		while ((@class = class6241_0.vmethod_2()) != null)
		{
			Class6216 class2 = new Class6216(class6233_0.Size.Width, class6233_0.Size.Height);
			class2.method_0(@class.vmethod_2());
			list.Add(class2);
		}
		return list.ToArray();
	}

	public Class6230 method_1(Struct220 columnMargin)
	{
		Class6230 @class = NodesFactory.vmethod_6(columnMargin, class6233_0);
		vmethod_2(@class, class6233_0);
		class6241_0.vmethod_0(@class);
		return @class;
	}

	public Class6229 method_2(int columnCount, Struct220 margin)
	{
		Class6229 @class = NodesFactory.vmethod_2(columnCount, margin, class6233_0);
		vmethod_2(@class, class6233_0);
		class6241_0.vmethod_0(@class);
		return @class;
	}

	public Class6229 method_3(string[][] data, Struct220 tableMargin, Struct220 paragraphMargin)
	{
		if (data.Length == 0)
		{
			throw new IndexOutOfRangeException("Data cannot be empty");
		}
		int num = data[0].Length;
		if (num == 0)
		{
			throw new IndexOutOfRangeException("Column count cannot be zero");
		}
		Class6229 @class = NodesFactory.vmethod_2(num, tableMargin, class6233_0);
		vmethod_2(@class, class6233_0);
		for (int i = 0; i < data.Length; i++)
		{
			Class6232 class2 = @class.vmethod_17();
			for (int j = 0; j < data[i].Length; j++)
			{
				Class6231 class3 = class2.vmethod_17();
				Class6228 class4 = class3.vmethod_17(0f, paragraphMargin);
				class4.AddText(data[i][j]);
			}
		}
		class6241_0.vmethod_0(@class);
		return @class;
	}

	public virtual Class6233 vmethod_1()
	{
		return (Class6233)class6233_0.Clone();
	}

	protected virtual void vmethod_2(Class6225 node, Class6233 page)
	{
		PointF location = new PointF(class6233_0.Location.X + class6233_0.Margin.float_1, class6233_0.Location.Y + class6233_0.Margin.float_0);
		node.Location = location;
	}

	public virtual void vmethod_3()
	{
		class6241_0.vmethod_0(NodesFactory.vmethod_8());
	}

	public void method_4(Class5998 defColor)
	{
		class6240_0.method_0(defColor);
	}

	public void method_5(Class5999 font)
	{
		class6240_0.method_1(font);
	}
}
