using Mapster;
using MemberInfo.Application.Authentication.Commands.Register;
using MemberInfo.Application.Authentication.Common;
using MemberInfo.Application.Authentication.Queries.Login;
using MemberInfo.Contracts.Authentication;

namespace MemberInfo.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
    
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest, src => src.User);
    }
}
