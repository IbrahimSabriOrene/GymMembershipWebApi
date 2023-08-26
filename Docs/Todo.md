TODO:

Return the list of personId's that has same product id, 

```

SqlDatabase should look like this

ProductTable

| ProductId | ProductName | ProductPrice | CreatedDate | ModifiedDate |
Person Table

| PersonId | PersonName | ProductId | ProductName | ProductPrice | isActive | CreatedDate | ModifiedDate | ExpirationDate |

```

Shall i remove PersonId from Product controller?? not sure

```

Currently looks like this

{
  "productId": "0bfa2514-7ca3-406a-9b2b-655c8fc68bbe",
  "productName": "Sample Product",
  "price": [
    {
      "amount": 1132130,
      "currency": "TRY"
    }
  ],
  "months": 6,
  "creationDate": "2023-08-26T14:21:41.1166105Z",
  "lastUpdateDate": "2023-08-26T14:21:41.1166109Z",
  "personId": "cd3e5fc5-2a88-44fd-aed6-095965df4635"
}

What i want


{
  "productId": "0bfa2514-7ca3-406a-9b2b-655c8fc68bbe", --> this is not primary key and unique to the product
  "productName": "Sample Product",
  "price": [
    {
      "amount": 1132130,
      "currency": "TRY"
    }
  ],
  "months": 6,
  "creationDate": "2023-08-26T14:21:41.1166105Z",
  "lastUpdateDate": "2023-08-26T14:21:41.1166109Z",
  "personIds": [
    "cd3e5fc5-2a88-44fd-aed6-095965df4635",
    "cd3e5fc5-2a88-44fd-aed6-095965df4635",
    "cd3e5fc5-2a88-44fd-aed6-095965df4635"
  ]
}

this would look like in sql db:

productId | productName | price | months | creationDate | lastUpdateDate | personIds
------------------------------------------------------------------------------------


like imagine that we have 1000 personId's that has same product id, we can get the list of personId's that has same product id.

Todo:
make product controller return personIds array instead of personId

shall i use List or Array for personIds array?? not sure

every person has its own delay for the product, so we need to store the left date for every person.

I am gonna create new branch for this

```

remove personId from product, because product is only for products, what we need is making the person object,
and we need to store product id in person object, so we can get the list of personId's that has same product id.

also we have to get months from product object, and store it in person object, so we can calculate the expiration date for every person.
But what if someone wants to get the list of personId's that has same product id also isActive = true.

so basically the person have:

Id,  --> Primary Key
Name,
ProductId, --> Foreign Key
IsActive,
ExpirationDate,
CreationDate,
ModifiedDate

and for the product:

Id, --> Primary Key
Name,
Price,
Months,
CreationDate,
ModifiedDate


SELECT * FROM Person WHERE ProductId = '0bfa2514-7ca3-406a-9b2b-655c8fc68bbe' AND IsActive = true

Response: 

```

{
  "personId": "cd3e5fc5-2a88-44fd-aed6-095965df4635", --> this is primary key
  "personName": "Sample Person", 
  "productId": "0bfa2514-7ca3-406a-9b2b-655c8fc68bbe", --> this is calculated from product's id
  "isActive": true, --> this is calculated from expiration date
  "expirationDate": "2023-08-26T14:21:41.1166109Z", --> this is calculated from product's months
  "creationDate": "2023-08-26T14:21:41.1166105Z",
  "lastUpdateDate": "2023-08-26T14:21:41.1166109Z"
}

```

Expiration date related to product's months, so we need to store months?? in person object, so we can calculate the expiration date for every person.
So person has to be logged in to the system, after logging in, we can add a product to its values.
This means everything except personId and person name can be null at beginning 

```

