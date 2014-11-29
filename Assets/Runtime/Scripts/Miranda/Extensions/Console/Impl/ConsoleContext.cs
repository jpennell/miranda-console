using Jamespennell.Injection.Extensions.Signals.Impl;

namespace Jamespennell.Injection.Extensions.Console.Impl
{
	public abstract class ConsoleContext : SignalContext
	{
		#region Constructors

		public ConsoleContext() : base()
		{

		}

		#endregion

		#region Methods

		protected override void MapPluginBindings()
		{
			base.MapPluginBindings();
		}

		#endregion

	}
}