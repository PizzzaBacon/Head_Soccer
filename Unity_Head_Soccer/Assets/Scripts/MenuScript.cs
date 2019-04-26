using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject panelLoading, panelTransit;
    public Image loadingImage;
    public static bool isLoading;
    public Text loadingText;

    void Start()
    {
        if(isLoading == false)
        {
            StartCoroutine(WaitLoadingMenu());
        }
        else
        {
            panelLoading.SetActive(false);
        }
    }

    
    void Update()
    {
        if (loadingImage.fillAmount < 1)
        {
            loadingImage.fillAmount += 0.1f;
        }
        if (loadingImage.fillAmount >= 1)
        {
            isLoading = true;
        }
        loadingText.text = (int)(loadingImage.fillAmount * 100) + " %";
    }

    IEnumerator WaitLoadingMenu()
    {
        yield return new WaitForSeconds(3f);
        panelTransit.SetActive(true);
        yield return new WaitForSeconds(5f);
        panelLoading.SetActive(false);
        yield return new WaitForSeconds(2f);
        panelTransit.SetActive(false);
    }
}
