using DG.Tweening;
using MVVM.ActiveUi.Model;
using MVVM.ActiveUi.ViewModel;
using MVVM.Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.ActiveUi.View
{
    public class ApplyBuffView : View<ApplyBuffViewModel, ApplyBuffModel>
    {
        [SerializeField] private Button applyBuffButton;

        protected override void Subscribe()
        {
            base.Subscribe();
            
            applyBuffButton.onClick.AddListener(OnApplyBuff);
            ViewModel.OnMaximumBuffs.Subscribe(_ => OnMaxBuffs()).AddTo(Disposable);
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();
            
            applyBuffButton.onClick.RemoveAllListeners();
        }
        
        private void OnApplyBuff()
        {
            ViewModel.OnApplyBuff();
        }

        private void OnMaxBuffs()
        {
            DOTween.Sequence()
                .Append(applyBuffButton.image.DOColor(Color.red, 0.1f))
                .Append(applyBuffButton.image.DOColor(Color.white, 0.1f));

            applyBuffButton.transform.DOShakeRotation(0.1f, new Vector3(0, 0, 10f), 10, 10f);
        }
    }
}