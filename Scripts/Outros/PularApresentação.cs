using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PularApresentação : MonoBehaviour
{

    public Perguntas perguntas;
    // Start is called before the first frame update
    void Start()
    {
        perguntas.StartaCorotinaFazerPergunta();
    }


}
