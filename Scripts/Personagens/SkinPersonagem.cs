using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkinPersonagem : MonoBehaviour
{


    public Transform posicaoPersonagem;
    public GameObject[] personagem;

    // Start is called before the first frame update
    void Awake()
    {
        //Material[] mats;
        //mats = this.GetComponent<SkinnedMeshRenderer>().materials;
        //mats[1] = SelecaoPersonagem.skinPersonagemRosto;
        //mats[0] = SelecaoPersonagem.skinPersonagemRoupa;
        //this.GetComponent<SkinnedMeshRenderer>().materials = mats;

        for (int i = 0; i < personagem.Length; i++)
        {
            if (SelecaoPersonagem.numeroPersonagem == i)
            {
            Instantiate(personagem[i], posicaoPersonagem);
            }
        }
        


    }


}
