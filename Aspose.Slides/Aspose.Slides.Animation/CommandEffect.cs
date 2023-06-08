using System.Runtime.InteropServices;
using ns27;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("E1E881A2-1C86-4BA4-B201-5145DC1F7D05")]
[ClassInterface(ClassInterfaceType.None)]
public class CommandEffect : Behavior, IBehavior, ICommandEffect
{
	internal CommandEffectType commandEffectType_0;

	internal string string_0;

	internal Shape shape_0;

	internal new Class361 PPTXUnsupportedProps => (Class361)base.PPTXUnsupportedProps;

	public CommandEffectType Type
	{
		get
		{
			return commandEffectType_0;
		}
		set
		{
			commandEffectType_0 = value;
		}
	}

	public string CommandString
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

	public IShape ShapeTarget
	{
		get
		{
			return shape_0;
		}
		set
		{
			shape_0 = (Shape)value;
		}
	}

	IBehavior ICommandEffect.AsIBehavior => this;

	public CommandEffect()
		: base(new Class361())
	{
	}
}
