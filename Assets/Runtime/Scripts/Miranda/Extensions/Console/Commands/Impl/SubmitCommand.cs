using System;
using System.Collections.Generic;

using UnityEngine;

using Jamespennell.Injection.Extensions.Signals.Api;
using Mestevens.Injection.Core;
using Jamespennell.Injection.Extensions.Console.Models.Api;
using Mestevens.Injection.Core.Api;
using Jamespennell.Injection.Extensions.Signals.Impl;
using UnityEngine.EventSystems;

namespace Jamespennell.Injection.Extensions.Console.Commands.Impl
{
	public class SubmitCommand : ICommand
	{
		#region Members

		private readonly IDictionary<String, Type> signalNames;

		private readonly IConsoleInputModel consoleInputModel;

		private readonly IBinder binder;

		private readonly IConsoleOutputModel consoleOutputModel;

		#endregion

		#region Constructors

		[Inject]
		public SubmitCommand([Named("miranda.console.signal_names")]IDictionary<String, Type> signalNames, 
		                     IConsoleInputModel consoleInputModel, IBinder binder, IConsoleOutputModel consoleOutputModel)
		{
			this.signalNames = signalNames;
			this.consoleInputModel = consoleInputModel;
			this.binder = binder;
			this.consoleOutputModel = consoleOutputModel;
		}

		#endregion

		#region Methods

		public void Execute()
		{
			String command = this.consoleInputModel.ConsoleInputField.text;

			if (String.IsNullOrEmpty(command))
			{
				this.consoleOutputModel.AppendLine (String.Empty);
			} 
			else 
			{
				if (this.signalNames.ContainsKey (command)) {
						Signal signal = this.binder.Get (this.signalNames [command]) as Signal;
						signal.Dispatch ();
				} 
				else 
				{
					this.consoleOutputModel.AppendLine (String.Format ("Unknown command [{0}]", command));
				}
			}

			if(this.consoleInputModel.ConsoleInputField.IsActive())
			{
				this.consoleInputModel.ConsoleInputField.text = "";
				EventSystem.current.SetSelectedGameObject(this.consoleInputModel.ConsoleInputField.gameObject, null);
				this.consoleInputModel.ConsoleInputField.ActivateInputField();
			}
		}

		#endregion
	}
}