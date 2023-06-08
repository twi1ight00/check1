using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Web;
using Aspose.Words.BuildingBlocks;
using Aspose.Words.Fields;
using Aspose.Words.Markup;
using Aspose.Words.Properties;
using Aspose.Words.Rendering;
using Aspose.Words.Reporting;
using Aspose.Words.Saving;
using Aspose.Words.Settings;
using Aspose.Words.Tables;
using x13cd31bb39e0b7ea;
using x13f1efc79617a47b;
using x16f9a31f749b8bb1;
using x1c8faa688b1f0b0c;
using x2182451cabb5c30d;
using x28925c9b27b37a46;
using x2cc366c8657e2b6a;
using x452f379ec5921195;
using x4a820b097ff6c983;
using x4e7201a131ebc6f0;
using x583d72a986201ed7;
using x59d6a4fc5007b7a4;
using x6a42c37b95e9caa1;
using x6c95d9cf46ff5f25;
using x79490184cecf12a1;
using x79578da6a8a3ae37;
using x85732faf56f7825d;
using x9b5b1a17490bd5f3;
using x9db5f2e5af3d596e;
using xa604c4d210ae0581;
using xb92b7270f78a4e8d;
using xc76255e87e5986c6;
using xcf014befd8b52c3b;
using xd2754ae26d400653;
using xe9865c3fb834da49;
using xf989f31a236ff98c;
using xf9a9481c3f63a419;
using xfbd1009a0cbb9842;
using xfce5b6a304778b89;

namespace Aspose.Words;

[JavaGenericArguments("DocumentBase<Node>")]
public class Document : DocumentBase, x38e21b53aa8148da
{
	internal const int xcce79d345753d0e0 = 8;

	private static readonly char[] x89619a4da9836b3f = new char[2] { '/', '\\' };

	private BuiltInDocumentProperties x2b8ab599d91359f7 = new BuiltInDocumentProperties();

	private CustomDocumentProperties x1512b9cd154b8a9d = new CustomDocumentProperties();

	private GlossaryDocument x8c14d55e2e8c412a;

	private x3dabda6865ed239d xd2714535f669c453;

	private CustomXmlPartCollection xab1af01fadae9ef6 = new CustomXmlPartCollection();

	private CustomPartCollection x30390e7207fe393e = new CustomPartCollection();

	private readonly DigitalSignatureCollection x3e8bd7063ccb8c0d = new DigitalSignatureCollection();

	private x227665e444fb500a x57e44a48db954d01;

	private byte[] x37d66afd5c6e9f25;

	private MemoryStream xf95cbd0e4e8ef839;

	private byte[] x25f59a48c797df63;

	private ArrayList xecc6de3be62f4102;

	private ArrayList x61effb22c4d503be;

	private xe7be411416cfcd54 x376d1d34953625f5;

	private byte[] x08c28142e937fa8b;

	private ArrayList x91aa9e2e041665fa;

	private xa0a845678e16cf58 x92cfec29a58b2394;

	private bool x0e7e7ed52da8938b;

	private readonly string xa1b6127f243e7e06;

	private LoadFormat xdb03ba346bcbcf22;

	private string x62ff3dabf0a6c41f;

	private xdeb77ea37ad74c56 xd5f4d4b5bdd8e58a = new xdeb77ea37ad74c56();

	private SectionCollection x91b4b3c73382cdb1;

	private MailMerge x8047454048e4589b;

	private xcde671c53995c411 xea05b90271141e94;

	private Hashtable x42a14c47764d1e79;

	private FootnoteOptions xce12c3e8eb510bf2;

	private FootnoteOptions x5d55ff5fadb3fbf1;

	private RevisionCollection xf49987382e3c3049;

	private int x813e960a7bc47821 = 256000000;

	private FieldOptions x702e297d6b8ec02d;

	private x5408c1b8277b7b1a x0dddace2e64cefd5;

	public string AttachedTemplate
	{
		get
		{
			return base.xdade2366eaa6f915.x8c0ad447fda248da;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			base.xdade2366eaa6f915.x8c0ad447fda248da = value;
		}
	}

	public bool ShadeFormData
	{
		get
		{
			return !base.xdade2366eaa6f915.x75c79d4f5c4f8bd1;
		}
		set
		{
			base.xdade2366eaa6f915.x75c79d4f5c4f8bd1 = !value;
		}
	}

	public bool TrackRevisions
	{
		get
		{
			return base.xdade2366eaa6f915.x98c0ec6ac7570a99;
		}
		set
		{
			base.xdade2366eaa6f915.x98c0ec6ac7570a99 = value;
		}
	}

	public override NodeType NodeType => NodeType.Document;

	public BuiltInDocumentProperties BuiltInDocumentProperties => x2b8ab599d91359f7;

	public CustomDocumentProperties CustomDocumentProperties => x1512b9cd154b8a9d;

	public MailMerge MailMerge
	{
		get
		{
			if (x8047454048e4589b == null)
			{
				x8047454048e4589b = new MailMerge(this);
			}
			return x8047454048e4589b;
		}
	}

	public ProtectionType ProtectionType => base.xdade2366eaa6f915.xcadc354ab6a177f1.x491ce6cbe2c9a184;

	internal xcadc354ab6a177f1 xcadc354ab6a177f1 => base.xdade2366eaa6f915.xcadc354ab6a177f1;

	public SectionCollection Sections
	{
		get
		{
			if (x91b4b3c73382cdb1 == null)
			{
				x91b4b3c73382cdb1 = new SectionCollection(this);
			}
			return x91b4b3c73382cdb1;
		}
	}

	public Section FirstSection => (Section)GetChild(NodeType.Section, 0, isDeep: false);

	public Section LastSection => (Section)GetChild(NodeType.Section, -1, isDeep: false);

	public ViewOptions ViewOptions => base.xdade2366eaa6f915.x17bade2eb7f9764f;

	public WriteProtection WriteProtection => base.xdade2366eaa6f915.xc57807e17cfa13d2;

	public CompatibilityOptions CompatibilityOptions => base.xdade2366eaa6f915.xe322902ca0e695f5;

	public MailMergeSettings MailMergeSettings
	{
		get
		{
			return base.xdade2366eaa6f915.xe690cef2446c7d46;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			base.xdade2366eaa6f915.xe690cef2446c7d46 = value;
		}
	}

	public bool HasRevisions => Revisions.Count != 0;

	public bool HasMacros => x376d1d34953625f5 != null;

	internal bool x55676d6d0c3d48c0
	{
		get
		{
			if (!xf6b81fe1e8a261f5 && !xd4f5fcbd0eb0353a)
			{
				return x6241a8bc689c088a;
			}
			return true;
		}
	}

	internal bool xf6b81fe1e8a261f5
	{
		get
		{
			if (x25f59a48c797df63 != null)
			{
				return x25f59a48c797df63.Length > 0;
			}
			return false;
		}
	}

	internal bool xd4f5fcbd0eb0353a
	{
		get
		{
			if (xecc6de3be62f4102 != null)
			{
				return xecc6de3be62f4102.Count > 0;
			}
			return false;
		}
	}

	internal bool x6241a8bc689c088a
	{
		get
		{
			if (x61effb22c4d503be != null)
			{
				return x61effb22c4d503be.Count > 0;
			}
			return false;
		}
	}

	public int VersionsCount => base.xdade2366eaa6f915.xb33c79064acb66c7;

	public double DefaultTabStop
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2(base.xdade2366eaa6f915.xd72f9bc5cc53fc1c);
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			base.xdade2366eaa6f915.xd72f9bc5cc53fc1c = x4574ea26106f0edb.x88bf16f2386d633e(value);
		}
	}

	public CustomXmlPartCollection CustomXmlParts
	{
		get
		{
			return xab1af01fadae9ef6;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "customXmlParts");
			xab1af01fadae9ef6 = value;
		}
	}

	public CustomPartCollection PackageCustomParts
	{
		get
		{
			return x30390e7207fe393e;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "packageCustomParts");
			x30390e7207fe393e = value;
		}
	}

	internal byte[] xa3c04447aa84f70f
	{
		get
		{
			return x37d66afd5c6e9f25;
		}
		set
		{
			x37d66afd5c6e9f25 = value;
		}
	}

	internal MemoryStream x70813fadbf467780
	{
		get
		{
			return xf95cbd0e4e8ef839;
		}
		set
		{
			xf95cbd0e4e8ef839 = value;
		}
	}

	internal byte[] x1bb9c356aa4ee24d
	{
		get
		{
			return x25f59a48c797df63;
		}
		set
		{
			x25f59a48c797df63 = value;
		}
	}

	internal ArrayList x92fa7c4d9fc66489
	{
		get
		{
			return xecc6de3be62f4102;
		}
		set
		{
			xecc6de3be62f4102 = value;
		}
	}

	internal ArrayList xd971f86352b6d53c
	{
		get
		{
			return x61effb22c4d503be;
		}
		set
		{
			x61effb22c4d503be = value;
		}
	}

	internal xe7be411416cfcd54 x92e2e3377da135e8
	{
		get
		{
			return x376d1d34953625f5;
		}
		set
		{
			x376d1d34953625f5 = value;
		}
	}

	internal byte[] xd7b817e9f42390ee
	{
		get
		{
			return x08c28142e937fa8b;
		}
		set
		{
			x08c28142e937fa8b = value;
		}
	}

	internal ArrayList x3829bffd91c3b45d
	{
		get
		{
			return x91aa9e2e041665fa;
		}
		set
		{
			x91aa9e2e041665fa = value;
		}
	}

	internal xa0a845678e16cf58 xa0a845678e16cf58
	{
		get
		{
			return x92cfec29a58b2394;
		}
		set
		{
			x92cfec29a58b2394 = value;
		}
	}

	public VariableCollection Variables => base.x8513e2047b99ae50;

	public GlossaryDocument GlossaryDocument
	{
		get
		{
			return x8c14d55e2e8c412a;
		}
		set
		{
			x8c14d55e2e8c412a = value;
		}
	}

	internal string xb93d084d48e486dd
	{
		get
		{
			return x62ff3dabf0a6c41f;
		}
		set
		{
			x62ff3dabf0a6c41f = value;
		}
	}

	public string OriginalFileName => xa1b6127f243e7e06;

	public LoadFormat OriginalLoadFormat => xdb03ba346bcbcf22;

	public DigitalSignatureCollection DigitalSignatures => x3e8bd7063ccb8c0d;

	internal bool x6cb2cfca19c7adb6
	{
		get
		{
			return x0e7e7ed52da8938b;
		}
		set
		{
			x0e7e7ed52da8938b = value;
		}
	}

	internal x227665e444fb500a x227665e444fb500a
	{
		get
		{
			return x57e44a48db954d01;
		}
		set
		{
			x57e44a48db954d01 = value;
		}
	}

	internal x5408c1b8277b7b1a x5408c1b8277b7b1a
	{
		get
		{
			return x0dddace2e64cefd5;
		}
		set
		{
			x0dddace2e64cefd5 = value;
		}
	}

	internal bool xc6ce8b20496b71f5 => xea05b90271141e94 != null;

	internal xcde671c53995c411 xcde671c53995c411 => x410db0f4a89a6ef1(x24af0daafcd8fb8c: true);

	internal xdeb77ea37ad74c56 xdeb77ea37ad74c56 => xd5f4d4b5bdd8e58a;

	internal Hashtable x0b16d2d2ced2de05
	{
		get
		{
			if (x42a14c47764d1e79 == null)
			{
				x42a14c47764d1e79 = new Hashtable();
			}
			return x42a14c47764d1e79;
		}
	}

	public int PageCount => xcde671c53995c411.xd44988f225497f3a;

	public RevisionCollection Revisions
	{
		get
		{
			if (xf49987382e3c3049 == null)
			{
				xf49987382e3c3049 = new RevisionCollection(this);
			}
			return xf49987382e3c3049;
		}
	}

	public FootnoteOptions FootnoteOptions
	{
		get
		{
			if (xce12c3e8eb510bf2 == null)
			{
				xce12c3e8eb510bf2 = new FootnoteOptions(this, FootnoteType.Footnote);
			}
			return xce12c3e8eb510bf2;
		}
	}

	public FootnoteOptions EndnoteOptions
	{
		get
		{
			if (x5d55ff5fadb3fbf1 == null)
			{
				x5d55ff5fadb3fbf1 = new FootnoteOptions(this, FootnoteType.Endnote);
			}
			return x5d55ff5fadb3fbf1;
		}
	}

	public FieldOptions FieldOptions
	{
		get
		{
			if (x702e297d6b8ec02d == null)
			{
				x702e297d6b8ec02d = new FieldOptions();
			}
			return x702e297d6b8ec02d;
		}
	}

	internal Document(bool isLoadBlank)
	{
		if (isLoadBlank)
		{
			x67472f7b3890110b();
			base.xdade2366eaa6f915.xe322902ca0e695f5.UICompat97To2003 = false;
		}
	}

	public Document()
		: this(isLoadBlank: true)
	{
	}

	public Document(string fileName)
		: this(fileName, null)
	{
	}

	public Document(string fileName, LoadOptions loadOptions)
		: this(isLoadBlank: false)
	{
		x0d299f323d241756.x48501aec8e48c869(fileName, "fileName");
		xa1b6127f243e7e06 = fileName;
		x62ff3dabf0a6c41f = Path.GetDirectoryName(fileName);
		using Stream xcf18e5243f8d5fd = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
		x5d95f5f98c940295(xcf18e5243f8d5fd, loadOptions);
	}

	public Document(Stream stream)
		: this(stream, null)
	{
	}

	public Document(Stream stream, LoadOptions loadOptions)
		: this(isLoadBlank: false)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		x5d95f5f98c940295(stream, loadOptions);
	}

	internal override x3dabda6865ed239d x9bb3f6e28fa55f34()
	{
		return xd2714535f669c453;
	}

	internal void x18ee99b6e1fced19(x3dabda6865ed239d x8ad4cdceb54e447f)
	{
		xd2714535f669c453 = x8ad4cdceb54e447f;
	}

	internal int xdebf548a9003abc2()
	{
		return x813e960a7bc47821++;
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		Document document = (Document)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		document.x2b8ab599d91359f7 = (BuiltInDocumentProperties)x2b8ab599d91359f7.x8b61531c8ea35b85();
		document.x1512b9cd154b8a9d = (CustomDocumentProperties)x1512b9cd154b8a9d.x8b61531c8ea35b85();
		if (x8c14d55e2e8c412a != null)
		{
			document.x8c14d55e2e8c412a = (GlossaryDocument)x8c14d55e2e8c412a.x8b61531c8ea35b85(x7a5f12b98e34a590: true, xe870d6f33992ceb4);
		}
		if (xd2714535f669c453 != null)
		{
			document.xd2714535f669c453 = xd2714535f669c453.x8b61531c8ea35b85();
		}
		document.xab1af01fadae9ef6 = xab1af01fadae9ef6.Clone();
		document.x30390e7207fe393e = x30390e7207fe393e.Clone();
		document.xd5f4d4b5bdd8e58a = xd5f4d4b5bdd8e58a.x8b61531c8ea35b85();
		document.x91b4b3c73382cdb1 = null;
		document.x8047454048e4589b = null;
		document.xea05b90271141e94 = null;
		document.x42a14c47764d1e79 = null;
		document.xce12c3e8eb510bf2 = null;
		document.x5d55ff5fadb3fbf1 = null;
		document.xf49987382e3c3049 = null;
		return document;
	}

	public Document Clone()
	{
		return (Document)Clone(isCloneChildren: true);
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitDocumentStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitDocumentEnd(this);
	}

	public void AppendDocument(Document srcDoc, ImportFormatMode importFormatMode)
	{
		NodeImporter nodeImporter = new NodeImporter(srcDoc, this, importFormatMode);
		nodeImporter.xb7f923c74a5f39e0(srcDoc, this);
		x1552b3704ef89039.xad88d3aca1ae1e9e(this);
	}

	public SaveOutputParameters Save(string fileName)
	{
		return Save(fileName, null);
	}

	public SaveOutputParameters Save(string fileName, SaveFormat saveFormat)
	{
		return Save(fileName, SaveOptions.CreateSaveOptions(saveFormat));
	}

	public SaveOutputParameters Save(string fileName, SaveOptions saveOptions)
	{
		if (saveOptions == null)
		{
			saveOptions = SaveOptions.CreateSaveOptions(fileName);
		}
		if (saveOptions.x49451109f9415aa0)
		{
			return xf381a641001e6830(null, fileName, saveOptions);
		}
		x0d299f323d241756.x48501aec8e48c869(fileName, "fileName");
		string directoryName = Path.GetDirectoryName(fileName);
		if (x0d299f323d241756.x5959bccb67bbf051(directoryName) && !Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		using Stream xcf18e5243f8d5fd = File.Create(fileName);
		return xf381a641001e6830(xcf18e5243f8d5fd, fileName, saveOptions);
	}

	[JavaInternal]
	public SaveOutputParameters Save(Stream stream, SaveFormat saveFormat)
	{
		return Save(stream, SaveOptions.CreateSaveOptions(saveFormat));
	}

	[JavaInternal]
	public SaveOutputParameters Save(Stream stream, SaveOptions saveOptions)
	{
		if (saveOptions == null)
		{
			saveOptions = new DocSaveOptions();
		}
		if (saveOptions.x49451109f9415aa0)
		{
			return xf381a641001e6830(stream, null, saveOptions);
		}
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		return xf381a641001e6830(stream, null, saveOptions);
	}

	[JavaDelete("We do not provide saving document to a response stream in Java.")]
	public SaveOutputParameters Save(HttpResponse response, string fileName, ContentDisposition contentDisposition, SaveOptions saveOptions)
	{
		if (response == null)
		{
			throw new ArgumentNullException("response");
		}
		x0d299f323d241756.x48501aec8e48c869(fileName, "fileName");
		if (fileName.IndexOfAny(x89619a4da9836b3f) >= 0)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ljdlglklambmnlimllpmnlgnggnngkeopklolkcpokjpijaanjhapjoaoefbljmbjidcjjkckibdpdidpipdohgegineehefcilfogcgohjgghahghhhehohmcfi", 14529368)), "fileName");
		}
		if (saveOptions == null)
		{
			saveOptions = SaveOptions.CreateSaveOptions(fileName);
		}
		if (saveOptions.x49451109f9415aa0)
		{
			throw new InvalidOperationException("Document cannot be written to HTTP response in this mode. Please choose another output format or don't request document splitting.");
		}
		response.ClearContent();
		string arg = ((contentDisposition == ContentDisposition.Attachment) ? "attachment" : "inline");
		response.AddHeader("Content-Disposition", $"{arg}; filename={x8cce2b7976c9b366(fileName)}");
		MemoryStream memoryStream = new MemoryStream();
		SaveOutputParameters saveOutputParameters = xf381a641001e6830(memoryStream, null, saveOptions);
		response.ContentType = saveOutputParameters.ContentType;
		response.OutputStream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
		return saveOutputParameters;
	}

	private static string x8cce2b7976c9b366(string xe4115acdf4fbfccc)
	{
		if (x0d299f323d241756.x94708db220d6095c(xe4115acdf4fbfccc))
		{
			return xe4115acdf4fbfccc;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < xe4115acdf4fbfccc.Length; i++)
		{
			char c = xe4115acdf4fbfccc[i];
			if (c > '\u007f')
			{
				byte[] bytes = Encoding.UTF8.GetBytes(c.ToString());
				byte[] array = bytes;
				foreach (byte b in array)
				{
					stringBuilder.AppendFormat("%{0:x2}", b);
				}
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	public void EnsureMinimum()
	{
		base.Styles.xca86a79e7ad537a5();
		Section section = FirstSection;
		if (section == null)
		{
			section = (Section)AppendChild(new Section(this));
		}
		section.EnsureMinimum();
	}

	public void AcceptAllRevisions()
	{
		Revisions.AcceptAll();
	}

	public void Protect(ProtectionType type)
	{
		base.xdade2366eaa6f915.xcadc354ab6a177f1.x1af5508d5dfde22e(type);
		xeaf2b771bd7ff7f7();
	}

	public void Protect(ProtectionType type, string password)
	{
		base.xdade2366eaa6f915.xcadc354ab6a177f1.x6cd27f17e64c23a1(type, password);
		xeaf2b771bd7ff7f7();
	}

	public void Unprotect()
	{
		base.xdade2366eaa6f915.xcadc354ab6a177f1.xfe6a949644368f06();
		xeaf2b771bd7ff7f7();
	}

	public bool Unprotect(string password)
	{
		bool flag = base.xdade2366eaa6f915.xcadc354ab6a177f1.xf4e3ad2be8a228ac(password);
		if (flag)
		{
			Unprotect();
		}
		return flag;
	}

	private void xeaf2b771bd7ff7f7()
	{
		TrackRevisions = ProtectionType == ProtectionType.AllowOnlyRevisions;
	}

	public void UpdateWordCount()
	{
		x04efd937c3c79eb4 visitor = new x04efd937c3c79eb4();
		Accept(visitor);
	}

	public void UpdateTableLayout()
	{
		NodeCollection nodeCollection = new NodeCollection(this, NodeType.Table, isDeep: true);
		foreach (Table item in nodeCollection)
		{
			if (!item.x752cfab9af626fd5)
			{
				item.xae19a615b411c9fa();
			}
		}
		xd5f4d4b5bdd8e58a.xd74e03b277432e5e = true;
	}

	public void UpdateListLabels()
	{
		xb95db2f3cd32b0b0.xb8f4fa4f62915b68(this);
	}

	public void RemoveMacros()
	{
		x25f59a48c797df63 = null;
		xecc6de3be62f4102 = null;
		x61effb22c4d503be = null;
		x376d1d34953625f5 = null;
		x08c28142e937fa8b = null;
		x91aa9e2e041665fa = null;
		x92cfec29a58b2394 = (xa0a845678e16cf58)0;
	}

	public void UpdateFields()
	{
		base.Range.UpdateFields();
	}

	public int JoinRunsWithSameFormatting()
	{
		NodeCollection childNodes = GetChildNodes(NodeType.Paragraph, isDeep: true);
		StringBuilder xfef0c89324a5fd = new StringBuilder(1024);
		int num = 0;
		foreach (Paragraph item in childNodes)
		{
			num += item.x1ac00ce31ec4975d(xfef0c89324a5fd);
		}
		return num;
	}

	public void ExpandTableStylesToDirectFormatting()
	{
		x416e4f8cf09bfa33 x416e4f8cf09bfa = new x416e4f8cf09bfa33();
		foreach (Table childNode in GetChildNodes(NodeType.Table, isDeep: true))
		{
			x416e4f8cf09bfa.x8810335244b90b9d(childNode);
		}
	}

	internal string x09fa0500a9c7f012(string xafe2f3653ee64ebc)
	{
		string path = ((x62ff3dabf0a6c41f != null) ? x62ff3dabf0a6c41f : "");
		return Path.GetFullPath(Path.Combine(path, xafe2f3653ee64ebc));
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x40e458b3a58f5782.NodeType == NodeType.Section;
	}

	private void x5d95f5f98c940295(Stream xcf18e5243f8d5fd3, LoadOptions x27aceb70372bde46)
	{
		if (x27aceb70372bde46 == null)
		{
			x27aceb70372bde46 = new LoadOptions();
		}
		if (x27aceb70372bde46.LoadFormat != 0)
		{
			long position = xcf18e5243f8d5fd3.Position;
			try
			{
				x5d4db34d48fb3129(xcf18e5243f8d5fd3, x27aceb70372bde46);
				return;
			}
			catch (Exception)
			{
				x27aceb70372bde46 = x27aceb70372bde46.x8b61531c8ea35b85();
				x27aceb70372bde46.LoadFormat = LoadFormat.Auto;
				xcf18e5243f8d5fd3.Position = position;
			}
		}
		x5d4db34d48fb3129(xcf18e5243f8d5fd3, x27aceb70372bde46);
	}

	private void x5d4db34d48fb3129(Stream xcf18e5243f8d5fd3, LoadOptions x27aceb70372bde46)
	{
		try
		{
			base.ResourceLoadingCallback = x27aceb70372bde46.ResourceLoadingCallback;
			if (xcf18e5243f8d5fd3.Position == xcf18e5243f8d5fd3.Length)
			{
				xcf18e5243f8d5fd3.Position = 0L;
			}
			if (x0d299f323d241756.x5959bccb67bbf051(x27aceb70372bde46.BaseUri))
			{
				x62ff3dabf0a6c41f = x27aceb70372bde46.BaseUri;
			}
			xdb03ba346bcbcf22 = x27aceb70372bde46.LoadFormat;
			x53dc82a419732f24 x53dc82a419732f = null;
			FileFormatInfo fileFormatInfo = null;
			if (xdb03ba346bcbcf22 == LoadFormat.Auto)
			{
				x53dc82a419732f = new x53dc82a419732f24();
				fileFormatInfo = x53dc82a419732f.xdef7f68a22ec051d(xcf18e5243f8d5fd3);
				xdb03ba346bcbcf22 = fileFormatInfo.LoadFormat;
			}
			switch (xdb03ba346bcbcf22)
			{
			case LoadFormat.Doc:
			case LoadFormat.Dot:
			case LoadFormat.DocPreWord97:
			{
				xd8c3135513b9115b fs = ((x53dc82a419732f != null) ? x53dc82a419732f.xd8c3135513b9115b : new xd8c3135513b9115b(xcf18e5243f8d5fd3));
				x0f8a9a895bdf560e x0f8a9a895bdf560e = new x0f8a9a895bdf560e(fs, x27aceb70372bde46.Password, this, x27aceb70372bde46);
				x0f8a9a895bdf560e.x06b0e25aa6ad68a9();
				break;
			}
			case LoadFormat.Html:
			{
				Encoding xff3edc9aa5f0523b = null;
				if (x27aceb70372bde46.Encoding != null)
				{
					xff3edc9aa5f0523b = x27aceb70372bde46.Encoding;
				}
				else if (x53dc82a419732f != null)
				{
					xff3edc9aa5f0523b = fileFormatInfo.Encoding;
				}
				xc5f6f2ca0aafd220 xc5f6f2ca0aafd = new xc5f6f2ca0aafd220(x27aceb70372bde46);
				xc5f6f2ca0aafd.x06b0e25aa6ad68a9(xcf18e5243f8d5fd3, xff3edc9aa5f0523b, this);
				break;
			}
			case LoadFormat.Mhtml:
			{
				xf018334243635fc2 xf018334243635fc = new xf018334243635fc2(x27aceb70372bde46);
				xf018334243635fc.x06b0e25aa6ad68a9(xcf18e5243f8d5fd3, this);
				break;
			}
			case LoadFormat.Rtf:
			{
				x66a12b1255ab95ec x66a12b1255ab95ec = new x66a12b1255ab95ec(xcf18e5243f8d5fd3, this, x27aceb70372bde46);
				x66a12b1255ab95ec.x06b0e25aa6ad68a9();
				break;
			}
			case LoadFormat.WordML:
			{
				x21a61af92fc2a45e x21a61af92fc2a45e = new x21a61af92fc2a45e(xcf18e5243f8d5fd3, this, x27aceb70372bde46);
				x21a61af92fc2a45e.x06b0e25aa6ad68a9();
				break;
			}
			case LoadFormat.Docx:
			case LoadFormat.Docm:
			case LoadFormat.Dotx:
			case LoadFormat.Dotm:
			case LoadFormat.FlatOpc:
			case LoadFormat.FlatOpcMacroEnabled:
			case LoadFormat.FlatOpcTemplate:
			case LoadFormat.FlatOpcTemplateMacroEnabled:
			{
				if (!x0d299f323d241756.x5959bccb67bbf051(x27aceb70372bde46.Password) && (x53dc82a419732f == null || !fileFormatInfo.IsEncrypted))
				{
					xae13d15563a3a703 xae13d15563a3a = new xae13d15563a3a703(xcf18e5243f8d5fd3, this, x27aceb70372bde46);
					xae13d15563a3a.x06b0e25aa6ad68a9();
					break;
				}
				xd8c3135513b9115b fs2 = ((x53dc82a419732f != null) ? x53dc82a419732f.xd8c3135513b9115b : new xd8c3135513b9115b(xcf18e5243f8d5fd3));
				xd855f141beac193d xd855f141beac193d = new xd855f141beac193d(fs2);
				if (xd855f141beac193d.xb5153263347a0278())
				{
					MemoryStream xcf18e5243f8d5fd4 = xd855f141beac193d.xcc381ffa3ede662f(x27aceb70372bde46.Password);
					x53dc82a419732f = null;
					xd855f141beac193d = null;
					fs2 = null;
					LoadFormat loadFormat = xdb03ba346bcbcf22;
					x5d4db34d48fb3129(xcf18e5243f8d5fd4, new LoadOptions());
					xdb03ba346bcbcf22 = loadFormat;
					return;
				}
				throw new UnsupportedFileFormatException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lbpdbdgelcnelcefjclfoccgccjgbnpgebhhebohebfikamicmcjfakjlabklaikdapkepfleanllldm", 212352710)));
			}
			case LoadFormat.Odt:
			case LoadFormat.Ott:
			{
				xf871da68decec406 xf871da68decec = new xf871da68decec406(xcf18e5243f8d5fd3, this, x27aceb70372bde46.WarningCallback);
				xf871da68decec.x06b0e25aa6ad68a9();
				break;
			}
			case LoadFormat.Text:
			{
				Encoding encoding = null;
				if (x27aceb70372bde46.Encoding != null)
				{
					encoding = x27aceb70372bde46.Encoding;
				}
				else if (x53dc82a419732f != null)
				{
					encoding = fileFormatInfo.Encoding;
				}
				xe4fc4f6e9a5490eb xe4fc4f6e9a5490eb = new xe4fc4f6e9a5490eb(xcf18e5243f8d5fd3, this, encoding);
				xe4fc4f6e9a5490eb.x06b0e25aa6ad68a9();
				break;
			}
			default:
				throw new UnsupportedFileFormatException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jijjpjakjjhkjjokhjflmjmlajdmpdkmcibnciincipnihgoadnodhepjhlpjhcabhjacgabchhbjcob", 1367644468)));
			}
			x9190101bb5c1ce1b x9190101bb5c1ce1b = new x9190101bb5c1ce1b();
			x9190101bb5c1ce1b.x18dfca7c5fd2402f(this, x27aceb70372bde46);
		}
		catch (Exception xfbf34718e704c6bc)
		{
			throw FileFormatUtil.x9c29bee5df34fc46(xfbf34718e704c6bc);
		}
	}

	internal void x67472f7b3890110b()
	{
		using (Stream xcf18e5243f8d5fd = xed747ca236d86aa0.xe1cd764b6fb0d6f6("Aspose.Words.Resources.Blank.doc"))
		{
			x5d95f5f98c940295(xcf18e5243f8d5fd, null);
		}
		BuiltInDocumentProperties.Author = "";
		BuiltInDocumentProperties.Company = "";
		BuiltInDocumentProperties.CreatedTime = DateTime.MinValue;
		BuiltInDocumentProperties.LastSavedBy = "";
		BuiltInDocumentProperties.LastSavedTime = DateTime.MinValue;
		BuiltInDocumentProperties.NameOfApplication = "Aspose.Words for .NET 11.9.0.0";
		BuiltInDocumentProperties.RevisionNumber = 1;
		base.Styles.x160c33d5600b9bc8();
	}

	private SaveOutputParameters xf381a641001e6830(Stream xcf18e5243f8d5fd3, string xafe2f3653ee64ebc, SaveOptions xc27f01f21f67608c)
	{
		x8556eed81191af11 x5ac1382edb7bf2c = new x8556eed81191af11(this, xcf18e5243f8d5fd3, xafe2f3653ee64ebc, xc27f01f21f67608c);
		xcc0b5baa75272714 xcc0b5baa = null;
		if (xc27f01f21f67608c.xda76bf558c43e688)
		{
			xcc0b5baa = new xcc0b5baa75272714();
			xcc0b5baa.x18dfca7c5fd2402f(x5ac1382edb7bf2c);
		}
		if (xc27f01f21f67608c is x99fd4075192789b2)
		{
			xd5f4d4b5bdd8e58a.x515e84b3fc4c5959 = ((x99fd4075192789b2)xc27f01f21f67608c).xce9c42bd4e3f2c89();
		}
		x3d2908992e1d1667 x3d2908992e1d = xb64ca40f4a97bbc0.xa0cd748a38fb4102(xc27f01f21f67608c.SaveFormat);
		SaveOutputParameters result = x3d2908992e1d.xa2e0b7f7da663553(x5ac1382edb7bf2c);
		xcc0b5baa?.x3522790e002e1ba4();
		return result;
	}

	internal Node x3812e1f81fa8d15f(string xeaf1b27180c0557b)
	{
		string[] array = xeaf1b27180c0557b.Split('.');
		Array.Reverse(array);
		CompositeNode compositeNode = this;
		for (int i = 0; i < array.Length - 1; i++)
		{
			compositeNode = (CompositeNode)compositeNode.ChildNodes[Convert.ToInt32(array[i])];
		}
		return compositeNode.ChildNodes[Convert.ToInt32(array[^1])];
	}

	internal xcde671c53995c411 x410db0f4a89a6ef1(bool x24af0daafcd8fb8c)
	{
		if (!xc6ce8b20496b71f5 && x24af0daafcd8fb8c)
		{
			UpdatePageLayout();
		}
		return xea05b90271141e94;
	}

	internal void xe4f03767b6c9b92b()
	{
		xea05b90271141e94 = null;
	}

	public void UpdatePageLayout()
	{
		x42a14c47764d1e79 = null;
		xea05b90271141e94 = xcde671c53995c411.xd9db07500873ae98(this, xd5f4d4b5bdd8e58a);
	}

	public SizeF RenderToScale(int pageIndex, Graphics graphics, float x, float y, float scale)
	{
		x0c90271e80b9c1ce(pageIndex, 1);
		x3a15c7024016ce52 x3a15c7024016ce = new x3a15c7024016ce52();
		xc67adcdbca121a26 xc67adcdbca121a = xaef272a322936116(pageIndex);
		return x3a15c7024016ce.x231ed5305a7bb3ea(xc67adcdbca121a, xc67adcdbca121a.x437e3b626c0fdd43, graphics, x, y, scale);
	}

	public float RenderToSize(int pageIndex, Graphics graphics, float x, float y, float width, float height)
	{
		x0c90271e80b9c1ce(pageIndex, 1);
		x3a15c7024016ce52 x3a15c7024016ce = new x3a15c7024016ce52();
		xc67adcdbca121a26 xc67adcdbca121a = xaef272a322936116(pageIndex);
		return x3a15c7024016ce.xc8a427e6e672c1ed(xc67adcdbca121a, xc67adcdbca121a.x437e3b626c0fdd43, graphics, x, y, width, height);
	}

	internal xc67adcdbca121a26 xaef272a322936116(int xbf13a47a02af0066)
	{
		xfef22f4f866de8d2 xfef22f4f866de8d = new xfef22f4f866de8d2();
		return xfef22f4f866de8d.xe406325e56f74b46(xcde671c53995c411.get_xe6d4b1b411ed94b5(xbf13a47a02af0066), xd5f4d4b5bdd8e58a);
	}

	public PageInfo GetPageInfo(int pageIndex)
	{
		x0c90271e80b9c1ce(pageIndex, 1);
		xdcf47a8f1807f37c page = xcde671c53995c411.get_xe6d4b1b411ed94b5(pageIndex);
		return new PageInfo(page);
	}

	internal void x0c90271e80b9c1ce(int xbf13a47a02af0066, int x0375600be29bf902)
	{
		if (xbf13a47a02af0066 < 0 || xbf13a47a02af0066 > PageCount - 1)
		{
			throw new ArgumentOutOfRangeException("pageIndex");
		}
		if (x0375600be29bf902 < 1 || xbf13a47a02af0066 + x0375600be29bf902 > PageCount)
		{
			throw new ArgumentOutOfRangeException("pageCount");
		}
	}

	public void Print()
	{
		Print(new PrinterSettings());
	}

	public void Print(string printerName)
	{
		x0d299f323d241756.x48501aec8e48c869(printerName, "printerName");
		PrinterSettings printerSettings = new PrinterSettings();
		printerSettings.PrinterName = printerName;
		Print(printerSettings);
	}

	public void Print(PrinterSettings printerSettings)
	{
		if (printerSettings == null)
		{
			throw new ArgumentNullException("printerSettings");
		}
		Print(printerSettings, null);
	}

	public void Print(PrinterSettings printerSettings, string documentName)
	{
		if (printerSettings == null)
		{
			throw new ArgumentNullException("printerSettings");
		}
		AsposeWordsPrintDocument asposeWordsPrintDocument = new AsposeWordsPrintDocument(this);
		if (documentName != null)
		{
			asposeWordsPrintDocument.DocumentName = documentName;
		}
		asposeWordsPrintDocument.PrinterSettings = printerSettings;
		asposeWordsPrintDocument.x8c61bb6b48e3599e();
		asposeWordsPrintDocument.Print();
	}

	public void UpdateThumbnail(ThumbnailGeneratingOptions options)
	{
		xac0cbd24f103d165.xcd715bf43e919c00(this, options);
	}

	public void UpdateThumbnail()
	{
		UpdateThumbnail(new ThumbnailGeneratingOptions());
	}

	private object xa8520499885dda4d(int xba08ce632055a1d9)
	{
		return base.xdade2366eaa6f915.xc8949e68d489222b.xb25c0862ce36b53c(xba08ce632055a1d9);
	}

	object x38e21b53aa8148da.xb25c0862ce36b53c(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa8520499885dda4d
		return this.xa8520499885dda4d(xba08ce632055a1d9);
	}

	private object x3be9b7b90db67467(int xba08ce632055a1d9)
	{
		return xfc72d4c9b765cad7.x0095b789d636f3ae(xba08ce632055a1d9);
	}

	object x38e21b53aa8148da.xe5b82b9f0104471f(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3be9b7b90db67467
		return this.x3be9b7b90db67467(xba08ce632055a1d9);
	}

	private void x7841d0dbdfcc97f5(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		base.xdade2366eaa6f915.xc8949e68d489222b.xa2dc0badd30e7585(xba08ce632055a1d9, xbcea506a33cf9111);
		foreach (Section section in Sections)
		{
			section.xa2dc0badd30e7585(xba08ce632055a1d9, xbcea506a33cf9111);
		}
	}

	void x38e21b53aa8148da.xa2dc0badd30e7585(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x7841d0dbdfcc97f5
		this.x7841d0dbdfcc97f5(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private void xb9e770c2023bca9c()
	{
		base.xdade2366eaa6f915.xc8949e68d489222b.x6e641a758e328481();
		foreach (Section section in Sections)
		{
			section.x6e641a758e328481();
		}
	}

	void x38e21b53aa8148da.x6e641a758e328481()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xb9e770c2023bca9c
		this.xb9e770c2023bca9c();
	}
}
