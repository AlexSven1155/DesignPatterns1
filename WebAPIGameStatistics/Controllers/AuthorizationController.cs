using DesignPatterns.ProcessingData;
using DesignPatterns.UserContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPIGameStatistics.Models;

namespace WebAPIGameStatistics.Controllers
{
	/// <summary>
	/// Контроллер авторизации пользователя.
	/// </summary>
	[Route("api/authorization")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{
		private readonly UserSessionModel _userSessionModel;

		public AuthorizationController(IRepositoryTable<UserData> userSessionRepo)
		{
			_userSessionModel = new UserSessionModel(userSessionRepo);
		}

		/// <summary>
		/// Возвращает список со всеми пользователями.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<string> GetUsersList()
		{
			return _userSessionModel.GetUsers();
		}

		/// <summary>
		/// Авторизовывает пользователя.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		/// <returns>Результат операции.</returns>
		[HttpPost]
		public bool AuthorizeUser([FromBody]string userName)
		{
			return _userSessionModel.CheckUserInDatabase(userName);
		}
	}
}