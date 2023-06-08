using System.Collections;
using Aspose;
using Aspose.Words;
using Aspose.Words.Fields;
using x6c95d9cf46ff5f25;
using xf989f31a236ff98c;
using xfbd1009a0cbb9842;

namespace x381fb081d11d6275;

internal abstract class x6868017fd9012087
{
	private readonly bool xcfbeca09e1c9f8be;

	private readonly bool x3c7a0acbe0f94ed5;

	private readonly x08802e9e984cd3ee x5a7a1d229173bf5d;

	private readonly x05df33911093beb0 x230c333abfdbfccd;

	private readonly Hashtable x4381c8054f7a3561;

	private bool xd1cc6e18811e7812;

	protected x6868017fd9012087(Document document, bool exportTocPageNumbers, bool exportTextInputFormFieldAsText, x08802e9e984cd3ee runWriter, x05df33911093beb0 hyperlinkWriter)
	{
		xcfbeca09e1c9f8be = exportTocPageNumbers;
		x3c7a0acbe0f94ed5 = exportTextInputFormFieldAsText;
		x5a7a1d229173bf5d = runWriter;
		x230c333abfdbfccd = hyperlinkWriter;
		x4381c8054f7a3561 = xe25d778fe9f1252a.xaacd1adf784d6cb4(document);
	}

	internal void x8605874f1b4c6798(FieldStart xa6315bf377f6364c)
	{
		Field field = (Field)x4381c8054f7a3561[xa6315bf377f6364c];
		if (field != null)
		{
			switch (xa6315bf377f6364c.FieldType)
			{
			case FieldType.FieldHyperlink:
			{
				xae25961a48dae6ad xae25961a48dae6ad = (xae25961a48dae6ad)field;
				x230c333abfdbfccd.x4e44079093b28b81(xae25961a48dae6ad.x58c712b0d1d1c39b, xae25961a48dae6ad.x42f4c234c9358072, xe389b456117f37b2: false);
				break;
			}
			case FieldType.FieldGoToButton:
			case FieldType.FieldMacroButton:
				x5a7a1d229173bf5d.xa7aaf885c26f719e(field);
				break;
			case FieldType.FieldSymbol:
				x5a7a1d229173bf5d.x9085a9baa2b43723(field);
				break;
			case FieldType.FieldTOC:
				xd1cc6e18811e7812 = true;
				break;
			}
		}
	}

	internal void x98ab27c28fa098eb(FieldEnd xc87e4e475724f9c3)
	{
		switch (xc87e4e475724f9c3.FieldType)
		{
		case FieldType.FieldHyperlink:
			x230c333abfdbfccd.x1210e8a0b401d5a2();
			break;
		case FieldType.FieldTOC:
			xd1cc6e18811e7812 = false;
			break;
		}
	}

	[JavaThrows(true)]
	internal abstract VisitorAction x85599597a4d57020(FormField x0ab8fc6e4b8e829c);

	internal bool xa29fb79ffcf5f9ba(FieldType x77ce91e5324df734)
	{
		switch (x77ce91e5324df734)
		{
		case FieldType.FieldSet:
		case FieldType.FieldSymbol:
			return true;
		case FieldType.FieldFormTextInput:
			return !x3c7a0acbe0f94ed5;
		case FieldType.FieldPageRef:
			if (xd1cc6e18811e7812)
			{
				return !xcfbeca09e1c9f8be;
			}
			return false;
		default:
			return false;
		}
	}

	internal bool xc4712ab603fe2431(Run xb0e5d73738e62f9e)
	{
		if (xcfbeca09e1c9f8be || !xd1cc6e18811e7812)
		{
			return false;
		}
		if (!(xb0e5d73738e62f9e.NextSibling is FieldStart fieldStart) || fieldStart.FieldType != FieldType.FieldPageRef)
		{
			return false;
		}
		return x0d299f323d241756.x70405672eb3bbb86(xb0e5d73738e62f9e.Text);
	}
}
