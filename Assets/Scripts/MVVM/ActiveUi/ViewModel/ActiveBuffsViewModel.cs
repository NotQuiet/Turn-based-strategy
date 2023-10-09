using System;
using System.Linq;
using DTO.Configurations;
using Factories;
using MVVM.ActiveUi.Model;
using MVVM.Core;
using Pools.Core;
using ScriptableObjects;
using UiCells.Buffs;
using UniRx;
using UnityEngine;

namespace MVVM.ActiveUi.ViewModel
{
    public class ActiveBuffsViewModel : ViewModel<ActiveBuffsModel>
    {
        public ActiveBuffsViewModel(ActiveBuffsModel model) : base(model)
        {
        }

        private BuffsUiDataSo _uiBuffsData;
        private BuffCellFactory _buffCellFactory;
        private Transform _grid;

        private GenericPool<BuffCell> _buffPool;

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                Model.GetBuff.Subscribe(OnGetBuff).AddTo(Disposable);
            });
        }

        public void SetTransformAndFactory(BuffCellFactory factory, Transform grid)
        {
            _buffCellFactory = factory;
            _grid = grid;
            
            SetPool();
        }
        public void SetBuffsUiSo(BuffsUiDataSo uiBuffs)
        {
            _uiBuffsData = uiBuffs;
        }

        private void OnGetBuff(BuffConfigDto config)
        {
            var cell = _buffPool.GetCell(_buffCellFactory, _grid);

            var buffUi = _uiBuffsData.buffsList.FirstOrDefault(d => d.title == config.title);
            cell.InitializeUi(buffUi);
        }

        private void SetPool()
        {
            _buffPool = new GenericPool<BuffCell>();
            _buffPool.SetPoolSize(5, _buffCellFactory);
        }
    }
}