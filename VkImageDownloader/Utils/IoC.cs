using Ninject;
using Ninject.Modules;
using NLog;

namespace VkImageDownloader.Utils
{
	public class IoC
	{
		private static IKernel _kernel;
		public static IKernel Kernel => _kernel ?? (_kernel = new StandardKernel());

		public static void AddModule(INinjectModule module)
		{
			Kernel.Load(module);
		}

		public static T Get<T>()
		{
			return (T) Kernel.Get(typeof(T));
		}

		public static Logger GetLogger(string name)
		{
			return LogManager.GetLogger(name);
		}
	}
}