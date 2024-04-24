using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCounter {
    public class SalesCounter {
        private List<Sale> _salse;

        //コンストラクタ
        public SalesCounter(List<Sale>salse) {
            _salse = salse;

        }

        //店舗別の売り上げを求める
        public Dictionary<string, int> GetPerStoreSales() { 
            Dictionary<string,int>dict = new Dictionary<string,int>(); 
            foreach (Sale sale in _salse) {
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
