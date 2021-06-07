using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Hubs
{
    public static class ChatModel
    {
        /// <summary>
        /// 当前登录人数
        /// </summary>
        public static List<UserModel> userModels { get; set; }
        /// <summary>
        /// 客服工作列表
        /// </summary>
        public static List<Chating> chatings { get; set; }
    }

    public class UserModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 连接Id
        /// </summary>
        public string connectionId { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        /// <summary>
        /// 显示视图类型
        /// 区分当前用户界面类型，以便于挑选发送消息的方法名
        /// </summary>
        public int ViewType { get; set; }
        /// <summary>
        /// 是否为后台工作人员
        /// </summary>
        public bool IsMag { get; set; }
    }

    /// <summary>
    /// 聊天对象
    /// </summary>
    public class Chating
    {
        /// <summary>
        /// 后台客服人员Id
        /// </summary>
        public int magUserId { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public int userId { get; set; }
    }

    /// <summary>
    /// 用户当前使用界面
    /// </summary>
    public enum ViewType
    {
        /// <summary>
        /// 菜单
        /// </summary>
        Menu = 0,
        /// <summary>
        /// 聊天视图
        /// </summary>
        ChatView = 1
    }
}