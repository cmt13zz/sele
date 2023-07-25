
using System.Net;

using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace Automation.Tests.Tests
{
    public class GetDetailedUSerTest : BaseTest
    {
        [TestCase("d5298eac-065e-4f61-b675-221c1a9a040c", "cmtchuong" )]
        [TestCase("d5298eac-065e-4f61-b675-221c1a9a040c141414f5", "cmtchuong")]
        [Category("GetUserAccount")]

        public async Task GetUserSuccessfulWhenExistData(string userId, string username)
        {

            var response = await UserService.GetUserDetailAsync(userId);




            using (new AssertionScope())
            {
                TestContext.Progress.WriteLine("Get detailed user");
                TestContext.Progress.WriteLine("Status code: " + response.StatusCode);
                TestContext.Progress.WriteLine(response.Content);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        response.Data.UserId.Should().Be(userId);
                        response.Data.Username.Should().Be(username);
                        response.Data.Books.Should().NotBeNull();
                        TestContext.Progress.WriteLine("Get detailed user successful");
                       
                        break;

                    case HttpStatusCode.Unauthorized:
                        response.Data.Code.Should().BePositive();
                        response.Data.Message.Should().NotBeNullOrEmpty();
                        TestContext.Progress.WriteLine("Get detailed user failed: " + response.Data.Message);
                        
                        break;

                }

            }
        }

    }
}