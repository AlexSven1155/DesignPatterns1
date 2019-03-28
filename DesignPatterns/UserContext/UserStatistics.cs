namespace DesignPatterns.UserContext
{
	using System;
	using System.Xml.Serialization;

	/// <summary>
	/// Статистика пользователя.
	/// </summary>
	[Serializable]
	public class UserStatistics
	{
		/// <summary>
		/// Убито противников.
		/// </summary>
		[XmlAttribute("EnemyKill")]
		public int EnemyKill { get; set; }

		/// <summary>
		/// Пройдено километров.
		/// </summary>
		[XmlAttribute("KilometersCovered")]
		public int KilometersCovered { get; set; }

		/// <summary>
		/// Получено предметов.
		/// </summary>
		[XmlAttribute("ReceivedItems")]
		public int ReceivedItems { get; set; }

		/// <summary>
		/// Использовано предметов.
		/// </summary>
		[XmlAttribute("UsedItems")]
		public int UsedItems { get; set; }

		/// <summary>
		/// Количество смертей.
		/// </summary>
		[XmlAttribute("NumberOfDeaths")]
		public int NumberOfDeaths { get; set; }
	}
}
