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
		private readonly Repository _repository = new Repository();

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
			var result = (from gun in _repository.GunData.TableData
						  where gun.Level == _level
						  select gun).ToList();
			return new Gun(result[_random.Next(0, result.Count)]);
		}

		/// <summary>
		/// Создать подвеску.
		/// </summary>
		/// <returns>Лёгкая подвеска.</returns>
		public Suspension CreateSuspension()
		{
			var result = (from suspension in _repository.SuspensionsData.TableData
						  where suspension.Level == _level
						  select suspension).ToList();
			var suspensionData = result[_random.Next(0, result.Count)];
			return new Suspension(suspensionData);
		}

		/// <summary>
		/// Создать кузов.
		/// </summary>
		/// <returns>Кузов от легковушки.</returns>
		public BodyMachine CreateBody()
		{
			var result = (from body in _repository.BodyMachinesData.TableData
						  where body.Level == _level
						  select body).ToList();
			var bodyData = result[_random.Next(0, result.Count)];
			return new BodyMachine(bodyData);
		}
	}
}