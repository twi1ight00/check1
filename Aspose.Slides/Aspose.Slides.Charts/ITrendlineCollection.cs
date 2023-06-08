using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("423225cf-bd13-49ff-82d4-9c9b3ddcd1c2")]
public interface ITrendlineCollection : IEnumerable, IEnumerable<ITrendline>
{
	ITrendline this[int index] { get; }

	int Count { get; }

	IEnumerable AsIEnumerable { get; }

	ITrendline Add(TrendlineType trendlineType);

	void Remove(ITrendline value);
}
