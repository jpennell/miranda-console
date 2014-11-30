using System;
using UnityEngine;
using Jamespennell.Injection.Extensions.Console.Models.Api;

namespace Jamespennell.Injection.Extensions.Console.Models.Impl
{
	public class ConsoleModel : IConsoleModel
	{
		#region Properties
		
		public GameObject ConsoleGameObject { get; set; }
		
		#endregion
	}
}