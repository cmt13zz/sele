using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Automation.Services.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace Automation.Tests.Tests
{
    public class CreateBookTest : BaseTest
    {
        [TestCase("d5298eac-065e-4f61-b675-221c1a9a040c", "9781449325862")]
        [Category("CreateBook")]
        public async Task CreateBookSuccessful(string userId, string isbn)
        {

            var response = await BookService.CreateBookAsync(userId, isbn);
            
         
            using (new AssertionScope())
            {
                TestContext.Progress.WriteLine("Create new book");
                TestContext.Progress.WriteLine("Status code: " + response.StatusCode);
                TestContext.Progress.WriteLine(response.Content);

                switch (response.StatusCode) {
                    case HttpStatusCode.Created:                        
                        response.Data.Isbn.Should().Be(isbn);
                        TestContext.Progress.WriteLine("Create new book successful");
                        break;

                     case HttpStatusCode.BadRequest:
                        response.Data.Code.Should().BePositive();
                        response.Data.Message.Should().NotBeNullOrEmpty();
                        TestContext.Progress.WriteLine("Create new book failed: " + response.Data.Message);
                        break;   

                    case HttpStatusCode.Unauthorized:  
                        response.Data.Code.Should().BePositive(); 
                        response.Data.Message.Should().BeNullOrEmpty();
                        TestContext.Progress.WriteLine("Create new book failed: " + response.Data.Message);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                
            }
        }
    }
}