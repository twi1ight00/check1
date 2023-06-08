using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class xeb7cca009d988b73 : Field
{
	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		if (x5c29822913be33c1.x338a5159d9aa7162(base.xb452e2ee706d7a67.xc96d173d58dd8a20) != base.Type)
		{
			return new xf39bd211ab89bfb8(this);
		}
		string xc96d173d58dd8a = base.xb452e2ee706d7a67.xc96d173d58dd8a20;
		if (x0d299f323d241756.x0fb62ca630231ea1(xc96d173d58dd8a))
		{
			x52b190e626f65140(x7d5e2f34b6651bf4.xf8d31d196ccd74c4);
			return new xf39bd211ab89bfb8(this);
		}
		x5f4c2139149eaf99(x5113d1e6ef8a0405: true);
		Bookmark bookmark = base.x2c8c6741422a1298.Range.Bookmarks[xc96d173d58dd8a];
		if (bookmark != null)
		{
			x52b190e626f65140(x7d5e2f34b6651bf4.xf8d31d196ccd74c4);
			x0a28863c804404d7.x775521112ede5e6f(bookmark.x451c3f5e0b9f8822(), base.End, null);
			return new xf39bd211ab89bfb8(this);
		}
		return new xd5801a931e010963(this, "Error! Bookmark not defined.");
	}
}
