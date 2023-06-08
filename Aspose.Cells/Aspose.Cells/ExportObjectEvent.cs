namespace Aspose.Cells;

public class ExportObjectEvent
{
	private object object_0;

	internal ExportObjectEvent(object object_1)
	{
		object_0 = object_1;
	}

	public object GetSource()
	{
		return object_0;
	}
}
