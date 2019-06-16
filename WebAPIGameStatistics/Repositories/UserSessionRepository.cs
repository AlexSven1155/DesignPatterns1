namespace WebAPIGameStatistics.Repositories
{
	using DesignPatterns.AbstractFactoryPattern.Machines;
	using DesignPatterns.AbstractFactoryPattern.Machines.Factories;
	using DesignPatterns.ProcessingData;
	using DesignPatterns.UserContext;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// Класс работы с сессией пользователя.
	/// </summary>
	public class UserSessionRepository
	{
		/// <summary>
		/// Максимальное количество записей в выборке.
		/// </summary>
		public int MaxQueryCount { get; set; } = 10;

		/// <summary>
		/// Репозиторий с данными пользователей.
		/// </summary>
		private readonly IRepositoryData<UserData> _repository;

		/// <summary>
		/// Инициализируется репозиторий.
		/// </summary>
		/// <param name="repository">Репозиторий.</param>
		public UserSessionRepository(IRepositoryData<UserData> repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		/// <summary>
		/// Возвращает список пользователей в базе.
		/// </summary>
		/// <param name="numberList">Номер старницы.</param>
		/// <returns>Список.</returns>
		public IEnumerable<string> GetUsers(int numberList = 0)
		{
			return _repository
				.TableData
				.Skip(MaxQueryCount * numberList)
				.Take(MaxQueryCount)
				.Select(e => e.UserName);
		}

		/// <summary>
		/// Проверить наличие пользователя в базе.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		public bool CheckUserInDatabase(string userName)
		{
			return _repository
				.TableData
				.Any(s => s.UserName == userName);
		}

		/// <summary>
		/// Получить статистику пользователя.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		/// <returns>Cтатистика.</returns>
		public UserStatistics GetUserStatistics(string userName)
		{
			return _repository
				.TableData
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
			return _repository
				.TableData
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
			var userData = _repository
				.TableData
				.FirstOrDefault(ud => ud.UserName == userName);

			if (userData == null)
			{
				return false;
			}

			userData.UserMachine.Name = machineName;
			_repository.AddData(userData);
			_repository.SaveData();

			return true;
		}

		/// <summary>
		/// Создаёт нового пользователя.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		public void CreateNewUser(string userName)
		{
			if (string.IsNullOrEmpty(userName))
			{
				throw new ArgumentNullException(nameof(userName));
			}

			if (CheckUserInDatabase(userName))
			{
				throw new Exception("Такой пользователь уже есть.");
			}

			_repository.AddData(new UserData
			{
				UserName = userName,
				UserStatistics = new UserStatistics()
			});

			_repository.SaveData();
		}

		/// <summary>
		/// Проверяет наиличие машины у юзера.
		/// </summary>
		/// <param name="userName">Имя пользователя.</param>
		/// <returns>true - есть, false - нет</returns>
		public bool CheckUserMachine(string userName)
		{
			if (string.IsNullOrEmpty(userName))
			{
				throw new ArgumentNullException(nameof(userName));
			}

			return _repository.TableData
					   .FirstOrDefault(e => e.UserName == userName)?
					   .UserMachine != null;
		}

		/// <summary>
		/// Создаёт юзеру новую машину, с указанными именем.
		/// </summary>
		/// <param name="userName">Юзер которому создать машину.</param>
		/// <param name="machineName">Имя новой машины.</param>
		public void AddMachine(string userName, string machineName)
		{
			if (string.IsNullOrWhiteSpace(userName))
			{
				throw new ArgumentNullException(nameof(userName));
			}

			if (string.IsNullOrWhiteSpace(machineName))
			{
				throw new ArgumentNullException(nameof(machineName));
			}

			var userData = _repository
					.TableData
					.FirstOrDefault(e => e.UserName == userName)
				?? throw new ArgumentNullException($"Не удалось найти пользователя с именем {userName}.");

			userData.UserMachine = new UserMachine(machineName, new MachineFactory(1));
			_repository.SaveData();
		}

		/// <summary>
		/// Заменяет юзеру существующую машину на указанную.
		/// </summary>
		/// <param name="userName">Юзер.</param>
		/// <param name="machine">Новая машина.</param>
		public void AddMachine(string userName, UserMachine machine)
		{
			if (string.IsNullOrWhiteSpace(userName))
			{
				throw new ArgumentNullException(nameof(userName));
			}

			var userData = _repository
					.TableData
					.FirstOrDefault(e => e.UserName == userName)
				?? throw new ArgumentNullException($"Не удалось найти пользователя с именем {userName}.");

			userData.UserMachine = machine ?? throw new ArgumentNullException(nameof(machine));

			_repository.SaveData();
		}
	}
}