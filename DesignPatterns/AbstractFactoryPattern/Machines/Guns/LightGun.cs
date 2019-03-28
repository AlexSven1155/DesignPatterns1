using DesignPatterns.SingletonePattern;

namespace DesignPatterns.AbstractFactoryPattern.Machines.Guns
{
	using System;
	using BaseClasses;

	/// <summary>
	/// Лёгкий пулемёт.
	/// </summary>
	[Serializable]
	public class LightGun : GunBase
	{
		public LightGun()
		{
			int userLevelKoef = 1;

			if (UserSession.GetSession().UserMachine != null)
			{
				userLevelKoef = UserSession.GetSession().UserMachine.Level * 35;
			}

			MinDamage = 100 + userLevelKoef;
			MaxDamage = 150 + userLevelKoef;
			Name = "Лёгкий пулемёт";
			Level = 1;
		}

		/// <summary>
		/// Выстрелить.
		/// </summary>
		/// <returns>Урон.</returns>
		public override int Shoot()
		{
			var random = new Random();
			return random.Next(MinDamage, MaxDamage + 1);
		}
	}
}
