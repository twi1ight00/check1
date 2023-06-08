using Aspose.Slides;
using ns62;
using ns63;

namespace ns15;

internal sealed class Class201
{
	private Class856 class856_0;

	private Class2639 class2639_0;

	private Class2670 class2670_0;

	private Class2834 class2834_0;

	private Class2817 class2817_0;

	private Class2837 class2837_0;

	private Class2641 class2641_0;

	private Class2642 class2642_0;

	private Class2894 class2894_0;

	private Class2894 class2894_1;

	private Class2987 class2987_0;

	private Class2987 class2987_1;

	private Class2987 class2987_2;

	private ITextFrame itextFrame_0;

	private Class2731 class2731_0;

	private Enum449 enum449_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	public bool FrameHasBulletSchemes
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool IsPlaceholder => bool_1;

	public Class856 ParentContext => class856_0;

	public Enum449 CurrentTextType
	{
		get
		{
			return enum449_0;
		}
		set
		{
			enum449_0 = value;
		}
	}

	public Class2894 CurrentTextDefaultStyle
	{
		get
		{
			return class2894_0;
		}
		set
		{
			class2894_0 = value;
		}
	}

	public Class2894 CurrentTextMasterStyle
	{
		get
		{
			return class2894_1;
		}
		set
		{
			class2894_1 = value;
		}
	}

	public Class2987 CurrentTextDefaultStyleLevel
	{
		get
		{
			return class2987_0;
		}
		set
		{
			class2987_0 = value;
		}
	}

	public Class2987 CurrentTextMasterStyleLevel
	{
		get
		{
			return class2987_1;
		}
		set
		{
			class2987_1 = value;
		}
	}

	public Class2987 RelatedTextStyleLevel
	{
		get
		{
			return class2987_2;
		}
		set
		{
			class2987_2 = value;
		}
	}

	public Class201(Class856 parentContext)
	{
		class856_0 = parentContext;
		parentContext.CurrentShapeContext = this;
	}

	public Class2670 method_0(Class2639 parentContainer, bool addToContainer)
	{
		bool_3 = false;
		class2639_0 = parentContainer;
		class2670_0 = new Class2670();
		if (addToContainer)
		{
			method_6();
		}
		return class2670_0;
	}

	public Class2834 method_1()
	{
		class2834_0 = new Class2834();
		class2670_0.method_2(class2834_0);
		return class2834_0;
	}

	public Class2817 method_2()
	{
		class2817_0 = new Class2817();
		class2670_0.method_2(class2817_0);
		return class2817_0;
	}

	public Class2837 method_3()
	{
		class2837_0 = new Class2837();
		class2670_0.method_2(class2837_0);
		return class2837_0;
	}

	public Class2641 method_4()
	{
		class2670_0.AutoInit = true;
		class2641_0 = class2670_0.ClientData;
		return class2641_0;
	}

	public Class2642 method_5()
	{
		class2670_0.AutoInit = true;
		class2642_0 = class2670_0.ClientTextBox;
		return class2642_0;
	}

	public void method_6()
	{
		if (!bool_3)
		{
			class2639_0.Records.Add(class2670_0);
		}
		bool_3 = true;
	}

	public void method_7()
	{
		if (class2834_0 != null && class2834_0.Properties.Count == 0)
		{
			class2670_0.Records.Remove(class2834_0);
		}
		if (class2837_0 != null && class2837_0.Properties.Count == 0)
		{
			class2670_0.Records.Remove(class2837_0);
		}
		if (class2641_0 != null && class2641_0.Records.Count == 0)
		{
			class2670_0.Records.Remove(class2641_0);
		}
	}

	public void method_8(ITextFrame textFrame, Class2731 slideListWithTextContainer, Enum449 textType)
	{
		itextFrame_0 = textFrame;
		class2731_0 = slideListWithTextContainer;
		enum449_0 = textType;
		bool_0 = true;
	}

	public void method_9()
	{
		if (bool_0)
		{
			bool_1 = class2641_0 != null && class2641_0.PlaceholderAtom != null;
			Class1036.smethod_9(itextFrame_0, class2731_0, enum449_0, this);
			bool_0 = false;
		}
	}
}
