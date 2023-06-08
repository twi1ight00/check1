using System.Collections;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("60E3D62D-F72D-486B-9342-BB04384F459A")]
public sealed class SvgShape : ISvgShape
{
	private SortedList sortedList_0 = new SortedList();

	internal IDictionary EventHandlers => sortedList_0;

	internal bool NeedsSvgGroup => sortedList_0.Count > 0;

	internal SvgShape()
	{
	}

	public void SetEventHandler(SvgEvent eventType, string handler)
	{
		if (handler != null)
		{
			sortedList_0[eventType] = handler;
		}
		else
		{
			sortedList_0.Remove(eventType);
		}
	}
}
