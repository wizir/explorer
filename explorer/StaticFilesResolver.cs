using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace explorer
{
    public interface IStaticFileResolver
    {
        string GetStylesheetUrl(string name);
        string GetScriptUrl(string name);
    }
    
    public class StaticFileResolver : IStaticFileResolver
    {
        private readonly IWebHostEnvironment _env;
        public StaticFileResolver(IWebHostEnvironment env)
        {
            _env = env;
        }
        
        public string GetStylesheetUrl(string name)
        {
            if (_env.IsDevelopment())
            {
                return $"https://localhost:8080/dist/{name}.js";
            }
            
            
            return "";
        }

        public string GetScriptUrl(string name)
        {
            return "main-7d3aa80c5903c6dd62ff.js";
        }
    }
}