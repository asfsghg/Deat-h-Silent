using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Damagable : MonoBehaviour
{
    public interface IDamagable
    {
        public void TakeDamage(int damage);
        public void Heal(int heal);
        public int GetHealth();
    }
    
}
