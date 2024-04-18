using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123,"かりんとう",180);

            int price = karinto.Price;  //税抜きの金額

            int taxIncluded = karinto.GetPriceIncludingTax();　//税込みの金額

            Console.WriteLine(karinto.Name + "の税込み価格" + taxIncluded + "円【税抜き" + price + "円】");


            Product daifuku = new Product(1234, "大福", 2000);

            int price2 = daifuku.Price;  //税抜きの金額

            int taxIncluded2 = daifuku.GetPriceIncludingTax();　//税込みの金額

            Console.WriteLine(daifuku.Name + "の税込み価格" + taxIncluded2 + "円【税抜き" + price2 + "円】");
        }
    }
}
