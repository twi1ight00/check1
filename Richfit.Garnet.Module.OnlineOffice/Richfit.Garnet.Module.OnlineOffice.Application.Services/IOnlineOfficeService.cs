using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.OnlineOffice.Application.DTO;

namespace Richfit.Garnet.Module.OnlineOffice.Application.Services;

public interface IOnlineOfficeService
{
	OL_OFFICEDTO GetOnlineOfficeByObjId(Guid objId);

	void UpateOnlineOffice(OL_OFFICEDTO dto);

	Guid SaveOnlineOffice(OL_OFFICEDTO dto);

	void DelTempOnlineOfficeById(OL_OFFICEDTO parameter);

	IList<OL_OFFICEDTO> GetTempOnlineOfficeByUserId(OL_OFFICEDTO parameter);

	void UpdateOnlineOfficeById(OL_OFFICEDTO dto);

	IList<OL_TEMPLATE_FILEDTO> GetTemplateFileByObjId(OL_TEMPLATE_FILE_MAPPINGDTO parameter);
}
