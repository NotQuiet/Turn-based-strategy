using System;
using UniRx;
using UnityEngine;

namespace MVVM.Core
{
    [Serializable]
    public abstract class Model
    {
        protected CompositeDisposable Disposable = new();

        private bool _isSubscribed;
        
        public virtual void OnViewShow()
        {
            Subscribe(() => Debug.Log("ViewShow"));
        }

        public virtual void OnViewHide()
        {
            Unsubscribe();
        }

        protected virtual void Subscribe(Action onSubscribe)
        {
            if (_isSubscribed) return;

            Debug.Log($"Model {GetType().Name} subscribe");

            _isSubscribed = true;
            onSubscribe!();
        }
        
        protected virtual void Unsubscribe()
        {
            _isSubscribed = false;
            Disposable.Clear();
            
            Debug.Log("Unsubscribe");
        }
    }
}