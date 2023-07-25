using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automation.Test.Cores.Utilities;
using FluentAssertions;
using Newtonsoft.Json;
using NJsonSchema;
using RestSharp;

namespace Automation.Test.Cores.Extensions
{
    public static class RestExtension
    {
        public static async void VerifySchema(this RestResponse response, string pathFile) {
            var schema = await JsonSchema.FromJsonAsync(JsonFileUtility.ReadJsonFile(pathFile));
            schema.Validate(response.Content).Should().NotBeNull();
        }

        public static dynamic ConvertToDynamicObject(this RestResponse response) {
            return (dynamic)JsonConvert.DeserializeObject(response.Content);
        }

        public static void VerifyStatusCodeOk(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        public static void VerifyStatusCodeCreated(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }

        public static void VerifyStatusCodeBadRequest(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        public static void VerifyStatusCodeUnauthorized(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }

        public static void VerifyStatusCodeNotFound(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        public static void VerifyStatusCodeNoContent(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        public static void VerifyStatusCodeInternalServerError(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        public static void VerifyStatusCodeConflict(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Conflict);
        }

        public static void VerifyStatusCodeForbidden(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

        public static void VerifyStatusCodeMethodNotAllowed(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.MethodNotAllowed);
        }

        public static void VerifyStatusCodeNotAcceptable(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotAcceptable);
        }

        public static void VerifyStatusCodeNotImplemented(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotImplemented);
        }

        public static void VerifyStatusCodeServiceUnavailable(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.ServiceUnavailable);
        }

        public static void VerifyStatusCodeGatewayTimeout(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.GatewayTimeout);
        }

        public static void VerifyStatusCodePreconditionFailed(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.PreconditionFailed);
        }

        public static void VerifyStatusCodeUnsupportedMediaType(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnsupportedMediaType);
        }

        public static void VerifyStatusCodeUnprocessableEntity(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnprocessableEntity);
        }

        public static void VerifyStatusCodeLocked(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Locked);
        }

        public static void VerifyStatusCodeUpgradeRequired(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UpgradeRequired);
        }

        public static void VerifyStatusCodeTooManyRequests(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.TooManyRequests);
        }

        public static void VerifyStatusCodeRequestHeaderFieldsTooLarge(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.RequestHeaderFieldsTooLarge);
        }

        public static void VerifyStatusCodeUnavailableForLegalReasons(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.UnavailableForLegalReasons);
        }

        public static void VerifyStatusCodeNetworkAuthenticationRequired(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NetworkAuthenticationRequired);
        }

        public static void VerifyStatusCodeContinue(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Continue);
        }

        public static void VerifyStatusCodeSwitchingProtocols(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.SwitchingProtocols);
        }

        public static void VerifyStatusCodeProcessing(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Processing);
        }

        public static void VerifyStatusCodeEarlyHints(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.EarlyHints);
        }

        public static void VerifyStatusCodePermanentRedirect(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.PermanentRedirect);
        }

        public static void VerifyStatusCodeTemporaryRedirect(this RestResponse response) {
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.TemporaryRedirect);
        }

        



    }
}