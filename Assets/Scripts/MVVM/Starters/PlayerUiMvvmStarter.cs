using System.Collections.Generic;
using MVVM.ActiveUi.Model;
using MVVM.ActiveUi.View;
using MVVM.ActiveUi.ViewModel;
using MVVM.Controllers;
using MVVM.Core;
using ScriptableObjects;
using UnityEngine;

namespace MVVM.Starters
{
    public class PlayerUiMvvmStarter : MvvmStarter
    {
        [SerializeField] private PlayerDataConfigurationSo dataSo;
        [SerializeField] private BuffsConfigDataSo buffsSo;
        
        private PlayerConfigController _configController;
        private ActiveBuffsController _buffsController;

        private List<ModelsController> _controllers;

        protected override void CreateControllers()
        {
            _configController = new PlayerConfigController(dataSo);
            _buffsController = new ActiveBuffsController(buffsSo);
            
            _controllers = new List<ModelsController>
            {
                _configController
            };
        }

        protected override void CreateMvvm()
        {
            ViewModelBase diVm = null;

            foreach (var view in views)
            {
                if (view is HealthBarView healthBarView)
                {
                    var model = new SliderBarBaseModel(_configController);
                    var viewModel = new SliderBarBaseViewModel(model);

                    diVm = viewModel;

                    healthBarView.Init(viewModel);
                }
                
                if (view is ArmorBarView armorBarView)
                {
                    armorBarView.Init((SliderBarBaseViewModel)diVm);
                }
                
                if (view is VampirismBarView vampirismBarView)
                {
                    vampirismBarView.Init((SliderBarBaseViewModel)diVm);
                }
                if (view is DamageBarView damageBarView)
                {
                    damageBarView.Init((SliderBarBaseViewModel)diVm);
                }
                
                if (view is AttackView attackView)
                {
                    var model = new AttackModel();
                    var viewModel = new AttackViewModel(model);
                    
                    attackView.Init(viewModel);
                }
                
                if (view is ApplyBuffView applyBuffView)
                {
                    var model = new ApplyBuffModel(_buffsController);
                    var viewModel = new ApplyBuffViewModel(model);
                    
                    applyBuffView.Init(viewModel);
                }
                
                if (view is ActiveBuffsView activeBuffsView)
                {
                    var model = new ActiveBuffsModel(_buffsController);
                    var viewModel = new ActiveBuffsViewModel(model);
                    
                    activeBuffsView.Init(viewModel);
                }
                
            }
        }

        protected override void ShowViews()
        {
            base.ShowViews();
            
            
            foreach (var controller in _controllers)
            {
                controller.OnInitialize();
            }
        }
    }
}