# Product API




# [POST] Register Request
```json
{
  
POST {{host}}/auth/register
Content-Type: application/json

{
    "firstname":"153",
    "lastname":"123",
    "email":"ibrahimoreen@wyandex.com",
    "password":"123456"
}

}


```

# [POST] Login Request
```json
POST {{host}}/auth/register
Content-Type: application/json

{
    "firstname":"153",
    "lastname":"123",
    "email":"ibrahimoreen@wyandex.com",
    "password":"123456"
}
```

# [POST] Create Product Request
```json 

  POST {{host}}/customer/createUser
  Content-Type: application/json
  Authorization: Bearer {{token}}
{
    "ProductName": "3 Months Subscription", //String
    "Price": [ // List<Prices>
        {
            "Amount": 1200, // Int
            "Currency": "USD" //String
        }
    ],
    "Months": 3 //Int
}


```

# [POST] Create Customer Request
```json 

  
POST {{host}}/customer/createUser
Content-Type: application/json
Authorization: Bearer {{token}}

{
    "firstName": "John",
    "lastName": "Doe",
    "email": "johndoe@example.com",
    "phoneNumber": "123457890",
    "value": "02090103-71d0-454e-abef-7df0ad51827a" //Value will be customerId
}



```


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


