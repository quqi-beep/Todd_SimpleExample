using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToddDemo.Infrastructure
{
    public class JwtSetting
    {
        /// <summary>
        /// 密匙
        /// </summary>
        public string SecurityKey { get; set; }
        /// <summary>
        /// 发行者
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// 接受者
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 过期时间（单位：秒）
        /// </summary>
        public int ExpireSeconds { get; set; }
    }
}
