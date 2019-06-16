namespace DesignPatterns.ProcessingData
{
	using AbstractFactoryPattern.Machines.BaseClasses;
	using System;
	using System.Runtime.Serialization;
	using UserContext;

	/// <summary>
	/// Класс данных игры.
	/// </summary>
	public class Repository
	{
		/// <summary>
		/// Репозиторий пушек.
		/// </summary>
		public IRepositoryData<Gun> GunData { get; }

		/// <summary>
		/// Репозиторий подвесок.
		/// </summary>
		public IRepositoryData<Suspension> SuspensionsData { get; }

		/// <summary>
		/// Репзиторий кузовов.
		/// </summary>
		public IRepositoryData<BodyMachine> BodyMachinesData { get; }

		/// <summary>
		/// Репозиторий данных игроков.
		/// </summary>
		public IRepositoryData<UserData> SavedUserData { get; }

		/// <summary>
		/// Иниациализирует репозиторий с указанными данными.
		/// </summary>
		/// <typeparam name="T">Тип данных репозитория.</typeparam>
		/// <param name="fileName">Название файла с данными.</param>
		/// <returns>Репозиторий.</returns>
		public IRepositoryData<T> GetRepository<T>(string fileName) where T : ISerializable, IEquatable<T>
		{
			return new RepositoryData<T>(fileName);
		}

		/// <summary>
		/// Инициализируем данные игры.
		/// </summary>
		public Repository()
		{
			GunData = GetRepository<Gun>(StringHelper.NameFiles.GunData);
			SuspensionsData = GetRepository<Suspension>(StringHelper.NameFiles.SuspensionData);
			BodyMachinesData = GetRepository<BodyMachine>(StringHelper.NameFiles.BodyMachineData);
			SavedUserData = GetRepository<UserData>(StringHelper.NameFiles.SavedUserData);

			if (GunData.TableData.Count == 0)
			{
				InsertTestData.AddGunData(this);
			}

			if (SuspensionsData.TableData.Count == 0)
			{
				InsertTestData.AddSuspensionsData(this);
			}

			if (BodyMachinesData.TableData.Count == 0)
			{
				InsertTestData.AddBodyMachinesData(this);
			}
		}
	}
}