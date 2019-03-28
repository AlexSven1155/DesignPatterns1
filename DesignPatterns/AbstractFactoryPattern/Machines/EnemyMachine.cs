namespace DesignPatterns.AbstractFactoryPattern.Machines
{
	using System;
	using Interfaces;
	using BaseClasses;

	/// <summary>
	/// Класс машины противника.
	/// </summary>
	public class EnemyMachine : Machine
	{
		public EnemyMachine(string name, IBasicMachineFactory factory)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException(nameof(name));
			}

			if (factory == null)
			{
				throw new ArgumentNullException(nameof(factory));
			}

			Suspension = factory.CreateSuspension();
			Body = factory.CreateBody();
			Gun = factory.CreateGun();
			Name = name;
			InitProperties();
		}
	}
}
