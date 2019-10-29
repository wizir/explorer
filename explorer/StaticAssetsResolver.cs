using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace explorer
{
    public interface IStaticAssetsResolver
    {
        string GetStylesheetUrl(string name);
        string GetScriptUrl(string name);
    }
    
    public class StaticAssetsResolver : IStaticAssetsResolver
    {
        private readonly IWebHostEnvironment _env;
        private readonly WebpackAssets _webpackAssets;
        public StaticAssetsResolver(IWebHostEnvironment env, WebpackAssets webpackAssets)
        {
            _env = env;
            _webpackAssets = webpackAssets;
        }
        
        public string GetStylesheetUrl(string name)
        {
            if (_env.IsDevelopment())
            {
                return $"https://localhost:8080/{name}.js";
            }

            return _webpackAssets[name].Css;
        }

        public string GetScriptUrl(string name)
        {
            if (_env.IsDevelopment())
            {
                return $"https://localhost:8080/{name}.js";
            }

            return _webpackAssets[name].Js;
        }
    }
}