using System;
using UnityEngine;
using UnityEngine.UI;

using Jamespennell.Injection.Extensions.Console.Models.Api;

namespace Jamespennell.Injection.Extensions.Console.Models.Impl
{
	public class ConsoleInputModel : IConsoleInputModel
	{
		#region Properties
		
		public InputField ConsoleInputField { get; set; }
		
		#endregion
	}
}