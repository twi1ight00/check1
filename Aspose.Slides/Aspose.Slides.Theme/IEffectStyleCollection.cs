using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("e398a77e-d8e9-44a3-9b04-6b386638661c")]
public interface IEffectStyleCollection : IEnumerable<IEffectStyle>, ICollection, IEnumerable
{
	IEffectStyle this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
