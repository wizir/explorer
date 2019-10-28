using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace explorer
{
    public class WebpackAssets
    {
        private IReadOnlyDictionary<string, Entry> _assets;
        private readonly IWebHostEnvironment _env;
        private readonly IFileInfo _webpackAssetsFile;
        public WebpackAssets(IWebHostEnvironment env)
        {
            var fileInfo = env.WebRootFileProvider.GetFileInfo("webpack-assets.json");

            if (!fileInfo.Exists)
            {
                throw new InvalidOperationException("wwwroot/webpack-assets.json file does not exists");
            }

            _env = env;
            _webpackAssetsFile = fileInfo;
            
            using var stream = fileInfo.CreateReadStream();
            using var reader = new StreamReader(stream);
                
            var json = reader.ReadToEnd();

            _assets = JsonConvert.DeserializeObject<IReadOnlyDictionary<string, Entry>>(json);
        }

        public Entry this[string name]
        {
            get
            {
                if (_env.IsDevelopment())
                {
                    using var stream = _webpackAssetsFile.CreateReadStream();
                    using var reader = new StreamReader(stream);
                
                    var json = reader.ReadToEnd();

                    _assets = JsonConvert.DeserializeObject<IReadOnlyDictionary<string, Entry>>(json);
                }
                if (_assets.TryGetValue(name, out var result))
                    return result;
                
                throw  new KeyNotFoundException($"webpack-manifest dest not contain entry for '${name}'");
            }
        }
    }

    public class Entry
    {
        public string Css { get; set; }
        public string Js { get; set; }
    }
}