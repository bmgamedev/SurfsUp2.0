using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class DifficultyTexts : MonoBehaviour, ISelectHandler// required interface when using the OnSelect method.
{
    public void OnSelect(BaseEventData eventData)
    {
        print(this.gameObject.name + " was selected");
    }
}
