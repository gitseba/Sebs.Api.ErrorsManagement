# Sebs.Api.ErrorsManagement

Purpose: Consistent API error responses.
Note: Project includes Api.ErrorManagement.postman_collection.json file for generating different errors in ErrorGeneratorController. 

#Handlers
ApiResponse class will return specific response and format based on response status code.

#Middlewares
ExceptionMiddleware - Purpose: Format the exception if it occurs in the system 
E.g: System.NullReferenceException: Object reference not set to an instance of an object.
Usage: app.UseMiddleware<ExceptionMiddleware>();

#Controllers
ErrorGeneratorController - generate different responses

ErrorHandlerController -  Purpose: handle requests that don't exist ({{url}}/api/endpointthatdoesnotexist) (see postman collection)
- Used in conjunction with: app.UseStatusCodePagesWithReExecute("/errors/{0}"); // Program.cs
