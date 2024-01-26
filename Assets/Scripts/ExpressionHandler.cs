using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExpressionHandler : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite sleepSprite;
    [SerializeField] private Sprite happySprite;

    [SerializeField] private GiantSoundManager soundManager;

    void Start()
    {
        SetExpression(Expression.SLEEP);
    }

    public void SetExpression(Expression expression)
    {
        switch (expression)
        {
            case Expression.SLEEP:
                _image.sprite = sleepSprite;
                // StartCoroutine(PlaySnoreSound());
                break;
            case Expression.HAPPY:
                _image.sprite = happySprite;
                PlayHappySound();
                break;
        }
    }

    // IEnumerator PlaySnoreSound()
    // {
    //     while (true)
    //     {
    //         // Play snore sound every 5 seconds
    //         soundManager.PlaySnoreLoop();
    //         yield return new WaitForSeconds(1f);
    //     }
    // }

    private void PlayHappySound()
    {
        soundManager.PlayHappySound();
    }

    public enum Expression
    {
        SLEEP = 0,
        HAPPY = 1
    }
}