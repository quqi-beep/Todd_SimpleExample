using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToddDemo.Controllers;
using ToddDemo.Protocol.IService;
using ToddDemo.Protocol.Requests;
using ToddDemo.Protocol.Responses;
using Xunit;

namespace ToddDemo.Test
{
    public class UserUnitTest
    {
        [Fact(DisplayName = "获取单个用户信息")]
        public async void TestGetUserAsync()
        {
            //Arrange 在这里做一些先决的设定。例如创建对象实例，数据，输入等
            var mock = new Mock<IUserService>();
            mock.Setup(x => x.GetUserFirstOrDefaultAsync()).Returns(Task.FromResult(new UserResponse { UserId = 1, Password = "123456", UserName = "wangdan" }));
            UserController user = new(mock.Object);

            //Act 在这里执行生产代码并返回结果。例如调用方法或者设置属性
            var response = (OkObjectResult)await user.GetUserAsync();

            //Assert 在这里检查结果，会产生测试通过或者失败两种结果
            if (response == null || response.Value == null)
            {
                Assert.True(false);
            }
            else
            {
                var re = (UserResponse)response.Value;
                Assert.True(re.UserId > 0);
            }
        }

        [Fact(DisplayName = "获取用户列表")]
        public async void TestGetUsersAsync()
        {
            //Arrange
            var mock = new Mock<IUserService>();
            mock.Setup(x => x.GetUsersAsync()).Returns(Task.FromResult(new UsersResponse
            {
                Users = new List<UserDto>
                {
                    new UserDto{
                    UserId=1,
                    UserName="todd",
                    Password="123456"
                    },
                    new UserDto{
                    UserId=2,
                    UserName="wanbin",
                    Password="123456"
                    }
                }
            }));

            var user = new UserController(mock.Object);
            var response = (OkObjectResult)await user.GetUsersAsync();
            if (response == null || response.Value == null)
            {
                Assert.True(false);
            }
            else
            {
                var res = (UsersResponse)response.Value;
                Assert.True(res.Users.Count > 0);
            }
        }

        [Fact(DisplayName = "添加用户")]
        public async void TestAddUserAsync()
        {
            var request = new UserRequest
            {
                UserId = 6,
                UserName = "lina",
                Password = "123456",
                Age = 18
            };

            var mock = new Mock<IUserService>();
            mock.Setup(x => x.AddUserAsync(It.IsAny<UserRequest>()));

            var user = new UserController(mock.Object);
            await user.AddUserAsync(request);

            Assert.True(true);
        }

        [Fact(DisplayName = "更新用户信息")]
        public async void TestPatchUserAsync()
        {
            var request = new JsonPatchDocument<UserRequest>
            {

            };

            var mock = new Mock<IUserService>();
            mock.Setup(x => x.PatchUserAsync(It.IsAny<JsonPatchDocument<UserRequest>>()));

            var user = new UserController(mock.Object);
            await user.PatchUserAsync(request);

            Assert.True(true);
        }
    }
}