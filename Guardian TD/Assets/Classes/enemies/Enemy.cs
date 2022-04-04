using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    public int NodeIndex;
    /** \Max health of enemies in float */
    public float MaxHealth;
    /** \health of enemies in float at an instance*/
    public float Health;
    /** \speed of enemies movement in float */
    public float Speed;
    /** \ enemies ID */
    public int ID;

    public int level;

    /// <summary>
    /// initializes the healthpool of enemies to max health of enemies
    /// </summary>
    public void Init()
    {
        
        Health = MaxHealth*level;
        transform.position = GameloopManager.NodePositions[0];
        NodeIndex = 0;

    }
}
