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
    public class DeleteBookTest : BaseTest
    {
        [TestCase("d5298eac-065e-4f61-b675-221c1a9a040c", "9781449325862")]
        [TestCase("d5298eac-065e-4f61-b675-221c1a9a040c142475", "9781449325862")]
        [Category("DeleteUsers")]

        public async Task DeleteUserSuccessful(string userId, string isbn)
        {

            var response = await BookService.DeleteUserAsync(userId, isbn);
            
            using (new AssertionScope())
            {
                TestContext.Progress.WriteLine("Delete user");
                TestContext.Progress.WriteLine("Status code: " + response.StatusCode);
                TestContext.Progress.WriteLine(response.Content);
                
                switch (response.StatusCode) {
                    case HttpStatusCode.NoContent:                        
                        response.Data.UserId.Should().Be(userId);
                        response.Data.Isbn.Should().Be(isbn);
                        response.Data.Message.Should().NotBeNullOrEmpty();
                        TestContext.Progress.WriteLine("Delete user successful");
                        break;

                     case HttpStatusCode.BadRequest:
                        response.Data.Code.Should().BePositive();
                        response.Data.Message.Should().NotBeNullOrEmpty();
                        TestContext.Progress.WriteLine("Delete user failed: " + response.Data.Message);
                        break;   

                    case HttpStatusCode.Unauthorized:  
                        response.Data.Code.Should().BePositive(); 
                        response.Data.Message.Should().NotBeNullOrEmpty();
                        TestContext.Progress.WriteLine("Delete user failed: " + response.Data.Message);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

            
            }
        }
    }
}