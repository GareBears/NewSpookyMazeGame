using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSave : MonoBehaviour
{
    public void Awale()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
