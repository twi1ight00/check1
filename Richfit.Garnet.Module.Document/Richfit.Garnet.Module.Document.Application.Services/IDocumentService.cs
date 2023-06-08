using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Attachment.Application.DTO;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Document.Application.DTO;

namespace Richfit.Garnet.Module.Document.Application.Services;

public interface IDocumentService
{
	DOC_CONTENTSDTO AddContent(DOC_CONTENTSDTO codeDTO);

	IList<TREE_NODE<T>> GetContentsTree<T>() where T : struct;

	IList<DOC_CONTENTSDTO> LoadCONTENTSTree();

	DOC_CONTENTSDTO UpdateDocContent(DOC_CONTENTSDTO codeDTO);

	void RemoveDocContent(string codeDTOId);

	QueryResult<DOC_CONTENTSDTO> GetDocContentList(DOC_CONTENTSDTO parameter);

	IList<DOC_CONTENTSDTO> GetSuggestTableByID();

	DOC_CONTENTSDTO GetContentByID(Guid ContentId);

	QueryResult<AttachmentDTO> QueryFileList(AttachmentDTO attachmentdto);
}
