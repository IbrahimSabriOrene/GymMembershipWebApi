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
            var months = product.Months;
            var expirationDate = product.GetExpirationDate(months, DateTime.UtcNow);
            //This is how its gonna work. We are gonna get GetExpirationDate(ProductId, DateTime.UtcNow) and make calculations based on that.
            //we can get the expiration date from the product itself.
            //var expirationDate = product.GetExpirationDate(months, DateTime.UtcNow); returns DateTime but added months depends on ProductId
            //getExpirationDate is calculation based on ICustomerRepository
            //var ExpirationDate = product.ExpirationDate.
            //if (productId is null): return Errors.NullReference.ProductNotFound("Product not found");
            var personTask = Task.Run(() => Person.Create(
                firstName: command.FirstName,
                lastName: command.LastName,
                email: command.Email,
                phoneNumber: command.PhoneNumber,
                productId: productId,
                expirationDate: Expiration.GetExpiration(expirationDate)
            //move this to another service class.
            // remove expiration date from here. this is how its gonna work: user chooses the productId, 
            //then the expiration date is set automatically based on the product chosen.
            ));

            var person = await personTask;
            //move addmonths to domain layer.





            _customerRepository.Add(person);

            

            return person;

        }

        // return new CustomerResult(
        //     person,
        //     person.Expiration
        // );
    }
}


