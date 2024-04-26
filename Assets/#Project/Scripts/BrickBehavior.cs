using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickBehavior : ColorChanger
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 startOffset = Vector3.up * 10;
    override protected void Start()
    {
        base.Start();
        GetComponent<Renderer>().enabled = false;
    }

    public void GotoFinalPosition(float time){
        StartCoroutine(_GotoFinalPosition(time));
    }
    // Update is called once per frame
    IEnumerator _GotoFinalPosition(float time){
        yield return null;
        GetComponent<Renderer>().enabled = true;
        Vector3 startPosition = transform.localPosition + startOffset;
        Vector3 finalPosition = transform.localPosition;
        float t = 0f;
        while (t < time){
            transform.localPosition = Vector3.Lerp(startPosition, finalPosition, t/time);
            t += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = finalPosition;
    }
}
