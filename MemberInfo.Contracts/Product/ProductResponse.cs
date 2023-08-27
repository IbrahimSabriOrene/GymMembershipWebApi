using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberInfo.Contracts.Product;

public record ProductResponse
(
     Guid ProductId,
     string ProductName,
     int Months,
     decimal Price
    
); 
