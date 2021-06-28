using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward2D : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.right * GameParameters.inst.StageSpeed * Time.deltaTime);
    }
}
