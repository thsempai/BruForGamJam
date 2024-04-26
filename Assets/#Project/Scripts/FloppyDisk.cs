using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChanger: MonoBehaviour{

    [HideInInspector] public LevelManager manager;
    public Color color;
     virtual protected void Start()
    {
        color = manager.AskColor();
        SetColor(color);
    }

    protected void SetColor(Color color){
        foreach(Renderer renderer in GetComponentsInChildren<Renderer>()){
            renderer.material.SetColor("_EmissionColor", color);
            renderer.material.SetColor("_BaseColor", color);
        }
    }
}
public class FloppyDisk : ColorChanger
{
    [SerializeField] float speed = 1f;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        StartCoroutine(Rotation());
    }

    IEnumerator Rotation(){
        Quaternion end = Quaternion.Euler(new(0f, 359f, 0f));
        while (true){
            float angle = speed * Time.deltaTime;
            transform.Rotate(0f, angle, 0f);
            yield return null;
        }
    }
}
