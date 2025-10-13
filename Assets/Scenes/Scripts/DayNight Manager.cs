using System;
using UnityEngine;

namespace DayNight
{
    [ExecuteInEditMode]
    public class DayNightSystem_ProperSky : MonoBehaviour
    {
        [SerializeField] Gradient directionalLightGradient;
        [SerializeField] Gradient ambientLightGradient;
    
        [SerializeField, Range(1,3600)] float timeOfDayInSeconds = 60;
        [SerializeField, Range(0, 1f)] float timeProgress;
    
        [SerializeField] Light dirLight;

        private Vector3 defoultAngles;

        private void Start() => defoultAngles = dirLight.transform.localEulerAngles;

        private void Update()
        {
            if (Application.isPlaying)
                timeProgress += Time.deltaTime / timeOfDayInSeconds;
            
            if (timeProgress > 1)
                timeProgress = 0f;
        
            dirLight.color = directionalLightGradient.Evaluate(timeProgress);
            RenderSettings.ambientLight = ambientLightGradient.Evaluate(timeProgress);
        
            dirLight.transform.localEulerAngles = new Vector3(360f * timeProgress - 90, defoultAngles.x, defoultAngles.z);
        }
    }

}
