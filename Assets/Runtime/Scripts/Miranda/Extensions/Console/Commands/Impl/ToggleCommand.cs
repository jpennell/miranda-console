using System;
using Jamespennell.Injection.Extensions.Signals.Api;
using Jamespennell.Injection.Extensions.Console.Models.Api;
using Mestevens.Injection.Core;
using UnityEngine.EventSystems;

namespace Jamespennell.Injection.Extensions.Console.Commands.Impl
{
	public class ToggleCommand : ICommand 
	{
		#region Members

		private readonly IConsoleModel console;

		private readonly IConsoleInputModel consoleInput;

		#endregion

		#region Constructors

		[Inject]
		public ToggleCommand(IConsoleModel console, IConsoleInputModel consoleInput)
		{
			this.console = console;
			this.consoleInput = consoleInput;
		}

		#endregion

		#region Methods
		
		public void Execute()
		{
			this.consoleInput.ConsoleInputField.text = "";

			if (this.console.ConsoleGameObject.activeSelf)
			{
				this.console.ConsoleGameObject.SetActive(false);
			}
			else
			{
				this.console.ConsoleGameObject.SetActive(true);
				EventSystem.current.SetSelectedGameObject(this.consoleInput.ConsoleInputField.gameObject, null);
				this.consoleInput.ConsoleInputField.ActivateInputField();
			}

		}
		
		#endregion
	}
}