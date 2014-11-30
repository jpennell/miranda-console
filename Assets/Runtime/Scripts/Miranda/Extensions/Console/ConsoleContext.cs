using UnityEngine;
using Jamespennell.Injection.Extensions.Signals.Impl;
using UnityEngine.UI;
using Jamespennell.Injection.Extensions.Console.Views.Impl;

using Jamespennell.Injection.Extensions.Console.Models.Api;
using Jamespennell.Injection.Extensions.Console.Models.Impl;
using Jamespennell.Injection.Extensions.Console.Signals.Impl;
using Jamespennell.Injection.Extensions.Console.Commands.Impl;
using Mestevens.Injection.Core;

namespace Jamespennell.Injection.Extensions.Console
{
	public abstract class ConsoleContext : SignalContext
	{
		#region Members

		private readonly GameObject root;

		#endregion

		#region Constructors

		public ConsoleContext(GameObject root) : base()
		{
			this.root = root;
		}

		#endregion

		#region Methods

		protected override void MapPluginBindings()
		{
			base.MapPluginBindings();

			this.Bind<ToggleSignal>().To<ToggleCommand>();
			this.Bind<SubmitSignal>().To<SubmitCommand>();

			this.Bind<IConsoleModel>().To<ConsoleModel>().ToSingleton();
			this.Bind<IConsoleInputModel>().To<ConsoleInputModel>().ToSingleton();
		}

		private void InitConsole(Context rootContext)
		{
			GameObject console = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Console")) as GameObject;
			console.name = "Console";
			console.transform.parent = this.root.transform;
			rootContext.Get<IConsoleModel>().ConsoleGameObject = console;

			ConsoleView view = this.root.AddComponent<ConsoleView>();
			view.ConsoleMediator = rootContext.Get<ConsoleMediator>();

			rootContext.Get<IConsoleInputModel>().ConsoleInputField = GameObject.Find("Console/Canvas/Panel/InputField").GetComponent<InputField>();
			//input.consoleOuputText = GameObject.Find("Console/Canvas/Panel/ScrollView/ScrollText").GetComponent<Text>();

			//Setting the console to inactive must be the last thing in this method.  
			//The above "Find" methods will not retrieve inactive GameObjects
			console.SetActive(false);
		}

		public override void PostInit(Context rootContext)
		{
			base.PostInit(rootContext);
			this.InitConsole(rootContext);
		}

		#endregion
	}
}
