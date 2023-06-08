using System;
using System.Runtime.Serialization;

namespace Aspose.Cells;

/// <summary>
///       The exception that is thrown when Aspose.Cells specified error occurs.
///       </summary>
[Serializable]
public class CellsException : ApplicationException
{
	private ExceptionType m_Code;

	/// <summary>
	///       Represenets custom exception code.
	///       </summary>
	public ExceptionType Code => m_Code;

	internal CellsException(ExceptionType exceptionType_0, string string_0)
		: base(string_0)
	{
		m_Code = exceptionType_0;
	}

	protected CellsException(SerializationInfo info, StreamingContext context)
		: base(info.GetString("message"))
	{
		m_Code = (ExceptionType)info.GetValue("code", ExceptionType.InvalidData.GetType());
	}
}
