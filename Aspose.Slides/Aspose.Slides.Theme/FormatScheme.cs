using ns4;

namespace Aspose.Slides.Theme;

public class FormatScheme : IPresentationComponent, ISlideComponent, IFormatScheme
{
	private Theme theme_0;

	private uint uint_0;

	private string string_0;

	private FillFormatCollection fillFormatCollection_0;

	private LineFormatCollection lineFormatCollection_0;

	private EffectStyleCollection effectStyleCollection_0;

	private FillFormatCollection fillFormatCollection_1;

	internal string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			method_1();
		}
	}

	public IFillFormatCollection FillStyles => fillFormatCollection_0;

	public ILineFormatCollection LineStyles => lineFormatCollection_0;

	public IEffectStyleCollection EffectStyles => effectStyleCollection_0;

	public IFillFormatCollection BackgroundFillStyles => fillFormatCollection_1;

	internal uint Version => uint_0 + fillFormatCollection_0.Version + lineFormatCollection_0.Version + effectStyleCollection_0.Version + fillFormatCollection_1.Version;

	ISlideComponent IFormatScheme.AsISlideComponent => this;

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	public IBaseSlide Slide => null;

	public IPresentation Presentation => theme_0.Presentation;

	internal void method_0(FormatScheme formatScheme)
	{
		fillFormatCollection_0.method_0(formatScheme.fillFormatCollection_0);
		lineFormatCollection_0.method_0(formatScheme.lineFormatCollection_0);
		effectStyleCollection_0.method_0(formatScheme.effectStyleCollection_0);
		fillFormatCollection_1.method_0(formatScheme.fillFormatCollection_1);
		theme_0 = formatScheme.theme_0;
		string_0 = formatScheme.string_0;
		method_1();
	}

	internal FormatScheme(Theme parent)
	{
		theme_0 = parent;
		fillFormatCollection_0 = new FillFormatCollection(this);
		lineFormatCollection_0 = new LineFormatCollection(this);
		effectStyleCollection_0 = new EffectStyleCollection(this);
		fillFormatCollection_1 = new FillFormatCollection(this);
	}

	private void method_1()
	{
		uint_0++;
	}

	internal void method_2()
	{
		Class1074.smethod_0(this);
		method_1();
	}
}
