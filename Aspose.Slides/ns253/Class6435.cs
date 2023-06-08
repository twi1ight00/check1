using ns252;

namespace ns253;

internal class Class6435
{
	internal class Class6436 : Interface277
	{
		private readonly Class6435 class6435_0;

		private readonly Class6450 class6450_0;

		public Interface276 ParentBag => class6450_0.method_0(class6435_0.Level).class6325_0;

		public Class6436(Class6435 paragraphProperties, Class6450 textListStyles)
		{
			class6435_0 = paragraphProperties;
			class6450_0 = textListStyles;
		}
	}

	private static Interface277 interface277_0 = new Class6328(Class6326.Instance);

	private Class6427 class6427_0;

	private Class6445 class6445_0;

	private int int_0;

	private Class6325 class6325_0 = new Class6325();

	public Class6427 BulletPropeties
	{
		get
		{
			return class6427_0;
		}
		set
		{
			class6427_0 = value;
		}
	}

	public int Level
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public Enum825 Alignment
	{
		get
		{
			return (Enum825)method_4(Enum823.const_0);
		}
		set
		{
			method_3(Enum823.const_0, value);
		}
	}

	public int DefaultTabSize
	{
		get
		{
			return (int)method_4(Enum823.const_1);
		}
		set
		{
			method_3(Enum823.const_1, value);
		}
	}

	public bool IsEastAsianLineBreakAllowed
	{
		get
		{
			return (bool)method_4(Enum823.const_2);
		}
		set
		{
			method_3(Enum823.const_2, value);
		}
	}

	public Enum821 FontAlignment
	{
		get
		{
			return (Enum821)method_4(Enum823.const_3);
		}
		set
		{
			method_3(Enum823.const_3, value);
		}
	}

	public bool IsHangingPunctuationAllowed
	{
		get
		{
			return (bool)method_4(Enum823.const_4);
		}
		set
		{
			method_3(Enum823.const_4, value);
		}
	}

	public int TextIdentation
	{
		get
		{
			return (int)method_4(Enum823.const_5);
		}
		set
		{
			method_3(Enum823.const_5, value);
		}
	}

	public bool IsLatinLineBreakAllowed
	{
		get
		{
			return (bool)method_4(Enum823.const_6);
		}
		set
		{
			method_3(Enum823.const_6, value);
		}
	}

	public int LeftMargin
	{
		get
		{
			return (int)method_4(Enum823.const_7);
		}
		set
		{
			method_3(Enum823.const_7, value);
		}
	}

	public int RightMargin
	{
		get
		{
			return (int)method_4(Enum823.const_8);
		}
		set
		{
			method_3(Enum823.const_8, value);
		}
	}

	public bool RightToLeftFlowDirection
	{
		get
		{
			return (bool)method_4(Enum823.const_9);
		}
		set
		{
			method_3(Enum823.const_9, value);
		}
	}

	public Class6445 DefaultRunProperties
	{
		get
		{
			if (class6445_0 == null)
			{
				class6445_0 = new Class6445();
			}
			return class6445_0;
		}
	}

	public Interface299 LineSpacing
	{
		get
		{
			return (Interface299)method_4(Enum823.const_11);
		}
		set
		{
			method_3(Enum823.const_11, value);
		}
	}

	public Interface299 SpaceAfter
	{
		get
		{
			return (Interface299)method_4(Enum823.const_12);
		}
		set
		{
			method_3(Enum823.const_12, value);
		}
	}

	public Interface299 SpaceBefore
	{
		get
		{
			return (Interface299)method_4(Enum823.const_13);
		}
		set
		{
			method_3(Enum823.const_13, value);
		}
	}

	public Class6435()
	{
		class6325_0.ParentBagProvider = interface277_0;
	}

	public void method_0(Class6450 textListStyles)
	{
		class6325_0.ParentBagProvider = new Class6436(this, textListStyles);
	}

	internal void method_1(Class6435 parentProperties)
	{
		class6325_0.ParentBagProvider = new Class6328(parentProperties.class6325_0);
	}

	internal void method_2(Class6326 parentProperties)
	{
		class6325_0.ParentBagProvider = new Class6328(parentProperties);
	}

	private void method_3(Enum823 propertyId, object value)
	{
		class6325_0.imethod_1(propertyId, value);
	}

	private object method_4(Enum823 propertyId)
	{
		return class6325_0.imethod_0(propertyId);
	}
}
