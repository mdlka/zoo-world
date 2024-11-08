using System.Collections;
using UnityEngine;

namespace ZooWorld
{
    public sealed class Predator : Animal
    {
        [SerializeField] private CanvasGroup _label;

        private Coroutine _coroutine;
        private AnimalSettings _settings;
        
        protected override void OnInitialize(AnimalSettings settings)
        {
            _settings = settings;
            _label.alpha = 0f;
        }

        public void ShowTasty()
        {
            if (gameObject.activeSelf == false)
                return;
            
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ShowingLabel());
        }

        private IEnumerator ShowingLabel()
        {
            _label.alpha = 1f;

            yield return new WaitForSeconds(_settings.LabelShowDurationInSeconds);

            _label.alpha = 0f;
        }
    }
}