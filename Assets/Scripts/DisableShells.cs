using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableShells : MonoBehaviour {

    private void Awake()
    {
        if (!GameMGMT.gameManager.GetShellRequirements())
        {
            print("shells not allowed");
            GameObject.Find("countText").SetActive(false);
            GameObject.Find("shellIcon").SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
