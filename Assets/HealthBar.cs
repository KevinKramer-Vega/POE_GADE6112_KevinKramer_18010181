using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image foreGroundImage;
    [SerializeField]
    private float updateSpeedSeconds = 0.5f;

    private void Awake()
    {
        GetComponentInParent<Health>().OnHealthPctChanged += HandleHealthChanged;
    }
    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }
    private IEnumerator ChangeToPct(float pct)
    {
        float preChacngePct = foreGroundImage.fillAmount;
        float elapsed = 0f;

        while(elapsed<updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foreGroundImage.fillAmount = Mathf.Lerp(preChacngePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }
        foreGroundImage.fillAmount = pct;
    }
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
