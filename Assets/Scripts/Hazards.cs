using UnityEngine;
using System.Collections;

public class Hazards : InteractiveObjects
{
/* In this class, I want to:
-handle collision with the player
-handle collision with the instantiated waves
-destroy itself on contact

This will eventually inherit from a general class called "Interactables"
 */

    private Player player;

    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        base.OnCollisionEnter2D(coll);
        player = coll.gameObject.GetComponent<Player>();
        player.KnockedOff();
    }


}
