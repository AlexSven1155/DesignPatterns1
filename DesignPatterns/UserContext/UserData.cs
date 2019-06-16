namespace DesignPatterns.UserContext
{
	using AbstractFactoryPattern.Machines;
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Класс данных пользователя.
	/// </summary>
	[Serializable]
	public class UserData : ISerializable, IEquatable<UserData>
	{
		/// <summary>
		/// Имя игрока.
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// Машина игрока.
		/// </summary>
		public UserMachine UserMachine { get; set; }

		/// <summary>
		/// Статистика игрока.
		/// </summary>
		public UserStatistics UserStatistics { get; set; }

		public UserData() { }

		/// <summary>
		/// Реализация интерфейса "ISerializable"
		/// </summary>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("UserName", UserName);
			info.AddValue("UserMachine", UserMachine);
			info.AddValue("UserStatistics", UserStatistics);
		}

		/// <summary>
		/// Реализация интерфейса "ISerializable"
		/// </summary>
		public UserData(SerializationInfo info, StreamingContext context)
		{
			UserName = (string)info.GetValue("UserName", typeof(string));
			UserMachine = (UserMachine)info.GetValue("UserMachine", typeof(UserMachine));
			UserStatistics = (UserStatistics)info.GetValue("UserStatistics", typeof(UserStatistics));
		}

		/// <summary>
		/// Реализация IEquatable.
		/// </summary>
		/// <param name="other">Данные с которыми идёт сравнение.</param>
		/// <returns>Результат сравнения.</returns>
		public bool Equals(UserData other)
		{
			return UserName == other?.UserName;
		}
	}
}