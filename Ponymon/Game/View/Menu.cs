using Ponyform.UI;

namespace Ponyform.Game.View {
	public class Menu: GameObject {
		private Button playButton, quitButton;

		private AssetManager _am;
		public Menu() {
			_am = DI.Get<AssetManager>();
			createView();
			arrangeView();
		}

		private void createView() {
			playButton = new Button(_am.play_button, OnClick);
			// quitButton = new Button(_am.quit_button, onQuit);
			AddAll(playButton);
		}

		private void arrangeView() {
			playButton.SetPosition(gameInfra.GetGameWidth()/2, gameInfra.GetGameHeight()*0.1f, Alignment.TOP);
			// quitButton.SetPosition(gameInfra.GetGameWidth()/2, gameInfra.GetGameHeight()*0.3f, Alignment.TOP);
			// quitButton.SetPosition(gameInfra.GetGameWidth()/2, gameInfra.GetGameHeight()*0.6f);
		}

        private void OnClick()
        {
            DI.Get<GameManager>().startGame(null);
		}

        private void onQuit()
        {
            DI.Get<GameManager>().quitGame();
		}
	}
}