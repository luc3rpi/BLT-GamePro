using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


public class WordBankOptions : MonoBehaviour, IPointerUpHandler
{
    public string str;
    public string str2;
    public bool found;
    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.clickCount == 1)
        {
            if (!found)
            GameObject.FindGameObjectWithTag("Bank").GetComponent<WordBank>().AddString(str);
            else
            GameObject.FindGameObjectWithTag("Bank").GetComponent<WordBank>().AddString(str2);

        }
    }
    private void Update()
    {
        if (!found)
        GetComponentInChildren<Text>().text = str;
        else
        GetComponentInChildren<Text>().text = str2;
    }

}
