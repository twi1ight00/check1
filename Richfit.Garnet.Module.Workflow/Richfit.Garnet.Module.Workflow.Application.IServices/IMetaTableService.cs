using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO.Parameters;

namespace Richfit.Garnet.Module.Workflow.Application.IServices;

internal interface IMetaTableService
{
	void SaveMetaTable(WF_META_TABLEDTO metaTable);

	void SaveMetaData(List<WF_METADATADTO> metaData);

	bool CreateTable(Guid templateId);

	bool SaveAccountTable(Guid templateId);

	IList<WF_META_TABLESIMPLEDTO> GetMainMetaTable();

	IList<WF_METADATADTO> GetColByTableId(WF_METADATADTO metaData);

	void SaveAccount(SaveAccountParameter saveAccountParameter);
}
