using System.Collections;
using ns189;
using ns195;

namespace ns171;

internal class Class5763
{
	private class Class5764
	{
		private bool bool_0;

		private Class5661 class5661_0;

		private Class5763 class5763_0;

		internal Class5764(Class5656 charIter, Class5763 parent)
		{
			class5661_0 = (Class5661)charIter;
			class5763_0 = parent;
		}

		internal bool method_0()
		{
			if (!bool_0)
			{
				Class5656 @class = class5661_0.method_0();
				while (@class.imethod_0())
				{
					switch (Class5710.smethod_0(@class.vmethod_0()))
					{
					case 1:
						if (class5763_0.int_1 == 108)
						{
							bool_0 = true;
							return bool_0;
						}
						break;
					case 4:
						break;
					default:
						return bool_0;
					}
				}
				bool_0 = class5763_0.bool_3 || class5763_0.bool_2;
			}
			return bool_0;
		}

		internal void method_1()
		{
			bool_0 = false;
		}
	}

	private class Class5765
	{
		internal Class5656 class5656_0;

		internal Class5765(Class5096 fo, Class5656 firstTrailingWhiteSpace)
		{
			class5656_0 = firstTrailingWhiteSpace;
		}
	}

	private bool bool_0;

	private bool bool_1 = true;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private bool bool_2;

	private bool bool_3;

	private Class5661 class5661_0;

	private ArrayList arrayList_0;

	private Stack stack_0 = new Stack();

	private Class5656 class5656_0;

	public void method_0(Class5096 fo, Class5088 firstTextNode, Class5088 nextChild)
	{
		Class5106 @class = null;
		int num = fo.vmethod_24();
		switch ((Enum679)num)
		{
		default:
			if (stack_0.Count != 0)
			{
				@class = (Class5106)stack_0.Peek();
			}
			break;
		case Enum679.const_65:
		{
			Class5088 class2 = fo;
			do
			{
				class2 = class2.method_4();
			}
			while (class2.vmethod_24() != 3 && class2.vmethod_24() != 70);
			if (class2.vmethod_24() == 3)
			{
				@class = (Class5106)class2;
				stack_0.Push(@class);
			}
			break;
		}
		case Enum679.const_4:
			@class = (Class5106)fo;
			if (stack_0.Count != 0 && fo == stack_0.Peek())
			{
				if (nextChild == null)
				{
					stack_0.Pop();
				}
			}
			else if (nextChild != null)
			{
				stack_0.Push(@class);
			}
			break;
		}
		if (@class != null)
		{
			int_1 = @class.method_71();
			int_3 = @class.method_73();
			int_2 = @class.method_72();
		}
		else
		{
			int_1 = 147;
			int_3 = 149;
			int_2 = 63;
		}
		bool_2 = nextChild == null && fo == @class;
		if (firstTextNode == null)
		{
			bool_1 = fo == @class && fo.class5088_2 == null;
			int_0 = 0;
			if (bool_2)
			{
				method_5();
			}
			return;
		}
		class5661_0 = new Class5661(fo, firstTextNode);
		bool_0 = false;
		if (fo == @class || @class == null || (num == 64 && fo.method_4() == @class))
		{
			if (firstTextNode == fo.class5088_2)
			{
				bool_1 = true;
			}
			else
			{
				int num2 = firstTextNode.class5088_1[0].vmethod_24();
				bool_1 = num2 == 3 || num2 == 72 || num2 == 71 || num2 == 40 || num2 == 4;
			}
		}
		if (num == 81)
		{
			Class5088 class5088_ = fo.class5088_0;
			int num3 = class5088_.vmethod_24();
			while (true)
			{
				switch (num3)
				{
				case 81:
					goto IL_01c8;
				case 4:
				case 16:
				case 70:
				case 75:
					bool_2 = nextChild == null;
					break;
				}
				break;
				IL_01c8:
				class5088_ = class5088_.class5088_0;
				num3 = class5088_.vmethod_24();
			}
		}
		if (nextChild != null)
		{
			int num4 = nextChild.vmethod_24();
			bool_3 = num4 == 3 || num4 == 72 || num4 == 71 || num4 == 40 || num4 == 4;
		}
		else
		{
			bool_3 = false;
		}
		method_3();
		if (fo == @class && (bool_2 || bool_3))
		{
			method_5();
		}
		if (nextChild != null)
		{
			return;
		}
		if (fo != @class)
		{
			if (int_0 > 0 && arrayList_0 != null)
			{
				arrayList_0.Clear();
			}
			if (bool_0)
			{
				method_4(fo);
			}
		}
		else
		{
			if (stack_0.Count != 0)
			{
				stack_0.Pop();
			}
			class5661_0 = null;
			class5656_0 = null;
		}
	}

	internal void method_1()
	{
		if (arrayList_0 != null)
		{
			arrayList_0.Clear();
		}
		stack_0.Clear();
		class5661_0 = null;
		class5656_0 = null;
	}

	public void method_2(Class5096 fo, Class5088 firstTextNode)
	{
		method_0(fo, firstTextNode, null);
	}

	private void method_3()
	{
		Class5764 @class = new Class5764(class5661_0, this);
		int_0 = 0;
		while (class5661_0.imethod_0())
		{
			if (!bool_0)
			{
				class5656_0 = class5661_0.method_0();
			}
			char c = class5661_0.vmethod_0();
			int num = Class5710.smethod_0(c);
			if (num == 1 && int_1 == 147)
			{
				c = ' ';
				class5661_0.vmethod_1(' ');
				num = Class5710.smethod_0(32);
			}
			switch (Class5710.smethod_0(c))
			{
			case 1:
				switch ((Enum679)int_1)
				{
				case Enum679.const_235:
					class5661_0.vmethod_1('\u200b');
					bool_0 = false;
					break;
				case Enum679.const_195:
					@class.method_1();
					bool_0 = false;
					bool_1 = true;
					break;
				case Enum679.const_61:
					class5661_0.imethod_6();
					break;
				}
				break;
			default:
				bool_0 = false;
				bool_1 = false;
				int_0++;
				@class.method_1();
				break;
			case 4:
			{
				if (bool_0 && int_3 == 149)
				{
					class5661_0.imethod_6();
					break;
				}
				bool flag = false;
				switch ((Enum679)int_2)
				{
				case Enum679.const_61:
					flag = true;
					break;
				case Enum679.const_62:
					flag = bool_1;
					break;
				case Enum679.const_63:
					flag = @class.method_0();
					break;
				case Enum679.const_64:
					flag = bool_1 || @class.method_0();
					break;
				}
				if (flag)
				{
					class5661_0.imethod_6();
					break;
				}
				bool_0 = true;
				if (c != ' ')
				{
					class5661_0.vmethod_1(' ');
				}
				break;
			}
			}
		}
	}

	private void method_4(Class5096 fo)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList(5);
		}
		arrayList_0.Add(new Class5765(fo, class5656_0));
	}

	private void method_5()
	{
		if (arrayList_0 == null || arrayList_0.Count == 0)
		{
			return;
		}
		if (int_0 == 0)
		{
			int num = arrayList_0.Count;
			while (--num >= 0)
			{
				Class5765 @class = (Class5765)arrayList_0[num];
				class5661_0 = (Class5661)@class.class5656_0;
				method_3();
				arrayList_0.Remove(@class);
			}
		}
		else
		{
			arrayList_0.Clear();
		}
	}
}
