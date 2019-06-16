using Moq;
using Xunit;
using System.Linq;
using DesignPatterns.UserContext;
using System.Collections.Generic;
using DesignPatterns.ProcessingData;
using WebAPIGameStatistics.Controllers;
using DesignPatterns.AbstractFactoryPattern.Machines;
using DesignPatterns.AbstractFactoryPattern.Machines.Factories;

namespace WebApiTest
{
	/// <summary>
	/// Тестирование методов контроллера.
	/// </summary>
	public class TestUserSession
	{
		/// <summary>
		/// Тестовые данные.
		/// </summary>
		private readonly List<UserData> _testData = new List<UserData>
		{
			new UserData
			{
				UserName = "Name1",
				UserMachine = new UserMachine("MachineName1", new MachineFactory(1)),
				UserStatistics = new UserStatistics()
			},
			new UserData
			{
				UserName = "Name2",
				UserMachine = new UserMachine("MachineName2", new MachineFactory(1)),
				UserStatistics = new UserStatistics()
			}
		};

		private readonly Mock<IRepositoryData<UserData>> _mock;

		public TestUserSession()
		{
			_mock = new Mock<IRepositoryData<UserData>>();
			_mock.Setup(a => a.TableData).Returns(_testData);
		}

		/// <summary>
		/// Тестирование контроллера авторизации.
		/// Вариант с удачной авторизацией.
		/// </summary>
		[Fact]
		public void TestSuccessAuthorization()
		{
			var authorizationController = new AuthorizationController(_mock.Object);
			var resultUserList = authorizationController.GetUsersList();
			var resultTrueAuthorizeUser = authorizationController.AuthorizeUser("Name1");
			var resultFalseAuthorizeUser = authorizationController.AuthorizeUser("Name");
			Assert.False(resultFalseAuthorizeUser);
			Assert.Equal(_testData.Select(e => e.UserName), resultUserList);
			Assert.True(resultTrueAuthorizeUser);
		}

		/// <summary>
		/// Тестирование метода получения статистики пользователя.
		/// </summary>
		[Fact]
		public void TestGetUserStatistic()
		{
			var userDataController = new UserDataController(_mock.Object);
			var result = userDataController.GetUserStatistic("Name1");
			Assert.NotNull(result);
		}

		/// <summary>
		/// Тестирование метода получения информации о машине.
		/// </summary>
		[Fact]
		public void TestGetUserMachineInfo()
		{
			var userDataController = new UserDataController(_mock.Object);
			var result = userDataController.GetUserMachineInfo("Name1");
			Assert.NotNull(result);
		}

		/// <summary>
		/// Тестирование метода смены имени машины.
		/// </summary>
		[Fact]
		public void TestSetNewMachineName()
		{
			string newName = "NewMachineName";

			var userDataController = new UserDataController(_mock.Object);
			// при вызове метода нужно передавать 2 параметра в массиве [0] - имя пользователя, [1] - новое имя машины
			var setMachineNameResult = userDataController.SetMachineName(new [] { "Name1", newName });
			Assert.True(setMachineNameResult);

			var userMachineInfo = userDataController.GetUserMachineInfo("Name1");
			Assert.True(userMachineInfo.Value.Name == newName);
		}
	}
}
