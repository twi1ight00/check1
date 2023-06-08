using System.ComponentModel.Design;
using System.Text;
using System.Web.UI.Design;

namespace PageOffice.Design;

internal sealed class PDFCtrlDesigner : ControlDesigner
{
	private DesignerActionListCollection _0002;

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			if (_0002 == null)
			{
				_0002 = new DesignerActionListCollection();
				_0002.Add(new PDFCtrlActionList(this));
			}
			return _0002;
		}
	}

	public override bool AllowResize => false;

	public override string GetDesignTimeHtml()
	{
		if (_0002 != null)
		{
			_ = _0002[0];
		}
		StringBuilder stringBuilder = new StringBuilder(_0005_2000._0002(1402765592));
		string text = _0005_2000._0002(1402765512);
		PDFCtrl pDFCtrl = (PDFCtrl)base.Component;
		if (pDFCtrl != null)
		{
			if (pDFCtrl.Caption != string.Empty)
			{
				text = text + _0005_2000._0002(1402765371) + pDFCtrl.Caption;
			}
			if (pDFCtrl.Titlebar)
			{
				stringBuilder.Append(_0005_2000._0002(1402766689));
				stringBuilder.Append(_0005_2000._0002(1402765347) + text + _0005_2000._0002(1402766241));
				stringBuilder.Append(_0005_2000._0002(1402766547));
			}
			if (pDFCtrl.Menubar)
			{
				stringBuilder.Append(_0005_2000._0002(1402766689));
				stringBuilder.Append(_0005_2000._0002(1402766255));
				stringBuilder.Append(_0005_2000._0002(1402766547));
			}
			if (pDFCtrl.CustomToolbar)
			{
				stringBuilder.Append(_0005_2000._0002(1402766689));
				stringBuilder.Append(_0005_2000._0002(1402766010));
				stringBuilder.Append(_0005_2000._0002(1402766547));
			}
			stringBuilder.Append(_0005_2000._0002(1402766689));
			stringBuilder.Append(_0005_2000._0002(1402769035));
			stringBuilder.Append(_0005_2000._0002(1402766547));
		}
		else
		{
			stringBuilder.Append(_0005_2000._0002(1402766689));
			stringBuilder.Append(_0005_2000._0002(1402767678));
			stringBuilder.Append(_0005_2000._0002(1402766547));
		}
		stringBuilder.Append(_0005_2000._0002(1402766529));
		return stringBuilder.ToString();
	}
}
