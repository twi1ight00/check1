using System;
using System.Threading;
using Aspose.Slides.Charts;
using ns4;
using ns63;

namespace Aspose.Slides;

public class TextStyle : ITextStyle
{
	public readonly byte MaxLevelCount = 9;

	internal ParagraphFormat[] paragraphFormat_0 = new ParagraphFormat[10];

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	private ParagraphFormat.Delegate9 delegate9_0;

	internal static readonly TextStyle[] textStyle_0 = new TextStyle[0];

	internal Enum449? nullable_0 = null;

	public IParagraphFormat DefaultParagraphFormat => paragraphFormat_0[0];

	internal uint Version
	{
		get
		{
			uint num = uint_0;
			ParagraphFormat[] array = paragraphFormat_0;
			foreach (ParagraphFormat paragraphFormat in array)
			{
				num += paragraphFormat.Version;
			}
			return num;
		}
	}

	internal IPresentationComponent Parent => ipresentationComponent_0;

	internal event ParagraphFormat.Delegate9 m_styleChanged
	{
		add
		{
			ParagraphFormat.Delegate9 @delegate = delegate9_0;
			ParagraphFormat.Delegate9 delegate2;
			do
			{
				delegate2 = @delegate;
				ParagraphFormat.Delegate9 value2 = (ParagraphFormat.Delegate9)Delegate.Combine(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate9_0, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
		remove
		{
			ParagraphFormat.Delegate9 @delegate = delegate9_0;
			ParagraphFormat.Delegate9 delegate2;
			do
			{
				delegate2 = @delegate;
				ParagraphFormat.Delegate9 value2 = (ParagraphFormat.Delegate9)Delegate.Remove(delegate2, value);
				@delegate = Interlocked.CompareExchange(ref delegate9_0, value2, delegate2);
			}
			while ((object)@delegate != delegate2);
		}
	}

	internal TextStyle(IPresentationComponent parent)
	{
		if (parent != null && !(parent is MasterSlide) && !(parent is Presentation) && !(parent is IFormattedTextContainer) && !(parent is TextFrame))
		{
			throw new ArgumentException();
		}
		ipresentationComponent_0 = parent;
		method_0(0);
	}

	internal void method_0(int levelInternalIndex)
	{
		paragraphFormat_0[levelInternalIndex] = new ParagraphFormat(ipresentationComponent_0);
		paragraphFormat_0[levelInternalIndex].m_changedEvent_OldMode += method_9;
		method_10();
	}

	internal void method_1(int levelInternalIndex, ParagraphFormat source)
	{
		paragraphFormat_0[levelInternalIndex] = new ParagraphFormat(source, ipresentationComponent_0);
		paragraphFormat_0[levelInternalIndex].m_changedEvent_OldMode += method_9;
		method_10();
	}

	internal void method_2(TextStyle source)
	{
		for (int i = 0; i < source.paragraphFormat_0.Length; i++)
		{
			if (source.paragraphFormat_0[i] != null)
			{
				paragraphFormat_0[i] = new ParagraphFormat(source.paragraphFormat_0[i], ipresentationComponent_0);
			}
			else
			{
				paragraphFormat_0[i] = null;
			}
		}
		method_10();
	}

	public IParagraphFormat GetLevel(int index)
	{
		method_11(index);
		return paragraphFormat_0[index + 1];
	}

	internal IParagraphFormat method_3(int index)
	{
		method_11(index);
		if (paragraphFormat_0[index + 1] == null)
		{
			method_0(index + 1);
		}
		return paragraphFormat_0[index + 1];
	}

	internal ParagraphFormat method_4(int index)
	{
		method_11(index);
		if (paragraphFormat_0[index + 1] == null)
		{
			method_1(index + 1, paragraphFormat_0[0]);
		}
		return paragraphFormat_0[index + 1];
	}

	internal void method_5(ITextStyle oldDefault, ITextStyle newDefault)
	{
		for (int i = 0; i < 8; i++)
		{
			ParagraphFormat paragraphFormat = (ParagraphFormat)oldDefault.GetLevel(i);
			ParagraphFormat paragraphFormat2 = (ParagraphFormat)newDefault.GetLevel(i);
			if (paragraphFormat != null || paragraphFormat2 != null)
			{
				ParagraphFormat paragraphFormat3 = method_4(i);
				if (paragraphFormat == null)
				{
					paragraphFormat = (ParagraphFormat)oldDefault.DefaultParagraphFormat;
				}
				if (paragraphFormat2 == null)
				{
					paragraphFormat2 = (ParagraphFormat)newDefault.DefaultParagraphFormat;
				}
				paragraphFormat3.method_6(paragraphFormat, paragraphFormat2);
			}
		}
		((ParagraphFormat)DefaultParagraphFormat).method_6((ParagraphFormat)oldDefault.DefaultParagraphFormat, (ParagraphFormat)newDefault.DefaultParagraphFormat);
	}

	internal ParagraphFormat method_6(IParagraphFormat paraProps)
	{
		if (paraProps == null)
		{
			return method_8(-1);
		}
		return paragraphFormat_0[0].method_3(paraProps);
	}

	internal IParagraphFormat method_7(int index, IParagraphFormat paraProps)
	{
		if (paraProps == null)
		{
			return method_8(index);
		}
		method_11(index);
		if (paragraphFormat_0[index + 1] != null)
		{
			return paragraphFormat_0[index + 1].method_3(paraProps);
		}
		return paraProps;
	}

	internal ParagraphFormat method_8(int index)
	{
		method_11(index);
		if (paragraphFormat_0[index + 1] != null)
		{
			return new ParagraphFormat(paragraphFormat_0[index + 1], ipresentationComponent_0);
		}
		return null;
	}

	internal void method_9(ParagraphFormat paragraph)
	{
		if (Class21.bool_0 && delegate9_0 != null)
		{
			delegate9_0(paragraph);
		}
	}

	private void method_10()
	{
		uint_0++;
	}

	private void method_11(int index)
	{
		if (index < 0 || index > 8)
		{
			throw new IndexOutOfRangeException("Level index must lay in 0..8 interval.");
		}
	}
}
