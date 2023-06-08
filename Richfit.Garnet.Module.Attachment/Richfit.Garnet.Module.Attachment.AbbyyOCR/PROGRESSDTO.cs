using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Attachment.AbbyyOCR;

public class PROGRESSDTO : DTOBase
{
	/// <summary>
	/// 百分比，0-99
	/// </summary>
	private int _percentage = 0;

	/// <summary>
	/// 提示的操作文本
	/// </summary>
	private string _OperationText = string.Empty;

	public int Percentage
	{
		get
		{
			return _percentage;
		}
		set
		{
			_percentage = value;
		}
	}

	public string OperationText
	{
		get
		{
			return _OperationText;
		}
		set
		{
			_OperationText = value;
		}
	}
}
