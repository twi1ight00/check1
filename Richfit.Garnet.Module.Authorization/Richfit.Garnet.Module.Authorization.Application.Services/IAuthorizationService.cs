using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Authorization.Application.DTO;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;

namespace Richfit.Garnet.Module.Authorization.Application.Services;

public interface IAuthorizationService
{
	QueryResult<SYS_AUTHORIZATION_PERSONDTO> GetAuthorizationPersonList(SYS_AUTHORIZATION_PERSONDTO trDTO);

	IList<AUTHORIZATION_ROLEDTO> GetRoleByUserID(AUTHORIZATION_ROLEDTO trDTO);

	IList<AUTHORIZATION_BUSINESSDTO> GetBusinessList(AUTHORIZATION_BUSINESSDTO trDTO);

	SYS_AUTHORIZATIONDTO SaveBusinessInfo(SYS_AUTHORIZATIONDTO trDTO);

	QueryResult<AUTHORIZATION_USERLISTDTO> QueryUserList(AUTHORIZATION_USERLISTDTO trDTO);

	SYS_AUTHORIZATION_SPECIALDTO SaveUserList(IList<SYS_AUTHORIZATION_SPECIALDTO> trDTO, Guid userID);

	QueryResult<SYS_AUTHORIZATIONDTO> GetAuthorizationListByUserID(SYS_AUTHORIZATIONDTO trDTO);

	void RemoveRecord(Guid authorizationID);

	void EditAuthInfo(Dictionary<string, string> dataparams);

	IList<AUTHORIZATION_BUSINESSDTO> GetBusinessListByAuthID(AUTHORIZATION_BUSINESSDTO trDTO);

	IList<AUTHORIZATION_BUSINESSDTO> GetRoleByAuthID(AUTHORIZATION_BUSINESSDTO trDTO);

	SYS_AUTHORIZATIONDTO GetAuthorizationByauthID(Guid authID);

	IList<SYS_AUTHORIZATION_SPECIALDTO> GetAuthorizationSpecialList(SYS_AUTHORIZATION_SPECIALDTO trDTO);

	SYS_AUTHORIZATIONDTO SaveAuthorization(SYS_AUTHORIZATIONDTO dict);

	QueryResult<SYS_AUTHORIZATIONDTO> GetAuthorizationByauthID(SYS_AUTHORIZATIONDTO dict);

	IList<AUTHORIZATION_BUSINESSDTO> GetAuthorizationRole(SYS_AUTHORIZATIONDTO dict);
}
