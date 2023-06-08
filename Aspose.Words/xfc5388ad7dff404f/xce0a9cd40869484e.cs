using System;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xfc5388ad7dff404f;

internal class xce0a9cd40869484e
{
	private xce0a9cd40869484e()
	{
	}

	public static void x6210059f049f0d48(x3c74b3c4f21844f9 xd07ce4b74c5774a7, string x37a96021dbbe3532, string x34f587299629dc06, string xed6cf05351de54fb, string xa6994ba1e9be7a20, string xc2358fbac7da3d45, string x7fe42f7d3eaf063d, string xde2016e90885f436, DateTime xd0ac65d2f2e92fc0, DateTime x008fedb04fddac08, DateTime xc6712b355bbb406e, string x6f02b6a80bf6b36f)
	{
		xd07ce4b74c5774a7.x9b9ed0109b743e3b("cp:coreProperties");
		xd07ce4b74c5774a7.xff520a0047c27122("xmlns:cp", "http://schemas.openxmlformats.org/package/2006/metadata/core-properties");
		xd07ce4b74c5774a7.xff520a0047c27122("xmlns:dc", "http://purl.org/dc/elements/1.1/");
		xd07ce4b74c5774a7.xff520a0047c27122("xmlns:dcterms", "http://purl.org/dc/terms/");
		xd07ce4b74c5774a7.xff520a0047c27122("xmlns:dcmitype", "http://purl.org/dc/dcmitype/");
		xd07ce4b74c5774a7.xff520a0047c27122("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
		xd07ce4b74c5774a7.x6d7247ebbf9a7643("dc:title", x37a96021dbbe3532);
		xd07ce4b74c5774a7.x6d7247ebbf9a7643("dc:subject", x34f587299629dc06);
		xd07ce4b74c5774a7.x6d7247ebbf9a7643("dc:creator", xed6cf05351de54fb);
		xd07ce4b74c5774a7.x6d7247ebbf9a7643("cp:keywords", xa6994ba1e9be7a20);
		xd07ce4b74c5774a7.x6d7247ebbf9a7643("dc:description", xc2358fbac7da3d45);
		xd07ce4b74c5774a7.x6d7247ebbf9a7643("cp:lastModifiedBy", x7fe42f7d3eaf063d);
		xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("cp:revision", xde2016e90885f436);
		xd07ce4b74c5774a7.x6d7247ebbf9a7643("cp:lastPrinted", xd0ac65d2f2e92fc0);
		x7a16abb8bb769162(xd07ce4b74c5774a7, "created", x008fedb04fddac08);
		x7a16abb8bb769162(xd07ce4b74c5774a7, "modified", xc6712b355bbb406e);
		xd07ce4b74c5774a7.x6d7247ebbf9a7643("cp:category", x6f02b6a80bf6b36f);
		xd07ce4b74c5774a7.xa0dfc102c691b11f();
	}

	private static void x7a16abb8bb769162(x3c74b3c4f21844f9 xd07ce4b74c5774a7, string xc15bd84e01929885, DateTime xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.Year > 1)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("dcterms:" + xc15bd84e01929885);
			xd07ce4b74c5774a7.xff520a0047c27122("xsi:type", "dcterms:W3CDTF");
			xd07ce4b74c5774a7.x3d1be38abe5723e3(xca004f56614e2431.x6efbf9d15154c80d(xbcea506a33cf9111));
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
	}
}
