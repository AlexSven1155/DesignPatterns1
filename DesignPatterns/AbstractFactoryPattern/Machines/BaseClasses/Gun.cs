namespace DesignPatterns.AbstractFactoryPattern.Machines.BaseClasses
{
	using Interfaces;
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Базовый класс оружия.
	/// </summary>
	[Serializable]
	public class Gun : IBaseGun, ISerializable, IEquatable<Gun>
	{
		Random _random = new Random();

		/// <summary>
		/// Базовый конструктор.
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="level">Уровень</param>
		/// <param name="minDamage">Минимальный урон</param>
		/// <param name="maxDamage">Максимальный урон</param>
		public Gun(string name, int level, int minDamage, int maxDamage)
		{
			Name = string.IsNullOrEmpty(name)
				? throw new ArgumentNullException(nameof(name))
				: name;

			Level = level <= 0
				? throw new ArgumentNullException(nameof(level))
				: level;

			MinDamage = minDamage <= 0
				? throw new ArgumentNullException(nameof(minDamage))
				: minDamage;

			MaxDamage = maxDamage <= 0
				? throw new ArgumentNullException(nameof(maxDamage))
				: maxDamage;
		}

		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Уровень.
		/// </summary>
		public int Level { get; set; }

		/// <summary>
		/// Минимальный урон.
		/// </summary>
		public int MinDamage { get; set; }

		/// <summary>
		/// Максимальный урон.
		/// </summary>
		public int MaxDamage { get; set; }

		/// <summary>
		/// Выстрелить.
		/// </summary>
		/// <returns>Урон.</returns>
		public int Shoot()
		{
			return _random.Next(MinDamage, MaxDamage + 1);
		}

		/// <summary>
		/// Реализация интерфейса "ISerializable"
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Name", Name);
			info.AddValue("Level", Level);
			info.AddValue("MinDamage", MinDamage);
			info.AddValue("MaxDamage", MaxDamage);
		}

		/// <summary>
		/// Реализация интерфейса "ISerializable"
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public Gun(SerializationInfo info, StreamingContext context)
		{
			Name = (string)info.GetValue("Name", typeof(string));
			Level = (int)info.GetValue("Level", typeof(int));
			MinDamage = (int)info.GetValue("MinDamage", typeof(int));
			MaxDamage = (int)info.GetValue("MaxDamage", typeof(int));
		}

		public override string ToString()
		{
			return $"Название: {Name}{Environment.NewLine}" +
				   $"Мин урон: {MinDamage}{Environment.NewLine}" +
				   $"Макс урон: {MaxDamage}{Environment.NewLine}" +
				   $"Уровень: {Level}";
		}

		public bool Equals(Gun other)
		{
			return Name == other?.Name;
		}
	}
}
