using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Jamespennell.Injection.Extensions.Console.Views.Impl
{
	public class ConsoleView : MonoBehaviour
	{
		#region Members

		public ConsoleMediator ConsoleMediator { get; set; }

		#endregion

		#region Methods

		void Update()
		{
			if(Input.GetKeyUp(KeyCode.BackQuote))
			{
				this.ConsoleMediator.Toggle();
			}

			if(Input.GetKeyUp(KeyCode.Return))
			{
				this.ConsoleMediator.Submit();
			}
		}

		#endregion
	}
}
