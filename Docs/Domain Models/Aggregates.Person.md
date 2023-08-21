# Domain Models

## Person


```csharp
class Person{
    Guid Id;
    string FirstName;
    string LastName;
    string PhoneNumber;
    string Email;
    DateTime CreationDate;
    DateTime ExpirationDate;
    DateTime LastUpdateDate;
    double TotalSpent = Person.Packages.Sum(p => p.Price);
    List<Guid> PackagesId;

}
```
POST /api/v1/persons
```json
{
    "FirstName": "John",
    "LastName": "Doe",
    "PhoneNumber": "+1-555-123-4567",
    "Email": "john.doe@example.com",
    "ProductId": "000000-00000000-0000000-00000000"
}
```	
```json


{
    "Id": "000000-00000000-0000000-00000001",
    "FirstName": "John",
    "LastName": "Doe",
    "PhoneNumber": "+1-555-123-4567",
    "Email": "john.doe@example.com",
    "CreationDate": "2023-08-21T10:15:00Z",
    "ExpirationDate": "2023-12-31T23:59:59Z",
    "LastUpdateDate": "2023-08-21T10:15:00Z",
    "ProductId": "000000-00000000-0000000-00000000"
}



```