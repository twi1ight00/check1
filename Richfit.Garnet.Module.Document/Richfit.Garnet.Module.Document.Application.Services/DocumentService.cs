using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Adapter;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Attachment.Application.DTO;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Document.Application.DTO;
using Richfit.Garnet.Module.Document.Domain.Models;

namespace Richfit.Garnet.Module.Document.Application.Services;

public class DocumentService : ServiceBase, IDocumentService
{
	private readonly IRepository<DOC_FILE> docfileRepository;

	private readonly IRepository<DOC_CONTENTS> doccontentsRepository;

	public DocumentService()
	{
		docfileRepository = ServiceLocator.Instance.GetService<IRepository<DOC_FILE>>();
		doccontentsRepository = ServiceLocator.Instance.GetService<IRepository<DOC_CONTENTS>>();
	}

	public DocumentService(IRepository<DOC_FILE> docfileRepository, IRepository<DOC_CONTENTS> doccontentsRepository)
	{
		this.docfileRepository = docfileRepository;
		this.doccontentsRepository = doccontentsRepository;
	}

	public DOC_CONTENTSDTO AddContent(DOC_CONTENTSDTO codeDTO)
	{
		if (!codeDTO.IsValid())
		{
			throw new ValidationException(codeDTO.GetInvalidMessages());
		}
		if (!IsExistContentOfNameParentID(codeDTO.CONTENT_NAME, (!codeDTO.PARENT_CONTENT_ID.HasValue) ? Guid.Empty : codeDTO.PARENT_CONTENT_ID.Value))
		{
			if (codeDTO == null)
			{
				throw new ArgumentException("AddContent方法参数不能为空！");
			}
			if (codeDTO.IsValid())
			{
				DOC_CONTENTS codePOCO = codeDTO.AdaptAsEntity<DOC_CONTENTS>();
				if (!IsExistContentOfNameID(codePOCO.CONTENT_NAME, codePOCO.CONTENT_ID))
				{
					doccontentsRepository.AddCommit(codePOCO);
				}
				else
				{
					doccontentsRepository.UpdateCommit(codePOCO);
				}
				codeDTO = codePOCO.AdaptAsDTO<DOC_CONTENTSDTO>();
				return codeDTO;
			}
			throw new ValidationException(codeDTO.GetInvalidMessages());
		}
		if (codeDTO == null)
		{
			throw new ArgumentException("AddContent方法参数不能为空！");
		}
		if (codeDTO.IsValid())
		{
			DOC_CONTENTS codePOCO = codeDTO.AdaptAsEntity<DOC_CONTENTS>();
			doccontentsRepository.UpdateCommit(codePOCO);
			codeDTO = codePOCO.AdaptAsDTO<DOC_CONTENTSDTO>();
			return codeDTO;
		}
		throw new ValidationException(codeDTO.GetInvalidMessages());
	}

	public DOC_CONTENTSDTO UpdateDocContent(DOC_CONTENTSDTO codeDTO)
	{
		if (codeDTO == null || codeDTO.CONTENT_ID == Guid.Empty)
		{
			throw new ArgumentException("UpdateDocContent方法参数不能为空！");
		}
		if (codeDTO.IsValid())
		{
			DOC_CONTENTS persisted = doccontentsRepository.GetByKey(codeDTO.CONTENT_ID);
			if (persisted != null)
			{
				persisted.CONTENT_NAME = codeDTO.CONTENT_NAME;
				persisted.SORT = codeDTO.SORT;
				persisted.PARENT_CONTENT_ID = codeDTO.PARENT_CONTENT_ID;
				doccontentsRepository.UpdateCommit(persisted);
				codeDTO = persisted.AdaptAsDTO<DOC_CONTENTSDTO>();
				return codeDTO;
			}
			throw new ArgumentException("UpdateDocContent不存在相关的实体对象！");
		}
		throw new ValidationException(codeDTO.GetInvalidMessages());
	}

	public bool IsExistContentOfNameParentID(string CodeName, Guid parentCodeID)
	{
		bool isExist = false;
		if (!string.IsNullOrEmpty(parentCodeID.ToString()) && !string.IsNullOrEmpty(CodeName))
		{
			Specification<DOC_CONTENTS> specification = new ExpressionSpecification<DOC_CONTENTS>((DOC_CONTENTS x) => x.ISDEL == 0m && x.CONTENT_NAME.Equals(CodeName));
			if (parentCodeID != Guid.Empty)
			{
				specification &= (Specification<DOC_CONTENTS>)new ExpressionSpecification<DOC_CONTENTS>((DOC_CONTENTS x) => x.PARENT_CONTENT_ID == parentCodeID);
			}
			else
			{
				specification &= (Specification<DOC_CONTENTS>)new ExpressionSpecification<DOC_CONTENTS>((DOC_CONTENTS x) => x.PARENT_CONTENT_ID == null);
			}
			isExist = doccontentsRepository.Exists(specification);
		}
		return isExist;
	}

	public bool IsExistContentOfNameID(string CodeName, Guid CodeID)
	{
		bool isExist = false;
		if (!string.IsNullOrEmpty(CodeID.ToString()) && !string.IsNullOrEmpty(CodeName))
		{
			Specification<DOC_CONTENTS> specification = new ExpressionSpecification<DOC_CONTENTS>((DOC_CONTENTS x) => x.CONTENT_NAME.Equals(CodeName));
			if (CodeID != Guid.Empty)
			{
				specification &= (Specification<DOC_CONTENTS>)new ExpressionSpecification<DOC_CONTENTS>((DOC_CONTENTS x) => x.CONTENT_ID == CodeID);
			}
			isExist = doccontentsRepository.Exists(specification);
		}
		return isExist;
	}

	public IList<TREE_NODE<T>> GetContentsTree<T>() where T : struct
	{
		IList<DOC_CONTENTSDTO> contentsList = LoadCONTENTSTree();
		IList<TREE_NODE<T>> contentsTree = new List<TREE_NODE<T>>();
		if (contentsList != null && contentsList.Any())
		{
			ITypeAdapter adapter = TypeAdapterFactory.CreateAdapter();
			contentsTree = adapter.Adapt<List<TREE_NODE<T>>>(contentsList);
		}
		return contentsTree;
	}

	public IList<DOC_CONTENTSDTO> LoadCONTENTSTree()
	{
		string sqlKey = "LoadContentTree";
		QueryResult<DOC_CONTENTSDTO> orgQueryResult = SqlQueryResult<DOC_CONTENTSDTO>(sqlKey, null);
		return orgQueryResult.List;
	}

	public void RemoveDocContent(string codeIds)
	{
		string[] codeIdArray = codeIds.Split(',');
		string[] array = codeIdArray;
		foreach (string codeId in array)
		{
			DOC_CONTENTS codePOCO = doccontentsRepository.GetByKey(Guid.Parse(codeId));
			if (codePOCO != null)
			{
				codePOCO.ISDEL = 1m;
				doccontentsRepository.Update(codePOCO);
			}
		}
		doccontentsRepository.DbContext.Commit();
	}

	public QueryResult<DOC_CONTENTSDTO> GetDocContentList(DOC_CONTENTSDTO parameter)
	{
		SqlRepository repository = new SqlRepository(null);
		string sqlExpress = repository.GetSqlConfig("GetDocContentList", GetType());
		return repository.SqlQueryPager<DOC_CONTENTSDTO>(sqlExpress, parameter);
	}

	public IList<DOC_CONTENTSDTO> GetSuggestTableByID()
	{
		return SqlQuery<DOC_CONTENTSDTO>("GetAllContent", null);
	}

	public DOC_CONTENTSDTO GetContentByID(Guid ContentId)
	{
		IList<DOC_CONTENTSDTO> dtoResult = SqlQuery<DOC_CONTENTSDTO>("GetContentByID", new
		{
			CONTENT_ID = ContentId
		});
		DOC_CONTENTSDTO dto = new DOC_CONTENTSDTO();
		if (dtoResult.Count > 0)
		{
			return dtoResult[0];
		}
		return dto;
	}

	public QueryResult<AttachmentDTO> QueryFileList(AttachmentDTO parameter)
	{
		SqlRepository repository = new SqlRepository(null);
		string sqlExpress = repository.GetSqlConfig("GetFileList", GetType());
		QueryResult<AttachmentDTO> attachmentDTOList = repository.SqlQueryPager<AttachmentDTO>(sqlExpress, parameter);
		foreach (AttachmentDTO attachmentDTO in attachmentDTOList.List)
		{
			if (attachmentDTO.ATTACHMENT_SIZE.Value / 1048576m > 1m)
			{
				attachmentDTO.ATTACHMENTSIZENAME = decimal.Round(attachmentDTO.ATTACHMENT_SIZE.Value / 1048576m, 2) + "MB";
			}
			else
			{
				attachmentDTO.ATTACHMENTSIZENAME = decimal.Round(attachmentDTO.ATTACHMENT_SIZE.Value / 1024m, 2) + "KB";
			}
		}
		return attachmentDTOList;
	}
}
