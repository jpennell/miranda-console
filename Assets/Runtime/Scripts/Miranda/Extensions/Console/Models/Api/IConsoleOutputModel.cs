using System;
using UnityEngine.UI;

namespace Jamespennell.Injection.Extensions.Console.Models.Api
{
	public interface IConsoleOutputModel
	{
		#region Properties
		
		Text ConsoleOutput { get; set; }
		
		#endregion

		#region Methods

		void AppendLine(String line);

		#endregion
	}
}