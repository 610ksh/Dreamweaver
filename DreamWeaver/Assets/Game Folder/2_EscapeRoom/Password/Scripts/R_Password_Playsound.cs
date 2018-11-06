using UnityEngine;
using System.Collections;

public class R_Password_Playsound : MonoBehaviour

{
    public void Clicky()
    {
        GetComponent<AudioSource>().Play();
    }
}
