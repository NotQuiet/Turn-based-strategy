using System.Collections.Generic;
using UnityEngine;

namespace MVVM.Core
{
    public class MvvmStarter : MonoBehaviour
    {
        [SerializeField] protected List<ViewBase> views;
        [SerializeField] protected List<ViewBase> viewsToShowOnStart;
        
        private bool _isInitialized;

        public void InitializeStarter(bool needToShowViews = true)
        {
            if (_isInitialized) return;

            CreateControllers();
            CreateMvvm();
            
            if(needToShowViews)
                ShowViews();

            _isInitialized = true;
        }

        public void DisposeStarter()
        {
            _isInitialized = false;
        }
        
        protected virtual void CreateControllers()
        {
            
        }
        
        protected virtual void ShowViews()
        {
            foreach (var view in viewsToShowOnStart)
            {
                view.Show();
            }
        }

        protected virtual void HideViews()
        {
            foreach (var view in views)
            {
                view.Hide();
            }
        }
        
        protected virtual void CreateMvvm()
        {
            
        }
    }
}