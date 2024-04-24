using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCounter {
    public class SalesCounter {
        private IEnumerable<Sale> _salse;

        //コンストラクタ
        public SalesCounter(string filsePass) {
            _salse = ReadSales(filsePass);

        }

        //売上データを読み込み、Saleオブジェクトのリストを返す
        private static IEnumerable<Sale> ReadSales(string filePath) {
            List<Sale> salse = new List<Sale>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines) {
                string[] items = line.Split(',');
                Sale sale = new Sale {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2]),
                };
                salse.Add(sale);
            }
            return salse;
        }


        //店舗別の売り上げを求める
        public IDictionary<string, int> GetPerStoreSales() { 
            var dict = new Dictionary<string,int>(); 
            foreach (var sale in _salse) {
                if(dict.ContainsKey(sale.ShopName)) {
                    dict[sale.ShopName] += sale.Amount;
                } else {
                    dict[sale.ShopName] = sale.Amount;
                }
            }
            return dict;
        }
    }
}
