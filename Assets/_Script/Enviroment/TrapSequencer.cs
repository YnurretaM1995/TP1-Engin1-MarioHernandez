using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrapSequencer : MonoBehaviour
{
    [SerializeField] private  List<FloorControl> floorScripts; 
    [SerializeField] private  float delayBetweenTraps = 0.3f;
    private bool _hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player") && !_hasTriggered)
        {
            _hasTriggered = true;
            StartCoroutine(StartSequence());
        }
    }

    IEnumerator StartSequence()
    {
        foreach (FloorControl floor in floorScripts)
        {
            if (floor != null)
                floor.FloorCollision();
            
            yield return new WaitForSeconds(delayBetweenTraps);
        }
    }
}