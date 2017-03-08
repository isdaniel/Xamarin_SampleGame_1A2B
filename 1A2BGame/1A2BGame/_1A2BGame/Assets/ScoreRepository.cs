using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using GameModel;

namespace Assets._1A2BGame
{
    public class ScoreRepository
    {
        public string StateMessage { get; set; }
        private SQLiteAsyncConnection conn;
        public ScoreRepository(string filepath) {
            conn = new SQLiteAsyncConnection(filepath);
            conn.CreateTableAsync<Score>();
        }
        /// <summary>
        /// 插入資料
        /// </summary>
        /// <param name="socre"></param>
        /// <returns></returns>
        public async Task InsertScore(Score socre) {
            try
            {
                await conn.InsertAsync(socre);
            }
            catch (Exception ex)
            {
                StateMessage = $"Failed to InsertScore. Error: {ex.ToString()}";
            }
        }
        /// <summary>
        /// 取最好的5個分數
        /// </summary>
        /// <returns></returns>
        public async Task<List<Score>> GetScoreList() {
            var scorelist=await conn.Table<Score>().ToListAsync();
            scorelist = (from data in scorelist
                        orderby data.CountTime
                        select data).Take(5).ToList();
            return scorelist;
        }
    }
}
