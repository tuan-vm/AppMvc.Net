using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace AppMVC01.ExtendMethods
{
    public static class AppExtend
    {
        public static void AddStatusCodePage(this IApplicationBuilder app)
        {
            //Code error 400 -599
            app.UseStatusCodePages(appError =>
            {
                appError.Run(async context =>
                {
                    var respone = context.Response;
                    var code = respone.StatusCode;

                    var content = $@"<html>
                                    <head>
                                        <meta charset='UTF-8'/>
                                        <title> Loi {code}</title>

                                    </head>
                                       <body> <p style='color:red; font-size: 30px'>Co loi xay ra {code} - {(HttpStatusCode)code} </p> </body>
                                    </html>";
                    await respone.WriteAsync(content);
                });
            });
        }
    }
}
