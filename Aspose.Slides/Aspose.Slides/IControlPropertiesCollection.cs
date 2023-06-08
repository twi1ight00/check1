using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("6f4e6038-be30-4481-a4c8-1c99072308a1")]
public interface IControlPropertiesCollection : IEnumerable, IEnumerable<KeyValuePair<string, string>>
{
	int Count { get; }

	string this[string name] { get; set; }

	ICollection NamesOfProperties { get; }

	IEnumerable AsIEnumerable { get; }

	void Add(string name, string value);

	void Remove(string name);

	void Clear();
}
