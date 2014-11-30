using System;
using Jamespennell.Injection.Extensions.Console.Signals.Impl;
using Mestevens.Injection.Core;

namespace Jamespennell.Injection.Extensions.Console.Views.Impl
{
	public class ConsoleMediator
	{
		#region Members

		private readonly ToggleSignal toggleSignal;

		private readonly SubmitSignal submitSignal;

		#endregion

		#region Constructors

		[Inject]
		public ConsoleMediator(ToggleSignal toggleSignal, SubmitSignal submitSignal)
		{
			this.toggleSignal = toggleSignal;
			this.submitSignal = submitSignal;
		}

		#endregion

		#region Methods

		public void Toggle()
		{
			this.toggleSignal.Dispatch();
		}

		public void Submit()
		{
			this.submitSignal.Dispatch();
		}

		#endregion
	}
}