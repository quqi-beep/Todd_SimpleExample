using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.Infrastructure
{
    public class CurrentUser
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public int Role { get; set; }
    }
}
