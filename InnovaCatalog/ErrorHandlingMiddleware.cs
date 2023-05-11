namespace InnovaCatalog
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Loguear la excepción si es necesario

            // Preparar una respuesta de error
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            // Aquí puedes personalizar el formato de la respuesta de error según tus necesidades
            var errorMessage = $"{{ \"error\": \"{exception.Message}\" }}";
            return context.Response.WriteAsync(errorMessage);
        }
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver una respuesta de error adecuada
                await HandleExceptionAsync(context, ex);
            }
        }
    }
}
