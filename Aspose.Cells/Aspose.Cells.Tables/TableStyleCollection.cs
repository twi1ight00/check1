using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Pivot;
using ns58;

namespace Aspose.Cells.Tables;

/// <summary>
///       Represents all custom table styles.
///       </summary>
public class TableStyleCollection : CollectionBase
{
	private WorksheetCollection worksheetCollection_0;

	private object object_0 = TableStyleType.TableStyleMedium9;

	private string string_0 = "PivotStyleLight16";

	/// <summary>
	///       Gets the table style by the index.
	///       </summary>
	/// <param name="index">The position of the table style in the list.</param>
	/// <returns>The table style object.</returns>
	public TableStyle this[int index] => (TableStyle)base.InnerList[index];

	/// <summary>
	///       Gets the table style by the name.
	///       </summary>
	/// <param name="name">The table style name.</param>
	/// <returns>The table style object.</returns>
	public TableStyle this[string name]
	{
		get
		{
			name = name.ToUpper();
			int num = 0;
			TableStyle tableStyle;
			while (true)
			{
				if (num < base.InnerList.Count)
				{
					tableStyle = (TableStyle)base.InnerList[num];
					if (tableStyle.Name.ToUpper() == name)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return tableStyle;
		}
	}

	[SpecialName]
	internal string method_0()
	{
		if (object_0 == null)
		{
			return null;
		}
		if (object_0 is string)
		{
			return (string)object_0;
		}
		return Class1736.smethod_0((TableStyleType)object_0);
	}

	[SpecialName]
	internal void method_1(string string_1)
	{
		TableStyleType tableStyleType = Class1736.smethod_1(string_1);
		if (tableStyleType != TableStyleType.Custom && tableStyleType != 0)
		{
			object_0 = tableStyleType;
		}
		else
		{
			object_0 = string_1;
		}
	}

	[SpecialName]
	internal string method_2()
	{
		return string_0;
	}

	[SpecialName]
	internal void method_3(string string_1)
	{
		string_0 = string_1;
	}

	[SpecialName]
	internal WorksheetCollection method_4()
	{
		return worksheetCollection_0;
	}

	internal TableStyleCollection(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
	}

	/// <summary>
	///       Adds a custom table style.
	///       </summary>
	/// <param name="name">The table style name.</param>
	/// <returns>The index of the table style.</returns>
	public int AddTableStyle(string name)
	{
		TableStyle tableStyle = new TableStyle(this, name);
		tableStyle.method_3(bool_2: false);
		base.InnerList.Add(tableStyle);
		return base.Count - 1;
	}

	/// <summary>
	///       Adds a custom pivot table style.
	///       </summary>
	/// <param name="name">The pivot table style name.</param>
	/// <returns>The index of the pivot table style.</returns>
	public int AddPivotTableStyle(string name)
	{
		TableStyle tableStyle = new TableStyle(this, name);
		tableStyle.method_5(bool_2: false);
		base.InnerList.Add(tableStyle);
		return base.Count - 1;
	}

	internal int Add(string string_1)
	{
		TableStyle value = new TableStyle(this, string_1);
		base.InnerList.Add(value);
		return base.Count - 1;
	}

	/// <summary>
	///       Gets the builtin table style
	///       </summary>
	/// <param name="type">The builtin table style type.</param>
	/// <returns>
	/// </returns>
	public TableStyle GetBuiltinTableStyle(TableStyleType type)
	{
		return type switch
		{
			TableStyleType.TableStyleLight1 => Class1688.smethod_0(worksheetCollection_0), 
			TableStyleType.TableStyleLight2 => Class1688.smethod_1(worksheetCollection_0), 
			TableStyleType.TableStyleLight3 => Class1688.smethod_2(worksheetCollection_0), 
			TableStyleType.TableStyleLight4 => Class1688.smethod_3(worksheetCollection_0), 
			TableStyleType.TableStyleLight5 => Class1688.smethod_4(worksheetCollection_0), 
			TableStyleType.TableStyleLight6 => Class1688.smethod_5(worksheetCollection_0), 
			TableStyleType.TableStyleLight7 => Class1688.smethod_6(worksheetCollection_0), 
			TableStyleType.TableStyleLight8 => Class1688.smethod_7(worksheetCollection_0), 
			TableStyleType.TableStyleLight9 => Class1688.smethod_8(worksheetCollection_0), 
			TableStyleType.TableStyleLight10 => Class1688.smethod_9(worksheetCollection_0), 
			TableStyleType.TableStyleLight11 => Class1688.smethod_10(worksheetCollection_0), 
			TableStyleType.TableStyleLight12 => Class1688.smethod_11(worksheetCollection_0), 
			TableStyleType.TableStyleLight13 => Class1688.smethod_12(worksheetCollection_0), 
			TableStyleType.TableStyleLight14 => Class1688.smethod_13(worksheetCollection_0), 
			TableStyleType.TableStyleLight15 => Class1688.smethod_14(worksheetCollection_0), 
			TableStyleType.TableStyleLight16 => Class1688.smethod_15(worksheetCollection_0), 
			TableStyleType.TableStyleLight17 => Class1688.smethod_16(worksheetCollection_0), 
			TableStyleType.TableStyleLight18 => Class1688.smethod_17(worksheetCollection_0), 
			TableStyleType.TableStyleLight19 => Class1688.smethod_18(worksheetCollection_0), 
			TableStyleType.TableStyleLight20 => Class1688.smethod_19(worksheetCollection_0), 
			TableStyleType.TableStyleLight21 => Class1688.smethod_20(worksheetCollection_0), 
			TableStyleType.TableStyleMedium1 => Class1688.smethod_21(worksheetCollection_0), 
			TableStyleType.TableStyleMedium2 => Class1688.smethod_22(worksheetCollection_0), 
			TableStyleType.TableStyleMedium3 => Class1688.smethod_23(worksheetCollection_0), 
			TableStyleType.TableStyleMedium4 => Class1688.smethod_24(worksheetCollection_0), 
			TableStyleType.TableStyleMedium5 => Class1688.smethod_25(worksheetCollection_0), 
			TableStyleType.TableStyleMedium6 => Class1688.smethod_26(worksheetCollection_0), 
			TableStyleType.TableStyleMedium7 => Class1688.smethod_27(worksheetCollection_0), 
			TableStyleType.TableStyleMedium8 => Class1688.smethod_28(worksheetCollection_0), 
			TableStyleType.TableStyleMedium9 => Class1688.smethod_29(worksheetCollection_0), 
			TableStyleType.TableStyleMedium10 => Class1688.smethod_30(worksheetCollection_0), 
			TableStyleType.TableStyleMedium11 => Class1688.smethod_31(worksheetCollection_0), 
			TableStyleType.TableStyleMedium12 => Class1688.smethod_32(worksheetCollection_0), 
			TableStyleType.TableStyleMedium13 => Class1688.smethod_33(worksheetCollection_0), 
			TableStyleType.TableStyleMedium14 => Class1688.smethod_34(worksheetCollection_0), 
			TableStyleType.TableStyleMedium15 => Class1688.smethod_35(worksheetCollection_0), 
			TableStyleType.TableStyleMedium16 => Class1688.smethod_36(worksheetCollection_0), 
			TableStyleType.TableStyleMedium17 => Class1688.smethod_37(worksheetCollection_0), 
			TableStyleType.TableStyleMedium18 => Class1688.smethod_38(worksheetCollection_0), 
			TableStyleType.TableStyleMedium19 => Class1688.smethod_39(worksheetCollection_0), 
			TableStyleType.TableStyleMedium20 => Class1688.smethod_40(worksheetCollection_0), 
			TableStyleType.TableStyleMedium21 => Class1688.smethod_42(worksheetCollection_0), 
			TableStyleType.TableStyleMedium22 => Class1688.smethod_41(worksheetCollection_0), 
			TableStyleType.TableStyleMedium23 => Class1688.smethod_43(worksheetCollection_0), 
			TableStyleType.TableStyleMedium24 => Class1688.smethod_44(worksheetCollection_0), 
			TableStyleType.TableStyleMedium25 => Class1688.smethod_45(worksheetCollection_0), 
			TableStyleType.TableStyleMedium26 => Class1688.smethod_46(worksheetCollection_0), 
			TableStyleType.TableStyleMedium27 => Class1688.smethod_47(worksheetCollection_0), 
			TableStyleType.TableStyleMedium28 => Class1688.smethod_48(worksheetCollection_0), 
			TableStyleType.TableStyleDark1 => Class1688.smethod_49(worksheetCollection_0), 
			TableStyleType.TableStyleDark2 => Class1688.smethod_50(worksheetCollection_0), 
			TableStyleType.TableStyleDark3 => Class1688.smethod_51(worksheetCollection_0), 
			TableStyleType.TableStyleDark4 => Class1688.smethod_52(worksheetCollection_0), 
			TableStyleType.TableStyleDark5 => Class1688.smethod_53(worksheetCollection_0), 
			TableStyleType.TableStyleDark6 => Class1688.smethod_54(worksheetCollection_0), 
			TableStyleType.TableStyleDark7 => Class1688.smethod_55(worksheetCollection_0), 
			TableStyleType.TableStyleDark8 => Class1688.smethod_56(worksheetCollection_0), 
			TableStyleType.TableStyleDark9 => Class1688.smethod_57(worksheetCollection_0), 
			TableStyleType.TableStyleDark10 => Class1688.smethod_58(worksheetCollection_0), 
			TableStyleType.TableStyleDark11 => Class1688.smethod_59(worksheetCollection_0), 
			_ => null, 
		};
	}

	internal TableStyle method_5(PivotTableStyleType pivotTableStyleType_0)
	{
		return pivotTableStyleType_0 switch
		{
			PivotTableStyleType.None => Class1687.smethod_0(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight1 => Class1687.smethod_29(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight2 => Class1687.smethod_40(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight3 => Class1687.smethod_50(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight4 => Class1687.smethod_51(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight5 => Class1687.smethod_52(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight6 => Class1687.smethod_53(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight7 => Class1687.smethod_54(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight8 => Class1687.smethod_55(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight9 => Class1687.smethod_56(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight10 => Class1687.smethod_30(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight11 => Class1687.smethod_31(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight12 => Class1687.smethod_32(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight13 => Class1687.smethod_33(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight14 => Class1687.smethod_34(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight15 => Class1687.smethod_35(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight16 => Class1687.smethod_36(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight17 => Class1687.smethod_37(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight18 => Class1687.smethod_38(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight19 => Class1687.smethod_39(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight20 => Class1687.smethod_41(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight21 => Class1687.smethod_42(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight22 => Class1687.smethod_43(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight23 => Class1687.smethod_44(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight24 => Class1687.smethod_45(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight25 => Class1687.smethod_46(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight26 => Class1687.smethod_47(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight27 => Class1687.smethod_48(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleLight28 => Class1687.smethod_49(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium1 => Class1687.smethod_57(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium2 => Class1687.smethod_68(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium3 => Class1687.smethod_78(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium4 => Class1687.smethod_79(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium5 => Class1687.smethod_80(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium6 => Class1687.smethod_81(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium7 => Class1687.smethod_82(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium8 => Class1687.smethod_83(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium9 => Class1687.smethod_84(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium10 => Class1687.smethod_58(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium11 => Class1687.smethod_59(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium12 => Class1687.smethod_60(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium13 => Class1687.smethod_61(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium14 => Class1687.smethod_62(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium15 => Class1687.smethod_63(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium16 => Class1687.smethod_64(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium17 => Class1687.smethod_65(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium18 => Class1687.smethod_66(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium19 => Class1687.smethod_67(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium20 => Class1687.smethod_69(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium21 => Class1687.smethod_70(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium22 => Class1687.smethod_71(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium23 => Class1687.smethod_72(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium24 => Class1687.smethod_73(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium25 => Class1687.smethod_74(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium26 => Class1687.smethod_75(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium27 => Class1687.smethod_76(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleMedium28 => Class1687.smethod_77(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark1 => Class1687.smethod_1(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark2 => Class1687.smethod_12(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark3 => Class1687.smethod_22(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark4 => Class1687.smethod_23(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark5 => Class1687.smethod_24(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark6 => Class1687.smethod_25(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark7 => Class1687.smethod_26(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark8 => Class1687.smethod_27(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark9 => Class1687.smethod_28(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark10 => Class1687.smethod_2(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark11 => Class1687.smethod_3(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark12 => Class1687.smethod_4(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark13 => Class1687.smethod_5(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark14 => Class1687.smethod_6(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark15 => Class1687.smethod_7(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark16 => Class1687.smethod_8(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark17 => Class1687.smethod_9(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark18 => Class1687.smethod_10(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark19 => Class1687.smethod_11(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark20 => Class1687.smethod_13(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark21 => Class1687.smethod_14(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark22 => Class1687.smethod_15(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark23 => Class1687.smethod_16(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark24 => Class1687.smethod_17(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark25 => Class1687.smethod_18(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark26 => Class1687.smethod_19(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark27 => Class1687.smethod_20(worksheetCollection_0), 
			PivotTableStyleType.PivotTableStyleDark28 => Class1687.smethod_21(worksheetCollection_0), 
			_ => null, 
		};
	}
}
