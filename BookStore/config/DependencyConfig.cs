using Autofac;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BookStore.DependencyConfig
{
    public static class DependencyConfig
    {
        public static ContainerBuilder RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            RegisterModules(builder);
            return builder;
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            try
            {
                var types = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(s => s.GetTypes())
                        .Where(p => p.IsSubclassOf(typeof(ModuleBase)) && !p.IsAbstract && p.IsClass)
                        .Select(s => Activator.CreateInstance(s) as ModuleBase)
                        .OrderBy(x => x.Order);

                foreach (var moduleBase in types)
                {
                    builder.RegisterModule(moduleBase);
                }
            }
            catch (ReflectionTypeLoadException rtlEx)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Exception exSub in rtlEx.LoaderExceptions)
                {
                    sb.AppendLine(exSub.Message);
                    FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                    if (exFileNotFound != null)
                    {
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                        {
                            sb.AppendLine("Fusion Log:");
                            sb.AppendLine(exFileNotFound.FusionLog);
                        }
                    }
                    sb.AppendLine();
                }
                string errorMessage = sb.ToString();
            }
            catch (Exception ex)
            {
            }

        }
    }
}

