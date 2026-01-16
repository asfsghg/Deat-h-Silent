using System.Collections;
using UnityEngine;

public class TreeHitCheck : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject treeLogPrefab; 
    [SerializeField] private Transform spawnPoint;  
    [SerializeField] private int hitsToDestroy = 4;  

    private ParticleSystem _particle;
    private Animator _animator;
    private int _currentHits = 0;
    private bool _isFalling = false;

    private void Awake()
    {
        _particle = GetComponentInChildren<ParticleSystem>();
        if (_particle != null) _particle.Stop();
        
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (_isFalling) return;

        if (other.CompareTag("Axe"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnHit();
            }
        }
    }

    private void OnHit()
    {
        _currentHits++;
        

        StopCoroutine("PlayHitEffects");
        StartCoroutine(PlayHitEffects());

        Debug.Log($"Удар по дереву! Всего ударов: {_currentHits}");

        if (_currentHits >= hitsToDestroy)
        {
            StartFalling();
        }
    }

    private void StartFalling()
    {
        _isFalling = true;

        StartCoroutine(FallingTreeRoutine());
    }

    IEnumerator PlayHitEffects()
    {
        _animator.SetTrigger("IsAtacked");
        if (_particle != null) _particle.Play();

        yield return new WaitForSeconds(1f);

        if (_particle != null) _particle.Stop();
        _animator.ResetTrigger("IsAtacked");
    }

    IEnumerator FallingTreeRoutine()
    {

        yield return new WaitForSeconds(2f); 

        if (treeLogPrefab != null)
        {
            Instantiate(treeLogPrefab, spawnPoint.position, spawnPoint.rotation);
        }

        Destroy(gameObject);
    }
}
