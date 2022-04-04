using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleDamage : MonoBehaviour, IDamageMethod
{
     public LayerMask EnemiesLayer;
    [SerializeField] private ParticleSystem MissleSystem;
    [SerializeField] private Transform TowerHead;
    
    private ParticleSystem.MainModule MissleSystemMain;
    public float Damage;
    private float Firerate;
    private float Delay;

    public void Init(float Damage, float Firerate)
    {
        MissleSystemMain = MissleSystem.main;

        this.Damage = Damage;
        this.Firerate = Firerate;
        Delay = 1f / Firerate;
    }
    public void DamageTick(Enemy Target)
    {
        if (Target)
        {
            if (Delay > 0f)
            {
                Delay -= Time.deltaTime;
                return;
            }

            MissleSystemMain.startRotationX = TowerHead.forward.x;
            MissleSystemMain.startRotationY = TowerHead.forward.y;
            MissleSystemMain.startRotationZ = TowerHead.forward.z;


            MissleSystem.Play();
            Delay = 1f / Firerate;
        }

    }
}
