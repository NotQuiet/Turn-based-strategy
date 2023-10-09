using DG.Tweening;
using UnityEngine;

namespace MVVM.Controllers
{
    public class PlayerUiController : MonoBehaviour
    {
        [SerializeField] private GameObject block;

        public void Activate()
        {
            transform.DOScale(Vector3.one, 0.5f);
            block.SetActive(false);
        }

        public void Deactivate()
        {
            block.SetActive(true);
            transform.DOScale(Vector3.one/2, 0.5f);
        }
    }
}