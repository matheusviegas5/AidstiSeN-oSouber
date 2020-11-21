using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testecortecamera : MonoBehaviour
{
    public Text numeroCorteCamera; 
    // Update is called once per frame
   public void SelecionaCorte()
    {
		try
		{

        Sistema.CorteCamera(int.Parse(numeroCorteCamera.text));
		}
		catch (System.Exception ex)
		{

			Debug.Log(ex);
		}
    }
}
