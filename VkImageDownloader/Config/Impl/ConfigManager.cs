using System;
using System.Collections.Generic;
using Monad;

namespace VkImageDownloader.Configs
{
	public class ConfigManager : IConfigManager
	{
		private Dictionary<string, Type> _fieldTypes;
		private IConfigSerializer _configSerializer;

		public ConfigManager(IConfigSerializer configSerializer)
		{
			_configSerializer = configSerializer;
			_fieldTypes = new Dictionary<string, Type>();
		}

		public bool RegisterField<T>(string name)
		{
			if (IsHasField(name)) return false;
			_fieldTypes.Add(name, typeof(T));
			return true;
		}

		public bool IsHasField(string name)
		{
			return _fieldTypes.ContainsKey(name);
		}

		public Option<Type> GetTypeOfField(string name)
		{
			if (IsHasField(name))
				return _fieldTypes[name].ToOption;
			return Option.Nothing<Type>();
		}

		public Option<T> GetField<T>(string name)
		{
			return from res in _configSerializer.ReadField<T>(name)
				select res;
		}

		public void SetField<T>(string name, T value)
		{
			if(IsHasField(name))
				_configSerializer.WriteField(name, value);
		}
	}
}