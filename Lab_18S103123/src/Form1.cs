using Game.Chess;
using Game.Go;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            game = new GoGame("player1","player2");
            PicShow = new PictureBox();
            this.Width = game.board.GetCellSize() * (game.board.GetBoardSize()+ 4);
            this.Height= game.board.GetCellSize() * (game.board.GetBoardSize() + 2);
        }
        private void PicShow_Paint(object sender, PaintEventArgs e)
        {
            //将Board 的 bmp 画到 picshow上
            if (game.board.GetBmp() != null)
            {
                e.Graphics.DrawImage(game.board.GetBmp(), 0, 0);
            }
        }
        private void PicShow_MouseDown(object sender, MouseEventArgs e)
        {
            if (game.stop)
                MessageBox.Show("请重新开始");
            //显示xy
            //this.Text = "wfGo——" + intX.ToString() + "," + intY.ToString();

            //放置棋子
            bool ret=game.Run(e.X, e.Y);

            if (ret)
            {
                //重画棋盘及棋子
                game.board.Draw();
                //刷新窗口
                this.Refresh();
            }
            else
            {
                MessageBox.Show("落子无效");
            }
            if (ret)
            {
                string s;
                if (game.flag==1)
                    s = game.player2.name;
                else
                    s = game.player1.name;
                this.Text = s + " 请下棋";
            }
        }
        

        private void btn_end_Click(object sender, EventArgs e)
        {
            game.stop = true;
            MessageBox.Show("游戏结束");
            this.Text = "已结束";
        }

        
        private void showhistory_Click(object sender, EventArgs e)
        {
            if (game.board.h_pos < 0)
            {
                MessageBox.Show("已回退至最初状态");
                return;
            }
            game.board.pieceList = game.board.history[game.board.h_pos--];
            game.board.Draw();
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.stop = false;
            if (gametype == 0)
                game = new ChessGame("player1", "player2");
            else
                game = new GoGame("player1", "player2");
            this.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                gametype = 0;
                game = new ChessGame("player1", "player2");
                this.Refresh();
            }
            else
            {
                gametype = 1;
                game = new GoGame("player1", "player2");
                this.Refresh();
            }
        }
        private PictureBox PicShow;
        private Game game;
        private int gametype;

        private void button1_Click(object sender, EventArgs e)
        {
            game.flag ^= 1;
            string s;
            if (game.flag == 1)
                s = game.player2.name;
            else
                s = game.player1.name;
            this.Text = s + " 请下棋";
        }

    }
}
