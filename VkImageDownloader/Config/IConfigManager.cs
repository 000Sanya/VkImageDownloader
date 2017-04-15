using System;
using Monad;

namespace VkImageDownloader.Configs
{
	public interface IConfigManager
	{
		bool RegisterField<T>(string name);
		bool IsHasField(string name);
		Option<Type> GetTypeOfField(string name);

		Option<T> GetField<T>(string name);
		void SetField<T>(string name, T value);
	}
}