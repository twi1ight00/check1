using Aspose.Slides.Charts;
using ns16;
using ns56;

namespace ns17;

internal class Class236
{
	public static void smethod_0(IErrorBarsFormat errorBarsFormat, Class2073 errorBarsElementData, Class1341 deserializationContext)
	{
		errorBarsFormat.IsVisible = true;
		if (errorBarsElementData.ErrBarType != null)
		{
			switch (errorBarsElementData.ErrBarType.Val)
			{
			default:
				errorBarsFormat.Type = ErrorBarType.Both;
				break;
			case Enum263.const_2:
				errorBarsFormat.Type = ErrorBarType.Minus;
				break;
			case Enum263.const_3:
				errorBarsFormat.Type = ErrorBarType.Plus;
				break;
			}
		}
		if (errorBarsElementData.ErrValType != null)
		{
			switch (errorBarsElementData.ErrValType.Val)
			{
			case Enum265.const_1:
				errorBarsFormat.ValueType = ErrorBarValueType.Custom;
				break;
			default:
				errorBarsFormat.ValueType = ErrorBarValueType.Fixed;
				errorBarsFormat.Value = (float)errorBarsElementData.Val.Val;
				break;
			case Enum265.const_3:
				errorBarsFormat.ValueType = ErrorBarValueType.Percentage;
				errorBarsFormat.Value = (float)errorBarsElementData.Val.Val;
				break;
			case Enum265.const_4:
				errorBarsFormat.ValueType = ErrorBarValueType.StandardDeviation;
				errorBarsFormat.Value = (float)errorBarsElementData.Val.Val;
				break;
			case Enum265.const_5:
				errorBarsFormat.ValueType = ErrorBarValueType.StandardError;
				break;
			}
		}
		Class921.smethod_0(errorBarsFormat.Format, errorBarsElementData.SpPr, deserializationContext);
		if (errorBarsElementData.NoEndCap != null)
		{
			errorBarsFormat.HasEndCap = !errorBarsElementData.NoEndCap.Val;
		}
		(errorBarsFormat as ErrorBarsFormat).PPTXUnsupportedProps.ExtensionList = errorBarsElementData.ExtLst;
	}

	public static void smethod_1(IErrorBarsFormat errorBarsFormat, Class2073 errorBarsElementData, Class1346 serializationContext)
	{
		switch (errorBarsFormat.Type)
		{
		default:
			errorBarsElementData.ErrBarType.Val = Enum263.const_1;
			break;
		case ErrorBarType.Minus:
			errorBarsElementData.ErrBarType.Val = Enum263.const_2;
			break;
		case ErrorBarType.Plus:
			errorBarsElementData.ErrBarType.Val = Enum263.const_3;
			break;
		}
		switch (errorBarsFormat.ValueType)
		{
		case ErrorBarValueType.Custom:
			errorBarsElementData.ErrValType.Val = Enum265.const_1;
			break;
		case ErrorBarValueType.Fixed:
			errorBarsElementData.ErrValType.Val = Enum265.const_2;
			errorBarsElementData.delegate1923_0().Val = errorBarsFormat.Value;
			break;
		case ErrorBarValueType.Percentage:
			errorBarsElementData.ErrValType.Val = Enum265.const_3;
			errorBarsElementData.delegate1923_0().Val = errorBarsFormat.Value;
			break;
		case ErrorBarValueType.StandardDeviation:
			errorBarsElementData.ErrValType.Val = Enum265.const_4;
			errorBarsElementData.delegate1923_0().Val = errorBarsFormat.Value;
			break;
		case ErrorBarValueType.StandardError:
			errorBarsElementData.ErrValType.Val = Enum265.const_5;
			break;
		}
		errorBarsElementData.delegate2763_0().Val = !errorBarsFormat.HasEndCap;
		Class921.smethod_1(errorBarsFormat.Format, errorBarsElementData.delegate1630_0, serializationContext);
		errorBarsElementData.delegate1535_0((errorBarsFormat as ErrorBarsFormat).PPTXUnsupportedProps.ExtensionList);
	}
}
