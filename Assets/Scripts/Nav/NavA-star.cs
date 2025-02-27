
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;
using UnityEngine.Rendering;

public class NavAStar
{
    public static bool Generate(NavNode start, NavNode end, ref List<NavNode> path)
    {
        var nodes = new SimplePriorityQueue<NavNode>();
         
        start.Cost = 0;
        nodes.Enqueue(start, start.Cost);

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

                    nodes.Enqueue(neighbor, cost);
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
