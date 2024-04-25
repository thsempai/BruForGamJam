using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorSwap : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float timeBetweenColor = 1f;
    [SerializeField] private Color[] colors = {Color.red, Color.green, Color.blue};
    private int index = 0;
    private Material material;
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if(renderer == null){
            Debug.LogError($"{name} as no render component.", gameObject);
        }

        material = renderer.material;
        StartCoroutine(Swaping());

        
    }

    private void SetColor(Color color){
        material.SetColor("_BaseColor",color);
        material.SetColor("_EmissionColor",color);
    }

    IEnumerator Swaping(){
        
        while(true){
            Color start = colors[index];
            index++;
            index = index == colors.Length ? 0 : index;
            Color end = colors[index];

            float time = 0f;

            while(time <= timeBetweenColor){
                Color color = Color.Lerp(start, end, time/timeBetweenColor);
                time += Time.deltaTime;
                SetColor(color);
                yield return null;
            }
        }
    }



}
