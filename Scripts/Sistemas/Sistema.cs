using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Sistema : MonoBehaviour
{
    public static Animator cameraCorte;
    public static Animator jogadorAnimator;
    public static Animator silvioAnimator;
    public static Animator drauzioAnimator;

    public Animator[] plateia;

    private void Start()
    {
        PlateiaNormal();
    }
    private void Awake()
    {
        cameraCorte = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        jogadorAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        silvioAnimator = GameObject.FindWithTag("Silvio").GetComponent<Animator>();
        drauzioAnimator = GameObject.FindWithTag("Drauzio").GetComponent<Animator>();

    }
    public static void CorteCamera(int numero)
    {
        cameraCorte.SetInteger("corte", numero);
    }

    public static void AnimacaoJogador(int numero)
    {
        jogadorAnimator.SetInteger("animacaoJogador", numero);
    }
    public static void AnimacaoSilvio(int numero)
    {
        silvioAnimator.SetInteger("animacaoSilvio", numero);
    }

    public static void AnimacaoDrauzio(int numero)
    {
        drauzioAnimator.SetInteger("animacaoDrauzio", numero);
    }

    public void PlateiaAplaude()
    {
        for (int i = 0; i < plateia.Length; i++)
        {
            plateia[i].SetTrigger("aplaudir");
        }
    }

    public void PlateiaNormal()
    {
        for (int i = 0; i < plateia.Length; i++)
        {
        float frame = Random.Range(0f, 1f);
            plateia[i].Play("parado", 0, frame);
        }
        
    }
}
