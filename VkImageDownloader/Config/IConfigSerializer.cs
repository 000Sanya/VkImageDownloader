using System;
using Monad;

namespace VkImageDownloader.Configs
{
	public interface IConfigSerializer
	{
		void WriteField(string name, object value);
		Option<object> ReadField(string name, Type type);
		Option<T> ReadField<T>(string name);

		void Load();
		void Save();
	}
}