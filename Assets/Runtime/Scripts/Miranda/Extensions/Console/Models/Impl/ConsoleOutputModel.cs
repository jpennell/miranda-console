using System;
using UnityEngine.UI;
using Jamespennell.Injection.Extensions.Console.Models.Api;

namespace Jamespennell.Injection.Extensions.Console.Models.Impl
{
	public class ConsoleOutputModel : IConsoleOutputModel
	{
		#region Properties

		public Text ConsoleOutput { get; set; }
		
		#endregion

		#region Methods

		public void AppendLine(String line)
		{
			this.ConsoleOutput.text += Environment.NewLine + line;
		}

		#endregion
	}
}