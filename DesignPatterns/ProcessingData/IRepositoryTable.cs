using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesignPatterns.ProcessingData
{
	/// <summary>
	/// Интефейс для работы с таблицей данных.
	/// </summary>
	public interface IRepositoryTable<T> where T : ISerializable
	{
		List<T> TableData { get; }

		/// <summary>
		/// Добавить экземпляр в список данных.
		/// </summary>
		/// <param name="data">Экземпляр класса</param>
		void AddData(T data);

		/// <summary>
		/// Удалить экземпляр из списка данных.
		/// </summary>
		/// <param name="data">Экземпляр класса.</param>
		void RemoveData(T data);
	}
}
