using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("76e0eac6-3a7f-41cc-bcbc-52090b045ff4")]
public interface IPortion : IPresentationComponent, ISlideComponent
{
	IPortionFormat PortionFormat { get; }

	string Text { get; set; }

	IField Field { get; }

	ISlideComponent AsISlideComponent { get; }

	IPortionFormatEffectiveData CreatePortionFormatEffective();

	void AddField(IFieldType fieldType);

	void AddField(string internalString);

	void RemoveField();
}
