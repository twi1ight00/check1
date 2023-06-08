using System.Collections.Generic;

namespace Richfit.Garnet.Module.Document.HandlerProcess.Handlers;

public class myDataType
{
	public string TypeID { get; set; }

	public int Count { get; set; }

	public string TypeName { get; set; }

	public int TypeLevel { get; set; }

	public string ParentID { get; set; }

	public string ParentName { get; set; }

	public string OrderID { get; set; }

	public string RootID { get; set; }

	public List<myDataType> children { get; set; }
}
