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

Change naming


list

start persontask


Revize api


Get users month inside the customer.

Instead of product's dateTime trick. No need.

What i really wanted is different than what i am going to do rightnow.

Change versions.


---Start making mappings in MemberInfo.Api part.


---After completing the mapping, there will be some changes about this api.

use Result.cs for Application layer. With this way you can map them easily.