namespace Aspose.Cells;

/// <summary>
///       Represents a referred objcet by the formula.
///       </summary>
public class ReferredArea
{
	private bool bool_0;

	private string string_0;

	private string string_1;

	private bool bool_1;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	/// <summary>
	///       Indicates whether this is an external link.
	///       </summary>
	public bool IsExternalLink => bool_0;

	/// <summary>
	///        this.KeepedRels = source.KeepedRels;
	///       </summary>
	public string ExternalFileName => string_0;

	/// <summary>
	///       Indicates which sheet this is in
	///       </summary>
	public string SheetName => string_1;

	/// <summary>
	///       Indicates whether this is an area.
	///       </summary>
	/// <remarks>
	///       If this is not an area, only StartRow and StartColumn effect.
	///       </remarks>
	public bool IsArea => bool_1;

	/// <summary>
	///       The end column of the area.
	///       </summary>
	public int EndColumn => int_3;

	/// <summary>
	///       The start column of the area.
	///       </summary>
	public int StartColumn => int_2;

	/// <summary>
	///       The end row of the area.
	///       </summary>
	public int EndRow => int_1;

	/// <summary>
	///       The start row of the area.
	///       </summary>
	public int StartRow => int_0;

	internal ReferredArea(bool bool_2, string string_2, string string_3, int int_4, int int_5)
	{
		bool_0 = bool_2;
		string_0 = string_2;
		string_1 = string_3;
		bool_1 = false;
		int_0 = int_4;
		int_2 = int_5;
	}

	internal ReferredArea(bool bool_2, string string_2, string string_3, int int_4, int int_5, int int_6, int int_7)
	{
		bool_0 = bool_2;
		string_0 = string_2;
		string_1 = string_3;
		bool_1 = true;
		int_0 = int_4;
		int_2 = int_5;
		int_3 = int_7;
		int_1 = int_6;
	}

	internal bool method_0(ReferredArea referredArea_0)
	{
		if (bool_1 == referredArea_0.bool_1)
		{
			if (IsArea)
			{
				if (bool_0 == referredArea_0.bool_0 && string_0 == referredArea_0.string_0 && string_1 == referredArea_0.string_1 && int_0 == referredArea_0.int_0 && int_2 == referredArea_0.int_2 && int_3 == referredArea_0.int_3)
				{
					return int_1 == referredArea_0.int_1;
				}
				return false;
			}
			if (bool_0 == referredArea_0.bool_0 && string_0 == referredArea_0.string_0 && string_1 == referredArea_0.string_1 && int_0 == referredArea_0.int_0)
			{
				return int_2 == referredArea_0.int_2;
			}
			return false;
		}
		return false;
	}
}
