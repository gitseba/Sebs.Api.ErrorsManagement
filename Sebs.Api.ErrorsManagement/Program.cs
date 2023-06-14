using Microsoft.AspNetCore.Mvc;
using Sebs.Api.ErrorsManagement;
using Sebs.Api.ErrorsManagement.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// this will flatten the errors 
builder.Services.Configure<ApiBehaviorOptions>(o =>
{
	o.InvalidModelStateResponseFactory = actionContext =>
	{
		var errors = actionContext.ModelState
		.Where(e => e.Value.Errors.Count > 0)
		.SelectMany(x => x.Value.Errors)
		.Select(x => x.ErrorMessage).ToArray();

		var errorResponse = new ApiValidationErrorResponse
		{
			Errors = errors
		};

		return new BadRequestObjectResult(errorResponse);
	};
});

var app = builder.Build();

// Exception/Errors Handlers
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
