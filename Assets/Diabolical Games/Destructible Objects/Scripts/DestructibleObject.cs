using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace DiabolicalGames
{
    public class DestructibleObject : MonoBehaviour
    {
        enum DebrisAmount { Low, Medium, High, Random }
        enum DespawnType { None, Timed, DistanceFromPlayer }

        [System.Serializable]
        struct DebrisPrefab
        {
            public string name;
            public GameObject prefab;
        }

        [Header("Debris")]
        [SerializeField] private List<DebrisPrefab> debrisPrefabs = new List<DebrisPrefab>();
        [SerializeField] private DebrisAmount debrisAmount = new DebrisAmount();
        [SerializeField] private float forceRequired;

        [Header("Despawning")]
        [SerializeField] private DespawnType despawnType = new DespawnType();
        [SerializeField, Range(0, 100)] private int despawnPercentage;
        [SerializeField] private float despawnTime;
        [SerializeField] private GameObject player;
        [SerializeField] private float distanceFromPlayer;

        [Header("Audio")]
        [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
        [SerializeField, Range(0f, 1f)] private float volume = 1f;
        [SerializeField, Range(0f, 0.2f)] private float volumeVariation = 0.1f;
        [SerializeField, Range(0f, 0.5f)] private float pitchVariation = 0.3f;

        [Header("Click Break Settings")]
        [SerializeField] private int clicksToBreak = 7;
        [SerializeField] private GameObject healthBarPrefab;
        [SerializeField] private Vector3 healthBarOffset = new Vector3(0, 2f, 0);

        private int currentClicks = 0;
        private GameObject debris;
        private new Rigidbody rigidbody;
        private GameObject healthBarObj;
        private Image healthFill;
        private Camera mainCam;

       
        void Start()
        {
            mainCam = Camera.main;
            rigidbody = GetComponent<Rigidbody>();

           
            switch (debrisAmount)
            {
                case DebrisAmount.Low:
                    debris = Instantiate(debrisPrefabs[0].prefab, transform.position, Quaternion.identity);
                    break;
                case DebrisAmount.Medium:
                    debris = Instantiate(debrisPrefabs[1].prefab, transform.position, Quaternion.identity);
                    break;
                case DebrisAmount.High:
                    debris = Instantiate(debrisPrefabs[2].prefab, transform.position, Quaternion.identity);
                    break;
                case DebrisAmount.Random:
                    debris = Instantiate(debrisPrefabs[Random.Range(0, 3)].prefab, transform.position, Quaternion.identity);
                    break;
                default:
                    debris = Instantiate(debrisPrefabs[0].prefab, transform.position, Quaternion.identity);
                    break;
            }
            debris.SetActive(false);
        }

        void Update()
        {
            if (healthBarObj != null)
            {
                healthBarObj.transform.position = transform.position + healthBarOffset;
                healthBarObj.transform.LookAt(mainCam.transform);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.relativeVelocity.magnitude > forceRequired)
            {
                Break();
            }
        }

       
        private void OnMouseDown()
        {
           
            if (healthBarObj == null && healthBarPrefab != null)
            {
                healthBarObj = Instantiate(healthBarPrefab, transform.position + healthBarOffset, Quaternion.identity);
                healthFill = healthBarObj.GetComponentInChildren<Image>();
            }

            currentClicks++;

            if (healthFill != null)
            {
                float fill = 1f - (float)currentClicks / clicksToBreak;
                healthFill.fillAmount = Mathf.Clamp01(fill);
            }

            
            if (currentClicks >= clicksToBreak)
            {
                if (healthBarObj != null)
                    Destroy(healthBarObj);

                Break();
            }
        }

       
        public void Break()
        {
            float velocityMagnitude = rigidbody.velocity.magnitude;

            debris.transform.position = transform.position;
            debris.transform.rotation = transform.rotation;
            debris.transform.localScale = transform.localScale;
            debris.SetActive(true);

            for (int i = 0; i < debris.transform.childCount; i++)
            {
                Rigidbody debrisRigidbody = debris.transform.GetChild(i).GetComponent<Rigidbody>();
                Vector3 randomise = new Vector3(
                    Random.Range(0f, velocityMagnitude),
                    Random.Range(0f, velocityMagnitude),
                    Random.Range(0f, velocityMagnitude)
                ) / 2;
                debrisRigidbody.velocity = rigidbody.velocity + randomise;
            }

            debris.GetComponent<Despawn>().SetVariables(
                despawnPercentage, despawnTime, distanceFromPlayer, player,
                audioClips[Random.Range(0, audioClips.Count)], volume, volumeVariation, pitchVariation
            );

            switch (despawnType)
            {
                case DespawnType.Timed:
                    debris.GetComponent<Despawn>().BeginCoroutine("Timed");
                    break;
                case DespawnType.DistanceFromPlayer:
                    debris.GetComponent<Despawn>().BeginCoroutine("Distance from Player");
                    break;
            }

            Destroy(gameObject);
        }
    }
}