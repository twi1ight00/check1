using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("d5c3c008-291f-4f39-add0-c319b9aa2134")]
[ComVisible(true)]
public interface IBehaviorProperties : IEnumerable, IList<PropertyType>, ICollection<PropertyType>, IEnumerable<PropertyType>
{
	IEnumerable AsIEnumerable { get; }
}
