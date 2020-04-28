using System;
using System.Diagnostics;
using System.IO;
using System.Web.Http;
using Owin;
using Beginor.Owin.StaticFile;

namespace MsOwinDemo {

    public class Startup {

        public void Configuration(IAppBuilder app) {
            ConfigStaticFile(app);
            ConfigWebApi(app);
        }

        [Conditional("DEBUG")]
        private void ConfigStaticFile(IAppBuilder app) {
            var options = new StaticFileMiddlewareOptions {
                DefaultFile = "index.html",
                EnableETag = false,
                EnableHtml5LocationMode = false,
                RootDirectory = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "../../../wwwroot"
                )
            };
            app.UseStaticFile(options);
        }

        private static void ConfigWebApi(IAppBuilder app) {
            var config = new HttpConfiguration();
            var xml = config.Formatters.XmlFormatter;
            config.Formatters.Remove(xml);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "rest/{controller}/{id}"
            );
            config.EnsureInitialized();
            app.UseWebApi(config);
        }

    }

}
