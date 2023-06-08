using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ClassInterface(ClassInterfaceType.None)]
[Guid("CBBFF247-5BA0-46FF-A413-76B35FFFBCD8")]
[ComVisible(true)]
public class SetEffect : Behavior, IBehavior, ISetEffect
{
	internal object object_0;

	public object To
	{
		get
		{
			return object_0;
		}
		set
		{
			method_0(value);
			object_0 = value;
		}
	}

	IBehavior ISetEffect.AsIBehavior => this;

	internal bool method_0(object val)
	{
		if (!(val.GetType() == typeof(string)) && !(val.GetType() == typeof(ColorFormat)) && !(val.GetType() == typeof(float)) && !(val.GetType() == typeof(int)) && !(val.GetType() == typeof(uint)) && !(val.GetType() == typeof(long)) && !(val.GetType() == typeof(ulong)) && !(val.GetType() == typeof(bool)))
		{
			throw new PptxException("invalid property value type");
		}
		return true;
	}
}
