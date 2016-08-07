using System;

using System.Windows.Forms;
using Control;

namespace View
{
    public partial class Welcome : Form
    {
        readonly Game _theGame = new Game();
        public Welcome()
        {
            InitializeComponent();
        }

        private void RollDiceBtn_Click(object sender, EventArgs e)
        {
            firstDiceBox.Text = _theGame.FirstPlayerToPlay()[0].ToString();
            secondDiceBox.Text = _theGame.FirstPlayerToPlay()[1].ToString();
            playerToPlay.Text = _theGame.CurrentPlayer.ToString();
            RollDiceBtn.Hide();
            button1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form pForm = new Form1(_theGame);
            pForm.Show();
        }
    }
}
