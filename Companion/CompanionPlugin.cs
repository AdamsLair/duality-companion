using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duality;

namespace Duality.Plugins.Companion
{
	/// <summary>
	/// Defines a Duality core plugin.
	/// </summary>
	public class CompanionPlugin : CorePlugin
	{
		// Override methods here for global logic

		protected override void OnBeforeUpdate()
		{
			base.OnBeforeUpdate();

			if (DualityApp.ExecContext == DualityApp.ExecutionContext.Game)
			{
				Timer.Update();
			}
		}

		protected override void OnExecContextChanged(DualityApp.ExecutionContext previousContext)
		{
			base.OnExecContextChanged(previousContext);

			Timer.Cleanup();
		}
	}
}
