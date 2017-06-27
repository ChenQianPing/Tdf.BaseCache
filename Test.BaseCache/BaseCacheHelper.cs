using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdf.BaseCache;

namespace Test.BaseCache
{
    public static class BaseCacheHelper
    {
        public static void TestRuntimeCaching()
        {
            // 自定义对象存储
            var user1 = new UserInfo
            {
                UserId = 2061755360,
                UserName = "难念的经"
            };

            var user2 = new UserInfo
            {
                UserId = 694802856,
                UserName = "爱的无法呼吸"
            };

            var lstUsers = new List<UserInfo>() {user1, user2};

            new RuntimeCaching().Set("UserInfos", lstUsers, 30);

            if (new RuntimeCaching().Exists("UserInfos"))
            {
                Console.WriteLine("缓存中存在UserInfos key；");

                var lstResult = new RuntimeCaching().Get<List<UserInfo>>("UserInfos");
                foreach (var user in lstResult)
                {
                    Console.WriteLine($"Hello,My UserId is {user.UserId} and UserName is {user.UserName}");
                }

                Console.Read();
            }
            else
            {
                Console.WriteLine("缓存中不存在UserInfos key；");
            }
        }

        public static void TestWebCaching()
        {
            var claim = new UserInfo
            {
                UserId = 694802856,
                UserName = "难念的经"
            };

            new WebCaching().Set("Claim", claim, 30);
            var newMyObj = new WebCaching().Get<UserInfo>("Claim") as UserInfo;

            Console.WriteLine($"Hello,My UserId is {newMyObj.UserId} and UserName is {newMyObj.UserName}");
            Console.ReadKey();
        }
    }

    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
