using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpressionHandler : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite sleepSprite;
    [SerializeField] private Sprite happySprite;
    [SerializeField] private Sprite angrySprite;
    
    // Start is called before the first frame update
    void Start()
    {
        SetExpression(Expression.SLEEP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetExpression(Expression expression)
    {
        switch (expression)
        {
            case Expression.SLEEP:
                _image.sprite = sleepSprite;
                break;
            case Expression.HAPPY:
                _image.sprite = happySprite;
                break;
            case Expression.ANGRY:
                _image.sprite = angrySprite;
                break;
        }
    }

    public enum Expression
    {
        SLEEP = 0,
        HAPPY = 1,
        ANGRY = 2
    }
}
