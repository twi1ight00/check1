using System;
using System.Drawing;
using System.IO;
using Aspose.Words.Saving;
using x011d489fb9df7027;
using x077e797660ceec8d;
using x13f1efc79617a47b;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace Aspose.Words.Drawing;

public class Shape : ShapeBase
{
	private Stroke x63d5390c2563530e;

	private Fill x019fd9871a27bafe;

	private ImageData xd97c5d950974bed3;

	private OleFormat x0df8487320c1aacd;

	private TextBox xd96015015f96ed26;

	private TextPath x0614cada9782662e;

	private x6c285a52cba39f1f x6715c5cb3e56cbe9;

	private x3b45b45d0f60a2d2 x6bb17de1be3f324b;

	public override NodeType NodeType => NodeType.Shape;

	public StoryType StoryType => StoryType.Textbox;

	public bool Filled
	{
		get
		{
			return (bool)xfc928672852cc4c4(443);
		}
		set
		{
			x0817d5cde9e19bf6(443, value);
		}
	}

	public Color FillColor
	{
		get
		{
			return Fill.Color;
		}
		set
		{
			Fill.Color = value;
		}
	}

	internal bool xfd021ba15b56aba0
	{
		get
		{
			return (bool)xfc928672852cc4c4(511);
		}
		set
		{
			x0817d5cde9e19bf6(511, value);
		}
	}

	public bool Stroked
	{
		get
		{
			return Stroke.On;
		}
		set
		{
			Stroke.On = value;
		}
	}

	public double StrokeWeight
	{
		get
		{
			return Stroke.Weight;
		}
		set
		{
			Stroke.Weight = value;
		}
	}

	public Color StrokeColor
	{
		get
		{
			return Stroke.Color;
		}
		set
		{
			Stroke.Color = value;
		}
	}

	internal x17abde5b32777816 x17abde5b32777816
	{
		get
		{
			return (x17abde5b32777816)xfc928672852cc4c4(772);
		}
		set
		{
			x0817d5cde9e19bf6(772, value);
		}
	}

	internal x17abde5b32777816 x48bc60110e00bc62
	{
		get
		{
			return (x17abde5b32777816)xfc928672852cc4c4(773);
		}
		set
		{
			x0817d5cde9e19bf6(773, value);
		}
	}

	internal x17abde5b32777816 x1d5ba058e521f0c3
	{
		get
		{
			return (x17abde5b32777816)xfc928672852cc4c4(774);
		}
		set
		{
			x0817d5cde9e19bf6(774, value);
		}
	}

	internal string xd402a2e9eed80360
	{
		get
		{
			return (string)xfc928672852cc4c4(910);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x0817d5cde9e19bf6(910, value);
		}
	}

	internal string x5e4f8afadf326191
	{
		get
		{
			return (string)xfc928672852cc4c4(919);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x0817d5cde9e19bf6(919, value);
		}
	}

	internal bool x5867d7e869ae6955
	{
		get
		{
			return (bool)xfc928672852cc4c4(827);
		}
		set
		{
			x0817d5cde9e19bf6(827, value);
		}
	}

	public Stroke Stroke
	{
		get
		{
			if (x63d5390c2563530e == null)
			{
				x63d5390c2563530e = new Stroke(this);
			}
			return x63d5390c2563530e;
		}
	}

	public Fill Fill
	{
		get
		{
			if (x019fd9871a27bafe == null)
			{
				x019fd9871a27bafe = new Fill(this);
			}
			return x019fd9871a27bafe;
		}
	}

	public bool HasImage
	{
		get
		{
			if (base.CanHaveImage)
			{
				return ImageData.HasImage;
			}
			return false;
		}
	}

	internal bool x169baa05e57bf312
	{
		get
		{
			if (base.CanHaveImage)
			{
				return ImageData.x169baa05e57bf312;
			}
			return false;
		}
	}

	public ImageData ImageData
	{
		get
		{
			if (!base.CanHaveImage)
			{
				return null;
			}
			if (xd97c5d950974bed3 == null)
			{
				Document doc = base.Document as Document;
				xd97c5d950974bed3 = new ImageData(this, doc);
			}
			return xd97c5d950974bed3;
		}
	}

	public OleFormat OleFormat
	{
		get
		{
			if (!base.xa170cce2bc40bdf5)
			{
				return null;
			}
			if (x0df8487320c1aacd == null)
			{
				x0df8487320c1aacd = new OleFormat(this);
			}
			return x0df8487320c1aacd;
		}
	}

	internal bool x2e3d2d1def6f4dad
	{
		get
		{
			if (base.xa8228c6215bc2643)
			{
				return OleFormat.xb7e718098524b76c != null;
			}
			return false;
		}
	}

	public TextBox TextBox
	{
		get
		{
			if (xd96015015f96ed26 == null)
			{
				xd96015015f96ed26 = new TextBox(this);
			}
			return xd96015015f96ed26;
		}
	}

	public TextPath TextPath
	{
		get
		{
			if (x0614cada9782662e == null)
			{
				x0614cada9782662e = new TextPath(this);
			}
			return x0614cada9782662e;
		}
	}

	internal x3b45b45d0f60a2d2 x3b45b45d0f60a2d2
	{
		get
		{
			if (x048513c924d75f6b(1983) == null)
			{
				return null;
			}
			if (x6bb17de1be3f324b == null)
			{
				x6bb17de1be3f324b = new x3b45b45d0f60a2d2(this);
			}
			return x6bb17de1be3f324b;
		}
	}

	internal x6c285a52cba39f1f x6c285a52cba39f1f
	{
		get
		{
			if (x6715c5cb3e56cbe9 == null)
			{
				x6715c5cb3e56cbe9 = new x6c285a52cba39f1f(this);
			}
			return x6715c5cb3e56cbe9;
		}
	}

	internal new x5b865d49b2c8440d x5b865d49b2c8440d
	{
		get
		{
			return base.x5b865d49b2c8440d;
		}
		set
		{
			base.x5b865d49b2c8440d = value;
		}
	}

	public Paragraph FirstParagraph => (Paragraph)GetChild(NodeType.Paragraph, 0, isDeep: false);

	public Paragraph LastParagraph => (Paragraph)GetChild(NodeType.Paragraph, -1, isDeep: false);

	internal x1ba6afab4f42a0ee x1ba6afab4f42a0ee
	{
		get
		{
			if (base.xa8228c6215bc2643)
			{
				return x1ba6afab4f42a0ee.xd5a7a92b8cfb14b3;
			}
			if (base.x917b07206b752ba4)
			{
				if (!OleFormat.IsLink)
				{
					return x1ba6afab4f42a0ee.xc24de6454f8b0f37;
				}
				return x1ba6afab4f42a0ee.x1891c445b78b044b;
			}
			return x1ba6afab4f42a0ee.x4d0b9d4447ba7566;
		}
	}

	internal x44f2b8bf33b16275[] xa31cfc0117535bfa => (x44f2b8bf33b16275[])xfc928672852cc4c4(326);

	internal x08d932077485c285[] xdbed53246e7dd53a => (x08d932077485c285[])xfc928672852cc4c4(325);

	internal x40937ad35b1cf5f7[] x821a79f393210107 => (x40937ad35b1cf5f7[])xfc928672852cc4c4(342);

	internal x26d9ecb4bdf0456d x6b716952abd14950
	{
		get
		{
			object obj = x048513c924d75f6b(282);
			if (obj == null || (int)obj == -1)
			{
				return x26d9ecb4bdf0456d.x45260ad4b94166f2;
			}
			return new x26d9ecb4bdf0456d((int)obj | -16777216);
		}
	}

	internal bool x6bdad93be187fcba => (bool)xfc928672852cc4c4(380);

	internal float xffa1fc725bf36690 => (float)x4574ea26106f0edb.xa23e6b6c3169521d((int)xfc928672852cc4c4(459));

	internal int x14450b2cd7bcfcfa
	{
		get
		{
			return (int)xfc928672852cc4c4(339);
		}
		set
		{
			x0817d5cde9e19bf6(339, value);
		}
	}

	internal int xe915b3cb9284a483
	{
		get
		{
			return (int)xfc928672852cc4c4(340);
		}
		set
		{
			x0817d5cde9e19bf6(340, value);
		}
	}

	internal bool x3ffbaff53e6d8618
	{
		get
		{
			return (bool)xfc928672852cc4c4(190);
		}
		set
		{
			x0817d5cde9e19bf6(190, value);
		}
	}

	internal bool x4172593a937c6db2
	{
		get
		{
			return (bool)xfc928672852cc4c4(574);
		}
		set
		{
			x0817d5cde9e19bf6(574, value);
		}
	}

	internal bool xc764a1afacb94b7e
	{
		get
		{
			return (bool)xfc928672852cc4c4(700);
		}
		set
		{
			x0817d5cde9e19bf6(700, value);
		}
	}

	internal int xc99301776bd4ba37 => (int)xfc928672852cc4c4(720);

	internal int x31d3d3644e2e74e9 => (int)xfc928672852cc4c4(644);

	internal int x3a3b8d7bf035e50d => (int)xfc928672852cc4c4(645);

	internal int x165d00c485a7b2c9 => (int)xfc928672852cc4c4(715);

	internal int x1bfd866a2c8f48ad => (int)xfc928672852cc4c4(716);

	internal int xce70ad8fb60f0bb3 => (int)xfc928672852cc4c4(717);

	internal int xae0a5d9ef79b011d => (int)xfc928672852cc4c4(718);

	internal int x003664e735fb913b => (int)xfc928672852cc4c4(719);

	internal bool x1f468b359604fb97 => (bool)xfc928672852cc4c4(765);

	internal int x4528634ab490365b => (int)xfc928672852cc4c4(705);

	internal int x7e78f33051281ce9 => (int)xfc928672852cc4c4(704);

	internal xb156f8ae92094cbb xc6152e5b7b3767b6 => (xb156f8ae92094cbb)xfc928672852cc4c4(713);

	internal x7efbe0a2dc0d335f[] x89e0f1069b9786a1 => (x7efbe0a2dc0d335f[])xfc928672852cc4c4(341);

	internal xbc9979937c838d75[] x055ad2518a1ca81c
	{
		get
		{
			xbc9979937c838d75[] array = (xbc9979937c838d75[])xfc928672852cc4c4(343);
			if (array != null && array.Length > 0)
			{
				return array;
			}
			xbc9979937c838d75 xbc9979937c838d = new xbc9979937c838d75();
			xbc9979937c838d.x72d92bd1aff02e37 = new x06e4f09a90ca939a(-base.x06c65daad0c0656c, isFormula: false);
			xbc9979937c838d.xe360b1885d8d4a41 = new x06e4f09a90ca939a(-base.x399bb78ac51a4081, isFormula: false);
			xbc9979937c838d.x419ba17a5322627b = new x06e4f09a90ca939a(base.x133d653c1b9b01f2 - base.x06c65daad0c0656c, isFormula: false);
			xbc9979937c838d.x9bcb07e204e30218 = new x06e4f09a90ca939a(base.xc97e136f0019c237 - base.x399bb78ac51a4081, isFormula: false);
			return new xbc9979937c838d75[1] { xbc9979937c838d };
		}
		set
		{
			x0817d5cde9e19bf6(343, value);
		}
	}

	internal bool x22d2b300aac1d857 => (bool)xfc928672852cc4c4(442);

	internal Shape(DocumentBase doc)
		: base(doc)
	{
	}

	public Shape(DocumentBase doc, ShapeType shapeType)
		: this(doc)
	{
		if (shapeType == ShapeType.OleControl || shapeType == ShapeType.OleObject || shapeType == ShapeType.NonPrimitive || shapeType == ShapeType.CustomShape)
		{
			throw new NotSupportedException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cddonekohfbpefipcfppefganpmandebjelbjdcccdjcceadadhdiondidfekcmeacdfmckfobbgjcigdnogpbghdbnhkmdilblimacjkajjbbakllgkmaokoaflcamlepcmkljm", 573498095)));
		}
		x88d1b78392d1a0ab(shapeType);
	}

	internal static Shape xb939ebca8a836c60(Document x6beba47238e0ade6)
	{
		Shape shape = new Shape(x6beba47238e0ade6, ShapeType.Rectangle);
		shape.WrapType = WrapType.Inline;
		shape.Filled = true;
		shape.FillColor = x6c285a52cba39f1f.xf834c2490de2a834.xc7656a130b2889c7();
		shape.Stroked = false;
		shape.x6c285a52cba39f1f.x173949c9cf8653ad = true;
		shape.x6c285a52cba39f1f.xd1fa05894bebebb2 = true;
		shape.Height = 1.5;
		shape.xf524ccc95fe8e714(x6beba47238e0ade6.FirstSection.PageSetup.x887b872a95caaab5);
		shape.x6c285a52cba39f1f.x9472539ef71e166c = 100.0;
		return shape;
	}

	internal static Shape x37dbdc5e220f1c5a(Document x6beba47238e0ade6, x4fdf549af9de6b97 x9cd0b8c5999d2c9d, double x9b0739496f8b5475, double x4d5aabc7a55b12ba)
	{
		Shape shape = new Shape(x6beba47238e0ade6, ShapeType.Image);
		shape.Width = x9b0739496f8b5475;
		shape.Height = x4d5aabc7a55b12ba;
		ImageSaveOptions imageSaveOptions = new ImageSaveOptions(SaveFormat.Png);
		imageSaveOptions.Resolution = 200f;
		using x3cd5d648729cd9b6 x3cd5d648729cd9b = x0a376fc3a80043f7.xf5af41f85264e71d(x9cd0b8c5999d2c9d, new SizeF((float)x9b0739496f8b5475, (float)x4d5aabc7a55b12ba), imageSaveOptions);
		using MemoryStream memoryStream = new MemoryStream();
		x3cd5d648729cd9b.x76d9d85825f57cda(memoryStream);
		memoryStream.Position = 0L;
		shape.ImageData.SetImage(memoryStream);
		return shape;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitShapeStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitShapeEnd(this);
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		Shape shape = (Shape)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		shape.x63d5390c2563530e = null;
		shape.x019fd9871a27bafe = null;
		shape.xd97c5d950974bed3 = null;
		shape.x0df8487320c1aacd = null;
		shape.xd96015015f96ed26 = null;
		shape.x0614cada9782662e = null;
		shape.x6715c5cb3e56cbe9 = null;
		shape.x6bb17de1be3f324b = null;
		return shape;
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x2b1ee3a87b36a988.xb6578aa94903986e(x40e458b3a58f5782);
	}

	internal static bool x2e634d5c614a25de(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9 != null)
		{
			if (!x5770cdefd8931aa9.Filled)
			{
				return x5770cdefd8931aa9.HasImage;
			}
			return true;
		}
		return false;
	}

	internal int x9036b7becf593874(int xc0c4c459c6ccbd00)
	{
		return (int)xfc928672852cc4c4(xc0c4c459c6ccbd00 switch
		{
			1 => 327, 
			2 => 328, 
			3 => 329, 
			4 => 330, 
			5 => 331, 
			6 => 332, 
			7 => 333, 
			8 => 334, 
			9 => 335, 
			10 => 336, 
			_ => throw new ArgumentOutOfRangeException("index"), 
		});
	}
}
