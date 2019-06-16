using DesignPatterns.AbstractFactoryPattern.Machines;
using DesignPatterns.ProcessingData;
using DesignPatterns.UserContext;
using Microsoft.AspNetCore.Mvc;
using WebAPIGameStatistics.Repositories;

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
		private readonly UserSessionRepository _userSessionRepository;

		public UserDataController(IRepositoryData<UserData> userSessionRepo)
		{
			_userSessionRepository = new UserSessionRepository(userSessionRepo);
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
			return _userSessionRepository.GetUserStatistics(userName);
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
			return _userSessionRepository.GetUserMachine(userName);
		}

		/// <summary>
		/// Метод меняет имя машины пользователя.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		/// <param name="newMachineName">Новое название машины.</param>
		/// <returns>Результат операции.</returns>
		[HttpPost]
		[ActionName("SetMachineName")]
		public bool SetMachineName([FromBody]string userName, [FromBody]string newMachineName)
		{
			return _userSessionRepository.SetNewNameMachine(userName, newMachineName);
		}
	}
}