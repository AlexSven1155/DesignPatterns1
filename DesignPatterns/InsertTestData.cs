using DesignPatterns.AbstractFactoryPattern.Machines.BaseClasses;
using DesignPatterns.AbstractFactoryPattern.Machines.Enums;
using DesignPatterns.ProcessingData;

namespace DesignPatterns
{
	/// <summary>
	/// Класс добавления данных в бд.
	/// </summary>
	public static class InsertTestData
	{
		public static void AddBodyMachinesData() //Repository repository
		{
			//if (repository == null)
			//{
			//	return;
			//}

			var repository = Repository<BodyMachine>.GetTable(StringHelper.NameFiles.BodyMachineData);
			repository.AddData(new BodyMachine("TestBodyMachine1", 1, 500, 150, 15, 10));
			repository.AddData(new BodyMachine("TestBodyMachine2", 2, 600, 200, 20, 20));
			repository.AddData(new BodyMachine("TestBodyMachine3", 3, 700, 250, 25, 25));
			repository.AddData(new BodyMachine("TestBodyMachine4", 4, 800, 300, 30, 30));
		}

		public static void AddSuspensionsData()
		{
			var repository = Repository<Suspension>.GetTable(StringHelper.NameFiles.SuspensionData);
			repository.AddData(new Suspension("TestSuspension1", 1, 200, 50, 5, 80, 300, 5, ModeMotionSuspension.Wheeled));
			repository.AddData(new Suspension("TestSuspension2", 2, 250, 70, 7, 100, 400, 6, ModeMotionSuspension.Wheeled));
			repository.AddData(new Suspension("TestSuspension3", 3, 300, 100, 10, 120, 450, 9, ModeMotionSuspension.Wheeled));
			repository.AddData(new Suspension("TestSuspension4", 4, 350, 130, 13, 150, 500, 12, ModeMotionSuspension.Wheeled));
		}

		public static void AddGunData()
		{
			var repository = Repository<Gun>.GetTable(StringHelper.NameFiles.GunData);
			repository.AddData(new Gun("TestGun1", 1, 120, 150));
			repository.AddData(new Gun("TestGun2", 2, 150, 200));
			repository.AddData(new Gun("TestGun3", 3, 200, 300));
			repository.AddData(new Gun("TestGun4", 4, 350, 500));
		}
	}
}
