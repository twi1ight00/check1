using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[Guid("4527F139-1E6E-43B4-9B88-8028C225B716")]
[ComVisible(true)]
public class ViewProperties : IViewProperties
{
	private ViewType viewType_0;

	private NullableBool nullableBool_0;

	private readonly Presentation presentation_0;

	public ViewType LastView
	{
		get
		{
			return viewType_0;
		}
		set
		{
			viewType_0 = value;
		}
	}

	public NullableBool ShowComments
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			nullableBool_0 = value;
		}
	}

	internal ViewProperties(Presentation presentation)
	{
		LastView = ViewType.NotDefined;
		nullableBool_0 = NullableBool.NotDefined;
	}
}
