namespace DesignPatterns.ProcessingData
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	/// <summary>
	/// Класс для работы с данными.
	/// </summary>
	/// <typeparam name="T">Класс модели сущности.</typeparam>
	public class RepositoryData<T> : IRepositoryData<T> where T : ISerializable, IEquatable<T>
	{
		/// <summary>
		/// Название файла.
		/// </summary>
		private readonly string _fileName;

		/// <summary>
		/// Список кешированных данных.
		/// </summary>
		public List<T> TableData { get; private set; }

		/// <summary>
		/// Загружает данные.
		/// </summary>
		/// <param name="fileName">Имя файла.</param>
		public RepositoryData(string fileName)
		{
			if (string.IsNullOrWhiteSpace(fileName))
			{
				throw new ArgumentNullException(nameof(fileName));
			}

			_fileName = fileName;
			LoadData();
		}

		/// <summary>
		/// Удалить экземпляр из списка кешированных данных.
		/// </summary>
		/// <param name="data">Экземпляр класса.</param>
		public void RemoveData(T data)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			TableData.Remove(data);
		}

		/// <summary>
		/// Добавить экземпляр в список кешированных данных.
		/// </summary>
		/// <param name="data">Экземпляр класса.</param>
		public void AddData(T data)
		{
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			TableData.Remove(data);
			TableData.Add(data);
		}

		/// <summary>
		/// Сохраняет данные в файл.
		/// </summary>
		public void SaveData()
		{
			Serializer.SerializeUserData(TableData, _fileName);
		}

		/// <summary>
		/// Загружает данные из файла.
		/// </summary>
		public void LoadData()
		{
			TableData = Serializer.DeserializeUserData<T>(_fileName);
		}
	}
}