using DesignPatterns.AbstractFactoryPattern.Machines;
using DesignPatterns.AbstractFactoryPattern.Machines.Factories;
using DesignPatterns.ProcessingData;
using DesignPatterns.UserContext;
using Moq;
using System.Collections.Generic;
using WebAPIGameStatistics.Controllers;
using Xunit;

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
			Assert.True(authorizationController.AuthorizeUser("Name1"));
		}

		/// <summary>
		/// Тестирование контроллера авторизации.
		/// Вариант с неудачной авторизацией.
		/// </summary>
		[Fact]
		public void TestFailAuthorization()
		{
			var authorizationController = new AuthorizationController(_mock.Object);
			var result = authorizationController.AuthorizeUser("Name");
			Assert.False(result);
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
			Assert.NotNull(result.Value);
			Assert.True(result.Value is UserStatistics);
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
			Assert.NotNull(result.Value);
			Assert.True(result.Value is UserMachine);
		}

		/// <summary>
		/// Тестирование метода смены имени машины.
		/// </summary>
		[Fact]
		public void TestSetNewMachineName()
		{
			var newMachineName = "NewMachineName";
			var userDataController = new UserDataController(_mock.Object);
			var setMachineNameResult = userDataController.SetMachineName("Name1", newMachineName);
			Assert.True(setMachineNameResult);
			var userMachineInfo = userDataController.GetUserMachineInfo("Name1");
			Assert.NotNull(userMachineInfo);
			Assert.NotNull(userMachineInfo.Value);
			Assert.True(userMachineInfo.Value is UserMachine);
			Assert.True(userMachineInfo.Value.Name == newMachineName);
		}
	}
}
