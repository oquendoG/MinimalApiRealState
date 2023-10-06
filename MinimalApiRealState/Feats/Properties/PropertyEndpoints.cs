using FluentValidation;
using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApiRealState.Data;
using MinimalApiRealState.Feats.Properties.Dtos;
using MinimalApiRealState.Shared;
using System.Net;

namespace MinimalApiRealState.Feats.Properties;

public static class PropertyEndpoints
{
    public static void AddPropertyEndpoints(this IEndpointRouteBuilder app)
    {
        //obtener todas las propiedades
        app.MapGet("api/properties", async (AppDbContext context) =>
        {
            ApiResponse response = new()
            {
                Result = await context.Properties.AsTracking().ToListAsync(),
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
            };

            return Results.Ok(response);
        })
            .WithName("propiedades")
            .Produces<ApiResponse>(200);

        //obtener propiedad por Id
        app.MapGet("api/properties/{id:guid}", async (AppDbContext context, Guid id) =>
        {
            ApiResponse response = new()
            {
                Result = await context.Properties.AsTracking()
                                .FirstOrDefaultAsync(prop => prop.Id == id),
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
            };

            return Results.Ok(response);
        })
            .WithName("propiedad")
            .Produces<ApiResponse>(200);

        //crear propiedad
        app.MapPost("/api/properties", async (AppDbContext context, IValidator<CreatePropertyDto> validator,
            [FromBody] CreatePropertyDto model) =>
        {
            ApiResponse response = new()
            {
                StatusCode = HttpStatusCode.BadRequest
            };

            ValidationResult result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                response.Errors.Add(result.Errors.FirstOrDefault()!.ToString());
                return Results.BadRequest(response);
            }

            if (await context.Properties
                    .FirstOrDefaultAsync(p => p.Name.ToLower() == model.Name.ToLower()) != null)
            {
                response.Errors.Add("El nombre de la propiedad ya existe");
                return Results.BadRequest(response);
            }

            RsProperty property = model.Adapt<RsProperty>();
            await context.Properties.AddAsync(property);
            await context.SaveChangesAsync();

            response.Result = model;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.Created;

            return Results.Ok(response);
        });

        app.MapPut("api/properties", async (AppDbContext context, IValidator<UpdatePropertyDto> validator,
                                            UpdatePropertyDto model) =>
        {
            ApiResponse response = new()
            {
                StatusCode = HttpStatusCode.BadRequest
            };

            ValidationResult result = await validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                response.Errors.Add(result.Errors.FirstOrDefault()!.ToString());
                return Results.BadRequest(response);
            }

            RsProperty property = model.Adapt<RsProperty>();
            context.Properties.Update(property);
            await context.SaveChangesAsync();

            response.Result = model;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.OK;

            return Results.Ok(response);
        });

        app.MapDelete("api/properties/{id:guid}", async (AppDbContext context, Guid id) =>
        {
            ApiResponse response = new()
            {
                StatusCode = HttpStatusCode.BadRequest
            };

            RsProperty? property = await context.Properties.FindAsync(id);
            if (property is null)
            {
                response.Errors.Add("El id de la propiedad es inválido");
                return Results.BadRequest(response);
            }

            context.Properties.Remove(property);
            await context.SaveChangesAsync();

            response.Result = property;
            response.IsSuccess = true;
            response.StatusCode = HttpStatusCode.NoContent;

            return Results.Ok(response);
        });
    }
}
