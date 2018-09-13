using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* 
 *   Autor/Author: Pedro Lucas de Oliveira Cabral 
 *   GitHub: https://github.com/DoisLucas
 *   Data/Date: 29/01/2018
 */

public class GameOver : MonoBehaviour
{
    #region Variaveis

    public Text pontuacao;
    public Text record;
    public Animation animseta;
    public Animation animrecord;

    #endregion

    void Start()
    {
        string nome = Sistema.instancia.nometema;

        if (PlayerPrefs.GetInt("Jogou") == 0)
        {
            PlayerPrefs.SetInt("Jogou", 1);
        }

        if (nome.Equals("Bagian 1"))
        {

            AddPerguntas.getPerguntas_exatas().Clear();
            AddPerguntas.Add_exatas();

        }
        else if (nome.Equals("Bagian 2"))
        {

            AddPerguntas.getPerguntas_humanas().Clear();
            AddPerguntas.Add_humanas();

        }
        else if (nome.Equals("Bagian 3"))
        {

            AddPerguntas.getPerguntas_bio().Clear();
            AddPerguntas.Add_bio();

        }
        else if (nome.Equals("Bagian 4"))
        {

			AddPerguntas.getPerguntas_bagian4().Clear();
			AddPerguntas.Add_bagian4();
        }

        pontuacao.text = Sistema.instancia.GetPontuacao().ToString();
        record.text = Sistema.instancia.GetRecord().ToString();

        if (Sistema.instancia.newrecord == 1)
        {

            StartCoroutine(GoNewRecord());
            Sistema.instancia.newrecord = 0;
        }

        StartCoroutine(GoSetaNovamente());
    }

	public void menu()
    {
        Sistema.instancia.BotaoSom();
        SceneManager.LoadScene("menu");
    }

    public void Novamente()
    {
        Sistema.instancia.BotaoSom();
        SceneManager.LoadScene("PreAll");
    }

    private  IEnumerator GoSetaNovamente()
    {
        yield return new WaitForSeconds(3f);
        animseta.Play("ARROW");
        StartCoroutine(GoSetaNovamente());
    }

    private IEnumerator GoNewRecord()
    {
        yield return new WaitForSeconds(1.5f);
        animrecord.Play("newscore");
    }

}
