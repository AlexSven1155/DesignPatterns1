namespace DesignPatterns.ProcessingData
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	/// <summary>
	/// Интефейс для работы с таблицей данных.
	/// </summary>
	/// <typeparam name="T">Тип используемой модели данных.</typeparam>
	public interface IRepositoryData<T> where T : ISerializable, IEquatable<T>
	{
		/// <summary>
		/// Таблица с даннными.
		/// </summary>
		List<T> TableData { get; }

		/// <summary>
		/// Добавить экземпляр в список данных.
		/// </summary>
		/// <param name="data">Экземпляр класса.</param>
		void AddData(T data);

		/// <summary>
		/// Удалить экземпляр из списка данных.
		/// </summary>
		/// <param name="data">Экземпляр класса.</param>
		void RemoveData(T data);

		/// <summary>
		/// Сохраняет данные.
		/// </summary>
		void SaveData();

		/// <summary>
		/// Загружает данные.
		/// </summary>
		void LoadData();
	}
}