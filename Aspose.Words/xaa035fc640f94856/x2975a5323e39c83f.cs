using Aspose.Words.Markup;
using x16f9a31f749b8bb1;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

internal class x2975a5323e39c83f : x6baa4d96ef0dd487
{
	protected override void DoProcessTag(x0f8a9a895bdf560e docReader, int itemIndex)
	{
		x31a5ab258b5c21f3 x31a5ab258b5c21f4 = docReader.x31a5ab258b5c21f3;
		SmartTag smartTag = docReader.xffb32620593acdf2.xdd43764a658cd8b8();
		x077550583a096f29 x077550583a096f30 = x31a5ab258b5c21f4.x1e59dca0d9402f11(itemIndex);
		xf0391b353ea8ab43 xf0391b353ea8ab44 = x31a5ab258b5c21f4.x4ac1c3cc4f5e7e94(x077550583a096f30.xea1e81378298fa81);
		smartTag.Element = xf0391b353ea8ab44.xd229d86af0f16fb0;
		smartTag.Uri = xf0391b353ea8ab44.xb405a444ca77e2d4;
		for (int i = 0; i < x077550583a096f30.xf74d8efdcaef8ee6.Length; i++)
		{
			string name = x31a5ab258b5c21f4.x48112399d54b30c7(x077550583a096f30.xf74d8efdcaef8ee6[i]);
			string value = x31a5ab258b5c21f4.x48112399d54b30c7(x077550583a096f30.xa32ede1025f7736e[i]);
			smartTag.Properties.x1cd8943d02c5342f(new CustomXmlProperty(name, "", value));
		}
	}
}
