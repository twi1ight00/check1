using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("4CDD3C98-B7D9-484B-B292-98E316A714CA")]
[ComVisible(true)]
public interface IPortionFactory
{
	IPortion CreatePortion();

	IPortion CreatePortion(string str);

	IPortion CreatePortion(IPortion portion);
}
