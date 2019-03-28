namespace DesignPatterns.AbstractFactoryPattern.Machines.BaseClasses
{
	using Enums;
	using Interfaces;
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Базовая подвеска машины.
	/// </summary>
	[Serializable]
	public class Suspension : IBaseMachinePart, ISerializable, IEquatable<Suspension>
	{
		public Suspension(string name,
			int level,
			int maxLifePoints,
			int maxArmorPoints,
			int armorResistance,
			int enginePower,
			int capacityFuelTank,
			int fuelConsumption,
			ModeMotionSuspension modeMotion)
		{
			Name = string.IsNullOrEmpty(name)
				? throw new ArgumentNullException(nameof(name))
				: name;

			Level = level <= 0
				? throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(level))
				: level;

			MaxLifePoints = maxLifePoints <= 0
				? throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(maxLifePoints))
				: maxLifePoints;

			MaxArmorPoints = maxArmorPoints <= 0
				? throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(maxArmorPoints))
				: maxArmorPoints;

			ArmorResistance = armorResistance < 0
				? throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(armorResistance))
				: armorResistance;

			EnginePower = enginePower <= 0
				? throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(enginePower))
				: enginePower;

			CapacityFuelTank = capacityFuelTank <= 0
				? throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(capacityFuelTank))
				: capacityFuelTank;

			FuelConsumption = fuelConsumption <= 0
				? throw new ArgumentException(StringHelper.IncorrectNumericValue, nameof(fuelConsumption))
				: fuelConsumption;

			ModeMotion = Enum.TryParse(modeMotion.ToString(), out modeMotion)
				? modeMotion
				: throw new ArgumentException(StringHelper.IncorrectEnumValue, nameof(modeMotion));

			SetSpeed();
		}

		/// <summary>
		/// Название подвески.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Уровень.
		/// </summary>
		public int Level { get; set; }

		/// <summary>
		/// Максимальное количество очков жизней.
		/// </summary>
		public int MaxLifePoints { get; set; }

		/// <summary>
		/// Максимальное количество очков брони.
		/// </summary>
		public int MaxArmorPoints { get; set; }

		/// <summary>
		/// Степень защиты брони.
		/// </summary>
		public int ArmorResistance { get; set; }

		/// <summary>
		/// Максимальная скорость.
		/// </summary>
		public int MaxSpeed { get; set; }

		/// <summary>
		/// Мощность двигателя.
		/// </summary>
		public int EnginePower { get; set; }

		/// <summary>
		/// Вместительность бака.
		/// </summary>
		public int CapacityFuelTank { get; set; }

		/// <summary>
		/// Расход бензина.
		/// </summary>
		public int FuelConsumption { get; set; }

		/// <summary>
		/// Текущее колчество топлива.
		/// </summary>
		public int QuantityFuel { get; set; }

		/// <summary>
		/// Способ движения.
		/// </summary>
		public ModeMotionSuspension ModeMotion { get; set; }

		/// <summary>
		/// Установить скорость.
		/// </summary>
		private void SetSpeed()
		{
			int result = 0;
			switch (ModeMotion)
			{
				case ModeMotionSuspension.Flying:
					result = EnginePower * 80 / 100;
					break;
				case ModeMotionSuspension.Walker:
					result = EnginePower * 25 / 100;
					break;
				case ModeMotionSuspension.Wheeled:
					result = EnginePower * 50 / 100;
					break;
			}

			MaxSpeed = result;
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Name", Name);
			info.AddValue("Level", Level);
			info.AddValue("MaxLifePoints", MaxLifePoints);
			info.AddValue("MaxArmorPoints", MaxArmorPoints);
			info.AddValue("ArmorResistance", ArmorResistance);
			info.AddValue("EnginePower", EnginePower);
			info.AddValue("CapacityFuelTank", CapacityFuelTank);
			info.AddValue("FuelConsumption", FuelConsumption);
			info.AddValue("QuantityFuel", QuantityFuel);
			info.AddValue("ModeMotion", ModeMotion);
		}

		public Suspension(SerializationInfo info, StreamingContext context)
		{
			Name = (string)info.GetValue("Name", typeof(string));
			Level = (int)info.GetValue("Level", typeof(int));
			MaxLifePoints = (int)info.GetValue("MaxLifePoints", typeof(int));
			MaxArmorPoints = (int)info.GetValue("MaxArmorPoints", typeof(int));
			ArmorResistance = (int)info.GetValue("ArmorResistance", typeof(int));
			EnginePower = (int)info.GetValue("EnginePower", typeof(int));
			CapacityFuelTank = (int)info.GetValue("CapacityFuelTank", typeof(int));
			FuelConsumption = (int)info.GetValue("FuelConsumption", typeof(int));
			QuantityFuel = (int)info.GetValue("QuantityFuel", typeof(int));
			ModeMotion = (ModeMotionSuspension)info.GetValue("ModeMotion", typeof(int));
			SetSpeed();
		}

		public override string ToString()
		{
			return $"Название: {Name}\n" +
				   $"Макс хп: {MaxLifePoints}\n" +
				   $"Макс брони: {MaxArmorPoints}\n" +
				   $"Уровень: {Level}\n" +
				   $"Защита брони: {ArmorResistance}\n" +
				   $"Макс скорость: {MaxSpeed}\n" +
				   $"Мощность двигателя: {EnginePower}\n" +
				   $"Объём бака: {CapacityFuelTank}\n" +
				   $"Расход: {FuelConsumption}\n" +
				   $"Тип подвески: {ModeMotion.ToString()}";
		}

		public bool Equals(Suspension other)
		{
			return Name == other?.Name;
		}
	}
}
