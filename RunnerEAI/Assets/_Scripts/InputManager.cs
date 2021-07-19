using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 direction;

    [SerializeField]
    private Transform playerTransform;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    startPos = _touch.position;
                    break;
                case TouchPhase.Moved:
                    direction = _touch.position.normalized - startPos.normalized;
                    if (direction.x > 0)
                    {
                        // vector3 eklemesi yap ve playerın x pozisyonunu bir **SAĞ**lane e geçecek kadar değiştir
                    }
                    else
                    {
                        // vector3 eklemesi yap ve playerın x pozisyonunu bir **SOL** lane e geçecek kadar değiştir
                    }
                    break;
            }
        }
    }
}
