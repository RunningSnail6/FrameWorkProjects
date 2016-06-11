using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteFactory : MonoBehaviour {

    public object[] allSprite;

	// Use this for initialization
	void Start () {
        allSprite = Resources.LoadAll("Number");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
