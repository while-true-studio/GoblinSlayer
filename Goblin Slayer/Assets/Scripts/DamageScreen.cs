using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    public Image image;
    public float time;
    public void StartAnimation()
    {
        //image.color = new Color(1, 0, 0, 0);
        image.CrossFadeAlpha(1, time, false);
    }

}
