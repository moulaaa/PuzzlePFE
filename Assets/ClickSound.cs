using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Buttons))]
public class ClickSound : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource source;

    private void OnMouseDown()
    {
        source.PlayOneShot(sound);
    }
}
