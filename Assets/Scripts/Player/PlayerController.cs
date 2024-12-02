using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement m_Movement;

    void Update()
    {
        float dirX = 0;
        float dirY = 0;

        if (Keyboard.current.aKey.isPressed)
        {
            dirX = -1;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            dirX = 1;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            dirY = 1;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            dirY = -1;
        }

        m_Movement.Move(dirX, dirY);
    }
}
