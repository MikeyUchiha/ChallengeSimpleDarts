using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeSimpleDarts
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click1(object sender, EventArgs e)
        {
            Game game = new Game("Player1", "Player2");
            game.GameStart();

            DisplayResult(game);
        }

        private void DisplayResult(Game game)
        {
            resultLabel.Text = "";
            resultLabel.Text = String.Format("{0}: {1}</br>{2}: {3}</br>Winner: {4}", 
                game.Player1.Name, game.Player1.Score, game.Player2.Name, 
                game.Player2.Score, game.Winner);
        }
    }
}