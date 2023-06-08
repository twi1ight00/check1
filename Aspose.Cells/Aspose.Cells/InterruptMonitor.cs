namespace Aspose.Cells;

/// <summary>
///       Represents all operator about the interrupt.
///       </summary>
public class InterruptMonitor
{
	internal bool bool_0;

	/// <summary>
	///       Interrupt the current operator.
	///       </summary>
	public void Interrupt()
	{
		bool_0 = true;
	}
}
