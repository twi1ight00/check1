using ns56;

namespace ns8;

internal class Class112 : Class103
{
	private Enum133 enum133_0;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private int int_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private Enum120 enum120_1;

	private Enum120 enum120_2;

	private Enum120 enum120_3;

	private Enum120 enum120_4;

	private Enum121 enum121_1;

	private Enum121 enum121_2;

	public Enum133 AutoTextRotation => enum133_0;

	public double LineSpaceAfterChildrenParagraphs => double_0;

	public double LineSpaceAfterParentParagraphs => double_1;

	public double LineSpacingChildren => double_2;

	public double LineSpacingParent => double_3;

	public Enum120 ParentLeftToRightAlignment => enum120_1;

	public Enum120 ParentRightToLeftAlignment => enum120_2;

	public Enum120 ShapeTextLeftToRightAlignment => enum120_3;

	public Enum120 ShapeTextRightToLeftAlignment => enum120_4;

	public int StartBulletLevel => int_0;

	public Enum121 VerticalAnchor => enum121_1;

	public Enum121 VerticalAnchorWithChildren => enum121_2;

	public bool IsTextVertical => bool_0;

	public bool IsTextCentred => bool_1;

	public bool IsTextCentredWithChildren => bool_2;

	public Class112(Class2146 algorithm)
	{
		enum133_0 = Enum133.const_1;
		double_0 = 15.0;
		double_1 = 35.0;
		double_2 = 90.0;
		double_3 = 90.0;
		enum120_1 = Enum120.const_2;
		enum120_2 = Enum120.const_2;
		enum120_3 = Enum120.const_1;
		enum120_4 = Enum120.const_3;
		int_0 = 2;
		enum121_1 = Enum121.const_2;
		enum121_2 = Enum121.const_1;
		bool_0 = false;
		bool_1 = false;
		bool_2 = false;
		Class2177[] paramList = algorithm.ParamList;
		foreach (Class2177 @class in paramList)
		{
			switch (@class.Type)
			{
			case Enum304.const_41:
				enum120_3 = Class103.smethod_1(@class.Val);
				break;
			case Enum304.const_42:
				enum120_4 = Class103.smethod_1(@class.Val);
				break;
			case Enum304.const_46:
				int_0 = int.Parse(@class.Val);
				break;
			case Enum304.const_48:
				bool_1 = @class.Val == "ctr";
				break;
			case Enum304.const_49:
				bool_2 = @class.Val == "ctr";
				break;
			case Enum304.const_50:
				enum121_1 = Class103.smethod_2(@class.Val);
				break;
			case Enum304.const_51:
				enum121_2 = Class103.smethod_2(@class.Val);
				break;
			case Enum304.const_52:
				bool_0 = @class.Val == "vert";
				break;
			case Enum304.const_54:
				base.VerticalAlignment = Class103.smethod_2(@class.Val);
				break;
			case Enum304.const_21:
				base.HorizontalAlignment = Class103.smethod_1(@class.Val);
				break;
			case Enum304.const_23:
				double_0 = Class103.smethod_4(@class.Val, 15.0);
				break;
			case Enum304.const_24:
				double_1 = Class103.smethod_4(@class.Val, 35.0);
				break;
			case Enum304.const_25:
				double_2 = Class103.smethod_4(@class.Val, 90.0);
				break;
			case Enum304.const_26:
				double_3 = Class103.smethod_4(@class.Val, 90.0);
				break;
			case Enum304.const_30:
				enum120_1 = Class103.smethod_1(@class.Val);
				break;
			case Enum304.const_31:
				enum120_2 = Class103.smethod_1(@class.Val);
				break;
			case Enum304.const_2:
				enum133_0 = method_0(@class.Val);
				break;
			}
		}
	}

	private Enum133 method_0(string value)
	{
		return value switch
		{
			"grav" => Enum133.const_2, 
			"upr" => Enum133.const_1, 
			_ => Enum133.const_0, 
		};
	}
}
