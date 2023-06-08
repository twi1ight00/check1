using System.Collections;

namespace Aspose.Cells;

/// <summary>
///       Describes a collection of CFValueObject.
///       Use only for icon sets.
///       </summary>
public class ConditionalFormattingValueCollection : CollectionBase
{
	internal FormatCondition formatCondition_0;

	internal bool bool_0;

	/// <summary>
	///       Get the CFValueObject element at the specified index.
	///       </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public ConditionalFormattingValue this[int index] => (ConditionalFormattingValue)base.InnerList[index];

	internal ConditionalFormattingValueCollection(FormatCondition formatCondition_1)
	{
		formatCondition_0 = formatCondition_1;
	}

	internal void Copy(ConditionalFormattingValueCollection conditionalFormattingValueCollection_0, CopyOptions copyOptions_0, int int_0, int int_1)
	{
		WorksheetCollection worksheetCollection_ = conditionalFormattingValueCollection_0.formatCondition_0.formatConditionCollection_0.conditionalFormattingCollection_0.worksheet_0.method_2();
		WorksheetCollection worksheetCollection_2 = formatCondition_0.formatConditionCollection_0.conditionalFormattingCollection_0.worksheet_0.method_2();
		bool_0 = conditionalFormattingValueCollection_0.bool_0;
		for (int i = 0; i < conditionalFormattingValueCollection_0.Count; i++)
		{
			ConditionalFormattingValue conditionalFormattingValue_ = conditionalFormattingValueCollection_0[i];
			ConditionalFormattingValue conditionalFormattingValue = new ConditionalFormattingValue(formatCondition_0);
			conditionalFormattingValue.Copy(conditionalFormattingValue_, worksheetCollection_, worksheetCollection_2, copyOptions_0, int_0, int_1);
			base.InnerList.Add(conditionalFormattingValue);
		}
	}

	/// <summary>
	///       Adds a CFValueObject to the collection.
	///       </summary>
	/// <param name="cfvo">CFValueObject object index.</param>
	internal void Add(ConditionalFormattingValue conditionalFormattingValue_0)
	{
		if (bool_0 && (conditionalFormattingValue_0.Type == FormatConditionValueType.Max || conditionalFormattingValue_0.Type == FormatConditionValueType.Min))
		{
			throw new CellsException(ExceptionType.DataValidation, "Cannot add a CFVO with type FormatConditionValueType.Max or FormatConditionValueType.Min to IconSet's CFVOS.");
		}
		base.InnerList.Add(conditionalFormattingValue_0);
	}

	/// <summary>
	///       Adds <see cref="T:Aspose.Cells.ConditionalFormattingValue" /> object.
	///       </summary>
	/// <param name="type">The value type.</param>
	/// <param name="value">The value.</param>
	/// <returns>Returns the index of new object in the list.</returns>
	public int Add(FormatConditionValueType type, string value)
	{
		base.InnerList.Add(new ConditionalFormattingValue(formatCondition_0, type, value));
		return base.Count - 1;
	}
}
