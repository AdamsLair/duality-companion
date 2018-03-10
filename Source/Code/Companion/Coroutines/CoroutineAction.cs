using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duality.Plugins.Companion.Coroutines
{
    public interface ICoroutineAction
    {
        bool IsComplete { get; }
    }

    internal sealed class StopAction : ICoroutineAction
    {
        public static IEnumerable<StopAction> Finalizer = new StopAction[] { StopAction.Value };
        public static StopAction Value = new StopAction();

        private StopAction() { }

        public bool IsComplete => false;
    }

    public sealed class WaitForTime : ICoroutineAction
    {
        private float _time;
        public WaitForTime(TimeSpan time)
        {
            _time = (float)time.TotalMilliseconds;
        }

        public bool IsComplete
        {
            get { _time -= Time.LastDelta; return _time <= float.Epsilon; }
        }
    }

    public sealed class WaitForFrames : ICoroutineAction
    {
        private int _frames;
        public WaitForFrames(int frames)
        {
            _frames = frames;
        }

        public bool IsComplete
        {
            get { _frames--; return _frames <= 0; }
        }
    }

    public sealed class WaitForSignal : ICoroutineAction
    {
        private string _signal;
        public WaitForSignal(string signal)
        {
            _signal = signal;
        }

        public bool IsComplete => CoroutineManager.IsSet(_signal);
    }

    public sealed class ConsumeSignal : ICoroutineAction
    {
        private string _signal;
        public ConsumeSignal(string signal)
        {
            _signal = signal;
        }

        public bool IsComplete => CoroutineManager.ConsumeSignal(_signal);
    }

    public sealed class EmitSignal : ICoroutineAction
    {
        private string _signal;
        private bool _continueIfCantEmit;

        public EmitSignal(string signal, bool waitUntilCanEmit = false)
        {
            _signal = signal;
            _continueIfCantEmit = !waitUntilCanEmit;
    }

        public bool IsComplete => _continueIfCantEmit || CoroutineManager.EmitSignal(_signal);
    }

    public sealed class WaitOne: ICoroutineAction
    {
        IEnumerable<ICoroutineAction> _conditions;
        public WaitOne(params ICoroutineAction[] conditions)
        {
            _conditions = conditions;
        }

        public bool IsComplete
        {
            get
            {
                bool result = false;
                foreach (ICoroutineAction c in _conditions)
                    result |= c.IsComplete;

                return result;
            }
        }
    }

    public sealed class WaitAll : ICoroutineAction
    {
        IEnumerable<ICoroutineAction> _conditions;
        public WaitAll(params ICoroutineAction[] conditions)
        {
            _conditions = conditions;
        }

        public bool IsComplete
        {
            get
            {
                bool result = true;
                foreach (ICoroutineAction c in _conditions)
                    result &= c.IsComplete;

                return result;
            }
        }
    }

    public sealed class ContinuousAction : ICoroutineAction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>true if the action is considered complete, false otherwise</returns>
        public delegate bool Action();

        private Action _action;
        public ContinuousAction(Action action)
        {
            _action = action;
        }

        public bool IsComplete
        {
            get { return _action(); }
        }
    }
}
