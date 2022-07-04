using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.AnnotationModel;
using MiniValidation;
using WorkShop.Library.IServices;

namespace WebAPI.Endpoints
{
    public static class CommandEndpoints
    {
        public static void AddEndpoints(IEndpointRouteBuilder app)
        {
            app.MapPost("/register/client", async (IRegistrationCommand registrationCommand,[FromBody] RegistrationAnnotation registration) =>
            {
                if(!MiniValidator.TryValidate(registration,out var errors))
                {
                    var response = new { errors };
                    return Results.BadRequest(response);
                }
                var result = await registrationCommand.CreateIndividual(registration);
                if (result)
                {
                    return Results.Ok();
                }
                else
                {

                    return Results.BadRequest(registrationCommand.GetErrorMessage());
                }
            }).WithName("RegisterClient").WithTags("Command");

            app.MapPost("/register/corporate",async (IRegistrationCommand registrationCommand, [FromBody] CorporateRegistrationAnnotation registration) =>
            {
                if (!MiniValidator.TryValidate(registration, out var errors))
                {
                    var response = new { errors };
                    return Results.BadRequest(response);
                }
                var result = await registrationCommand.CreateCorporate(registration);
                if (result)
                {
                    return Results.Ok();
                }
                else
                {
                    return Results.BadRequest(registrationCommand.GetErrorMessage());
                }
            }).WithName("RegisterCorporate").WithTags("Command");
        }
    }
}
