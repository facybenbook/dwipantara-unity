using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
 *   Autor/Author: Pedro Lucas de Oliveira Cabral 
 *   GitHub: https://github.com/DoisLucas
 *   Data/Date: 29/01/2018
 */

public class Partida : MonoBehaviour
{

	#region Variaveis

	public Text txtPergunta;
	public Text txtA;
	public Text txtB;
	public Text txtC;
	public Text txtD;
	public Text txtLife;
	public Text txtPulo;
	public Text txtPuloAnim;
	public Text txtChance;
	public Text[] txt_button;
	public Text[] buttonAtxt;
	public Text[] buttonBtxt;
	public Text[] buttonCtxt;
	public Text[] buttonDtxt;

	public Button ButtonA;
	public Button ButtonB;
	public Button ButtonC;
	public Button ButtonD;

	List<Button> botoes_save = new List<Button>();
	List<Text> txt_save = new List<Text>();

	public GameObject exit;
	public GameObject[] all_interable;
	public GameObject backanim;

	public Animation loselife;
	public Animation botaoanim;
	public Animation erropulo;
	public Animation fadeerro;

	public GameObject gambarPrefab;
	public Sprite[] gambarSprites;
	public Image gambartanya;

	int i = 0;

	/*
     * 0 = Exatas
     * 1 = Humanas
     * 2 = Bio
     * 3 = All
    */

	int theme_index;
	int updatecall = 0;
	int tap = 0;

	/*
     * 1 = A
     * 1 = B
     * 2 = C
     * 3 = D
    */

	int press_button = 0;
	int life = 0;
	int score = 0;
	int correct = 0;
	int error = 0;
	int coin = 0;

	bool skip = true;
	bool skip_verif = true;
	bool chance_verif = true;

	List<Perguntas> exatas_list;
	List<Perguntas> hist_list;
	List<Perguntas> bio_list;
	List<Perguntas> bagian4_list;
	List<Perguntas> skipped_questions = new List<Perguntas>();

	#endregion

	void Start()
	{
		txtPulo.text = (PlayerPrefs.GetInt("Pulos").ToString());
		txtChance.text = (PlayerPrefs.GetInt("Chance").ToString());
		life = PlayerPrefs.GetInt("Vida");
		UiOn();
		skipped_questions.Clear();
		exit.SetActive(false);
		string name = "";
		name = Sistema.instancia.GetNomeTema();

		if (name.Equals("Bagian Papua"))
		{
			exatas_list = AddPerguntas.getPerguntas_exatas();
			MisturarArray(exatas_list);
			theme_index = 0;
			txtPergunta.text = exatas_list[i].GetTexto();
			txtA.text = exatas_list[i].GetQ1();
			txtB.text = exatas_list[i].GetQ2();
			txtC.text = exatas_list[i].GetQ3();
			txtD.text = exatas_list[i].GetQ4();
			txtLife.text = ("" + life);
		}
		else if (name.Equals("Bagian Maluku"))
		{
			hist_list = AddPerguntas.getPerguntas_humanas();
			MisturarArray(hist_list);
			theme_index = 1;
			txtPergunta.text = hist_list[i].GetTexto();
			txtA.text = hist_list[i].GetQ1();
			txtB.text = hist_list[i].GetQ2();
			txtC.text = hist_list[i].GetQ3();
			txtD.text = hist_list[i].GetQ4();
			txtLife.text = ("" + life);
		}
		else if (name.Equals("Bagian Sulawesi Tengah"))
		{
			bio_list = AddPerguntas.getPerguntas_bio();
			MisturarArray(bio_list);
			theme_index = 2;
			txtPergunta.text = bio_list[i].GetTexto();
			txtA.text = bio_list[i].GetQ1();
			txtB.text = bio_list[i].GetQ2();
			txtC.text = bio_list[i].GetQ3();
			txtD.text = bio_list[i].GetQ4();
			txtLife.text = ("" + life);
		}
		else if (name.Equals("Bagian Kalimantan Barat"))
		{
			bagian4_list = AddPerguntas.getPerguntas_bagian4();
			MisturarArray(bagian4_list);
			theme_index = 3;
			txtPergunta.text = bagian4_list[i].GetTexto();
			txtA.text = bagian4_list[i].GetQ1();
			txtB.text = bagian4_list[i].GetQ2();
			txtC.text = bagian4_list[i].GetQ3();
			txtD.text = bagian4_list[i].GetQ4();
			txtLife.text = ("" + life);
		}
	}

	void Update()
	{
		string name = "";
		name = Sistema.instancia.GetNomeTema();
		if (name.Equals ("Bagian Papua")) {
			string gambar = ""; 
			gambar = exatas_list[i].GetTexto();
			if (gambar.Equals ("Apa nama Senjata daerah yang berasal dari Papua ini?")) {
				Sprite gambarSprite = gambarSprites [5];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 

			if (gambar.Equals ("Disebut apakah rumah tradisional ini?")) {
				Sprite gambarSprite = gambarSprites [6];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 

			if (gambar.Equals ("Apakah nama pakaian adat ini?")) {
				Sprite gambarSprite = gambarSprites [7];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 

			if (gambar.Equals ("Nama Alat Musik ini adalah?")) {
				Sprite gambarSprite = gambarSprites [8];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 
		}

		if (name.Equals ("Bagian Maluku")) {
			string gambar = ""; 
			gambar = hist_list [i].GetTexto ();
			if (gambar.Equals ("Apa nama Senjata daerah yang berasal dari Maluku ini?")) {
				Sprite gambarSprite = gambarSprites [0];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 

			if (gambar.Equals ("Disebut apakah rumah tradisional ini?")) {
				Sprite gambarSprite = gambarSprites [1];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 

			if (gambar.Equals ("Apakah nama pakaian adat ini?")) {
				Sprite gambarSprite = gambarSprites [2];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 

			if (gambar.Equals ("Nama Alat Musik ini adalah?")) {
				Sprite gambarSprite = gambarSprites [3];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 
		}

		if (name.Equals ("Bagian Sulawesi Tengah")) {
			string gambar = ""; 
			gambar = bio_list[i].GetTexto();
			if (gambar.Equals ("Apa nama Senjata daerah yang berasal dari Sulawesi Tengah ini?")) {
				Sprite gambarSprite = gambarSprites [10];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 

			if (gambar.Equals ("Disebut apakah rumah tradisional ini?")) {
				Sprite gambarSprite = gambarSprites [11];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 

			if (gambar.Equals ("Apakah nama pakaian adat ini?")) {
				Sprite gambarSprite = gambarSprites [12];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 

			if (gambar.Equals ("Nama Alat Musik ini adalah?")) {
				Sprite gambarSprite = gambarSprites [13];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 
		}

		if (name.Equals ("Bagian Kalimantan Barat")) {
			string gambar = ""; 
			gambar = bagian4_list[i].GetTexto();
			if (gambar.Equals ("Apa nama Senjata daerah yang berasal dari Kalimantan Barat ini?")) {
				Sprite gambarSprite = gambarSprites [15];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 

			if (gambar.Equals ("Disebut apakah rumah tradisional ini?")) {
				Sprite gambarSprite = gambarSprites [16];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 

			if (gambar.Equals ("Apakah nama pakaian adat ini?")) {
				Sprite gambarSprite = gambarSprites [17];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			} 

			if (gambar.Equals ("Nama Alat Musik ini adalah?")) {
				Sprite gambarSprite = gambarSprites [18];
				gambartanya.GetComponent<Image> ().sprite = gambarSprite;
			}
		}

		if (updatecall == 1)
		{
			ButtonA.GetComponent<Selectable>().interactable = true;
			ButtonB.GetComponent<Selectable>().interactable = true;
			ButtonC.GetComponent<Selectable>().interactable = true;
			ButtonD.GetComponent<Selectable>().interactable = true;

			if (press_button == 1)
			{
				botaoanim.Play("NormalA");
			}
			else if (press_button == 2)
			{
				botaoanim.Play("NormalB");
			}
			else if (press_button == 3)
			{
				botaoanim.Play("NormalC");
			}
			else if (press_button == 4)
			{
				botaoanim.Play("NormalD");
			}

			press_button = 0;
			tap = 0;

			int size;

			if (theme_index == 0)
			{
				size = exatas_list.Count;

				if (i == (size) && skipped_questions.Count != 0)
				{
					skip = false;
					print("Entrou SKIPPED_QUESTIONS");
					i = 0;
					skip_verif = false;
					exatas_list.Clear();

					for (int z = 0; z < skipped_questions.Count; z++)
					{
						exatas_list.Add(skipped_questions[z]);
					}

					txtA.text = exatas_list[i].GetQ1();
					txtB.text = exatas_list[i].GetQ2();
					txtC.text = exatas_list[i].GetQ3();
					txtD.text = exatas_list[i].GetQ4();
					txtPergunta.text = exatas_list[i].GetTexto();
					chance_verif = true;
					UiOn();
				}
				else
				{
					txtA.text = exatas_list[i].GetQ1();
					txtB.text = exatas_list[i].GetQ2();
					txtC.text = exatas_list[i].GetQ3();
					txtD.text = exatas_list[i].GetQ4();
					txtPergunta.text = exatas_list[i].GetTexto();
					chance_verif = true;
					UiOn();
				}
			}
			else if (theme_index == 1)
			{
				size = hist_list.Count;

				if (i == (size) && skipped_questions.Count != 0)
				{
					skip = false;
					print("Entrou SKIPPED_QUESTIONS");
					i = 0;
					skip_verif = false;
					hist_list.Clear();

					for (int z = 0; z < skipped_questions.Count; z++)
					{
						hist_list.Add(skipped_questions[z]);
					}

					txtA.text = hist_list[i].GetQ1();
					txtB.text = hist_list[i].GetQ2();
					txtC.text = hist_list[i].GetQ3();
					txtD.text = hist_list[i].GetQ4();
					txtPergunta.text = hist_list[i].GetTexto();
					chance_verif = true;
					UiOn();
				}
				else
				{
					txtA.text = hist_list[i].GetQ1();
					txtB.text = hist_list[i].GetQ2();
					txtC.text = hist_list[i].GetQ3();
					txtD.text = hist_list[i].GetQ4();
					txtPergunta.text = hist_list[i].GetTexto();
					chance_verif = true;
					UiOn();
				}
			}
			else if (theme_index == 2)
			{
				size = bio_list.Count;

				if (i == (size) && skipped_questions.Count != 0)
				{
					skip = false;
					print("Entrou SKIPPED_QUESTIONS");
					i = 0;
					skip_verif = false;
					bio_list.Clear();

					for (int z = 0; z < skipped_questions.Count; z++)
					{
						bio_list.Add(skipped_questions[z]);
					}

					txtA.text = bio_list[i].GetQ1();
					txtB.text = bio_list[i].GetQ2();
					txtC.text = bio_list[i].GetQ3();
					txtD.text = bio_list[i].GetQ4();
					txtPergunta.text = bio_list[i].GetTexto();
					chance_verif = true;
					UiOn();
				}
				else
				{
					txtA.text = bio_list[i].GetQ1();
					txtB.text = bio_list[i].GetQ2();
					txtC.text = bio_list[i].GetQ3();
					txtD.text = bio_list[i].GetQ4();
					txtPergunta.text = bio_list[i].GetTexto();
					chance_verif = true;
					UiOn();
				}
			}
			else if (theme_index == 3)
			{
				size = bagian4_list.Count;

				if (i == (size) && skipped_questions.Count != 0)
				{
					skip = false;
					print("Entrou SKIPPED_QUESTIONS");
					i = 0;
					skip_verif = false;
					bagian4_list.Clear();

					for (int z = 0; z < skipped_questions.Count; z++)
					{
						bagian4_list.Add(skipped_questions[z]);
					}
					txtA.text = bagian4_list[i].GetQ1();
					txtB.text = bagian4_list[i].GetQ2();
					txtC.text = bagian4_list[i].GetQ3();
					txtD.text = bagian4_list[i].GetQ4();
					txtPergunta.text = bagian4_list[i].GetTexto();
					chance_verif = true;
					UiOn();
				}
				else
				{
					txtA.text = bagian4_list[i].GetQ1();
					txtB.text = bagian4_list[i].GetQ2();
					txtC.text = bagian4_list[i].GetQ3();
					txtD.text = bagian4_list[i].GetQ4();
					txtPergunta.text = bagian4_list[i].GetTexto();
					chance_verif = true;
					UiOn();
				}
			}
		}

		txtLife.text = ("" + life);
		txtPulo.text = (PlayerPrefs.GetInt("Pulos").ToString());
		txtChance.text = (PlayerPrefs.GetInt("Chance").ToString());
		updatecall = 0;

		if (Input.GetKeyDown(KeyCode.Escape) && exit.activeInHierarchy)
		{
			Sistema.instancia.BotaoSom();
			OffPopup(exit.GetComponent<Animation>());
		}

		if (Input.GetKeyDown(KeyCode.Escape) && !exit.activeInHierarchy)
		{
			Sistema.instancia.BotaoSom();
			ShowPopup(exit);
		}
	}

	public void ShowPopup(GameObject popup)
	{
		Sistema.instancia.BotaoSom();
		botoes_save.Clear();
		txt_save.Clear();

		if (ButtonA.GetComponent<Selectable>().interactable == false)
		{
			botoes_save.Add(ButtonA);
		}

		if (ButtonB.GetComponent<Selectable>().interactable == false)
		{
			botoes_save.Add(ButtonB);
		}

		if (ButtonC.GetComponent<Selectable>().interactable == false)
		{
			botoes_save.Add(ButtonC);
		}

		if (ButtonD.GetComponent<Selectable>().interactable == false)
		{
			botoes_save.Add(ButtonD);
		}

		UiOff();
		popup.SetActive(true);
	}

	public void OffPopup(Animation animpopup)
	{
		Sistema.instancia.BotaoSom();
		UiOn();
		animpopup.Play("exitMotionSecond");
	}

	public void ButtonSair(Animation animpopup)
	{
		animpopup.Play("exitMotionSecond");
		StartCoroutine(AnimSair());
	}

	public void BotaoA()
	{
		int respostaA = 1;

		if (tap == 1 && press_button != 1)
		{
			tap = 0;
			if (press_button == 1)
			{
				botaoanim.Play("NormalA");
			}
			else if (press_button == 2)
			{
				botaoanim.Play("NormalB");
			}
			else if (press_button == 3)
			{
				botaoanim.Play("NormalC");
			}
			else if (press_button == 4)
			{
				botaoanim.Play("NormalD");
			}
		}
		else
		{
			botaoanim.Play("btnA");

			if (theme_index == 0)
			{
				LogicaPartida(exatas_list, respostaA, "ScoreE");
			}
			else if (theme_index == 1)
			{
				LogicaPartida(hist_list, respostaA, "ScoreH");
			}
			else if (theme_index == 2)
			{
				LogicaPartida(bio_list, respostaA, "ScoreB");
			}
			else if (theme_index == 3)
			{
				LogicaPartida(bagian4_list, respostaA, "ScoreG");
			}
		}
	}

	public void BotaoB()
	{
		int respostaB = 2;

		if (tap == 1 && press_button != 2)
		{
			tap = 0;
			if (press_button == 1)
			{
				botaoanim.Play("NormalA");
			}
			else if (press_button == 2)
			{
				botaoanim.Play("NormalB");
			}
			else if (press_button == 3)
			{
				botaoanim.Play("NormalC");
			}
			else if (press_button == 4)
			{
				botaoanim.Play("NormalD");
			}
		}
		else
		{
			botaoanim.Play("btnB");

			if (theme_index == 0)
			{
				LogicaPartida(exatas_list, respostaB, "ScoreE");
			}
			else if (theme_index == 1)
			{
				LogicaPartida(hist_list, respostaB, "ScoreH");
			}
			else if (theme_index == 2)
			{
				LogicaPartida(bio_list, respostaB, "ScoreB");
			}
			else if (theme_index == 3)
			{
				LogicaPartida(bagian4_list, respostaB, "ScoreG");
			}
		}
	}

	public void BotaoC()
	{
		int respostaC = 3;

		if (tap == 1 && press_button != 3)
		{
			tap = 0;
			if (press_button == 1)
			{
				botaoanim.Play("NormalA");
			}
			else if (press_button == 2)
			{
				botaoanim.Play("NormalB");
			}
			else if (press_button == 3)
			{
				botaoanim.Play("NormalC");
			}
			else if (press_button == 4)
			{
				botaoanim.Play("NormalD");
			}
		}
		else
		{
			botaoanim.Play("btnC");

			if (theme_index == 0)
			{
				LogicaPartida(exatas_list, respostaC, "ScoreE");
			}
			else if (theme_index == 1)
			{
				LogicaPartida(hist_list, respostaC, "ScoreH");
			}
			else if (theme_index == 2)
			{
				LogicaPartida(bio_list, respostaC, "ScoreB");
			}
			else if (theme_index == 3)
			{
				LogicaPartida(bagian4_list, respostaC, "ScoreG");
			}
		}
	}

	public void BotaoD()
	{
		int respostaD = 4;

		if (tap == 1 && press_button != 4)
		{
			tap = 0;
			if (press_button == 1)
			{
				botaoanim.Play("NormalA");
			}
			else if (press_button == 2)
			{
				botaoanim.Play("NormalB");
			}
			else if (press_button == 3)
			{
				botaoanim.Play("NormalC");
			}
			else if (press_button == 4)
			{
				botaoanim.Play("NormalD");
			}
		}
		else
		{
			botaoanim.Play("btnD");

			if (theme_index == 0)
			{
				LogicaPartida(exatas_list, respostaD, "ScoreE");
			}
			else if (theme_index == 1)
			{
				LogicaPartida(hist_list, respostaD, "ScoreH");
			}
			else if (theme_index == 2)
			{
				LogicaPartida(bio_list, respostaD, "ScoreB");
			}
			else if (theme_index == 3)
			{
				LogicaPartida(bagian4_list, respostaD, "ScoreG");
			}
		}
	}

	public void PoderPulo()
	{
		if (PlayerPrefs.GetInt("Pulos") != 0)
		{
			int qtdperguntas = 1;

			if (theme_index == 0)
			{
				skipped_questions.Add(exatas_list[i]);
				qtdperguntas = exatas_list.Count;
			}
			else if (theme_index == 1)
			{
				skipped_questions.Add(hist_list[i]);
				qtdperguntas = hist_list.Count;
			}
			else if (theme_index == 2)
			{
				skipped_questions.Add(bio_list[i]);
				qtdperguntas = bio_list.Count;
			}
			else if (theme_index == 3)
			{
				skipped_questions.Add(bagian4_list[i]);
				qtdperguntas = bagian4_list.Count;
			}

			if (skip)
			{
				if (i != (qtdperguntas))
				{
					i = i + 1;
					PlayerPrefs.SetInt("Pulos", (PlayerPrefs.GetInt("Pulos") - 1));
					//press_button = 0;
					updatecall = 1;
				}
			}
			else
			{
				txtPuloAnim.text = ("NÃO É POSSIVEL PULAR UMA PERGUNTA DUAS VEZES NA MESMA PARTIDA!");
				erropulo.Play("erropulo");
				print("Pulo Indisponivel");
			}
		}
		else
		{
			txtPuloAnim.text = ("VOCÊ NÃO TEM MAIS PULOS, VOCÊ PODE COMPRAR MAIS NA LOJA!");
			erropulo.Play("erropulo");
			print("Pulo Indisponivel");
		}
	}

	public void PoderChance()
	{
		if (PlayerPrefs.GetInt("Chance") != 0)
		{
			if (chance_verif)
			{
				chance_verif = false;
				PlayerPrefs.SetInt("Chance", (PlayerPrefs.GetInt("Chance") - 1));
				int resposta = -1;

				if (theme_index == 0)
				{
					resposta = exatas_list[i].GetResposta();
				}
				else if (theme_index == 1)
				{
					resposta = hist_list[i].GetResposta();
				}
				else if (theme_index == 2)
				{
					resposta = bio_list[i].GetResposta();
				}
				else if (theme_index == 3)
				{
					resposta = bagian4_list[i].GetResposta();
				}

				List<int> roleta = new List<int>();

				if (resposta == 1)
				{
					roleta.Add(2);
					roleta.Add(3);
					roleta.Add(4);
				}
				else if (resposta == 2)
				{
					roleta.Add(1);
					roleta.Add(3);
					roleta.Add(4);
				}
				else if (resposta == 3)
				{
					roleta.Add(1);
					roleta.Add(2);
					roleta.Add(4);
				}
				else if (resposta == 4)
				{
					roleta.Add(1);
					roleta.Add(2);
					roleta.Add(3);
				}

				Color c;
				ColorUtility.TryParseHtmlString("#C8C8C880", out c);

				MisturarArray(roleta);
				int off_1 = roleta[0];
				int off_2 = roleta[1];
				print(off_1);
				print(off_2);

				if (off_1 == 1 || off_2 == 1)
				{
					ButtonA.GetComponent<Selectable>().interactable = false;
					for (int i = 0; i < buttonAtxt.Length; i++)
					{
						buttonAtxt[i].color = c;
					}
				}

				if (off_1 == 2 || off_2 == 2)
				{
					ButtonB.GetComponent<Selectable>().interactable = false;
					for (int i = 0; i < buttonBtxt.Length; i++)
					{
						buttonBtxt[i].color = c;
					}
				}

				if (off_1 == 3 || off_2 == 3)
				{
					ButtonC.GetComponent<Selectable>().interactable = false;
					for (int i = 0; i < buttonCtxt.Length; i++)
					{
						buttonCtxt[i].color = c;
					}
				}

				if (off_1 == 4 || off_2 == 4)
				{
					ButtonD.GetComponent<Selectable>().interactable = false;
					for (int i = 0; i < buttonDtxt.Length; i++)
					{
						buttonDtxt[i].color = c;
					}
				}
			}
			else
			{
				txtPuloAnim.text = ("SÓ É POSSIVEL USAR O PODER DE PORCENTAGEM UMA VEZ POR PERGUNTA!");
				erropulo.Play("erropulo");
				print("ja usou");
			}
		}
		else
		{
			if (!chance_verif)
			{
				txtPuloAnim.text = ("SÓ É POSSIVEL USAR O PODER DE PORCENTAGEM UMA VEZ POR PERGUNTA!");
				erropulo.Play("erropulo");
			}
			else
			{
				txtPuloAnim.text = ("VOCÊ NÃO TEM MAIS PODER DE PORCENTAGEM, VOCÊ PODE COMPRAR MAIS NA LOJA!");
				erropulo.Play("erropulo");
			}
		}
	}

	private IEnumerator AnimSair()
	{
		yield return new WaitForSeconds(0.3f);
		SceneManager.LoadScene("Tema");
	}

	private void UiOn()
	{
		Color c;
		ColorUtility.TryParseHtmlString("#FFFFFFFF", out c);

		Color life;
		ColorUtility.TryParseHtmlString("#323232FF", out life);

		Color de;
		ColorUtility.TryParseHtmlString("#C8C8C880", out de);

		for (int i = 0; i < all_interable.Length; i++)
		{
			all_interable[i].GetComponent<Selectable>().interactable = true;
		}

		for (int i = 0; i < txt_button.Length; i++)
		{
			txt_button[i].color = c;
		}

		all_interable[3].GetComponent<Animator>().enabled = true;
		backanim.GetComponent<Selectable>().interactable = true;
		backanim.GetComponent<Animator>().enabled = true;

		if (botoes_save.Count != 0)
		{
			for (int i = 0; i < botoes_save.Count; i++)
			{
				botoes_save[i].GetComponent<Selectable>().interactable = false;
				print(botoes_save[i].name);

				if (botoes_save[i].name == "btnA")
				{
					for (int x = 0; x < buttonAtxt.Length; x++)
					{
						txt_save.Add(buttonAtxt[x]);
						buttonAtxt[x].color = de;
					}
				}
				else if (botoes_save[i].name == "btnB")
				{
					for (int x = 0; x < buttonBtxt.Length; x++)
					{
						txt_save.Add(buttonBtxt[x]);
						buttonBtxt[x].color = de;
					}
				}
				else if (botoes_save[i].name == "btnC")
				{
					for (int x = 0; x < buttonCtxt.Length; x++)
					{
						txt_save.Add(buttonCtxt[x]);
						buttonCtxt[x].color = de;
					}
				}
				else if (botoes_save[i].name == "btnD")
				{
					for (int x = 0; x < buttonDtxt.Length; x++)
					{
						txt_save.Add(buttonDtxt[x]);
						buttonDtxt[x].color = de;
					}
				}
			}

			botoes_save.Clear();
			txt_save.Clear();
		}
	}

	private void UiOff()
	{
		Color c;
		ColorUtility.TryParseHtmlString("#C8C8C880", out c);

		Color life;
		ColorUtility.TryParseHtmlString("#323232FF", out life);

		for (int i = 0; i < all_interable.Length; i++)
		{
			all_interable[i].GetComponent<Selectable>().interactable = false;
		}

		for (int i = 0; i < txt_button.Length; i++)
		{
			txt_button[i].color = c;
		}

		all_interable[3].GetComponent<Animator>().enabled = false;
		backanim.GetComponent<Selectable>().interactable = false;
		backanim.GetComponent<Animator>().enabled = false;
	}

	private void LogicaPartida(List<Perguntas> lista, int resposta, string scoreprefstema)
	{
		if (tap == 0)
		{
			press_button = resposta;
			tap = 1;
		}
		else
		{
			press_button = resposta;

			if (lista[i].GetResposta().Equals(resposta))
			{
				print("Correto");
				fadeerro.Blend("VISUCORRECT");
				coin += lista[i].GetCoin();
				correct = correct + 1;
				Sistema.instancia.Acerto();
				score = score + 100;
				print("mais " + lista[i].GetCoin() + "REAIS");

				if (i >= (lista.Count - 1) && (life > 0))
				{
					if (skip_verif && skipped_questions.Count != 0)
					{
						skip_verif = false;
						i = i + 1;
						updatecall = 1;
					}
					else
					{
						print("END GAME / CORRETO");

						PlayerPrefs.SetInt("Acertos", PlayerPrefs.GetInt("Acertos") + correct);
						PlayerPrefs.SetInt("Erros", PlayerPrefs.GetInt("Erros") + error);
						PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coin);
						print("total ganho: " + coin);

						if (score > PlayerPrefs.GetInt(scoreprefstema))
						{
							PlayerPrefs.SetInt(scoreprefstema, score);
							Sistema.instancia.newrecord = 1;
						}

						Sistema.instancia.SetPontuacao(correct);
						Sistema.instancia.SetRecord(PlayerPrefs.GetInt(scoreprefstema));
						SceneManager.LoadScene("Fim");
					}
				}
				else
				{
					i = i + 1;
					updatecall = 1;
					tap = 0;
				}
			}
			else
			{
				life = life - 1;
				print("Errado");
				loselife.Play("LifeLose");
				fadeerro.Blend("VISUWRONG");
				lista.Add(lista[i]);
				Sistema.instancia.Erro();
				error = error + 1;

				if (life <= 0)
				{
					print("GAME OVER / SEM VIDAS");
					PlayerPrefs.SetInt("Acertos", PlayerPrefs.GetInt("Acertos") + correct);
					PlayerPrefs.SetInt("Erros", PlayerPrefs.GetInt("Erros") + error);
					PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coin);
					print("total ganho: " + coin);

					if (score > PlayerPrefs.GetInt(scoreprefstema))
					{
						PlayerPrefs.SetInt(scoreprefstema, score);
						Sistema.instancia.newrecord = 1;
					}

					Sistema.instancia.SetPontuacao(correct);
					Sistema.instancia.SetRecord(PlayerPrefs.GetInt(scoreprefstema));
					print("qts correto" + correct);
					SceneManager.LoadScene("GameOver");
				}
				else
				{
					if (i >= (lista.Count - 1) && (life > 0))
					{
						if (skip_verif && skipped_questions.Count != 0)
						{
							skip_verif = false;
							i = i + 1;
							updatecall = 1;
						}
					}
					else
					{
						i = i + 1;
						updatecall = 1;
						tap = 0;
					}
				}
			}
		}
	}

	private void MisturarArray(List<Perguntas> p)
	{
		for (int i = 0; i < p.Count; i++)
		{
			Perguntas temp = p[i];
			int randomIndex = Random.Range(i, p.Count);
			p[i] = p[randomIndex];
			p[randomIndex] = temp;
		}
	}

	private void MisturarArray(List<int> p)
	{
		for (int i = 0; i < p.Count; i++)
		{
			int temp = p[i];
			int randomIndex = Random.Range(i, p.Count);
			p[i] = p[randomIndex];
			p[randomIndex] = temp;
		}
	}
}

