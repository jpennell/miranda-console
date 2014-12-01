using UnityEngine.EventSystems;
using Mestevens.Injection.Core;
using Jamespennell.Injection.Extensions.Signals.Api;
using Jamespennell.Injection.Extensions.Console.Models.Api;

namespace Jamespennell.Injection.Extensions.Console.Commands.Impl
{
	public class ClearCommand : ICommand
	{
		#region Members

		private readonly IConsoleInputModel consoleInputModel;

		private readonly IConsoleOutputModel consoleOutputModel;
		
		#endregion
		
		#region Constructors
		
		[Inject]
		public ClearCommand(IConsoleInputModel consoleInputModel, IConsoleOutputModel consoleOutputModel)
		{
			this.consoleInputModel = consoleInputModel;
			this.consoleOutputModel = consoleOutputModel;
		}
		
		#endregion
		
		#region Methods
		
		public void Execute()
		{
			this.consoleOutputModel.ConsoleOutput.text = "";
			this.consoleInputModel.ConsoleInputField.text = "";
			EventSystem.current.SetSelectedGameObject(this.consoleInputModel.ConsoleInputField.gameObject, null);
			this.consoleInputModel.ConsoleInputField.ActivateInputField();
		}
		
		#endregion
	}
}