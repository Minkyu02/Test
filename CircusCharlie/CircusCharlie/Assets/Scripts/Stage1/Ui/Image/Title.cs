using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    private Image titleImage = null;
    bool isFade = false;
    private Color tempColor = default;
    // Start is called before the first frame update
    void Start()
    {
        titleImage = GetComponent<Image>();
        tempColor = titleImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFade) {
            StartCoroutine(FadeTitle());
        }
    }


    IEnumerator FadeTitle()
    {
        yield return new WaitForSeconds(0.5f);
        isFade = true;
        tempColor.a = 0f;
        titleImage.color = tempColor;
        yield return new WaitForSeconds(0.5f);
        isFade = false;
        tempColor.a = 1f;
        titleImage.color = tempColor;

    }
}
