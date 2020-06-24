using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObject : MonoBehaviour
{
    [SerializeField] GameObject target;

    public void DisableTarget()
    {
        target.SetActive(false);
    }
}
