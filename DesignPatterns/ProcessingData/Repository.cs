namespace DesignPatterns.ProcessingData
{
	using AbstractFactoryPattern.Machines.BaseClasses;
	using UserContext;

	/// <summary>
	/// Класс данных игры.
	/// </summary>
	public class Repository
	{
		public IRepositoryTable<Gun> GunData;
		public IRepositoryTable<Suspension> SuspensionsData;
		public IRepositoryTable<BodyMachine> BodyMachinesData;
		public IRepositoryTable<UserData> SavedUserData;

		/// <summary>
		/// Инициализируем классы данных.
		/// </summary>
		public Repository()
		{
			GunData = new RepositoryTable<Gun>(StringHelper.NameFiles.GunData);
			SuspensionsData = new RepositoryTable<Suspension>(StringHelper.NameFiles.SuspensionData);
			BodyMachinesData = new RepositoryTable<BodyMachine>(StringHelper.NameFiles.BodyMachineData);
			SavedUserData = new RepositoryTable<UserData>(StringHelper.NameFiles.SavedUserData);

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
