using System.Text;
using Aspose.Words.Settings;
using x556d8f9846e43329;

namespace x2182451cabb5c30d;

internal class x304639ab40e89271 : x3b57052406b93b82
{
	private readonly MailMergeSettings x8acf702ae93e7151;

	private x25099a8bbbd55d1c x164c19a26a4543bf => x28fcdc775a1d069c.xa3a0cc3e91617aca.xffb3238a8fd59aa7.x1a55de3a01c1c82d.x3146d638ec378671;

	internal x304639ab40e89271(xe5e546ef5f0503b2 context)
		: base(context)
	{
		x8acf702ae93e7151 = base.x2c8c6741422a1298.xdade2366eaa6f915.xe690cef2446c7d46;
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\mmmaintypecatalog":
		case "\\mmmaintypeenvelopes":
		case "\\mmmaintypelabels":
		case "\\mmmaintypeletters":
		case "\\mmmaintypeemail":
		case "\\mmmaintypefax":
			x8acf702ae93e7151.MainDocumentType = xa0d3611565b2a1f2.x8cf97090ad1be525(x153c99a852375422.x1dafd189c5465293());
			break;
		case "\\mmdatatypeaccess":
		case "\\mmdatatypeexcel":
		case "\\mmdatatypeqt":
		case "\\mmdatatypeodbc":
		case "\\mmdatatypeodso":
		case "\\mmdatatypefile":
			x8acf702ae93e7151.DataType = xa0d3611565b2a1f2.xc8f95ea6619cc2d3(x153c99a852375422.x1dafd189c5465293());
			break;
		case "\\mmdestnewdoc":
		case "\\mmdestprinter":
		case "\\mmdestemail":
		case "\\mmdestfax":
			x8acf702ae93e7151.Destination = xa0d3611565b2a1f2.x72be8363c5b507b9(x153c99a852375422.x1dafd189c5465293());
			break;
		case "\\mmlinktoquery":
			x8acf702ae93e7151.LinkToQuery = true;
			break;
		case "\\mmblanklinks":
			x8acf702ae93e7151.DoNotSupressBlankLines = true;
			break;
		case "\\mmreccur":
			x8acf702ae93e7151.ActiveRecord = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mmerrors":
			x8acf702ae93e7151.CheckErrors = (MailMergeCheckErrors)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mmattach":
			x8acf702ae93e7151.MailAsAttachment = true;
			break;
		case "\\mmshowdata":
			x8acf702ae93e7151.ViewMergedData = true;
			break;
		default:
			base.xa2d8e36cb99ac0f4(x153c99a852375422);
			break;
		case "\\mmdefaultsql":
			break;
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x164c19a26a4543bf)
		{
		case x25099a8bbbd55d1c.x3dcb6172bba0fdd3:
			x8acf702ae93e7151.ConnectString = Encoding.Unicode.GetString(x153c99a852375422.xbfeb690f3f95a932());
			break;
		case x25099a8bbbd55d1c.x4bd63874288829f2:
			if (x8acf702ae93e7151.ConnectString == string.Empty)
			{
				x8acf702ae93e7151.ConnectString = x153c99a852375422.x9f1a6a3451a38d10();
			}
			break;
		case x25099a8bbbd55d1c.x3a3ae8df3afa649a:
			x8acf702ae93e7151.DataSource = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.xb0116bc64ea34bba:
			x8acf702ae93e7151.Query = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x99554c2b06a86891:
			x8acf702ae93e7151.HeaderSource = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x23b6ecfdadd026b3:
			x8acf702ae93e7151.AddressFieldName = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x2d5c9d669ec1e0e9:
			x8acf702ae93e7151.MailSubject = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		default:
			base.xbd6083b329527c4e(x153c99a852375422);
			break;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x3dcb6172bba0fdd3:
		case x25099a8bbbd55d1c.x4bd63874288829f2:
		case x25099a8bbbd55d1c.xb0116bc64ea34bba:
		case x25099a8bbbd55d1c.x3a3ae8df3afa649a:
		case x25099a8bbbd55d1c.x99554c2b06a86891:
		case x25099a8bbbd55d1c.x23b6ecfdadd026b3:
		case x25099a8bbbd55d1c.x2d5c9d669ec1e0e9:
			return this;
		case x25099a8bbbd55d1c.x207bba6610a1ab10:
			return new xb12e85764fe123c7(x28fcdc775a1d069c);
		default:
			return base.x3e0bce851c12a688(x8d3f74e5f925679c);
		}
	}
}
