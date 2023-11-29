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


***create customer result, product result, make connections again***


first Create customer result
then create product result
make mappings about it, change product and customer command
Carry expiration date to the application layer.
make it work!

then when you complete everything includes validation. 

fix the product id system

One person have only 1 product id, 
1 product have multiple person id's
