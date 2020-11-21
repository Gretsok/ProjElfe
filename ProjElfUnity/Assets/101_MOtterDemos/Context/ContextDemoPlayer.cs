using MOtter;
using MOtter.Context;
using UnityEngine;

public class ContextDemoPlayer : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);
        RaycastHit hitInfo;
        MOtterApplication.GetInstance().CONTEXT.GetContext<BooleanContext>("detectingGround").Value = false;

        if (Physics.Raycast(ray, out hitInfo, 10f))
        {
            ContextDemoZone zone = null;
            if(hitInfo.collider.TryGetComponent<ContextDemoZone>(out zone))
            {
                MOtterApplication.GetInstance().CONTEXT.GetContext<StatedContext>("zoneTile").Value = zone.zoneNameHash;
                MOtterApplication.GetInstance().CONTEXT.GetContext<BooleanContext>("detectingGround").Value = true;
                
            }
            
        }
    }
}
