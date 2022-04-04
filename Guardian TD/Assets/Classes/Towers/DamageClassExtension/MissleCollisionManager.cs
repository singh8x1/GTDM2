using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleCollisionManager : MonoBehaviour
{
    [SerializeField] private MissleDamage BaseClass;
    [SerializeField] private ParticleSystem ExplosionSystem;
    [SerializeField] private ParticleSystem MissleSystem;
    [SerializeField] private float ExplosionRadius;
    private List<ParticleCollisionEvent> MissleCollisions;
    private void Start()
    {
        MissleCollisions = new List<ParticleCollisionEvent>();
    }
   private void OnParticleCollision(GameObject other)
    {
        MissleSystem.GetCollisionEvents(other, MissleCollisions);

        for(int collisionevent =0; collisionevent<MissleCollisions.Count; collisionevent++)
        {
            ExplosionSystem.transform.position = MissleCollisions[collisionevent].intersection;
            ExplosionSystem.Play();

            Collider[] EnemiesInRadius = Physics.OverlapSphere(MissleCollisions[collisionevent].intersection,ExplosionRadius, BaseClass.EnemiesLayer);
            
            for(int i = 0; i < EnemiesInRadius.Length; i++)
            {
                Enemy EnemyToDamage = Entitysummoner.EnemyTransformPairs[EnemiesInRadius[i].transform.parent];
                EnemyDamageData DamageToApply = new EnemyDamageData(EnemyToDamage, BaseClass.Damage, EnemyToDamage.DamageResistance);
                GameloopManager.EnqueueDamageData(DamageToApply);
            
            }
        
        }
    }
}
