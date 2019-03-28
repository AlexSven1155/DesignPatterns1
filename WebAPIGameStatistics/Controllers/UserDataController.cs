using Microsoft.AspNetCore.Mvc;
using DesignPatterns.UserContext;
using WebAPIGameStatistics.Models;
using DesignPatterns.ProcessingData;
using DesignPatterns.AbstractFactoryPattern.Machines;

namespace WebAPIGameStatistics.Controllers
{
	/// <summary>
	/// Контроллер для работы с данными пользователя.
	/// </summary>
	[Route("api/userData")]
	[ApiController]
	public class UserDataController : ControllerBase
	{
		/// <summary>
		/// Модель предоставления и обработки данных пользователя.
		/// </summary>
		private readonly UserSessionModel _userSessionModel;

		public UserDataController(IRepositoryTable<UserData> userSessionRepo)
		{
			_userSessionModel = new UserSessionModel(userSessionRepo);
		}

		/// <summary>
		/// Возвращает статистику пользователя.
		/// </summary>
		/// <param name="userName">Пользователь.</param>
		/// <returns>Экземпляр статистики.</returns>
		[HttpPost]
		[Route("GetUserStatistic")]
		public ActionResult<UserStatistics> GetUserStatistic([FromBody]string userName)
		{
			return _userSessionModel.GetUserStatistics(userName);
		}

		/// <summary>
		/// возращает информацию о машине пользователя.
		/// </summary>
		/// <param name="userName">Пользователь.</param>
		/// <returns>Экземпляр машины.</returns>
		[HttpPost]
		[ActionName("GetMachineInfo")]
		public ActionResult<UserMachine> GetUserMachineInfo([FromBody]string userName)
		{
			return _userSessionModel.GetUserMachine(userName);
		}

		/// <summary>
		/// Метод меняет имя машины пользователя.
		/// </summary>
		/// <param name="data">Данные: 1. Имя игрока 2. Новое имя машины</param>
		/// <returns>Результат операции.</returns>
		[HttpPost]
		[ActionName("SetMachineName")]
		public bool SetMachineName([FromBody]string[] data)
		{
			return _userSessionModel.SetNewNameMachine(data[0], data[1]);
		}
	}
}