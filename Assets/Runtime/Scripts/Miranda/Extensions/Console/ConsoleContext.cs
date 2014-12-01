using UnityEngine;
using Jamespennell.Injection.Extensions.Signals.Impl;
using UnityEngine.UI;
using Jamespennell.Injection.Extensions.Console.Views.Impl;

using Jamespennell.Injection.Extensions.Console.Models.Api;
using Jamespennell.Injection.Extensions.Console.Models.Impl;
using Jamespennell.Injection.Extensions.Console.Signals.Impl;
using Jamespennell.Injection.Extensions.Console.Commands.Impl;
using Mestevens.Injection.Core;
using System;
using System.Collections.Generic;

namespace Jamespennell.Injection.Extensions.Console
{
	public abstract class ConsoleContext : SignalContext
	{
		#region Members

		private readonly IDictionary<String, Type> signalNames;

		private readonly GameObject root;

		private Type signal;

		#endregion

		#region Constructors

		public ConsoleContext(GameObject root) : base()
		{
			this.root = root;
			this.signalNames = new Dictionary<String, Type>();
		}

		#endregion

		#region Methods

		public override Context Named(string name)
		{
			if (this.signal != null)
			{
				this.signalNames.Add(name, this.signal);
				this.signal = null;
			} 
			else 
			{
				base.Named(name);
			}

			return this;
		}

		public override Context Bind<T>()
		{
			Type type = typeof(T);
			this.signal = typeof(Signal).IsAssignableFrom(type) ? type : null;
			base.Bind<T>();
			return this;
		}

		public override Context To<T>()
		{
			base.To<T>();
			return this;
		}

		protected override void MapPluginBindings()
		{
			base.MapPluginBindings();

			this.Bind<ToggleSignal>().To<ToggleCommand>().Named(ConsoleConstants.TOGGLE_SIGNAL_COMMAND_NAME);
			this.Bind<ClearSignal>().To<ClearCommand>().Named(ConsoleConstants.CLEAR_SIGNAL_COMMAND_NAME);
			this.Bind<SubmitSignal>().To<SubmitCommand>();

			this.Bind<IConsoleModel>().To<ConsoleModel>().ToSingleton();
			this.Bind<IConsoleInputModel>().To<ConsoleInputModel>().ToSingleton();
			this.Bind<IConsoleOutputModel>().To<ConsoleOutputModel>().ToSingleton();

			this.Bind<IDictionary<String, Type>>().Named(ConsoleConstants.SIGNAL_NAMES_NAME).To(this.signalNames);

			this.Bind<ConsoleMediator>().To<ConsoleMediator>();
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
			rootContext.Get<IConsoleOutputModel>().ConsoleOutput = GameObject.Find("Console/Canvas/Panel/ScrollView/ScrollText").GetComponent<Text>();

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
