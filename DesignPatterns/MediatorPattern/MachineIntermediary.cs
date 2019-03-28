namespace DesignPatterns.MediatorPattern
{
	using System;
	using AbstractFactoryPattern.Machines;
	using AbstractFactoryPattern.StaticObject.Enums;
	using AbstractFactoryPattern.StaticObject.Interfaces;

	/// <summary>
	/// Класс реализует взаимодействие машины и лута
	/// </summary>
	public class MachineIntermediary
	{
		private UserMachine _userMachine;

		private IBaseStaticObject _staticObject;

		/// <summary>
		/// Инициализация класса.
		/// </summary>
		/// <param name="userMachine">Машина пользователя</param>
		/// <param name="staticObject">Предмет с которым происходит взаимодействие</param>
		public MachineIntermediary(UserMachine userMachine, IBaseStaticObject staticObject)
		{
			_userMachine = userMachine ?? throw new ArgumentNullException(nameof(userMachine));
			_staticObject = staticObject ?? throw new ArgumentNullException(nameof(staticObject));
		}

		/// <summary>
		/// Взять предмет.
		/// </summary>
		/// <returns>Результат действия.</returns>
		public bool Take()
		{
			if (_userMachine.CurrentSizeInventory() < _staticObject.Size)
			{
				return false;
			}

			_userMachine.Inventory.Add(_staticObject);

			return true;
		}

		/// <summary>
		/// Выбросить предмет.
		/// </summary>
		/// <returns>Результат действия.</returns>
		public bool Turf()
		{
			if (_userMachine.Inventory.Contains(_staticObject))
			{
				_userMachine.Inventory.Remove(_staticObject);
				return true;
			}

			return false;
		}

		/// <summary>
		/// Использовать предмет.
		/// </summary>
		/// <param name="quantity">Количество которое необходимо использовать.</param>
		/// <returns>Результат действия.</returns>
		public bool Use(int quantity)
		{
			if (_staticObject.Use(quantity))
			{
				switch (_staticObject.Type)
				{
					case StaticObjectType.Armor:
						_userMachine.RepairArmorPoints(quantity);
						break;
					case StaticObjectType.Life:
						_userMachine.RepairLifePoints(quantity);
						break;
					case StaticObjectType.Petrol:
						_userMachine.TankUp(quantity);
						break;
				}

				//Если ценность объекта 0 то избавимся от него.
				if (_staticObject.Price == 0)
				{
					Turf();
				}

				return true;

			}

			return false;
		}
	}
}
