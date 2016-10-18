using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public sealed class UIManager : MonoBehaviour {

    private static UIManager instance;

    public static UIManager self
    {
        get
        {
            if (instance == null)
                instance = new UIManager();
            return instance;
        }
    }

    [SerializeField]
    private Canvas UICanvas;

    // Use this for initialization
    void Start ()
    {
        if (UICanvas == null)
            UICanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

}
