using UnityEngine;
using Mestevens.Injection.Core;

namespace Jamespennell.Injection.Extensions.Console
{
	public class TestConsoleRoot : MonoBehaviour
	{
		#region Methods
		
		void Start()
		{
			Miranda.Init(new TestConsoleContext(this.gameObject));
		}
		
		#endregion
		
	}
	
	public class TestConsoleContext : ConsoleContext
	{
		#region Methods
		
		public override void MapBindings()
		{

		}
		
		#endregion
		
		#region Constructors
		
		public TestConsoleContext(GameObject root) : base(root) { }
		
		#endregion
	}
}
