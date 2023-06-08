using System;
using System.Collections.Generic;
using System.IO;
using Richfit.Garnet.Module.Attachment.Application.DTO;
using Richfit.Garnet.Module.Attachment.SolrNet;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Attachment.Application.Services.Attachment;

public interface IAttachmentService
{
	/// <summary>
	/// 添加附件
	/// </summary>
	/// <param name="attachmentDTO">attachmentDTO</param>
	/// <param name="inputStream">inputStream</param>
	/// <returns>AttachmentDTO</returns>
	AttachmentDTO UploadAttachment(AttachmentDTO attachmentDTO, Stream inputStream);

	/// <summary>
	/// 批量逻辑删除附件及映射关系(暂时没有调用)
	/// </summary>
	/// <param name="objectID">objectID</param>
	/// <param name="objectTableName">objectTableName</param>
	/// <param name="attachmentIDs">attachmentIDs</param>
	void RemoveAttachmentAndMapping(Guid objectID, string objectTableName, List<Guid> attachmentIDs);

	/// <summary>
	/// 批量逻辑删除附件信息
	/// </summary>
	/// <param name="attachmentIDs">attachmentIDs</param>
	void RemoveAttachment(List<Guid> attachmentIDs);

	/// <summary>
	/// 查询单个附件信息
	/// </summary>
	/// <param name="AttachmentID">AttachmentID</param>
	/// <returns>QueryAttachmentByID</returns>
	QueryResult<AttachmentDTO> QueryAttachmentByID(Guid AttachmentID);

	/// <summary>
	/// 查询附件列表信息
	/// </summary>
	/// <param name="queryCondition">queryCondition</param>
	/// <returns>QueryAttachmentList</returns>
	QueryResult<AttachmentDTO> QueryAttachmentList(QueryCondition queryCondition);

	/// <summary>
	/// 保存附件映射(先删除，再添加)
	/// </summary>
	/// <param name="objectID">业务记录ID</param>
	/// <param name="objectTableName">业务记录表名</param>
	/// <param name="attachmentIDs">附件列表</param>
	void SaveAttachmentMapping(Guid objectID, string objectTableName, List<AttachmentDTO> attachmentIDs);

	/// <summary>
	/// 从数据库读取附件的内容并以二进制流方式传出
	/// </summary>
	/// <param name="attachmentDTO">所要读取附件记录的DTO</param>
	/// <returns>附件内容的二进制流</returns>
	Stream ReadBaseAttachment(AttachmentDTO attachmentDTO);

	/// <summary>
	/// 添加附件映射关系
	/// </summary>
	/// <param name="objectID">业务记录ID</param>
	/// <param name="objectTableName">业务记录表名</param>
	/// <param name="attachmentID">附件ID</param>
	void AddAttachmentMapping(Guid objectID, string objectTableName, Guid attachmentID);

	IList<AttachmentDTO> GetAttachmentByObjId(Guid guid);

	AttachmentDTO GetAttachmentById(Guid guid);

	IList<AttachmentMappingDTO> GetAttachmentListByAttachment_ID(Guid guid);

	void SaveAttachment(AttachmentDTO attachmentDTO);

	void SaveAttachmentMapping(IList<AttachmentMappingDTO> attachmentDTO);

	QueryResult<SOLRNETDTO> QuerySolrbyword(SOLRNETDTO solrnetdto);

	void ChangeContentMapping(Guid objectID, Guid attachmentID);

	IList<AttachmentDTO> GetAttachmentBymap(AttachmentMappingDTO attachmentmapDTO);
}
