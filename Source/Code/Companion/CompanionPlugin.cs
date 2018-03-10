using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duality;
using Duality.Plugins.Companion.Coroutines;
using Duality.Resources;

namespace Duality.Plugins.Companion
{
	/// <summary>
	/// Defines a Duality core plugin.
	/// </summary>
	public class CompanionPlugin : CorePlugin
	{
        protected override void OnBeforeUpdate()
		{
			base.OnBeforeUpdate();

			if (DualityApp.ExecContext == DualityApp.ExecutionContext.Game)
			{
				Timer.Update();
                CoroutineManager.Update();
			}
		}

        protected override void OnExecContextChanged(DualityApp.ExecutionContext previousContext)
		{
			base.OnExecContextChanged(previousContext);

			Timer.Cleanup();
		}
	}
}
