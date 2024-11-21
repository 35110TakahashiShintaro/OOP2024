using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CustomerApp.Objects {
    public class Customer {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 電話番号
        /// </summary>
        public string Phone { get; set; }

        public string Address { get; set; }

        public byte[] ImageData { get; set; }

        public BitmapImage ImageSource {
            get {
                if (ImageData == null || ImageData.Length == 0) return null;

                using (var stream = new MemoryStream(ImageData)) {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                    return image;
                }
            }
        }

        public override string ToString() {
            return $"{Id}  {Name}  {Phone} {Address}";
        }
    }
}