using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource source;

    public void PlayAudio(){
        source.Play();
    }
}
