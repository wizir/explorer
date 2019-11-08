using System;
using Microsoft.Extensions.Configuration;
using Reinforced.Typings.Ast.TypeNames;
using Reinforced.Typings.Fluent;
using ConfigurationBuilder = Reinforced.Typings.Fluent.ConfigurationBuilder;

namespace explorer
{
    public static class ReinforcedTypings
    {
        public static void Configure(ConfigurationBuilder configuration)
        {
            configuration.Substitute(typeof(DateTimeOffset), new RtSimpleTypeName("Date"));
            configuration.Substitute(typeof(DateTime), new RtSimpleTypeName("Date"));
            configuration.Context.TargetDirectory = "Components/Model";
            configuration.Global(config =>
            {
                config.UseModules();
                config.RootNamespace("explorer.Model");
                
                
                
                
            });
        }
    }
}