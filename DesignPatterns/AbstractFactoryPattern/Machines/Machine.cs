namespace DesignPatterns.AbstractFactoryPattern.Machines
{
	using System;
	using Interfaces;
	using BaseClasses;
	using System.Xml.Serialization;

	/// <summary>
	/// Класс машины.
	/// </summary>
	[Serializable]
	public class Machine : IBaseMachinePart
	{
		/// <summary>
		/// Название машины.
		/// </summary>
		[XmlAttribute("Name")]
		public string Name { get; set; }

		/// <summary>
		/// Количество очков жизней.
		/// </summary>
		[XmlAttribute("LifePoints")]
		public int LifePoints { get; set; }

		/// <summary>
		/// Максимальное количество очков жизней.
		/// </summary>
		[XmlAttribute("MaxLifePoints")]
		public int MaxLifePoints { get; set; }

		/// <summary>
		/// Количество очков брони.
		/// </summary>
		[XmlAttribute("ArmorPoints")]
		public int ArmorPoints { get; set; }

		/// <summary>
		/// Максимальное количество очков брони.
		/// </summary>
		[XmlAttribute("MaxArmorPoints")]
		public int MaxArmorPoints { get; set; }

		/// <summary>
		/// Степень защиты брони.
		/// </summary>
		[XmlAttribute("ArmorResistance")]
		public int ArmorResistance { get; set; }

		/// <summary>
		/// Уровень машины.
		/// </summary>
		[XmlAttribute("Level")]
		public int Level { get; set; }

		/// <summary>
		/// Подвеска.
		/// </summary>
		[XmlElement("Suspension")]
		public SuspensionBase Suspension { get; set; }

		/// <summary>
		/// Кузов.
		/// </summary>
		[XmlElement("BodyMachine")]
		public BodyMachineBase BodyMachine { get; set; }

		/// <summary>
		/// Оружие.
		/// </summary>
		[XmlElement("Gun")]
		public GunBase Gun { get; set; }

		/// <summary>
		/// Пустой конструктор для сериализации.
		/// </summary>
		public Machine() { }

		/// <summary>
		/// Создать машину.
		/// </summary>
		/// <param name="name">Имя машины.</param>
		/// <param name="factory">Фабрика создающая машину.</param>
		public Machine(string name, MachineBaseFactory factory)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new NullReferenceException("Имя машины не может быть пустым или NULL.");
			}

			if (factory == null)
			{
				throw new NullReferenceException("Фабрика машин не может быть NULL.");
			}

			Name = name;
			Suspension = factory.GetSuspension();
			BodyMachine = factory.GetBody();
			Gun = factory.GetGun();
			MaxLifePoints = factory.MaxLifePoints;
			LifePoints = MaxLifePoints;
			MaxArmorPoints = factory.MaxArmorPoints;
			ArmorPoints = MaxArmorPoints;
			ArmorResistance = factory.ArmorResistance;
			Level = Math.Max(Gun.Level, Math.Max(Suspension.Level, BodyMachine.Level));
		}

		/// <summary>
		/// Выстрелить.
		/// </summary>
		/// <returns>Урон.</returns>
		public int Shoot()
		{
			return Gun.Shoot();
		}

		/// <summary>
		/// Получить урон.
		/// </summary>
		/// <param name="damage">Количество урона.</param>
		/// <returns>Результат.</returns>
		public string GetDamage(int damage)
		{
			if (LifePoints <= 0)
			{
				return "Машина уже уничтожена!";
			}

			if (ArmorPoints > 0)
			{
				var damageFromArmor = damage * ArmorResistance / 100;

				for (int index = 1; index <= damageFromArmor; index++)
				{
					damage--;
					ArmorPoints--;

					if (ArmorPoints == 0)
					{
						break;
					}
				}
			}

			if (damage > 0)
			{
				for (int index = 1; index <= damage; index++)
				{
					LifePoints--;

					if (LifePoints == 0)
					{
						return "Машина уничтожена!!";
					}
				}
			}

			return $"Осталось жизней: {LifePoints}\nОсталось брони: {ArmorPoints}";
		}
	}
}
