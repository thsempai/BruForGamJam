using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConstructWalls : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float appartitionRate = 0.8f;
    [SerializeField] float constractionTime = 2f;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        BrickBehavior[] bricks = GetComponentsInChildren<BrickBehavior>();
        float distanceMax = 0f;
        for (int index = 0; index < bricks.Length; index++)
        {
            distanceMax = Mathf.Max(
                distanceMax,
                Vector3.Distance(
                    player.transform.position, bricks[index].transform.position));
        }

        for (int index = 0; index < bricks.Length; index++)
        {
            if(Random.Range(0f, 1f) > appartitionRate){
                Destroy(bricks[index].gameObject);
                continue;
            }

            float time = 1 - Vector3.Distance(
                player.transform.position, bricks[index].transform.position) / distanceMax;
            time *= constractionTime;
            bricks[index].GotoFinalPosition(time);
        }
    }
}
