using Aspose.Slides;
using Aspose.Slides.Vba;
using ns53;
using ns71;

namespace ns18;

internal class Class246
{
	internal void method_0(byte[] vbaProjectData, IPresentation presentation)
	{
		if (vbaProjectData != null)
		{
			Presentation presentation2 = (Presentation)presentation;
			presentation2.VbaProjectRootStorage = new Class3542(vbaProjectData);
			presentation2.VbaProject = new VbaProject(presentation2.VbaProjectRootStorage);
		}
	}

	internal void method_1(Class1342 vbaProjectEntry, IPresentation presentation)
	{
		if (((Presentation)presentation).VbaProjectRootStorage != null)
		{
			vbaProjectEntry.Data = ((Presentation)presentation).VbaProjectRootStorage.ToBinary();
		}
	}
}
