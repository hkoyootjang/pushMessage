using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Service.Hubs
{
    public class MyHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello("这是全体广播！");
        }

        /// <summary>
        /// 登录参数
        /// </summary>
        /// <param name="viewType"></param>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        public void Login(int viewType, string userName, string pwd)
        {
            var res = new ResultModel()
            {
                Data = null,
                Message = "系统错误",
                Status = false,
                StatusCode = (int)StatusCode.SysError
            };

            var userModel = new UserModel()
            {
                Id = ChatModel.userModels == null ? 1 : ChatModel.userModels.Max(u => u.Id) + 1,
                /*
                 * 前五个登录的人为客服
                 * 可以直接从数据库读取，登录人的信息，是否为客服
                 */
                IsMag = ChatModel.userModels != null && ChatModel.userModels.Count <= 5 ? true : false,
                Pwd = pwd,
                UserName = userName,
                ViewType = viewType,
                connectionId = Context.ConnectionId
            };

            if (ChatModel.userModels != null && ChatModel.userModels.Any(u => u.UserName == userModel.UserName))
                Clients.Client(userModel.connectionId).getLogin(res = new ResultModel()
                {
                    Data = null,
                    StatusCode = (int)StatusCode.Error_MoreOne,
                    Message = "该账号以有人登录",
                    Status = false
                });

            ChatModel.userModels.Add(userModel);

            Clients.All.getLogin(res = new ResultModel()
            {
                Data = ChatModel.userModels,
                Message = userModel.UserName + "上线了",
                Status = true,
                StatusCode = (int)StatusCode.Success
            });

        }



    }
}