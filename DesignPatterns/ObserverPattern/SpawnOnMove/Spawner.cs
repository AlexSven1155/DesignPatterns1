namespace DesignPatterns.ObserverPattern.SpawnOnMove
{
	using System;
	using AbstractFactoryPattern.Machines;
	using AbstractFactoryPattern.Machines.Factories;
	using AbstractFactoryPattern.Machines.Interfaces;
	using AbstractFactoryPattern.StaticObject.Factories;
	using AbstractFactoryPattern.StaticObject.Interfaces;

	/// <summary>
	/// Класс спауна.
	/// </summary>
	public class Spawner
	{
		/// <summary>
		/// Фабрика объектов.
		/// </summary>
		private IBaseStaticObjectFactory _staticObjectFactory;

		/// <summary>
		/// Текущий уровень игрока.
		/// </summary>
		private int _userLevel;

		/// <summary>
		/// Класс спаунер. 
		/// Служит для генерации объектов и врагов которые моугут попадаться на пути игрока по время игры.
		/// </summary>
		/// <param name="userMachine">Машина игрока.</param>
		public Spawner(UserMachine userMachine)
		{
			if (userMachine == null)
			{
				throw new ArgumentNullException(nameof(userMachine));
			}

			_userLevel = userMachine.Level;

			userMachine.OnMoveLoot += SpawnLoot;
			userMachine.OnMoveEnemy += SpawnEnemy;
		}

		/// <summary>
		/// Метод спауна объектов.
		/// </summary>
		/// <returns>Объект.</returns>
		private IBaseStaticObject SpawnLoot()
		{
			var random = new Random();
			if (random.Next(0, 100) <= 50)
			{
				var type = random.Next(0, 3);
				switch (type)
				{
					case 0:
						_staticObjectFactory = new RepairPartsFactory();
						return _staticObjectFactory.GetStaticObject(_userLevel);
					case 1:
						_staticObjectFactory = new ScrapMetalFactory();
						return _staticObjectFactory.GetStaticObject(_userLevel);
					case 2:
						_staticObjectFactory = new СanisterFactory();
						return _staticObjectFactory.GetStaticObject(_userLevel);
					case 3:
						break; //TODO СОЗДАТЬ МУСОР
				}
			}
			return null;
		}

		/// <summary>
		/// Метод спауна врагов.
		/// </summary>
		/// <returns>Враг.</returns>
		private IBaseMachine SpawnEnemy()
		{
			var random = new Random();
			if (random.Next(0, 101) <= 20)
			{
				var type = random.Next(0, 1);
				switch (type)
				{
					case 0:
						return new EnemyMachine("Враг", new MachineFactory(_userLevel));
					case 1:
						//TODO НАДЕЛАТЬ ВРАГОВ
						break;
				}
			}

			return null;
		}
	}
}
