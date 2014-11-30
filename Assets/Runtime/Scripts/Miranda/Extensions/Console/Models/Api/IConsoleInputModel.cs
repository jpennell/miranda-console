using System;
using UnityEngine;
using UnityEngine.UI;

namespace Jamespennell.Injection.Extensions.Console.Models.Api
{
	public interface IConsoleInputModel
	{
		#region Properties
		
		InputField ConsoleInputField { get; set; }
		
		#endregion
	}
}