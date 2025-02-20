
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;
using UnityEngine.Rendering;

public class NavD
{
    public static bool Generate(NavNode start, NavNode end, ref List<NavNode> path)
    {
        var nodes = new SimplePriorityQueue<NavNode>();
         
        start.Cost = 0;
        float h = (start.transform.position - end.transform.position).magnitude;
        nodes.EnqueueWithoutDuplicates(start, start.Cost + h);

        bool found = false;
        while(!found && nodes.Count > 0)
        {
            var currentNode = nodes.Dequeue();
            if ((currentNode == end))
            {
                found = true;
                break;
            }
            foreach (var neighbor in currentNode.neighbors)
            {
                float cost = currentNode.Cost + (currentNode.transform.position - 
                    neighbor.transform.position).magnitude;
                if (cost < neighbor.Cost)
                {
                    neighbor.Cost = cost;
                    neighbor.Previous = currentNode;
                    h = (neighbor.transform.position - end.transform.position).magnitude;
                    nodes.EnqueueWithoutDuplicates(neighbor, cost + h);
                }
            }
        }
        if (found)
        {
            NavNode.CreatePath(end, ref path);
        }

        return found;
    }
}
