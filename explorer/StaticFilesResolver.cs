using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace explorer
{
    public class StaticFileResolver
    {
        private readonly IWebHostEnvironment _env;
        private readonly WebpackAssets _webpackAssets;
        public StaticFileResolver(IWebHostEnvironment env, WebpackAssets webpackAssets)
        {
            _env = env;
            _webpackAssets = webpackAssets;
        }
        
        public string GetStylesheetUrl(string name)
        {
            if (_env.IsDevelopment())
            {
                return $"http://localhost:8080/{name}.css";
            }

            return _webpackAssets[name].Css;
        }

        public string GetScriptUrl(string name)
        {
            if (_env.IsDevelopment())
            {
                return $"http://localhost:8080/{name}.js";
            }

            return _webpackAssets[name].Js;
        }
    }
}