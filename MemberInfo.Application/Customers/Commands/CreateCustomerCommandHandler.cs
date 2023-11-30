using Customer.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Person;
using Customer.Domain.Persons.ValueObjects;
using Customer.Domain.Products;
using ErrorOr;
using MediatR;
using MemberInfo.Domain.Common.Interfaces.Persistence;
using Customer.Domain.Common.Errors;

namespace MemberInfo.Application.Customers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Person>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<Person>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {


            Product? product = _productRepository.FindById(command.Value);
            if (product is null)
            {
                return Errors.NullReference.ProductNotFound("Product not found");
            }
            var productId = product.Id;
            var currentDate = DateTime.UtcNow;
            var months = product.Months;



            var expirationDate = Product.GetExpirationDate(months, currentDate);
            var personTask = Task.Run(() => Person.Create(
                firstName: command.FirstName,
                lastName: command.LastName,
                email: command.Email,
                phoneNumber: command.PhoneNumber,
                productId: productId,
                expirationDate: Expiration.GetExpiration(expirationDate)
                // fix namings
            ));

            var person = await personTask;





            _customerRepository.Add(person);

            

            return person;

        }

        // return new CustomerResult(
        //     person,
        //     person.Expiration
        // );
    }
}


