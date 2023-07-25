using System.Xml.Linq;
using System.Net;
using FluentAssertions;
using NUnit.Framework;
using FluentAssertions.Execution;
using Automation.Test.Cores.Extensions;
using Automation.Tests.Constants;
using System;
using Automation.Services.Models;

namespace Automation.Tests.Tests
{
    public class UserServiceTest : BaseTest
    {


        [TestCase("cytest", "cytest@cypss.io", "Female", "Active")]
        [Category("CreateUsers")]
        public async Task CreateUserSuccessful(string name, string email, string gender, string status)
        {

            var respone = await UserService.CreateUserAsync(name, email, gender, status);
            
         
            using (new AssertionScope())
            {
                TestContext.Progress.WriteLine("Create new user");
                TestContext.Progress.WriteLine("Status code: " + respone.StatusCode);
                TestContext.Progress.WriteLine(respone.Content);

                respone.Data.Code.Should().Be(201);

                respone.Data.Meta.Should().BeNull();
                
               
                respone.Data.Users.Id.Should().BePositive();
                respone.Data.Users.Name.Should().Be(name);
                respone.Data.Users.Email.Should().Be(email);
                respone.Data.Users.Gender.Should().Be(gender);
                respone.Data.Users.Status.Should().Be(status);
                
                
            }
        }


        [Test]
        [Category("GetUsers")]

        public async Task GetUserSuccessful()
        {

            var respone = await UserService.GetUserAsync();

            respone.VerifySchema(FileConstant.GetAllUserSchemaFilePath.GetAbsolutePath());

            using (new AssertionScope())
            {
                TestContext.Progress.WriteLine("Get all users");
                TestContext.Progress.WriteLine("Status code: " + respone.StatusCode);
                TestContext.Progress.WriteLine(respone.Content);
                respone.StatusCode.Should().Be(HttpStatusCode.OK);

                respone.Data.Meta.Should().NotBeNull();
                
                respone.Data.Meta.Pagination.Should().NotBeNull();
                respone.Data.Meta.Pagination.Limit.Should().BePositive();
                respone.Data.Meta.Pagination.Page.Should().BePositive();
                respone.Data.Meta.Pagination.Pages.Should().BePositive();
                respone.Data.Meta.Pagination.Total.Should().BePositive();
                respone.Data.Users.Should().NotBeEmpty();

            }
        }

        [TestCase("1254", "Bhavani Bhattacharya MD", "bhattacharya_bhavani_md@hoeger-barton.org", "female", "active")]
        [Category("GetDetailedUsers")]

        public async Task GetUserSuccessfulWhenExistData(string userId, string name, string email, string gender, string status)
        {

            var respone = await UserService.GetUserDetailAsync(userId);

            

            using (new AssertionScope())
            {
                TestContext.Progress.WriteLine("Get detailed user");
                TestContext.Progress.WriteLine("Status code: " + respone.StatusCode);
                TestContext.Progress.WriteLine(respone.Content);
                respone.StatusCode.Should().Be(HttpStatusCode.OK);

                respone.Data.Meta.Should().BeNull();
               
                respone.Data.Users.Name.Should().Be(name);
                respone.Data.Users.Email.Should().Be(email);
                respone.Data.Users.Gender.Should().Be(gender);
                respone.Data.Users.Status.Should().Be(status);

            }
        }

        [TestCase("3525", "Chandraayan Naik", "naik_chandraayan@ratke.com", "male", "inactive")]
        [Category("UpdateUserWithSchema")]

        public async Task UpdateUserWithSchemaSuccessful(string userId, string name, string email, string gender, string status)
        {

            var respone = await UserService.UpdateUserAsync(userId, email, gender, status);
            

            respone.VerifySchema(FileConstant.GetAllUserSchemaFilePath.GetAbsolutePath());




            using (new AssertionScope())
            {
                TestContext.Progress.WriteLine("Update user with schema");
                TestContext.Progress.WriteLine("Status code: " + respone.StatusCode);
                TestContext.Progress.WriteLine(respone.Content);
                respone.StatusCode.Should().Be(HttpStatusCode.OK);

                var user = Int32.Parse(userId);

                respone.Data.Users.Id.Should().Be(user);
                respone.Data.Users.Name.Should().Be(name);
                respone.Data.Users.Email.Should().Be(email);
                respone.Data.Users.Gender.Should().Be(gender);
                respone.Data.Users.Status.Should().Be(status);

            
            }
        }

        [TestCase("3525")]
        [Category("DeleteUsers")]

        public async Task DeleteUserSuccessful(string userId)
        {

            var respone = await UserService.DeleteUserAsync(userId);
            





            using (new AssertionScope())
            {
                TestContext.Progress.WriteLine("Delete user");
                TestContext.Progress.WriteLine("Status code: " + respone.StatusCode);
                TestContext.Progress.WriteLine(respone.Content);
                

                respone.Data.Code.Should().Be(204);
                respone.Data.Meta.Should().BeNull();
                respone.Data.Users.Should().BeNull();

            
            }
        }

    }
}