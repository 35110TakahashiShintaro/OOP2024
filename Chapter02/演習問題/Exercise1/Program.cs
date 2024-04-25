using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    internal class Program {
        static void Main(string[] args) {

            var songs = new Song[]{

                new Song("飛行艇", "King Gnu", 261),
                new Song("SPECIALZ", "King Gnu", 238),
                new Song("Flash!!", "King Gnu", 170),
                new Song("Slmberland", "King Gnu", 184),
                new Song("硝子窓", "King Gnu", 217),

            };
            PrintSongs(songs);
        }
        private static void PrintSongs(Song[] songs) {

            foreach(var song in songs) {
                Console.WriteLine(@"{0},{1} {2:mm\:ss}",song.Title,song.ArtistName,TimeSpan.FromSeconds(song.Length));
            }

        }
    }
}
