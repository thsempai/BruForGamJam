using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Color[] colors = {Color.red, Color.green, Color.blue};
    // Start is called before the first frame update

    private List<BrickBehavior> bricks;
    void Awake()
    {
        foreach(ColorChanger colorChanger in FindObjectsOfType<ColorChanger>()){
            colorChanger.manager =  this;
            if(colorChanger.GetType() == typeof(BrickBehavior)){
                bricks.Add((BrickBehavior)colorChanger);
            }
        }

        foreach(BrickBehavior brick in FindObjectsOfType<BrickBehavior>()){
        }
    }

    // Update is called once per frame
    public Color AskColor(){
        int index = Random.Range(0, colors.Length);
        return colors[index];
    }
}
