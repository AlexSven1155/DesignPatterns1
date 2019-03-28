using DesignPatterns.SingletonePattern;

namespace DesignPatterns.AbstractFactoryPattern.Machines.Guns
{
	using System;
	using BaseClasses;

	/// <summary>
	/// Пушка "Армагеддон".
	/// </summary>
	[Serializable]
	public class NuclearCannon : GunBase
	{
		public NuclearCannon()
		{
			int userLevelKoef = 1;

			if (UserSession.GetSession().UserMachine != null)
			{
				userLevelKoef = UserSession.GetSession().UserMachine.Level * 35;
			}

			Name = "Армагеддон";
			MinDamage = 1000000 + userLevelKoef;
			MaxDamage = 1000000 + userLevelKoef;
			Level = 5;
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
