using DesignPatterns.ProcessingData;
using DesignPatterns.UserContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPIGameStatistics.Repositories;

namespace WebAPIGameStatistics.Controllers
{
	/// <summary>
	/// Контроллер авторизации пользователя.
	/// </summary>
	[Route("api/authorization")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{
		/// <summary>
		/// Модель дла работы с данными пользвоателя.
		/// </summary>
		private readonly UserSessionRepository _userSessionRepository;

		public AuthorizationController(IRepositoryData<UserData> userSessionRepo)
		{
			_userSessionRepository = new UserSessionRepository(userSessionRepo);
		}

		/// <summary>
		/// Возвращает список со всеми юзерами.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<string> GetUsersList()
		{
			return _userSessionRepository.GetUsers();
		}

		/// <summary>
		/// Авторизовывает юзера.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		/// <returns>Результат операции.</returns>
		[HttpPost]
		public bool AuthorizeUser([FromBody]string userName)
		{
			return _userSessionRepository.CheckUserInDatabase(userName);
		}

		/// <summary>
		/// Создаёт нового юзера с указанным имененм.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		/// <returns>Результат.</returns>
		[HttpPut]
		public string CreateUser([FromBody]string userName)
		{
			if (_userSessionRepository.CheckUserInDatabase(userName))
			{
				return "Такой пользователя уже есть.";
			}

			_userSessionRepository.CreateNewUser(userName);
			return "OK";
		}
	}
}