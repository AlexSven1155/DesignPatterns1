using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.UserContext;
using DesignPatterns.ProcessingData;
using DesignPatterns.AbstractFactoryPattern.Machines;

namespace WebAPIGameStatistics.Models
{
	/// <summary>
	/// Класс работы с сессией пользователя.
	/// </summary>
	public class UserSessionModel
	{
		private readonly IRepositoryTable<UserData> _repository;

		public UserSessionModel(IRepositoryTable<UserData> repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		/// <summary>
		/// Возвращает список всех пользователей в базе.
		/// </summary>
		/// <returns>Список.</returns>
		public IEnumerable<string> GetUsers()
		{
			return _repository.TableData.Select(e => e.UserName);
		}

		/// <summary>
		/// Проверить наличие пользователя в базе.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		public bool CheckUserInDatabase(string userName)
		{
			return _repository.TableData
				.Any(s => s.UserName == userName);
		}

		/// <summary>
		/// Получить статистику пользователя.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		/// <returns>Cтатистика.</returns>
		public UserStatistics GetUserStatistics(string userName)
		{
			return _repository.TableData
				.FirstOrDefault(s => s.UserName == userName)?
				.UserStatistics;
		}

		/// <summary>
		/// Получить машину пользователя.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		/// <returns>Экземпляр машины.</returns>
		public UserMachine GetUserMachine(string userName)
		{
			return _repository.TableData
				.FirstOrDefault(s => s.UserName == userName)?
				.UserMachine;
		}

		/// <summary>
		/// Установить новое имя для машины.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		/// <param name="machineName">Новое имя машины.</param>
		public bool SetNewNameMachine(string userName, string machineName)
		{
			var userData = _repository.TableData
				.FirstOrDefault(ud => ud.UserName == userName);

			if (userData == null)
			{
				return false;
			}

			userData.UserMachine.Name = machineName;
			_repository.AddData(userData);

			return true;
		}
	}
}
