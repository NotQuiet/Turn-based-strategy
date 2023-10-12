using System;
using System.Collections.Generic;
using System.Linq;
using Buffs;
using DG.Tweening;
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
        private List<Enums.Enums.BuffTitle> _titlesToRemove = new();

        // title - prefab
        private Dictionary<Enums.Enums.BuffTitle, BuffCell> _activeBuffs = new();

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

        private void OnGetBuff(BaseBuff config)
        {
            var cell = _buffPool.GetCell(_buffCellFactory, _grid);
            var buffUi = _uiBuffsData.buffsList.FirstOrDefault(d => d.title == config.title);
            cell.InitializeUi(buffUi, OnBuffEnd, config.lifeTime);
            
            ShowAnimation(cell.transform);
            
            _activeBuffs.Add(buffUi.title, cell);
        }
        
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

        private void OnBuffEnd(Enums.Enums.BuffTitle title)
        {
            _titlesToRemove.Add(title);
        }

        private void RemoveBuffs(Enums.Enums.BuffTitle title)
        {
            HideAnimation(_activeBuffs[title].transform);
            _activeBuffs.Remove(title);
            Model.BuffEnd(title);
        }

        private void SetPool()
        {
            _buffPool = new GenericPool<BuffCell>();
            _buffPool.SetPoolSize(5, _buffCellFactory);
        }

        private void ShowAnimation(Transform transform)
        {
            transform.localScale = Vector3.zero;
            
            DOTween.Sequence()
                .Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f))
                .Append(transform.DOScale(Vector3.one, 0.1f));

        }

        private void HideAnimation(Transform transform)
        {
            DOTween.Sequence()
                .Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f))
                .Append(transform.DOScale(Vector3.zero, 0.1f))
                .AppendCallback(() =>
                {
                    transform.gameObject.SetActive(false);
                });
        }
    }
}