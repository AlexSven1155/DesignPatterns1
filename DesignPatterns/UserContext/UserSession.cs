namespace DesignPatterns.UserContext
{
	using AbstractFactoryPattern.Machines;
	using ProcessingData;
	using System;
	using System.Linq;

	/// <summary>
	/// Класс работы с сессией пользователя.
	/// </summary>
	public class UserSession
	{
		/// <summary>
		/// Показывает, новый игрок или нет.
		/// </summary>
		public bool IsNew { get; private set; }

		/// <summary>
		/// Данные игрока.
		/// </summary>
		public UserData UserData { get; }

		/// <summary>
		/// Ссылка на репозиторий с данными.
		/// </summary>
		private readonly IRepositoryTable<UserData> _repository = Repository<UserData>.GetTable(StringHelper.NameFiles.SavedUserData);

		/// <summary>
		/// Создать сессию используя имя.
		/// Если в репозитории есть игрок таким именем то данные подтянутся от туда.
		/// </summary>
		/// <param name="userName">Имя игрока.</param>
		public UserSession(string userName)
		{
			if (string.IsNullOrEmpty(userName))
			{
				throw new ArgumentNullException(nameof(userName));
			}

			UserData = new UserData
			{
				UserName = userName
			};

			InitUserData();
		}

		/// <summary>
		/// Инициализация данных игрока.
		/// </summary>
		private void InitUserData()
		{
			if (string.IsNullOrEmpty(UserData.UserName))
			{
				throw new ArgumentNullException(nameof(UserData.UserName));
			}

			// попытка загрузить игру из репозитория
			if (LoadGame())
			{
				return;
			}

			// если ничего нет в репозитории, инициализируем оставшиеся свойства класса
			IsNew = true;
			UserData.UserStatistics = new UserStatistics();
		}

		/// <summary>
		/// Добавить машину игрока в данные.
		/// </summary>
		/// <param name="userMachine">Машина игрока</param>
		public void AddMachine(UserMachine userMachine)
		{
			UserData.UserMachine = userMachine ?? throw new ArgumentNullException(nameof(userMachine));
		}

		/// <summary>
		/// Сохранить игру.
		/// </summary>
		public void SaveGame()
		{
			_repository.AddData(UserData);
		}

		/// <summary>
		/// Загрузить последнюю сохранённую игру.
		/// </summary>
		/// <returns>Успешность операции.</returns>
		public bool LoadGame()
		{
			var userData = _repository.TableData
				.FirstOrDefault(ud => ud.UserName == UserData.UserName);

			if (userData == null)
			{
				return false;
			}

			UserData.UserMachine = userData.UserMachine;
			UserData.UserStatistics = userData.UserStatistics;

			return true;
		}
	}
}
