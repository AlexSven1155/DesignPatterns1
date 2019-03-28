using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesignPatterns.ProcessingData
{
	/// <summary>
	/// Класс для работы с данными.
	/// </summary>
	/// <typeparam name="T">Класс сущности</typeparam>
	public class RepositoryTable<T> : IRepositoryTable<T> where T : ISerializable
	{
		private readonly string _fileName;

		/// <summary>
		/// Для инициализации требуется имя файла с данными.
		/// </summary>
		/// <param name="fileName">Имя файла.</param>
		public RepositoryTable(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException(nameof(fileName));
			}

			_fileName = fileName;
			LoadDataFromFiles();
		}

		/// <summary>
		/// Список кешированных данных.
		/// </summary>
		public List<T> TableData { get; private set; }

		/// <summary>
		/// Удалить экземпляр из списка кешированных данных.
		/// </summary>
		/// <param name="data">Экземпляр класса.</param>
		public void RemoveData(T data)
		{
			LoadDataFromFiles();

			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			TableData.Remove(data);
			SaveDataToFiles();
		}

		/// <summary>
		/// Добавить экземпляр в список кешированных данных.
		/// </summary>
		/// <param name="data">Экземпляр класса</param>
		public void AddData(T data)
		{
			LoadDataFromFiles();

			if (data == null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			TableData.Remove(data);
			TableData.Add(data);
			SaveDataToFiles();
		}

		/// <summary>
		/// Кешировать данные из файла.
		/// </summary>
		private void LoadDataFromFiles()
		{
			TableData = Serializer.DeserializeUserData<T>(_fileName) ?? new List<T>();
		}

		/// <summary>
		/// Записать данные кеша в файл.
		/// </summary>
		private void SaveDataToFiles()
		{
			Serializer.SerializeUserData(TableData, _fileName);
		}
	}
}
