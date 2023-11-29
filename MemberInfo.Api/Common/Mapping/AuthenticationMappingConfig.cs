using Mapster;
using Customer.Application.Authentication.Commands.Register;
using Customer.Application.Authentication.Common;
using Customer.Application.Authentication.Queries.Login;
using Customer.Contracts.Authentication;

namespace Customer.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<UserResult, AuthenticationResponse>()
        .Map(dest => dest, src => src.User);
    }
}
