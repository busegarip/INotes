using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(INotes.API.Startup))]

namespace INotes.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);//api projesine UI projesinden erişebilmek için yazdık kapıyı pencereyi açıyoruz.
            ConfigureAuth(app);
        }
    }
}
