using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("FF69F8CD-F5E3-4B0C-9012-653F93890460")]
public class PropertyEffect : Behavior, IBehavior, IPropertyEffect
{
	internal string string_0;

	internal string string_1;

	internal string string_2;

	internal PointCollection pointCollection_0 = new PointCollection();

	internal PropertyCalcModeType propertyCalcModeType_0 = PropertyCalcModeType.NotDefined;

	internal PropertyValueType propertyValueType_0 = PropertyValueType.NotDefined;

	public string From
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string To
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string By
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public PropertyValueType ValueType
	{
		get
		{
			return propertyValueType_0;
		}
		set
		{
			propertyValueType_0 = value;
		}
	}

	public PropertyCalcModeType CalcMode
	{
		get
		{
			return propertyCalcModeType_0;
		}
		set
		{
			propertyCalcModeType_0 = value;
		}
	}

	public IPointCollection Points
	{
		get
		{
			return pointCollection_0;
		}
		set
		{
			pointCollection_0 = (PointCollection)value;
		}
	}

	IBehavior IPropertyEffect.AsIBehavior => this;

	internal bool method_0(object val)
	{
		if (!(val.GetType() == typeof(string)) && !(val.GetType() == typeof(ColorFormat)) && !(val.GetType() == typeof(int)) && !(val.GetType() == typeof(uint)) && !(val.GetType() == typeof(long)) && !(val.GetType() == typeof(ulong)))
		{
			throw new PptxException("PropertyEffect, invalid property value type");
		}
		return true;
	}

	internal bool method_1()
	{
		if (string_0 != null && string_1 != null && string_0.GetType() == To.GetType())
		{
			return true;
		}
		return false;
	}
}
