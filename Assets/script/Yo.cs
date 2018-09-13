using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Yo : MonoBehaviour
{
	#region Variaveis

	public GameObject exit;
	public GameObject ajustes;
	public GameObject perfil;
	private GameObject coringago;
	public GameObject dev;
	public GameObject coin;
	public GameObject loja;
	public GameObject[] games;

	public Button b1;
	public Button b2;
	public Button b3;
	public Button b4;
	public Button b5;
	public Button som;
	public Button fx;

	public Text txtCoin;
	public Text txtNome;
	public Text[] txtbtn;

	public InputField inputNome;

	public Sprite OnMusic;
	public Sprite OffMusic;
	public Sprite OnFX;
	public Sprite OffFX;

	public Image iconloja;

	public Animation up;
	public Animation up1;

	public Fade e;
	public bool anim = true;

	#endregion

	void Start()
	{
		if (PlayerPrefs.GetInt("Jogou") == 1)
		{
			PlayerPrefs.SetInt("Jogou", 2);
		}

		if (PlayerPrefs.HasKey("Nome"))
		{

			if (PlayerPrefs.GetInt("Coins") >= 100)
			{
				iconloja.enabled = true;
			}
			else
			{
				iconloja.enabled = false;
			}

			coin.GetComponent<Animator>().enabled = true;

			string original = PlayerPrefs.GetString("Nome");

			string[] str = original.Split(' ');

			string nomeum = str[0];

			txtNome.text = nomeum;
			txtCoin.text = PlayerPrefs.GetInt("Coins").ToString();

		}
		else
		{
			coin.GetComponent<Animator>().enabled = false;
			iconloja.enabled = false;
		}

		exit.SetActive(false);
		ajustes.SetActive(false);
		perfil.SetActive(false);
		dev.SetActive(false);

		if (Sistema.instancia.GetClick() == 1)
		{
			e.SetTempoFade(0.3f);
		}

		if (Sistema.instancia.GetAtivoMusica() == true)
		{
			if (!Sistema.instancia.GetMusica().isPlaying)
			{
				Sistema.instancia.Tocar();
			}
		}

		if (Sistema.instancia.GetAtivoMusica())
		{
			som.image.sprite = OnMusic;
		}
		else
		{
			som.image.sprite = OffMusic;
		}

		if (Sistema.instancia.GetAtivofx())
		{
			fx.image.sprite = OnFX;
		}
		else
		{
			fx.image.sprite = OffFX;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && exit.activeInHierarchy)
		{
			Sistema.instancia.BotaoSom();
			OffPopup(exit.GetComponent<Animation>());
		}
			
		if (Input.GetKeyDown(KeyCode.Escape) && ajustes.activeInHierarchy)
		{
			Sistema.instancia.BotaoSom();
			OffPopup(ajustes.GetComponent<Animation>());
		}

		if (Input.GetKeyDown(KeyCode.Escape) && perfil.activeInHierarchy)
		{
			Sistema.instancia.BotaoSom();
			OffPopup(perfil.GetComponent<Animation>());
		}

		if (Input.GetKeyDown(KeyCode.Escape) && dev.activeInHierarchy)
		{
			Sistema.instancia.BotaoSom();
			OffPopup(dev.GetComponent<Animation>());
		}

		if (perfil.activeInHierarchy)
		{

			if (anim)
			{
				AnimacaoUP();
			}
			else
			{
				AnimacaoDown();
			}
		}	
	}

	public void BotaoJogar()
	{
		if (PlayerPrefs.HasKey ("Nome")) {
			Sistema.instancia.BotaoSom ();
			SceneManager.LoadScene ("Mode");
			Sistema.instancia.SetClick (1);
		}
		else
		{
			ShowPopup(perfil);
		}
	}

	public void Ensiklopedia()
	{
		if (PlayerPrefs.HasKey ("Nome")) {
		Sistema.instancia.BotaoSom();
		SceneManager.LoadScene("Ensiklopedia");
		Sistema.instancia.SetClick(1);
		}
		else
		{
			ShowPopup(perfil);
		}
	}

	public void BotaoLoja()
	{
		if (PlayerPrefs.HasKey("Nome"))
		{
			Sistema.instancia.BotaoSom();
			SceneManager.LoadScene("Loja");
			Sistema.instancia.SetClick(1);
		}
		else
		{
			ShowPopup(perfil);
		}
	}

	public void BotaoPerfil()
	{
		Color c;
		ColorUtility.TryParseHtmlString("#C2C2C25F", out c);

		if (PlayerPrefs.HasKey("Nome"))
		{
			Sistema.instancia.BotaoSom();
			SceneManager.LoadScene("Perfil");
			Sistema.instancia.SetClick(1);
		}
		else
		{
			ShowPopup(perfil);
		}
	}

	public void CriarPerfil(Animation AnimGameObejct)
	{
		try
		{
			string nomee = inputNome.text;

			if (nomee.Equals(""))
			{
				up.Blend("Error");
			}
			else
			{
				PlayerPrefs.SetString("Nome", nomee);
				PlayerPrefs.SetInt("level", 1);
				PlayerPrefs.SetInt("Acertos", 0);
				PlayerPrefs.SetInt("Coins", 0);
				PlayerPrefs.SetInt("Erros", 0);
				PlayerPrefs.SetInt("ScoreE", 0);
				PlayerPrefs.SetInt("ScoreH", 0);
				PlayerPrefs.SetInt("ScoreB", 0);
				PlayerPrefs.SetInt("ScoreG", 0);
				PlayerPrefs.SetInt("Pulos", 2);
				PlayerPrefs.SetInt("Chance", 2);
				PlayerPrefs.SetInt("Jogou", 0);
				PlayerPrefs.SetInt("Vida", 5);
				PlayerPrefs.SetInt("Reset", 0);
				OffPopup(AnimGameObejct);
			}
		}
		catch (Exception)
		{
			LimparCampos();
		}
	}

	public void GameObjectCoringa(GameObject coringa)
	{
		coringago = coringa;
	}

	public void ShowPopup(GameObject popupGameObject)
	{
		LimparCampos();
		Sistema.instancia.BotaoSom();
		b1.interactable = false;
		b2.interactable = false;
		b3.interactable = false;
		b4.interactable = false;
		b5.interactable = false;
		Offbarcoin();
		loja.GetComponent<Selectable>().interactable = false;
		b1.GetComponent<Animator>().enabled = false;
		popupGameObject.SetActive(true);
	}

	public void ShowPopup()
	{
		LimparCampos();
		Sistema.instancia.BotaoSom();
		b1.interactable = false;
		b2.interactable = false;
		b3.interactable = false;
		b4.interactable = false;
		b5.interactable = false;
		Offbarcoin();
		loja.GetComponent<Selectable>().interactable = false;
		b1.GetComponent<Animator>().enabled = false;
	}

	public void OffPopup(Animation animGameObject)
	{
		Sistema.instancia.BotaoSom();
		b1.interactable = true;
		b2.interactable = true;
		b3.interactable = true;
		b4.interactable = true;
		b5.interactable = true;
		Onbarcoin();
		loja.GetComponent<Selectable>().interactable = true;
		b1.GetComponent<Animator>().enabled = true;
		animGameObject.Play("exitMotionSecond");
	}

	public void MusicaClick(Button btnMusica)
	{
		if (Sistema.instancia.GetAtivoMusica())
		{
			Sistema.instancia.SetAtivoMusica(false);
		}
		else
		{
			Sistema.instancia.SetAtivoMusica(true);
		}

		MusicaTrocaSprite();
	}

	public void FXClick(Button btnFX)
	{
		if (Sistema.instancia.GetAtivofx())
		{
			Sistema.instancia.SetAtivoFX(false);
		}
		else
		{
			Sistema.instancia.SetAtivoFX(true);
		}

		FXTrocaSprite();
	}

	public void EmailSimplePiece()
	{
		PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 500);
		Sistema.instancia.BotaoSom();
		string email = "simplepieceofc@gmail.com";
		string subject = CorpoURL("QuizMulado 1.0 - Android Unity Version (5.6.2F1)");
		string body = CorpoURL("");
		Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
	}

	public void EmailDesenvolvedor()
	{
		Sistema.instancia.BotaoSom();
		string email = "pedrolucas499@gmail.com";
		string subject = CorpoURL("Contato Dev. QuizMulado 1.0 - Android Unity Version (5.6.2F1)");
		string body = CorpoURL("");
		Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
	}

	public void GithubSimplePiece()
	{
		Application.OpenURL("https://github.com/SimplePiece");
	}

	public void GithubDesenvolvedor()
	{
		Application.OpenURL("https://github.com/DoisLucas");
	}

	private void Offbarcoin()
	{
		for (int i = 0; i < games.Length; i++)
		{
			games[i].GetComponent<Selectable>().interactable = false;
		}

		for (int i = 0; i < txtbtn.Length; i++)
		{
			txtbtn[i].GetComponent<Selectable>().interactable = false;
		}
	}

	private void Onbarcoin()
	{
		for (int i = 0; i < games.Length; i++)
		{
			games[i].GetComponent<Selectable>().interactable = true;
		}

		for (int i = 0; i < txtbtn.Length; i++)
		{
			txtbtn[i].GetComponent<Selectable>().interactable = true;
		}
	}

	private void MusicaTrocaSprite()
	{
		if (Sistema.instancia.GetAtivoMusica())
		{
			som.image.sprite = OnMusic;
			Sistema.instancia.Tocar();
		}
		else
		{
			som.image.sprite = OffMusic;
			Sistema.instancia.Pausar();
		}
	}

	private void FXTrocaSprite()
	{
		if (Sistema.instancia.GetAtivofx())
		{
			fx.image.sprite = OnFX;
		}
		else
		{
			fx.image.sprite = OffFX;
		}
	}

	public void SairGame()
	{
		Sistema.instancia.BotaoSom();
		Application.Quit();
	}

	private void AnimacaoUP()
	{
		if (TouchScreenKeyboard.visible)
		{
			up1.Play("KeyOn1");
			anim = false;
		}
	}

	private void AnimacaoDown()
	{
		if (!TouchScreenKeyboard.visible)
		{
			up.Play("KeyOn2");
			anim = true;
		}
	}

	private void LimparCampos()
	{
		inputNome.text = "";
	}

	private string CorpoURL(string url)
	{
		return WWW.EscapeURL(url).Replace("+", "%20");
	}

	private IEnumerator AnimAfterCriacao()
	{
		if (coringago.name.Equals(b1.name))
		{
			yield return new WaitForSeconds(0.3f);
			SceneManager.LoadScene("topikkuis");
			Sistema.instancia.SetClick(1);
		}

		if (coringago.name.Equals(b2.name))
		{
			yield return new WaitForSeconds(0.3f);
			SceneManager.LoadScene("Perfil");
			Sistema.instancia.SetClick(1);
		}

		if (coringago.name.Equals(this.loja.name))
		{
			yield return new WaitForSeconds(0.3f);
			SceneManager.LoadScene("Loja");
			Sistema.instancia.SetClick(1);
		}
	}
}