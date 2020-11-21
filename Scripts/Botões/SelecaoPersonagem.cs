using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecaoPersonagem : MonoBehaviour
{
    public GameObject[] personagens;
    public static int numeroPersonagem = 0;
    public static Material skinPersonagemRosto;
    public static Material skinPersonagemRoupa;
    // Start is called before the first frame update

    private void Start()
    {
        Atualiza();
    }
    public void AumentaIndice()
    {
        if (personagens.Length-1 == numeroPersonagem) numeroPersonagem = 0;
        else numeroPersonagem++;
        Atualiza();
    }

    public void DiminuiIndice()
    {
        if (numeroPersonagem == 0) numeroPersonagem = personagens.Length - 1;
        else numeroPersonagem--;
        Atualiza();
    }

    void Atualiza()
    {
        for (int i = 0; i < personagens.Length; i++)
        {
            if (i == numeroPersonagem) personagens[numeroPersonagem].SetActive(true);
            else personagens[i].SetActive(false);
        }

    }

    public void Seleciona()
    {
        //Material[] mats;
        //mats = personagens[numeroPersonagem].GetComponent<SkinnedMeshRenderer>().materials;
        //skinPersonagemRoupa = mats[0];
        //skinPersonagemRosto = mats[1];
        SceneManager.LoadScene("Jogo");
    }
}
