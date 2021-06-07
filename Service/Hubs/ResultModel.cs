using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Hubs
{
    public class ResultModel
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    /// <summary>
    /// 状态码
    /// </summary>
    public enum StatusCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 1000,
        /// <summary>
        /// 系统错误
        /// </summary>
        SysError = 2001,
        /// <summary>
        /// 未找到相关数据
        /// </summary>
        NotFund = 2002,
        /// <summary>
        /// 空列表
        /// </summary>
        NullList = 2003,
        /// <summary>
        /// 账号重复
        /// </summary>
        Error_MoreOne = 3001
    }
}