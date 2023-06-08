using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("8c3f59db-38e1-4ead-ada3-048a42079890")]
[ComVisible(true)]
public interface IAudioCollection : ICollection, IEnumerable, IEnumerable<IAudio>
{
	IAudio this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	IAudio AddAudio(IAudio audio);

	IAudio AddAudio(Stream stream);

	IAudio AddAudio(byte[] audioData);
}
