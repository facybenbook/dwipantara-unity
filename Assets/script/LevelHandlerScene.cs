using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Dwipantara {
	
	public class LevelHandlerScene : BasicScene {

		#region EDITOR VARIABLES
		
		[Header ("UI Panel Elements")]
		public TransitionPanel Transition;
		public GameInfoPanel GameInfo;
		public VirtualInputPanel VirtualInput;
		public PauseMenuPanel PauseMenu;
		public GoalMenuPanel GoalMenu;
		public Button som;
		public Button fx;

		public Sprite OnMusic;
		public Sprite OffMusic;
		public Sprite OnFX;
		public Sprite OffFX;

		#endregion

		#region CONSTANTS

		private enum GameState {
			Initializing = 0,
			Playing,
			Paused,
			Win,
			Lose,
		}

		private const int TOTAL_LIVES = 4;
		private const int COIN_SCORE = 100;
		private const int TREASURE_SCORE = 1000;

		#endregion

		#region VARIABLES

		private GameState _gameState = GameState.Initializing;
		private int _score;
		private int control;
		private int _lives;
		private float _time;
		private int _timeInSeconds;
		private int _treasuresCollected;
		private string _sceneName;
		private string _levelName;
		private int _levelId;

		#endregion

		#region MONOBEHAVIOUR METHODS

		protected override void Awake () {
			base.Awake ();
		}

		private void Start () {
			StartCoroutine(InitSequence());
		}
			
		private void Update () {
			if(_gameState == GameState.Playing) {
				UpdateTimerCountdown();
				UpdateGameInfoUI();
			}
			if(_timeInSeconds == -1) {
				_lives--;
				StartCoroutine(InitSequencei());
				Respawn ();
			}
			if(_lives <= 0) {
				GameOver();
			}
		}
			
		private void OnDestroy() {
			UnSubscribeLevelElementsEvents();
		}

		#endregion

		private IEnumerator InitSequencei() {
			SubscribeLevelElementsEvents ();
			yield return StartCoroutine(InitScene());
		}

		private IEnumerator InitSequence() {
			_lives = TOTAL_LIVES;
			SubscribeLevelElementsEvents ();
			yield return StartCoroutine(InitScene());
		}

		private IEnumerator InitScene() {
			_score = 0;
			_treasuresCollected = 0;
			_time = 180;// Session.Instance.GetLevelMetadata().TotalTime;
			_levelId = Session.Instance.GetLevelId();
			_sceneName = Session.Instance.GetLevelMetadata().SceneName;
			_levelName = Session.Instance.GetLevelMetadata().LevelName;
			InputWrapper.Instance.EnableInput (false);

			HideAllThePanels ();
			Transition.gameObject.SetActive(true);
			Transition.DisplayIntro (true);
			Transition.DisplayGameOver (false);
			Transition.SetIntro (_levelId, _levelName, _lives);

			LevelHandlerUtils.DestroyLevel();
			yield return StartCoroutine( LevelHandlerUtils.LoadLevel(_sceneName));
			Debug.Log (_sceneName);
			yield return new WaitForSeconds(1.5f);

			HideAllThePanels ();
			GameInfo.gameObject.SetActive(true);
			VirtualInput.gameObject.SetActive(true);
			UpdateGameInfoUI();
			InputWrapper.Instance.EnableInput (true);
			_gameState = GameState.Playing;
		}

		private void HideAllThePanels() {
			Transition.gameObject.SetActive(false);
			GameInfo.gameObject.SetActive(false);
			VirtualInput.gameObject.SetActive(false);
			GoalMenu.gameObject.SetActive(false);
			PauseMenu.gameObject.SetActive (false);
		}

		private void SubscribeLevelElementsEvents () {
			Player.PlayerDeathEvent += new Player.PlayerDeathDelegate(RestartLevel);
			InteractiveCoinController.StartInteractionEvent += new InteractiveCoinController.StartInteractionDelegate(CollectCoin);
			InteractiveTreasureController.StartInteractionEvent += new InteractiveTreasureController.StartInteractionDelegate(CollectTreasure);
			InteractiveGoalFlagController.StartInteractionEvent += new InteractiveGoalFlagController.StartInteractionDelegate(LevelFinish);
		}

		private void UnSubscribeLevelElementsEvents () {
			Player.PlayerDeathEvent -= new Player.PlayerDeathDelegate(RestartLevel);
			InteractiveCoinController.StartInteractionEvent -= new InteractiveCoinController.StartInteractionDelegate(CollectCoin);
			InteractiveTreasureController.StartInteractionEvent -= new InteractiveTreasureController.StartInteractionDelegate(CollectTreasure);
			InteractiveGoalFlagController.StartInteractionEvent -= new InteractiveGoalFlagController.StartInteractionDelegate(LevelFinish);
		}

		private void UpdateGameInfoUI() {
			GameInfo.SetScore(_score);
			GameInfo.SetLives(_lives);
			GameInfo.SetTime(_timeInSeconds);
		}

		private void UpdateTimerCountdown() {
			_time = _time - UnityEngine.Time.deltaTime;
			_timeInSeconds = Mathf.FloorToInt(_time);
		}

		#region LEVEL ELEMENTS EVENTS

		private void LevelFinish () {
			_gameState = GameState.Win;
			Time.timeScale = 0;
			GoalMenu.SetTime(_timeInSeconds);
			GoalMenu.SetScore(_score);
			if(_levelName.Equals("Permulaan")){
				PlayerPrefs.SetInt ("PapuaScore", _score);
				PlayerPrefs.SetInt ("PapuaTime", _timeInSeconds);
			} else if(_levelName.Equals("Kewajiban")){
				PlayerPrefs.SetInt ("MalukuScore", _score);
				PlayerPrefs.SetInt ("MalukuTime", _timeInSeconds);
			} else if(_levelName.Equals("Perusak")){
				PlayerPrefs.SetInt ("SulawesiScore", _score);
				PlayerPrefs.SetInt ("SulawesiTime", _timeInSeconds);
			} else if(_levelName.Equals("Berjuang")){
				PlayerPrefs.SetInt ("KalimantanScore", _score);
				PlayerPrefs.SetInt ("KalimantanTime", _timeInSeconds);
			}
			GoalMenu.SetTreasures(_treasuresCollected);
			HideAllThePanels ();
			GoalMenu.EnableNext(Session.Instance.HasNext());
			GoalMenu.gameObject.SetActive(true);
		}

		private void CollectTreasure () {
			_score += TREASURE_SCORE;
			_treasuresCollected++;
		}

		private void CollectCoin () {
			_score += COIN_SCORE;
		}

		void Respawn(){
			GameObject player = GameObject.Find("Player");
			GameObject respawn = GameObject.Find("Respawn");
			player.transform.position = respawn.transform.position;
		}

		private void RestartLevel() {
			Debug.Log("RestartLevel called!");
			_gameState = GameState.Lose;
			_lives--;
			if(_lives <= 0) {
				GameOver();
			} else {
				HideAllThePanels();
				Transition.gameObject.SetActive(true);
				Transition.DisplayIntro (true);
				Transition.DisplayGameOver (false);
				Transition.SetIntro (_levelId, _levelName, _lives);
				LevelHandlerUtils.DestroyLevel();
				StartCoroutine(InitScene());
			}
		}

		private void LoadNextLevel() {
			HideAllThePanels();
			Session.Instance.PlayNext();
			StartCoroutine(InitScene());
		}

		private void GameOver() {
			Time.timeScale = 0;
			HideAllThePanels ();
			Transition.gameObject.SetActive(true);
			Transition.DisplayIntro (false);
			Transition.DisplayGameOver (true);
			LevelHandlerUtils.DestroyLevel();
		}

		#endregion

		#region ONCLICK EVENTS

		// All the events of the buttons, except VirtualInput, are handled here.
		public void CobaLagiOnClick () {
			Time.timeScale = 1;
			Start ();
		}

		public void PauseButtonOnClick() {
			Debug.Log("PauseButtonOnClick called...");
			_gameState = GameState.Paused;
			Time.timeScale = 0;
			PauseMenu.gameObject.SetActive(true);
			GameInfo.gameObject.SetActive(false);
			VirtualInput.gameObject.SetActive(false);
		}

		public void QuitButtonOnClick() {
			Debug.Log("QuitButtonOnClick called...");
			Time.timeScale = 1;
			GoToScene(Scene.Menu);
		}

		public void PilihLevelOnClick() {
			Debug.Log("PilihLevelOnClick called...");
			Time.timeScale = 1;
			GoToScene(Scene.LevelSelect);
		}

		public void PlayButtonOnClick() {
			Debug.Log("PlayButtonOnClick called...");
			Time.timeScale = 1;
			PauseMenu.gameObject.SetActive(false);
			GameInfo.gameObject.SetActive(true);
			VirtualInput.gameObject.SetActive(true);
			_gameState = GameState.Playing;
		}

		public void ShowPopup(GameObject popupGameObject)
		{
			Time.timeScale = 1;
			popupGameObject.SetActive(true);
		}

		public void OffPopup(Animation animGameObject)
		{
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

		public void NextButtonOnClick() {
			Debug.Log("NextButtonOnClick called...");
			Time.timeScale = 1;
			LoadNextLevel();
		}
	
		#endregion
	}
}