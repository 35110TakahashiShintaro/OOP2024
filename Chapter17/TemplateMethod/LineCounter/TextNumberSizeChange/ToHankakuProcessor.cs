using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;
using TextNumberSizeChange.Framework;

namespace TextNumberSizeChange {
    class ToHankakuProcessor : TextProcessor, ITextFileService {

        private int _count;
        string _text;
        private Dictionary<char, char> _fullWidthToHalfWidth;

        public ToHankakuProcessor() {
            _fullWidthToHalfWidth = new Dictionary<char, char> {
                {'０', '0'},
                {'１', '1'},
                {'２', '2'},
                {'３', '3'},
                {'４', '4'},
                {'５', '5'},
                {'６', '6'},
                {'７', '7'},
                {'８', '8'},
                {'９', '9'},
            };
        }

        public void Initialize(string fname) {
            _count = 0;
        }

        public void Execute(string line) {
            string convertedLine = ConvertToHalfWidthNumbers(line);
            Console.WriteLine(convertedLine);
            _text = convertedLine;
            _count++;
        }

        public void Terminate() {
            Console.WriteLine("{0}行", _count);
            Console.WriteLine(_text);
        }

        private string ConvertToHalfWidthNumbers(string line) {
            StringBuilder sb = new StringBuilder();

            foreach (char c in line) {
                if (_fullWidthToHalfWidth.TryGetValue(c, out char halfWidthChar)) {
                    sb.Append(halfWidthChar);
                } else {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
