using ErrorOr;

namespace Customer.Domain.Common.Errors;

public static partial class Errors
{
  public static class NullReference
  {
    public static Error ProductNotFound(string description)
    {

      return Error.NotFound(
        code: "Product.NotFound",
        description: description);
    }
  }

  public static Error CustomerNotFound(string description)
  {

    return Error.NotFound(
      code: "Customer.NotFound",
      description: description);
  }


}
