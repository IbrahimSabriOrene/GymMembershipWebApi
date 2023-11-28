
using Customer.Domain.Common.Interfaces.Persistence;

using Customer.Domain.Person;
using Customer.Domain.Products.ValueObjects;
using ErrorOr;
using MediatR;
using MemberInfo.Domain.Common.Interfaces.Persistence;
namespace MemberInfo.Application.Customers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Person>>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ErrorOr<Person>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            await Task.CompletedTask;
            var productId = ProductId.CreateUnique();

            var person = Person.Create(
                firstName: request.FirstName,
                lastName: request.LastName,
                email: request.Email,
                phoneNumber: request.PhoneNumber,
                productId: productId


            );
            _customerRepository.Add(person);
            return person;

        }

        /*  public static Person Create(
                string firstName,
                string lastName,
                string email,
                string phoneNumber,
                ProductId productId)
            {
        */

    }

}