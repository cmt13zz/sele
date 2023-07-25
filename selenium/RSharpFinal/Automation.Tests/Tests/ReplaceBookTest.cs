using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions.Execution;
using NUnit.Framework;
using Automation.Services.Services;
using FluentAssertions;
using Automation.Test.Cores.Extensions;
using Automation.Tests.Constants;

namespace Automation.Tests.Tests
{
    public class ReplaceBookTest : BaseTest
    {


        [TestCase("9781449325862", "d5298eac-065e-4f61-b675-221c1a9a040c", "9781449331818", "cmtchuong")]
        [TestCase("9781449325862", "d5298eac-065e-4f61-b675-221c1a9a040c14245", "9781449331818", "cmtchuong")]
        [Category("ReplaceBookWithSchema")]

        public async Task ReplaceBookWithSchema(string isbn, string userId, string isbnReplace, string username)
        {

            var response = await BookService.UpdateBookAsync(isbn, userId, isbnReplace);
            var bookResponse = await BookService.GetBookDetailAsync(isbnReplace);

            response.VerifySchema(FileConstant.GetAllUserSchemaFilePath.GetAbsolutePath());




            using (new AssertionScope())
            {
                TestContext.Progress.WriteLine("Update new book with schema");
                TestContext.Progress.WriteLine("Status code: " + response.StatusCode);
                TestContext.Progress.WriteLine(response.Content);

                switch (response.StatusCode) {
                    case HttpStatusCode.Created:                        
                        response.Data.UserId.Should().Be(userId);
                        response.Data.Username.Should().Be(username);
                        response.Data.Books.Should().NotBeNull();
                        response.Data.Books[0].Isbn.Should().Be(isbnReplace);
                        response.Data.Books[0].Title.Should().Be(bookResponse.Data.Title);
                        response.Data.Books[0].Author.Should().Be(bookResponse.Data.Author);
                        response.Data.Books[0].Description.Should().Be(bookResponse.Data.Description);
                        response.Data.Books[0].Subtitle.Should().Be(bookResponse.Data.Subtitle);
                        response.Data.Books[0].Publisher.Should().Be(bookResponse.Data.Publisher);
                        response.Data.Books[0].Website.Should().Be(bookResponse.Data.Website);
                        TestContext.Progress.WriteLine("Update new book successful");

                        break;

                     case HttpStatusCode.BadRequest:
                        response.Data.Code.Should().BePositive();
                        response.Data.Message.Should().NotBeNullOrEmpty();
                        TestContext.Progress.WriteLine("Update new book failed: ", response.Data.Message);
                        break;   

                    case HttpStatusCode.Unauthorized:  
                        response.Data.Code.Should().BePositive(); 
                        response.Data.Message.Should().NotBeNullOrEmpty();
                        TestContext.Progress.WriteLine("Update new book failed: " + response.Data.Message);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

       
    }
}