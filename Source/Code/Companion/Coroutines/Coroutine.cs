using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duality.Plugins.Companion.Coroutines
{
    public sealed class Coroutine : ICoroutineAction, IDisposable
    {
        public static Coroutine Start(IEnumerable<ICoroutineAction> coroutine)
        {
            Coroutine c = new Coroutine(coroutine);
            CoroutineManager.Register(c);
            return c;
        }

        internal IEnumerator<ICoroutineAction> Enumerator { get; private set; }

        internal ICoroutineAction Current => Enumerator.Current;

        public bool IsComplete => Current == StopAction.Value;

        private Coroutine(IEnumerable<ICoroutineAction> values)
        {
            Enumerator = values.Concat(StopAction.Finalizer).GetEnumerator();
        }

        internal void Restart()
        {
            Enumerator.Reset();
            Enumerator.MoveNext();
        }

        public void Abort()
        {
            (Enumerator.Current as Coroutine)?.Abort();

            Enumerator.Dispose();
            Enumerator = StopAction.Finalizer.GetEnumerator();
            Enumerator.MoveNext();
        }

        public void Dispose()
        {
            Enumerator.Dispose();
        }
    }
}
