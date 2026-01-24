using UnityEngine;

public class FloorFollower : BaseFloorAction
{
    [SerializeField] private Vector3 _scaleDirection; 

    protected override void Update()
    {
       
    }
    public void UpdateScaleProgress(float progress)
    {
        transform.localScale = Vector3.Lerp(_initialScale, _scaleDirection, progress);
    }
 
}
