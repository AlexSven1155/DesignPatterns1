namespace DesignPatterns.AbstractFactoryPattern.Machines
{
	using System;
	using Interfaces;
	using System.Linq;
	using BaseClasses;
	using ObserverPattern.Delegates;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using AbstractFactoryPattern.StaticObject.Interfaces;

	/// <summary>
	/// Машина игрока.
	/// </summary>
	[Serializable]
	public class UserMachine : Machine, ISerializable
	{
		/// <summary>
		/// Инвентарь.
		/// </summary>
		public List<IBaseStaticObject> Inventory { get; set; }

		/// <summary>
		/// Событие движения машины для спауна лута.
		/// </summary>
		public event DelegateOnMoveLoot OnMoveLoot;

		/// <summary>
		/// Событие движения машины для спауна врагов.
		/// </summary>
		public event DelegateOnMoveEnemy OnMoveEnemy;

		/// <summary>
		/// Конструктор с использованием фабрики.
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="factory">Экземпляр фабрики.</param>
		public UserMachine(string name, IBasicMachineFactory factory)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException(nameof(name));
			}

			if (factory == null)
			{
				throw new ArgumentNullException(nameof(factory));
			}

			Name = name;
			Suspension = factory.CreateSuspension();
			Body = factory.CreateBody();
			Gun = factory.CreateGun();
			Inventory = new List<IBaseStaticObject>();
			InitProperties();
		}

		/// <summary>
		/// Создать машину игрока.
		/// </summary>
		/// <param name="name">Имя.</param>
		/// <param name="suspension">Подвеска.</param>
		/// <param name="bodyMachine">Кузов.</param>
		/// <param name="gun">Оружие.</param>
		/// <param name="inventory">Инвентарь</param>
		public UserMachine(string name, Suspension suspension, BodyMachine bodyMachine, Gun gun, List<IBaseStaticObject> inventory = null)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException(nameof(name));
			}
			Name = name;

			Gun = gun ?? throw new ArgumentNullException(nameof(gun));
			Body = bodyMachine ?? throw new ArgumentNullException(nameof(bodyMachine));
			Suspension = suspension ?? throw new ArgumentNullException(nameof(suspension));
			Inventory = inventory ?? new List<IBaseStaticObject>();
			InitProperties();
		}

		/// <summary>
		/// Текущее количество свободного места в инвентаре.
		/// </summary>
		/// <returns>Количество.</returns>
		public int CurrentSizeInventory()
		{
			return Body.SizeInventory - Inventory.Sum(i => i.Size);
		}

		/// <summary>
		/// Восстановить очки жизней.
		/// </summary>
		/// <param name="quantity">Количество очков для восстановления.</param>
		/// <returns>Количество очков после восстановления.</returns>
		public int RepairLifePoints(int quantity)
		{
			if (quantity <= 0)
			{
				throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(quantity));
			}

			return LifePoints = 
				LifePoints + quantity >= MaxLifePoints
				? MaxLifePoints
				: LifePoints + quantity;
		}

		/// <summary>
		/// Восстановить очки брони.
		/// </summary>
		/// <param name="quantity">Количество очков для восстановления.</param>
		/// <returns>Количество очков после восстановления.</returns>
		public int RepairArmorPoints(int quantity)
		{
			if (quantity <= 0)
			{
				throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(quantity));
			}

			return ArmorPoints = 
				ArmorPoints + quantity >= MaxArmorPoints
				? MaxArmorPoints
				: ArmorPoints + quantity;
		}

		/// <summary>
		/// Движение.
		/// </summary>
		/// <param name="distance">Дистанция.</param>
		/// <returns>Результат.</returns>
		public new object Move(int distance)
		{
			if (Suspension.QuantityFuel == 0)
			{
				return 0;
			}

			var fullDistance = distance;

			while (distance > 0)
			{
				if (base.Move(1) == 0)
				{
					distance--;

					//каждый километр есть шанс что попадётся противник или лут
					var rnd = new Random();
					if (rnd.Next(0, 2) == 1)
					{
						var resultSpawnLoot = OnMoveLoot?.Invoke();
						if (resultSpawnLoot != null)
						{
							return resultSpawnLoot;
						}
					}
					else
					{
						var resultSpawnEnemy = OnMoveEnemy?.Invoke();
						if (resultSpawnEnemy != null)
						{
							return resultSpawnEnemy;
						}
					}
				}
				else
				{
					break;
				}
			}

			return fullDistance - distance;
		}

		/// <summary>
		/// Реализация сериализации данных класса.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Gun", Gun);
			info.AddValue("Body", Body);
			info.AddValue("Name", Name);
			info.AddValue("Level", Level);
			info.AddValue("Inventory", Inventory);
			info.AddValue("LifePoints", LifePoints);
			info.AddValue("Suspension", Suspension);
			info.AddValue("ArmorPoints", ArmorPoints);
		}

		/// <summary>
		/// Конструктор для сериализатора.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public UserMachine(SerializationInfo info, StreamingContext context)
		{
			Gun = (Gun)info.GetValue("Gun", typeof(Gun));
			Body = (BodyMachine)info.GetValue("Body", typeof(BodyMachine));
			Name = (string)info.GetValue("Name", typeof(string));
			Level = (int)info.GetValue("Level", typeof(int));
			Inventory = (List<IBaseStaticObject>)info.GetValue("Inventory", typeof(List<IBaseStaticObject>));
			LifePoints = (int)info.GetValue("LifePoints", typeof(int));
			Suspension = (Suspension)info.GetValue("Suspension", typeof(Suspension));
			ArmorPoints = (int)info.GetValue("ArmorPoints", typeof(int));
			InitProperties();
		}
	}
}
