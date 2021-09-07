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
			playButton = new Button(_am.play_button, () => {
				DI.Get<GameManager>().startGame(null);
			});
			quitButton = new Button(_am.quit_button, () => {
				DI.Get<GameManager>().quitGame();
			});
		}

		private void arrangeView() {
			playButton.SetPosition(gameInfra.GetGameWidth(), gameInfra.GetGameHeight()*0.3f, Alignment.TOP);
			playButton.SetPosition(gameInfra.GetGameWidth(), gameInfra.GetGameHeight()*0.6f, Alignment.TOP);
		}
	}
}