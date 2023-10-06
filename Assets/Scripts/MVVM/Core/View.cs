using UniRx;
using UnityEngine;

namespace MVVM.Core
{
    public abstract class View<T, TJ> : ViewBase where T : ViewModel<TJ> where TJ : Model
    {
        protected CompositeDisposable Disposable = new();
        protected T ViewModel;
        protected bool IsInitialized;
        protected bool IsShown;

        public void Init(T viewModel)
        {
            if(IsInitialized) return;
            
            ViewModel = viewModel;
            IsInitialized = true;
        }

        public override void Show()
        {
            if (!IsInitialized) return;
            if (IsShown) return;

            IsShown = true;

            Subscribe();

            Debug.Log($"Initialize {GetType().Name} by view model: " + ViewModel.GetType().Name);

            ViewModel.OnViewShow();
        }

        public override void Hide()
        {
            if (!IsInitialized) return;
            if (!IsShown) return;

            IsShown = false;

            Unsubscribe();
            ViewModel.OnViewHide();
        }

        protected virtual void Subscribe()
        {
            Disposable = new CompositeDisposable();
        }

        protected virtual void Unsubscribe()
        {
            Disposable.Clear();
        }
    }
}
