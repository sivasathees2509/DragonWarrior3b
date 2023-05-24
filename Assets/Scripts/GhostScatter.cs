using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScatter : GhostBehavior  // this script is to move the ghost in random direction
{

    private void OnDisable()
    {
        this.ghost.chase.Enable();  // when this script is disabled, then immediately chase scripts gets enabled
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled && !this.ghost.frightened.enabled)  // node available, sript enable, ghost not frightenend(if frightened enble it will override everything)
        {
            int index = Random.Range(0, node.availableDirections.Count); // random range from 0 to avadirctns

            if (node.availableDirections[index] == -this.ghost.movement.direction && node.availableDirections.Count > 1)  // if it goes in opposite direction and node direction is available
            {
                index++; //change it to next one

                if(index >= node.availableDirections.Count) // if index is greater than node direction count
                {
                    index = 0; // assign to 0
                }
            }

            this.ghost.movement.SetDirection(node.availableDirections[index]); // ghost movement to new direction
        }
    }
}
