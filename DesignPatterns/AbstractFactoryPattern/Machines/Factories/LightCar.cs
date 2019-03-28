namespace DesignPatterns.AbstractFactoryPattern.Machines.Factories
{
	using BaseClasses;
	using Bodies;
	using Guns;
	using Suspensions;

	/// <summary>
	/// Лёгкий автомобиль.
	/// </summary>
	public class LightCar : MachineBaseFactory
	{
		/// <summary>
		/// Коэффициент для повышения уровня.
		/// </summary>
		private int _koef;

		public LightCar(int koef = 0)
		{
			Name = "Лёгкий автомобиль";
			_koef = koef;
		}

		/// <summary>
		/// Получить кузов.
		/// </summary>
		/// <returns>Кузов.</returns>
		public override BodyMachineBase GetBody()
		{
			var carBody = new CarBody();
			LifePoints += carBody.LifePoints + _koef;
			ArmorPoints += carBody.ArmorPoints + _koef;
			MaxArmorPoints += carBody.MaxArmorPoints + _koef;
			MaxLifePoints += carBody.MaxLifePoints + _koef;

			if (ArmorResistance == 0)
			{
				ArmorResistance += carBody.ArmorResistance;
			}
			else
			{
				ArmorResistance = (ArmorResistance + carBody.ArmorResistance) / 2;
			}

			return carBody;
		}

		/// <summary>
		/// Получить подвеску.
		/// </summary>
		/// <returns>Подвеска.</returns>
		public override SuspensionBase GetSuspension()
		{
			var carSuspension = new CarSuspension();
			LifePoints += carSuspension.LifePoints + _koef;
			ArmorPoints += carSuspension.ArmorPoints + _koef;
			MaxArmorPoints += carSuspension.MaxArmorPoints + _koef;
			MaxLifePoints += carSuspension.MaxLifePoints + _koef;

			if (ArmorResistance == 0)
			{
				ArmorResistance += carSuspension.ArmorResistance;
			}
			else
			{
				ArmorResistance = (ArmorResistance + carSuspension.ArmorResistance) / 2;
			}
			return carSuspension;
		}

		/// <summary>
		/// Получить оружие.
		/// </summary>
		/// <returns>Оружие.</returns>
		public override GunBase GetGun()
		{
			return new LightGun();
		}
	}
}
