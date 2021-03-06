﻿using System.Threading.Tasks;
using Abp.Application.Services;
using LylBoilerPlate.Authorization.Accounts.Dto;

namespace LylBoilerPlate.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
