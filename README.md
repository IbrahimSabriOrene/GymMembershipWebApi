# Product API
```json 
{
  "productId": "bdc38fb0-4586-4bed-afdd-37d2248d8e37",
  "productName": "Product 2",
  "price": [
    {
      "amount": 10123150,
      "currency": "USD"
    }
  ],
  "months": 12,
  "creationDate": "2023-10-30T02:58:04.4309434Z",
  "lastUpdateDate": "2023-10-30T02:58:04.4309441Z",
  "personId": [
    {
      "id": "cd3e5fc5-2a88-44fd-aed6-0959652f4635"
    }
  ]
}
```

```json

Person Api
{
  "personId": "cd3e5fc5-2a88-44fd-aed6-0959652f4635",
  "firstName": "Person 1",
  "lastName": "Person 1",
  "email": "",
    "phoneNumber": "",
    "address": "",
    "creationDate": "2023-10-30T02:58:04.4309434Z",
    "lastUpdateDate": "2023-10-30T02:58:04.4309441Z",
    "products": [
        {
            "productId": "bdc38fb0-4586-4bed-afdd-37d2248d8e37"
        }
    ]

}


routes we need.

Create Product.
Get Product.
Get Product by Id.
Update Product.
Delete Product by Id.

Create Person.
Get Person by Id.
Update Person.
Delete Person by Id.

Make sure that the person has a list of products.


