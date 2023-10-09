using Factories;
using MVVM.ActiveUi.Model;
using MVVM.ActiveUi.ViewModel;
using MVVM.Core;
using ScriptableObjects;
using UnityEngine;

namespace MVVM.ActiveUi.View
{
    public class ActiveBuffsView : View<ActiveBuffsViewModel, ActiveBuffsModel>
    {
        [SerializeField] private BuffCellFactory buffCellFactory;
        [SerializeField] private Transform grid;
        [SerializeField] private BuffsUiDataSo buffsUiDataSo;
        
        
        public override void Show()
        {
            base.Show();
            
            ViewModel.SetTransformAndFactory(buffCellFactory, grid);
            ViewModel.SetBuffsUiSo(buffsUiDataSo);
        }
    }
}