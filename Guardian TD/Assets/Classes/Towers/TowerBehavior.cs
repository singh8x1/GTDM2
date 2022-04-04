using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// setting behaviour of tower yet to be decided
/// </summary>
public class TowerBehavior : MonoBehaviour
{

    public LayerMask EnemiesLayer;


    public Enemy Target;
    public Transform Crystal;

    public float Damage;
    public float Firerate;
    public float Range;


    private float Delay;

    // Start is called before the first frame update
    void Start()
    {
        Delay = 1 / Firerate;
    }

    public void Tick()
    {
        if(Target != null)
        {
            Crystal.transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position);
        }
    }
}
