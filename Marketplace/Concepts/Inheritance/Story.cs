using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marketplace.Concepts.Interfaces;
using Marketplace.Concepts.EventHandling;

namespace Marketplace.Concepts.Inheritance
{
    public abstract class Story : IStateEventSubscriber, IStateEventNotifier
    {
        protected IStorySettings _settings;
        protected DateTime _cur;

        #region IStateEventSubscriber

        protected IList<StateEventListener> _eventListeners;

        public virtual DateTime GetEventOccured()
        {
            return _cur;
        }

        public virtual void AddListener(StateEventListener listener)
        {
            if (listener == null)
                throw new ArgumentNullException("listener");
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
            }
        }

        #endregion

        #region IStateEventNotifier

        public event StateEventHandler Changed;

        protected virtual void OnChanged(string message)
        {
            StateEventHandler handler = Changed;
            if (handler != null)
            {
                var args = new StateEventArgs() { Message = message };
                handler(this, args);
            }
        }

        #endregion

        public Story()
        {
            _eventListeners = new List<StateEventListener>();
        }

        public virtual void Play(IStorySettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException("settings");

            _settings = settings;

            // Template method pattern
            Initialize();
            AttachListeners();
            Run();
        }

        protected virtual void Initialize()
        {
            _cur = _settings.Start;
        }

        protected virtual void AttachListeners()
        {
            if (_eventListeners.Count == 0)
            {
                _eventListeners.Add(StateEventListener.DefaultEventListener);
            }
            foreach (var listener in _eventListeners)
            {
                listener.Subscribe(this, this);
            }
        }

        protected virtual void Run()
        {
            _cur = _settings.Start.Add(_settings.EventInterval);
            while (_cur < _settings.End)
            {
                RunStoryLine(); // Template method pattern
                _cur = _cur.Add(_settings.EventInterval);
            }
        }

        protected virtual void RunStoryLine() // No default implementation, but if marked as abstract would require decorators to implement
        {
        }
    }
}
