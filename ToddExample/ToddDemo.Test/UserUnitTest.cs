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
        [Fact(DisplayName = "��ȡ�����û���Ϣ")]
        public async void TestGetUserAsync()
        {
            //Arrange ��������һЩ�Ⱦ����趨�����紴������ʵ�������ݣ������
            var mock = new Mock<IUserService>();
            mock.Setup(x => x.GetUserFirstOrDefaultAsync()).Returns(Task.FromResult(new UserResponse { UserId = 1, Password = "123456", UserName = "wangdan" }));
            UserController user = new(mock.Object);

            //Act ������ִ���������벢���ؽ����������÷���������������
            var response = (OkObjectResult)await user.GetUserAsync();

            //Assert ���������������������ͨ������ʧ�����ֽ��
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

        [Fact(DisplayName = "��ȡ�û��б�")]
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

        [Fact(DisplayName = "����û�")]
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

        [Fact(DisplayName = "�����û���Ϣ")]
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