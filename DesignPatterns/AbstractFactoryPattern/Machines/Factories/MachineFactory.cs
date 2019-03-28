namespace DesignPatterns.AbstractFactoryPattern.Machines.Factories
{
	using BaseClasses;
	using Interfaces;
	using ProcessingData;
	using System;
	using System.Linq;

	/// <summary>
	/// Фабрика машин.
	/// </summary>
	public class MachineFactory : IBasicMachineFactory
	{
		private readonly int _level;
		private readonly Random _random = new Random();
		private readonly IRepositoryTable<Gun> _gunData = Repository<Gun>.GetTable(StringHelper.NameFiles.GunData);
		private readonly IRepositoryTable<Suspension> _suspensionsData = Repository<Suspension>.GetTable(StringHelper.NameFiles.SuspensionData);
		private readonly IRepositoryTable<BodyMachine> _bodyMachinesData = Repository<BodyMachine>.GetTable(StringHelper.NameFiles.BodyMachineData);

		/// <summary>
		/// Задать уровень машины для производства.
		/// </summary>
		/// <param name="level">Уровень.</param>
		public MachineFactory(int level)
		{
			_level = level > 0
				? level
				: throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(level));
		}

		/// <summary>
		/// Создать оружие.
		/// </summary>
		/// <returns>Оружие.</returns>
		public Gun CreateGun()
		{
			var result = (from gun in _gunData.TableData
						  where gun.Level == _level
						  select gun).ToList();
			var gunData = result[_random.Next(0, result.Count)];
			return new Gun(gunData.Name,
				gunData.Level,
				gunData.MinDamage,
				gunData.MaxDamage);
		}

		/// <summary>
		/// Создать подвеску.
		/// </summary>
		/// <returns>Лёгкая подвеска.</returns>
		public Suspension CreateSuspension()
		{
			var result = (from suspension in _suspensionsData.TableData
						  where suspension.Level == _level
						  select suspension).ToList();
			var suspensionData = result[_random.Next(0, result.Count)];
			return new Suspension(suspensionData.Name,
						suspensionData.Level,
						suspensionData.MaxLifePoints,
						suspensionData.MaxArmorPoints,
						suspensionData.ArmorResistance,
						suspensionData.EnginePower,
						suspensionData.CapacityFuelTank,
						suspensionData.FuelConsumption,
						suspensionData.ModeMotion);
		}

		/// <summary>
		/// Создать кузов.
		/// </summary>
		/// <returns>Кузов от легковушки.</returns>
		public BodyMachine CreateBody()
		{
			var result = (from body in _bodyMachinesData.TableData
						  where body.Level == _level
						  select body).ToList();
			var bodyData = result[_random.Next(0, result.Count)];
			return new BodyMachine(bodyData.Name,
				bodyData.Level,
				bodyData.MaxLifePoints,
				bodyData.MaxArmorPoints,
				bodyData.ArmorResistance,
				bodyData.SizeInventory);
		}
	}
}
