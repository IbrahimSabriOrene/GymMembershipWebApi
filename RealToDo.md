move these:

```csharp
//Expiration Date shall move to application layer.
    public DateTime? UpdateExpirationDate(DateTime date)
    {
        Product? product = _productRepository.FindById(ProductId);
        DateTime? expirationDate = product?.GetExpirationDate(date);
        this.ExpirationDate = expirationDate;

        return this.ExpirationDate;

    }
```
