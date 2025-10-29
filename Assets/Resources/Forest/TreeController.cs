using System.Collections;
using System;
using UnityEngine;


public class TreeHitCheck : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("AttackCount", 1f);
       
    }

    private void LateUpdate()
    {
        float a = _animator.GetFloat("AttackCount");
        if (a >= 4)
        {

            a = Mathf.MoveTowards(a, 4f, Time.deltaTime);
            _animator.SetFloat("AttackCount", a);
            
        }
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyedTree"))
        {
            float current = _animator.GetFloat("AttackCount");
            _animator.SetFloat("AttackCount", current + 1f);
            
            float a = _animator.GetFloat("AttackCount");
            Debug.Log("AttackCount = " + a);
            StartCoroutine(Attack());
            
            
        }
    }

    IEnumerator Attack()
    {
        _animator.SetTrigger("IsAtacked");
        yield return new WaitForSeconds(1f);
        _animator.ResetTrigger("IsAtacked");
    }
}

