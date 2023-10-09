using System;
using System.Collections.Generic;
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

        // title - prefab
        private Dictionary<string, BuffCell> _activeBuffs = new();

        protected override void Subscribe(Action onSubscribe)
        {
            base.Subscribe(() =>
            {
                Model.GetBuff.Subscribe(OnGetBuff).AddTo(Disposable);
                Model.OnRoundEnd.Subscribe(_ => OnRoundEnd()).AddTo(Disposable);
                Model.OnRestart.Subscribe(_ => OnRestart()).AddTo(Disposable);
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
            cell.InitializeUi(buffUi, OnBuffEnd, config.lifeTime);
            
            _activeBuffs.Add(buffUi.title, cell);
        }

        private List<string> _titlesToRemove = new();

        private void OnRestart()
        {
            _buffPool.SetActiveCellsToFalse();
            _activeBuffs.Clear();
        }
        
        private void OnRoundEnd()
        {
            _titlesToRemove = new();
            
            foreach (var buff in _activeBuffs)
            {
                buff.Value.OnRoundEnd();
            }

            foreach (var title in _titlesToRemove)
            {
                RemoveBuffs(title);
            }
        }

        private void OnBuffEnd(string title)
        {
            _titlesToRemove.Add(title);
        }

        private void RemoveBuffs(string title)
        {
            _activeBuffs[title].gameObject.SetActive(false);
            _activeBuffs.Remove(title);
            Model.BuffEnd(title);
        }

        private void SetPool()
        {
            _buffPool = new GenericPool<BuffCell>();
            _buffPool.SetPoolSize(5, _buffCellFactory);
        }
    }
}