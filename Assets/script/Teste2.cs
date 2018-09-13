using UnityEngine;

/* 
 *   Autor/Author: Pedro Lucas de Oliveira Cabral 
 *   GitHub: https://github.com/DoisLucas
 *   Data/Date: 01/02/2018
 */

public class Teste2 : MonoBehaviour {

    #region Variaveis

    public GameObject off;

    #endregion

    public void FecharDialogo(){
		off.SetActive (false);
		Time.timeScale = 0;
	}

}
