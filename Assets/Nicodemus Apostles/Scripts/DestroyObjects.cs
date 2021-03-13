using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Just destroys stuff that touches this object.
public class DestroyObjects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
