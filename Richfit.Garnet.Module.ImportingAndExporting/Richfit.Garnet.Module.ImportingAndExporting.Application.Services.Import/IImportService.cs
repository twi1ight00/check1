using System;
using System.Collections;
using System.Data;
using Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.Services.Import;

public interface IImportService
{
	Type GetDTOTpe();

	object Validate(DataRow dr, string colName, string value, ref ValidateInfo validate);

	ImportResult Save(IList result, ref ImportResult importResult);
}
