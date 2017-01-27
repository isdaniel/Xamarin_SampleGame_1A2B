using GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameBLL
{
    public class GameLogic
    {
        public List<Record> Recordlist;
        private int _A;
        private int _B;
        public bool IsCorrect;
        /// <summary>
        /// 是否正確如果是正確清除紀錄
        /// </summary>
        private void CheckCorrect() {
            IsCorrect = _A == 4;
            if (IsCorrect)
            {
                Recordlist.Clear();
            }
        }
        public string _Answer { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool CheckNumber(string number)
        {
            return number.Length == 4 ? true : false;
        }
        /// <summary>
        /// 建構子
        /// </summary>
        public GameLogic()
        {
            Recordlist=new List<Record>();
            SetAnswer();
        }
        /// <summary>
        /// 設置四位數字答案
        /// </summary>
        private void SetAnswer()
        {
            _Answer = MakeRand(1, 9, 4);
        }
        /// <summary>
        /// 檢查是否為四位數字
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool CheckFourNumber(string num)
        {
            return num.Length == 4 ? true : false;
        }
        /// <summary>
        /// 檢查為幾A幾B
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string CheckNum(string number)
        {
            _A = 0;
            _B = 0;
            for (int i = 0; i < number.Length; i++)
            {
                //如果不是在同一個位置就判斷是否為B
                if (!FindNumber(_Answer[i], number[i]))
                {
                    FindNumber(number[i]);
                }
            }
            //$"{_A}A{_B}B", number
            Recordlist.Add(new Record() {
                AB = $"{_A}A{_B}B",
                UserNumber = number
            });
            CheckCorrect();
            return $"{_A}A{_B}B";
        }
        /// <summary>
        /// 找尋A有幾個
        /// </summary>
        /// <param name="ansChar"></param>
        /// <param name="userAser"></param>
        /// <returns></returns>
        private bool FindNumber(char ansChar, char userAser)
        {
            if (ansChar.CompareTo(userAser) == 0)
            {
                _A++;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 找尋B有幾個
        /// </summary>
        /// <param name="ansChar"></param>
        /// <param name="userAser"></param>
        /// <returns></returns>
        private void FindNumber(char userAser)
        {
            if (_Answer.Contains(userAser.ToString()))
            {
                _B++;
            }
        }
        /// <summary>
        /// 設置一個四位亂數(數字不重複)
        /// </summary>
        public void ResetAnswer()
        {
            _Answer = MakeRand(1, 9, 4);
        }
        //// <summary> 
        /// 產生不重複的亂數 
        /// </summary> 
        /// <param name="intLower"></param>產生亂數的範圍下限 
        /// <param name="intUpper"></param>產生亂數的範圍上限 
        /// <param name="intNum"></param>產生亂數的數量 
        /// <returns></returns> 
        private string MakeRand(int intLower, int intUpper, int intNum)
        {
            string stringRand = "";
            Random random = new Random((int)DateTime.Now.Ticks);
            int intRnd;
            while (stringRand.Length < intNum)
            {
                intRnd = random.Next(intLower, intUpper + 1);
                //如果亂數中沒有包含此數字就加入字串中
                if (!stringRand.Contains(intRnd.ToString()))
                {
                    stringRand += intRnd;
                }
            }
            return stringRand;
        }
    }
}
