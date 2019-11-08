using System.Collections.Generic;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace explorer.Utils    
{
    public static class HttpContextExtensions
    {
        private const string Scripts = "scripts";
        private const string Stylesheets = "stylesheets";
        public static void AddScript(this HttpContext context, string name)
        {
            if (!(context.Items[Scripts] is HashSet<string>))
            {
                context.Items[Scripts] = new HashSet<string>();
            }
            
            var resolver = ServiceProvider.Resolve<IStaticAssetsResolver>();
            
            ((HashSet<string>) context.Items[Scripts]).Add(resolver.GetScriptUrl(name));
        }


        public static HtmlString RenderScripts(this HttpContext context)
        {
            var builder = new StringBuilder();

            if (!(context.Items[Scripts] is HashSet<string> hashSet))
            {
                return HtmlString.Empty;
            }
            
            foreach (var scriptUrl in hashSet)
            {
                builder.AppendLine($"<script src=\"{scriptUrl}\"></script>");
            }

            return new HtmlString(builder.ToString());
        }
        
        public static void AddStylesheet(this HttpContext context, string name)
        {
            if (!(context.Items[Stylesheets] is HashSet<string>))
            {
                context.Items[Stylesheets] = new HashSet<string>();
            }
            
            var resolver = ServiceProvider.Resolve<IStaticAssetsResolver>();
            
            ((HashSet<string>) context.Items[Stylesheets]).Add(resolver.GetStylesheetUrl(name));
        }


        public static HtmlString RenderStylesheets(this HttpContext context)
        {
            var builder = new StringBuilder();

            if (!(context.Items[Stylesheets] is HashSet<string> hashSet))
            {
                return HtmlString.Empty;
            }

            var env = ServiceProvider.Resolve<IWebHostEnvironment>();
            
            foreach (var stylesheetUrl in hashSet)
            {
                if (env.IsDevelopment())
                {
                    builder.AppendLine($"<script src=\"{stylesheetUrl}\"></script>");
                }
                else
                {
                    builder.AppendLine($"<link rel=\"stylesheet\" href=\"{stylesheetUrl}\"/>");
                }
            }

            return new HtmlString(builder.ToString());
        }

    }
}