move these:

```csharp
 foreach (var personId in personIds)
            {
                product.AddPersonId(personId);
            }

```

```csharp
 public static DateTime GetExpirationDate(int months, DateTime date)
        {
            
            return date.AddMonths(months);
        }
```




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


After connecting to the database, connect redis for storing jwt token.