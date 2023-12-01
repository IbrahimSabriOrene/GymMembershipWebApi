# [POST] Register Response
```json

{
  "id": "Guid-id",
  "firstName": "153",
  "lastName": "123",
  "email": "ibrahimoreen@wyandex.com",
  "token": "some-token-thing"
}

```
# [POST] Login Response
```json
{
  "id": "Guid-id",
  "firstName": "153",
  "lastName": "123",
  "email": "ibrahimoreen@wyandex.com",
  "token": "some-token-thing"
}
```
# [POST] Product Response
```json
{
  "productId": "Guid-Id", //Primary Key + Foreign Key
  "productName": "3 Months Subscription",
  "price": [
    {
      "amount": 1200,
      "currency": "USD"
    }
  ],
  "months": 3,
  "creationDate": "2023-12-01T00:49:43.4609048Z",
  "lastUpdateDate": "2023-12-01T00:49:43.4609058Z"
}

```
# [POST] Customer Response
```json
{
  "customerId": {
    "value": "Guid-id" // Primary Key
  },
  "firstName": "John",
  "lastName": "Doe",
  "email": "johndoe@example.com",
  "phoneNumber": "123457890",
  "creationDate": "2023-12-01T00:50:39.0626661Z",
  "lastUpdateDate": "2023-12-01T00:50:39.0626671Z",
  "expirationDate": "2024-03-01T03:50:39.0620031+03:00",
  "productId": {
    "value": "Guid-id" //Foreign key of productId
  }
}
```