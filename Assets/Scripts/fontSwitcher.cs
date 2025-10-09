using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fontSwitcher : MonoBehaviour
{

    public TMP_FontAsset NordMedium;
    public TMP_FontAsset NordRegular;



    public void switchFontBold()
    {
        GetComponent<TMP_Text>().font = NordRegular;

    }

    public void switchFontLight()
    {
        GetComponent<TMP_Text>().font = NordMedium;

    }
}
