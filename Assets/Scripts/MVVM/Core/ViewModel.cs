using System;
using UniRx;
using UnityEngine;

namespace MVVM.Core
{
    [Serializable]
    public abstract class ViewModel<T> : ViewModelBase where T : Model
    {
        protected CompositeDisposable Disposable = new ();
        protected T Model;

        private bool _isSubscribed;

        protected ViewModel(T model)
        {
            Model = model;
        }

        public virtual void OnViewShow()
        {
            Subscribe(() => Debug.Log($"ViewModel {GetType().Name} subscribe"));
            Model.OnViewShow();
        }
        public virtual void OnViewHide()
        {
            Unsubscribe();
            Model.OnViewHide();
        }

        protected virtual void Subscribe(Action onSubscribe)
        {
            if (_isSubscribed) return;

            _isSubscribed = true;
            onSubscribe!();
        }
        
        protected virtual void Unsubscribe()
        {
            _isSubscribed = false;
            Disposable.Clear();
        }
    }
}