using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirismStatusBar : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;

    private Coroutine _currentCoroutine;
    private Slider _statusBar;

    private void Awake()
    {
        _statusBar = GetComponent<Slider>();
        _statusBar.value = 1;
    }

    private void OnEnable()
    {
        _vampirism.VampirismActivated += UpdateStatusBar;
    }

    private void OnDisable()
    {
        _vampirism.VampirismActivated += UpdateStatusBar;
    }

    private void UpdateStatusBar()
    {
        _currentCoroutine = StartCoroutine(SmoothDurationRoutine());
    }

    private IEnumerator SmoothDurationRoutine()
    {
        float startValue = _statusBar.value;
        float targetValue = 0f;
        float timePassed = 0f;

        while (timePassed < _vampirism.Duration)
        {
            timePassed += Time.deltaTime;
            _statusBar.value = Mathf.MoveTowards(startValue, targetValue, timePassed / _vampirism.Duration);

            yield return null;
        }

        _statusBar.value = targetValue;
        StartCoroutine(SmoothCooldownRestoration());

        _currentCoroutine = null;
    }

    private IEnumerator SmoothCooldownRestoration()
    {
        float startValue = _statusBar.value;
        float targetValue = 1f;
        float timePassed = 0f;

        while (timePassed < _vampirism.Duration)
        {
            timePassed += Time.deltaTime;
            _statusBar.value = Mathf.MoveTowards(startValue, targetValue, timePassed / _vampirism.Cooldown);

            yield return null;
        }

        _statusBar.value = targetValue;
        _currentCoroutine = null;
    }
}
