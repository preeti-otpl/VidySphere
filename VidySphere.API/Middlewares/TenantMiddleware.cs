namespace VidySphere.API.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var host = context.Request.Host.Host;

            // Example: gd.vidysphere.com → gd
            var subdomain = host.Split('.')[0];

            // TODO: fetch tenant from DB using subdomain
            // For now:
            var tenantId = subdomain switch
            {
                "gd" => 1,
                "md" => 2,
                _ => 0
            };

            context.Items["TenantId"] = tenantId;

            await _next(context);
        }
    }
}
