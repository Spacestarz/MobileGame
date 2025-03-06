using UnityEngine;
using DG.Tweening;

public class HighLight : MonoBehaviour
{
    public static HighLight Instance;
    private SpriteRenderer _spriteRenderer;
    private Tween _HighLightTween;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
       _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            Debug.Log("button cant find spriterenderer");
        }
    }


    public void HighLightMe()
    {
        _HighLightTween = _spriteRenderer.DOFade(1, 3).SetLoops(-1, LoopType.Yoyo);
    }

    public void DisableHighLight()
    {
        _HighLightTween.Kill();
        Color NOA = _spriteRenderer.color;
        NOA.a = 0;
        _spriteRenderer.color = NOA;
    }
}
