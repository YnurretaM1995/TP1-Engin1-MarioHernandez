using System;
using UnityEngine;

public class FloorControl : MonoBehaviour
{
    [SerializeField] private Vector3 _Translation;
    private void OnCollisionEnter(Collision other)
   {
       transform.Translate(_Translation);
   }
}
