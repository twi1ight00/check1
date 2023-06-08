using System;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;
using xfbd1009a0cbb9842;

namespace Aspose.Words.Fields;

public class FormField : SpecialChar
{
	internal const string x16ca60cbddb8385c = "\uf0a3";

	internal const string x9704435007550db9 = "\uf054";

	internal const string xc4bc4a7cdf6db771 = "Wingdings 2";

	private x58bf2a36f9adf9a9 x1b8d68194b6218f8;

	private Field x3e166e493d3a1827;

	internal static readonly string xb8fa1e789c415fba = new string('\u2002', 5);

	public override NodeType NodeType => NodeType.FormField;

	public string Name
	{
		get
		{
			return x1b8d68194b6218f8.x759aa16c2016a289;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			BookmarkStart bookmarkStart = x724e8b0eb9767138;
			if (bookmarkStart != null)
			{
				bookmarkStart.Bookmark.Name = value;
			}
			x1b8d68194b6218f8.x759aa16c2016a289 = value;
		}
	}

	public FieldType Type
	{
		get
		{
			if (xd1b40af56a8385d4 == null)
			{
				return FieldType.FieldNone;
			}
			return xd1b40af56a8385d4.Type;
		}
	}

	internal xdda013621290d582 xdda013621290d582 => Type switch
	{
		FieldType.FieldFormTextInput => xdda013621290d582.x09e38cfc94ebc64d, 
		FieldType.FieldFormCheckBox => xdda013621290d582.xfd2f38e457ba1955, 
		FieldType.FieldFormDropDown => xdda013621290d582.xca07ebdb4698a889, 
		_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gcpnmdgogdnogdepedlpjdcancjamnpapbhbfcobfcfcnbmcnmcdabkdabbejaienapecagfllmfmaegoalgcachepihklph", 947117777))), 
	};

	internal Field xd1b40af56a8385d4
	{
		get
		{
			if (x3e166e493d3a1827 == null)
			{
				Node parentNode = base.ParentNode;
				while (x3e166e493d3a1827 == null && parentNode != null)
				{
					x6435b7bbb0879a04 x6435b7bbb0879a = xe25d778fe9f1252a.x105bab38d511372f(parentNode);
					x3e166e493d3a1827 = x6435b7bbb0879a.xb5d8f9e48f1d338e(this);
					parentNode = parentNode.ParentNode;
				}
			}
			return x3e166e493d3a1827;
		}
	}

	public string Result
	{
		get
		{
			switch (Type)
			{
			case FieldType.FieldFormTextInput:
			{
				if (xd1b40af56a8385d4 == null)
				{
					return "";
				}
				string result = xd1b40af56a8385d4.Result;
				if (!(result == xb8fa1e789c415fba))
				{
					return result;
				}
				return "";
			}
			case FieldType.FieldFormCheckBox:
				if (!Checked)
				{
					return "0";
				}
				return "1";
			case FieldType.FieldFormDropDown:
				return x6e77c7675d1ac719;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bdblheilbeplbegmpdnmeeenidlnhobokcjoadapadhpicopinealbmalbdbebkbibbcnaicgmochbgdjbndnaeeppkefmbf", 1124511964)));
			}
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			switch (Type)
			{
			case FieldType.FieldFormTextInput:
				xd1b40af56a8385d4.Result = value;
				break;
			case FieldType.FieldFormCheckBox:
				Checked = xca004f56614e2431.xa93402510be8434e(value) != 0;
				break;
			case FieldType.FieldFormDropDown:
				x6e77c7675d1ac719 = value;
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fkbbllibflpbflgcdlnciledmkldlfceojjeekafekhfmjofmefgpimgpidhiikhmibibiiikdpiligjninjbiekdhlkjdcl", 1326190928)));
			}
		}
	}

	public string StatusText
	{
		get
		{
			return x1b8d68194b6218f8.x50bd293cbfa8c01a;
		}
		set
		{
			x1b8d68194b6218f8.x50bd293cbfa8c01a = value;
		}
	}

	public bool OwnStatus
	{
		get
		{
			return x1b8d68194b6218f8.x5a70ee0d6c0cb151;
		}
		set
		{
			x1b8d68194b6218f8.x5a70ee0d6c0cb151 = value;
		}
	}

	public string HelpText
	{
		get
		{
			return x1b8d68194b6218f8.x22f04e1437bdf856;
		}
		set
		{
			x1b8d68194b6218f8.x22f04e1437bdf856 = value;
		}
	}

	public bool OwnHelp
	{
		get
		{
			return x1b8d68194b6218f8.x0c2c83899c41d345;
		}
		set
		{
			x1b8d68194b6218f8.x0c2c83899c41d345 = value;
		}
	}

	public bool CalculateOnExit
	{
		get
		{
			return x1b8d68194b6218f8.x8cc2703314d01b16;
		}
		set
		{
			x1b8d68194b6218f8.x8cc2703314d01b16 = value;
		}
	}

	public string EntryMacro
	{
		get
		{
			return x1b8d68194b6218f8.x6ebae521c5565993;
		}
		set
		{
			x1b8d68194b6218f8.x6ebae521c5565993 = value;
		}
	}

	public string ExitMacro
	{
		get
		{
			return x1b8d68194b6218f8.xedb00d3630ef56d1;
		}
		set
		{
			x1b8d68194b6218f8.xedb00d3630ef56d1 = value;
		}
	}

	public bool Enabled
	{
		get
		{
			return x1b8d68194b6218f8.x9f2c0dc847992f03;
		}
		set
		{
			x1b8d68194b6218f8.x9f2c0dc847992f03 = value;
		}
	}

	public string TextInputFormat
	{
		get
		{
			return x1b8d68194b6218f8.xe8f8d8a7db32427b;
		}
		set
		{
			x1b8d68194b6218f8.xe8f8d8a7db32427b = value;
		}
	}

	public TextFormFieldType TextInputType
	{
		get
		{
			return x1b8d68194b6218f8.x98ed2e2b5602a6f1;
		}
		set
		{
			x1b8d68194b6218f8.x98ed2e2b5602a6f1 = value;
		}
	}

	public string TextInputDefault
	{
		get
		{
			return x1b8d68194b6218f8.x5e1adcb28cb5f299;
		}
		set
		{
			x1b8d68194b6218f8.x5e1adcb28cb5f299 = value;
			if (TextInputType == TextFormFieldType.Calculated)
			{
				Node x10aaa7cdfa38f = xd1b40af56a8385d4.Start.x03a9a1b8afdf52f9(NodeType.Run);
				x5699f8523a546a42.x52b190e626f65140(x10aaa7cdfa38f, x4ec19a117bbb0963: false, this, xead571f03cb4ee1d: false);
				DocumentBuilder documentBuilder = new DocumentBuilder(x357c90b33d6bb8e6());
				documentBuilder.MoveTo(this);
				documentBuilder.InsertField(value, "");
				xd1b40af56a8385d4.Update();
			}
		}
	}

	public int MaxLength
	{
		get
		{
			return x1b8d68194b6218f8.xc5c2fb4db5b8c3bd;
		}
		set
		{
			x1b8d68194b6218f8.xc5c2fb4db5b8c3bd = value;
		}
	}

	public DropDownItemCollection DropDownItems => x1b8d68194b6218f8.xc055d178db9e8d17;

	public int DropDownSelectedIndex
	{
		get
		{
			if (x1b8d68194b6218f8.x6cf648f1ac6f4032)
			{
				return x1b8d68194b6218f8.xfeefd92fb9bd0678;
			}
			return x1b8d68194b6218f8.x290a782f6c7cab2f;
		}
		set
		{
			x1b8d68194b6218f8.xfeefd92fb9bd0678 = value;
		}
	}

	internal string x6e77c7675d1ac719
	{
		get
		{
			int dropDownSelectedIndex = DropDownSelectedIndex;
			if (dropDownSelectedIndex < 0 || dropDownSelectedIndex >= DropDownItems.Count)
			{
				return "";
			}
			return DropDownItems[dropDownSelectedIndex];
		}
		set
		{
			for (int i = 0; i < DropDownItems.Count; i++)
			{
				if (x0d299f323d241756.x90637a473b1ceaaa(DropDownItems[i], value))
				{
					DropDownSelectedIndex = i;
					break;
				}
			}
		}
	}

	public bool Checked
	{
		get
		{
			if (x1b8d68194b6218f8.x7c5abf7ed147c26c)
			{
				return x1b8d68194b6218f8.x4ac39a4f11664c6b;
			}
			return x1b8d68194b6218f8.x5e6597fb50c93e39;
		}
		set
		{
			x1b8d68194b6218f8.x4ac39a4f11664c6b = value;
		}
	}

	public bool IsCheckBoxExactSize
	{
		get
		{
			return !x1b8d68194b6218f8.xbd91bc7364251d6d;
		}
		set
		{
			x1b8d68194b6218f8.xbd91bc7364251d6d = !value;
		}
	}

	public double CheckBoxSize
	{
		get
		{
			return x4574ea26106f0edb.x4610495f80b4c267(x1b8d68194b6218f8.x4bdafa5e724a058a);
		}
		set
		{
			x1b8d68194b6218f8.x4bdafa5e724a058a = x4574ea26106f0edb.x3f26fa43a4a41e70(value);
		}
	}

	internal BookmarkStart x724e8b0eb9767138
	{
		get
		{
			if (xd1b40af56a8385d4 == null)
			{
				return null;
			}
			BookmarkStart bookmarkStart = xd1b40af56a8385d4.Start.NextSibling as BookmarkStart;
			if (bookmarkStart == null)
			{
				bookmarkStart = xd1b40af56a8385d4.Start.PreviousSibling as BookmarkStart;
			}
			return bookmarkStart;
		}
	}

	internal x58bf2a36f9adf9a9 x58bf2a36f9adf9a9 => x1b8d68194b6218f8;

	internal FormField(DocumentBase doc, x58bf2a36f9adf9a9 formFieldPr, xeedad81aaed42a76 runPr)
		: base(doc, '\u0001', runPr)
	{
		x1b8d68194b6218f8 = formFieldPr;
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		FormField formField = (FormField)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		formField.x1b8d68194b6218f8 = (x58bf2a36f9adf9a9)x1b8d68194b6218f8.x8b61531c8ea35b85();
		formField.x3e166e493d3a1827 = null;
		return formField;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return Node.x9708eba393e07242(visitor.VisitFormField(this));
	}

	internal void x8d26c876d3c390f2()
	{
		if (xd1b40af56a8385d4 != null)
		{
			if (xd1b40af56a8385d4.Start.NextSibling is BookmarkStart bookmarkStart)
			{
				bookmarkStart.Remove();
				xd1b40af56a8385d4.Start.xdfa6ecc6f742f086.InsertBefore(bookmarkStart, xd1b40af56a8385d4.Start);
			}
			xd1b40af56a8385d4.Remove();
		}
	}

	public void SetTextInputValue(object newValue)
	{
		if (newValue == null)
		{
			throw new ArgumentNullException("newValue");
		}
		if (Type != FieldType.FieldFormTextInput)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bglechcfmgjfecaghghgngogngfhfgmhfbdiifkiifbjbfijffpjkegkdankjeelafllkpbmfejmdeanfehnoonnmcfoiolojddphckphdbaadiajnoambgbccnbcceckblckmbdnajdnaaegahekaoeppefgmlf", 1113213709)));
		}
		switch (TextInputType)
		{
		case TextFormFieldType.Regular:
		{
			xbc1709746b087e6c x67e7091832843e9a = x4d6668da4d2c085c(TextInputFormat);
			Result = xb7dbd7bb3ed97d5b.x041cc377735f8501((string)newValue, x67e7091832843e9a);
			break;
		}
		case TextFormFieldType.Number:
			Result = xca004f56614e2431.x3fefcbaee4514358(Convert.ToDouble(newValue), TextInputFormat, x5c4c72022ea54b2c: true);
			break;
		case TextFormFieldType.Date:
			Result = xb7dbd7bb3ed97d5b.x6bf3310acbc2c04f((DateTime)newValue, TextInputFormat);
			break;
		case TextFormFieldType.CurrentDate:
		case TextFormFieldType.CurrentTime:
		case TextFormFieldType.Calculated:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ihbhdjihnjphkjgiijnikjejdeljdjckcijkoialhdhliioljhfmdhmmlcdnogknehboehiomgpombgppfnppfeaiflamfcbbfjbkaacnfhcfeocnefddfmdaedeipjehdbfhdifcdpfncggodngjdehiclhaobigcjiocajhngjnbojecfkomlkoadljaklbbbmfaimebpmiagnkpmnkaeoipkoepbpllip", 1891135797)));
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cmkdinbecniecnpeangffnnfjmegihlgllchbmjhbmaijlhijgoimkfjmkmjfkdkjkkkojblhfilikplkkgmojnmajengfln", 509819501)));
		}
	}

	private static xbc1709746b087e6c x4d6668da4d2c085c(string x67e7091832843e9a)
	{
		x67e7091832843e9a = x67e7091832843e9a.ToLower();
		return x67e7091832843e9a switch
		{
			"uppercase" => xbc1709746b087e6c.xad26a7203634de8e, 
			"lowercase" => xbc1709746b087e6c.x3f230538ea01aa0e, 
			"first capital" => xbc1709746b087e6c.x4c95b3a38f1afc3a, 
			"title case" => xbc1709746b087e6c.xa6417f0b87702333, 
			_ => xbc1709746b087e6c.xb9715d2f06b63cf0, 
		};
	}
}
