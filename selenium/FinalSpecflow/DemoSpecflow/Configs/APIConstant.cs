using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSpecflow.Configs
{
    public class APIConstant
    {


        public const string GetBooksEndPoint = "BookStore/v1/Books";

        public const string GetBookEndPoint = "BookStore/v1/Book";

        public const string GetAccountEndPoint = "Account/v1/User";

        public const string GenerateTokenEndpoint = "Account/v1/GenerateToken";

        public const string DeleteAllBooksParam = "UserId"; 
        public const string BookDetailedParam = "ISBN";

        
    }
}