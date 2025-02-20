using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPerception : Perception
{
    [SerializeField] int numRaycast = 2;
    public override GameObject[] GetGameObjects()
    {
        List<GameObject> objects = new List<GameObject>();

        /*Vector3[] directions = Utilities.GetDirectionInCircle(numRaycast, maxAngle);
        foreach (Vector3 direction in directions)
        {
            Ray ray = new Ray(transform.position, transform.rotation * direction);
            if(Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
        
                if (hit.collider.gameObject == gameObject) continue;
                if(tagName != "" && !hit.collider.CompareTag(tagName))
                {

                }
                
            }
        }*/

        return objects.ToArray();
    }
    //public override bool GetOpenDirection(ref Vector3 openDirection)
    //{
    //    Vector3[] directions = Utilities.GetDirectionsInCircle
    //}
}
