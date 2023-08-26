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
  "personIds": [
    "cd3e5fc5-2a88-44fd-aed6-095965df4635",
    "cd3e5fc5-2a88-44fd-aed6-095965df4635",
    "cd3e5fc5-2a88-44fd-aed6-095965df4635"
  ]
}

we can store many personId's in personIds array, and we can get the list of personId's that has same product id, 

like imagine that we have 1000 personId's that has same product id, we can get the list of personId's that has same product id.

Todo:
make product controller return personIds array instead of personId

shall i use List or Array for personIds array?? not sure

every person has its own delay for the product, so we need to store the left date for every person.

maybe i can make something like 
"personIds": [
    {"id" : "cd3e5fc5-2a88-44fd-aed6-095965df4635",
     "isActive": True,
     "ExpirationDate": "2023-08-26T14:21:41.1166109Z"},
    {"id" : "cd3e5fc5-2a88-44fd-aed6-095965df4635",
     "isActive": True,
     "ExpirationDate": "2023-08-26T14:21:41.1166109Z"},
     {"id" : "cd3e5fc5-2a88-44fd-aed6-095965df4635",
     "isActive": True,
     "ExpirationDate": "2023-08-26T14:21:41.1166109Z"},
  ]
But i am not sure if this is the best way to do it.
I am gonna create new branch for this

```