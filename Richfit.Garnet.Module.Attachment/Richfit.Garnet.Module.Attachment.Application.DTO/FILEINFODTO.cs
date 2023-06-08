using System;

namespace Richfit.Garnet.Module.Attachment.Application.DTO;

public class FILEINFODTO
{
	protected string extension;

	/// <summary>
	/// 主键 FileInfoID(NOT NULL)
	/// </summary>
	public Guid? FileInfoID { get; set; }

	/// <summary>
	/// ParentId(NOT NULL)
	/// </summary>
	public Guid ParentId { get; set; }

	/// <summary>
	/// FileType(NOT NULL)
	/// </summary>
	public int FileType { get; set; }

	/// <summary>
	/// FileName(NOT NULL)
	/// </summary>
	public string FileName { get; set; }

	/// <summary>
	/// FileSize(NOT NULL)
	/// </summary>
	public long FileSize { get; set; }

	public string FileNameDes
	{
		get
		{
			if (!string.IsNullOrEmpty(Extension))
			{
				if (Version == 0)
				{
					return $"{FileName}{Extension}";
				}
				return $"{FileName}({Version}){Extension}";
			}
			if (Version == 0)
			{
				return FileName;
			}
			return $"{FileName}({Version})";
		}
	}

	public string FileLength
	{
		get
		{
			if (FileSize < 1024)
			{
				return $"{FileSize}字节";
			}
			if (FileSize < 1048576)
			{
				return string.Format("{0}kb", ((decimal)FileSize / 1024m).ToString("f2"));
			}
			if (FileSize < 1073741824)
			{
				return string.Format("{0}MB", ((decimal)FileSize / 1048576m).ToString("f2"));
			}
			return string.Format("{0}GB", ((decimal)FileSize / 1073741824m).ToString("f2"));
		}
	}

	public string Extension
	{
		get
		{
			return extension;
		}
		set
		{
			extension = value;
		}
	}

	/// <summary>
	/// UserId(NOT NULL)
	/// </summary>
	public Guid UserId { get; set; }

	/// <summary>
	/// IsDel(NOT NULL)
	/// </summary>
	public decimal IsDel { get; set; }

	/// <summary>
	/// Creator
	/// </summary>
	public Guid Creator { get; set; }

	/// <summary>
	/// CreateTime
	/// </summary>
	public DateTime? CreateTime { get; set; }

	/// <summary>
	/// Modifier
	/// </summary>
	public Guid Modifier { get; set; }

	/// <summary>
	/// ModifyTime
	/// </summary>
	public DateTime? ModifyTime { get; set; }

	public int Version { get; set; }

	public int Isfolder { get; set; }

	public string FilePath { get; set; }

	/// <summary>
	/// 实体 FileInfo
	/// </summary>
	public FILEINFODTO()
	{
	}
}
