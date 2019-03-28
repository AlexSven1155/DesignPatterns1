namespace DesignPatterns.AbstractFactoryPattern.Machines.BaseClasses
{
	using System;
	using Interfaces;

	/// <summary>
	/// Базовая машина.
	/// </summary>
	public abstract class Machine : IBaseMachine
	{
		private object _obj = new object();

		private int _armorResistance;

		private int _maxArmorPoints;

		private int _maxLifePoints;

		/// <summary>
		/// Признак смерти машины.
		/// </summary>
		public bool IsDead;

		/// <summary>
		/// Название машины.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Количество жизней.
		/// </summary>
		public int LifePoints { get; set; }

		/// <summary>
		/// Количество брони машины.
		/// </summary>
		public int ArmorPoints { get; set; }

		/// <summary>
		/// Уровень машины.
		/// </summary>
		public int Level { get; set; }

		/// <summary>
		/// Максимальное количество жизней.
		/// </summary>
		public int MaxLifePoints
		{
			get => _maxLifePoints;
			protected set
			{
				if (value < 0)
				{
					throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(MaxLifePoints));
				}

				_maxLifePoints = value;
			}
		}

		/// <summary>
		/// Максимальное количество брони.
		/// </summary>
		public int MaxArmorPoints
		{
			get => _maxArmorPoints;
			protected set
			{
				if (value < 0)
				{
					throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(MaxArmorPoints));
				}

				_maxArmorPoints = value;
			}
		}

		/// <summary>
		/// Степень защиты брони.
		/// </summary>
		public int ArmorResistance
		{
			get => _armorResistance;

			protected set
			{
				if (value < 0)
				{
					throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(ArmorResistance));
				}

				_armorResistance = value;
			}
		}

		/// <summary>
		/// Подвеска.
		/// </summary>
		public Suspension Suspension { get; set; }

		/// <summary>
		/// Кузов.
		/// </summary>
		public BodyMachine Body { get; set; }

		/// <summary>
		/// Оружие.
		/// </summary>
		public Gun Gun { get; set; }

		/// <summary>
		/// Инициализация свойств машины.
		/// </summary>
		protected void InitProperties()
		{
			ArmorResistance = (Body.ArmorResistance + Suspension.ArmorResistance) / 2;
			MaxArmorPoints = Suspension.MaxArmorPoints + Body.MaxArmorPoints;
			MaxLifePoints = Suspension.MaxLifePoints + Body.MaxLifePoints;
			IsDead = false;

			if (Level == 0)
			{
				Level = Math.Max(Suspension.Level, Math.Max(Body.Level, Gun.Level));
			}

			if (LifePoints == 0)
			{
				LifePoints = MaxLifePoints;
			}

			if (ArmorPoints == 0)
			{
				ArmorPoints = MaxArmorPoints;
			}
		}

		/// <summary>
		/// Выстрелить.
		/// </summary>
		/// <returns>Урон.</returns>
		public int Shoot()
		{
			lock (_obj)
			{
				Console.WriteLine(Name);
				return Gun.Shoot();
			}
		}

		/// <summary>
		/// Получить урон.
		/// </summary>
		/// <param name="damage">Количество урона.</param>
		/// <returns>Полученный урон.</returns>
		public int GetDamage(int damage)
		{
			var inflictedDamage = 0;
			if (ArmorPoints > 0)
			{
				var damageFromArmor = damage * ArmorResistance / 100;

				while (damageFromArmor != 0)
				{
					damage--;
					ArmorPoints--;
					damageFromArmor--;

					if (ArmorPoints == 0)
					{
						break;
					}
				}
			}

			if (damage > 0)
			{
				while (damage != 0)
				{
					LifePoints--;
					damage--;
					inflictedDamage++;
				}
			}

			IsDead = LifePoints <= 0;

			return inflictedDamage;
		}

		/// <summary>
		/// Передвижение.
		/// </summary>
		/// <returns>Оставшееся расстояние.</returns>
		public int Move(int distance)
		{
			if (Suspension.QuantityFuel == 0)
			{
				return distance;
			}

			while (distance > 0)
			{
				Suspension.QuantityFuel--;
				distance--;

				if (Suspension.QuantityFuel == 0)
				{
					break;
				}
			}

			return distance;
		}

		/// <summary>
		/// Заправка бака.
		/// </summary>
		/// <param name="amountFuel">Количество бензина для заправки.</param>
		/// <returns>Количество бензина после заправки.</returns>
		public int TankUp(int amountFuel)
		{
			if (amountFuel < 0)
			{
				throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(amountFuel));
			}

			while (true)
			{
				amountFuel--;
				Suspension.QuantityFuel++;

				if (Suspension.QuantityFuel == Suspension.CapacityFuelTank)
				{
					return Suspension.QuantityFuel;
				}

				if (amountFuel == 0)
				{
					return Suspension.QuantityFuel;
				}
			}
		}
	}
}
