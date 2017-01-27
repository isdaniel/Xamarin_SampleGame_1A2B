using GameBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _1A2BGame
{
    public partial class MainPage : ContentPage
    {
        private GameLogic gameLogic;
        private StringBuilder _Number = new StringBuilder();
        public MainPage()
        {
            InitializeComponent();
            gameLogic = new GameLogic();
        }
        void OnBtnClear(object sender, EventArgs e)
        {
            _Number.Clear();
            SetNumberText();
        }
        private void SetNumberText()
        {
            txt_1A2BNumber.Text = _Number.ToString();
        }
        private async void accptGame()
        {
            bool IsAccpet = await DisplayAlert("恭喜猜到數字", "是否還要在一場", "OK", "NO");
            if (IsAccpet)
            {
                txt_1A2BNumber.Text = "";
                gameLogic.ResetAnswer();
            }
        }
        private async void OnAgain(object sender, EventArgs e)
        {
            bool IsAccpet = await DisplayAlert("重新開始", "是否要放棄遊戲", "OK", "NO");
            if (IsAccpet)
            {
                txt_1A2BNumber.Text = "";
                gameLogic.ResetAnswer();
            }
        }
        void OnBtnSend(object sender, EventArgs e)
        {
            _Number.Clear();
            string Input_Number = txt_1A2BNumber.Text;
            if (gameLogic.CheckFourNumber(Input_Number))
            {
                txt_Answer.Text = gameLogic.CheckNum(Input_Number);
                if (gameLogic.IsCorrect)
                {
                    accptGame();
                }
            }
            else
            {
                DisplayAlert("請輸入正確數字", "請輸入四個數字", "OK");
            }
        }
        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;
            _Number.Append(pressed);
            SetNumberText();
        }
        void OnBtnCheckList(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RecordList(gameLogic.Recordlist));
        }
    }
}
