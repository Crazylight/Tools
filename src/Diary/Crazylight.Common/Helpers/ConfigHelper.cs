using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Crazylight.Common.Helpers
{
    public class ConfigHelper
    {
        /// <summary>
        /// 配置
        /// </summary>
        public static IConfiguration Configuration { get; set; }
        public static string IsOnline { get; set; }
        public static void InitConfig()
        {
            try
            {
                string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);


                var builder = new ConfigurationBuilder().SetBasePath(path);//SetBasePath 需要添加Microsoft.Extensions.Configuration.Json引用  Directory.GetCurrentDirectory()取得是C盘目录

                string evname = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                builder.AddJsonFile("appsettings.json").AddJsonFile($"appsettings.{evname}.json");

                Configuration = builder.Build();
                IsOnline = GetSectionValue("IsOnline");

            }
            catch (Exception e)
            {
                NLogHelper.LogError(e.ToString());
            }
        }

        public static void InitConfig(string configPath, string fileName)
        {
            try
            {
                var builder = new ConfigurationBuilder().SetBasePath(configPath);//SetBasePath 需要添加Microsoft.Extensions.Configuration.Json引用  Directory.GetCurrentDirectory()取得是C盘目录

                builder.AddJsonFile(fileName);

                Configuration = builder.Build();
            }
            catch (Exception e)
            {
                NLogHelper.LogError(e.ToString());
                throw e;
            }
        }
        /// <summary>
        /// 获取Config文件appSettings节点配置值
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="defval">默认值</param>
        /// <returns></returns>
        public static string GetAppSettingString(string key, string defval = "")
        {
            if (Configuration == null)
            {
                return defval;
            }
            var conn = Configuration.GetSection("appSettings:" + key);
            if (!conn.Exists())
            {
                return defval;
            }
            return conn.Value;
        }

        /// <summary>
        /// 获取Config文件appSettings节点配置值
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="defval">默认值</param>
        /// <returns></returns>
        public static string GetSectionValue(string key, string defval = "")
        {
            if (Configuration == null)
            {
                return defval;
            }
            var conn = Configuration.GetSection(key);
            if (!conn.Exists())
            {
                return defval;
            }
            return conn.Value;
        }

        /// <summary>
        /// 获取Config文件ClientRedis节点配置值
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="defval">默认值</param>
        /// <returns></returns>
        public static string GetClientRedisInfo(string key, string defval = "")
        {
            if (Configuration == null)
            {
                return defval;
            }
            var conn = Configuration.GetSection("ClientRedis:" + key);
            if (!conn.Exists())
            {
                return defval;
            }
            return conn.Value;
        }

    }
}
