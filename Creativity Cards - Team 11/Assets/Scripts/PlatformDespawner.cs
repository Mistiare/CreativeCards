using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDespawner : MonoBehaviour
{
    private LayerMask platformMask = 8;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == platformMask.value)
        {
            Destroy(col.gameObject);
        }
    }
}
