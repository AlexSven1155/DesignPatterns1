namespace DesignPatterns.AbstractFactoryPattern.Guns
{
	using BaseClasses;

	/// <summary>
	/// Пистолет пулемёт.
	/// </summary>
	public class AutomaticPistol : GunBase
	{
		public AutomaticPistol()
		{
			Damage = 10;
			Name = "Пистолет-пулемёт";
		}

		public override int Shoot()
		{
			return Damage;
		}
	}
}
