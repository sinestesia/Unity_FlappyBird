using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private AudioSource audioSource;
    public static SoundManager instancia;

    [SerializeField] private AudioClip volar;
    [SerializeField] private AudioClip tuberiaSuperada;
    [SerializeField] private AudioClip morir;
    [SerializeField] private AudioClip clic;


    private void Awake()
    {
        instancia = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void SonidoVolar()
    {
        audioSource.PlayOneShot(volar);
    }
    public void SonidoTuberiaSuperada()
    {
        audioSource.PlayOneShot(tuberiaSuperada);
    }
    public void SonidoMorir()
    {
        audioSource.PlayOneShot(morir);
    }

    public void SonidoClic()
    {
        audioSource.PlayOneShot(clic);
    }

}
