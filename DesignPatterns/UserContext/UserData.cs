namespace DesignPatterns.UserContext
{
	using System;
	using System.Runtime.Serialization;
	using AbstractFactoryPattern.Machines;

	/// <summary>
	/// Класс данных пользователя.
	/// </summary>
	[Serializable]
	public class UserData : ISerializable, IEquatable<UserData>
	{
		/// <summary>
		/// Имя игрока.
		/// </summary>
		public string UserName;

		/// <summary>
		/// Машина игрока.
		/// </summary>
		public UserMachine UserMachine;

		/// <summary>
		/// Статистика игрока.
		/// </summary>
		public UserStatistics UserStatistics;

		public UserData() { }

		/// <summary>
		/// Реализация интерфейса "ISerializable"
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("UserName", UserName);
			info.AddValue("UserMachine", UserMachine);
			info.AddValue("UserStatistics", UserStatistics);
		}

		/// <summary>
		/// Реализация интерфейса "ISerializable"
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public UserData(SerializationInfo info, StreamingContext context)
		{
			UserName = (string)info.GetValue("UserName", typeof(string));
			UserMachine = (UserMachine)info.GetValue("UserMachine", typeof(UserMachine));
			UserStatistics = (UserStatistics)info.GetValue("UserStatistics", typeof(UserStatistics));
		}

		public bool Equals(UserData other)
		{
			return UserName == other?.UserName;
		}
	}
}
