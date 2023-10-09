using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.Controllers
{
    public class PlayerUiController : MonoBehaviour
    {
        [SerializeField] private Image block;

        public void Activate()
        {
           transform.DOScale(Vector3.one, 0.5f);
           DOTween.Sequence()
               .Append(block.DOFade(0, 0.5f))
               .AppendCallback(() => block.gameObject.SetActive(false));
        }

        public void Deactivate()
        {
            block.gameObject.SetActive(true);
            block.DOFade(0.6f, 0.5f);
            transform.DOScale(Vector3.one/2, 0.5f);
        }
    }
}