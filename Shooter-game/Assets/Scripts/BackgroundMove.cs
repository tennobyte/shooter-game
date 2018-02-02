using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMove : MonoBehaviour {
    
    public float layerOneSpeed;
    public float layerTwoSpeed;
    public float layerThreeSpeed;

    public RawImage layerOne;
    public RawImage layerTwo;
    public RawImage layerThree;

    // Update is called once per frame
    void Update () {
        //layerOne.uvRect.Set(layerOne.uvRect.x, layerOne.uvRect.y + Time.deltaTime*layerOneSpeed, 1,1);
        //Vector2 offset = new Vector2(0, Time.time * layerOneSpeed);
        layerOne.uvRect = new Rect(layerOne.uvRect.x, layerOne.uvRect.y + Time.deltaTime * layerOneSpeed, 1, 1);
        layerTwo.uvRect = new Rect(layerTwo.uvRect.x, layerTwo.uvRect.y + Time.deltaTime * layerTwoSpeed, 1, 1);
        layerThree.uvRect = new Rect(layerThree.uvRect.x, layerThree.uvRect.y + Time.deltaTime * layerThreeSpeed, 1, 1);
        //layerOne.material.mainTextureOffset = offset;
        //Debug.Log(Time.time);

    }
}
