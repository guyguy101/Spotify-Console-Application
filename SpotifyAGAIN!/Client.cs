using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAGAIN_
{
    public class Client : Person
    {
        private readonly string _userName;
        public ClientType ClientType { get; private set; }

        public Dictionary<Category, int> CategoryCounter { get; private set; }
        public Dictionary<SongAuthor,int> AuthorCounter { get;private set; }
        public List<Song> History { get; private set; }
        public List<Song> LikedSongs { get;private set; }
        public List<Album> LikedAlbums { get;private set; }
        public MediaPlayer MediaPlayer { get; private set; }
        public Client(string firstName, string lastName, string userName ,ClientType clientType, MediaPlayer mediaPlayer) : base(firstName, lastName)
        {
            CategoryCounter = new Dictionary<Category, int>();
            AuthorCounter= new Dictionary<SongAuthor, int>();
            _userName= userName;
            LikedSongs = new List<Song>();
            LikedAlbums = new List<Album>();
            History = new List<Song>();
            MediaPlayer= mediaPlayer;
            ClientType = clientType;
        }
        public void Play(Song s1)
        {
            if(s1 != null)
            {
                MediaPlayer.Play(s1);
                History.Add(s1);
                
                if(CategoryCounter.ContainsKey(s1.Category))
                {
                    CategoryCounter[s1.Category]++;
                }
                else
                {
                    CategoryCounter.Add(s1.Category, 0);
                }
                if(AuthorCounter.ContainsKey(s1.Author))
                {
                    AuthorCounter[s1.Author]++;
                }
                else
                {
                    AuthorCounter.Add(s1.Author, 0);
                }
                

            }
            
            
        }
        public void UpgradeToPremium()
        {
            ClientType = ClientType.Premium;
        }
        public void Next()
        {
            Song s1 = MediaPlayer.Next();
            History.Add(s1);
            Play(s1);
            
        }
        public void LikeSpecificSong(Song s1)
        {
            
            if(ClientType == ClientType.Regular && LikedSongs.Count < 10 || (ClientType == ClientType.Premium || ClientType == ClientType.Admin))
            {
                MediaPlayer.Like(s1);
                LikedSongs.Add(s1);
            }
            else
            {
                throw new ActionNotAllowedException();
            }
                
            
            
            
        }
        public void LikeAlbum(Album album)
        {
            album.LikeAlbum();
            LikedAlbums.Add(album);
        }
        public void PrintStatistics()
        {
            int lastTenSongs =0;
            if(History.Count == 0)
            {
                Console.WriteLine("You havent listened to a single song");
                return;
            }
            if(History.Count > 10)
            {
               lastTenSongs = History.Count - 10;
            }
            else
            {
                lastTenSongs = History.Count;
            }
            for(int i =0;i<lastTenSongs;i++)
            {

                Console.WriteLine(History[i].ToString());
            }
            if(CategoryCounter.Count >= 2 && AuthorCounter.Count >= 3)
            {
                Console.WriteLine("Top 2 listened categories are:");

                Console.WriteLine(CategoryCounter.Max().Key);
                var maxValue = CategoryCounter.Max();
                var maxKey = CategoryCounter.Max().Key;
                CategoryCounter.Remove(CategoryCounter.Max().Key);
                Console.WriteLine(CategoryCounter.Max().Key);

                CategoryCounter.Add(maxKey, maxValue.Value);

                Console.WriteLine("Top 3 listened authors are:");

                Console.WriteLine(AuthorCounter.Max().Key);
                var maxAuthorValue1 = AuthorCounter.Max();
                var maxAuthorKey1 = AuthorCounter.Max().Key;
                AuthorCounter.Remove(AuthorCounter.Max().Key);
                Console.WriteLine(AuthorCounter.Max().Key);
                var maxAuthorValue2 = AuthorCounter.Max();
                var maxAuthorKey2 = AuthorCounter.Max().Key;
                AuthorCounter.Remove(AuthorCounter.Max().Key);
                Console.WriteLine(AuthorCounter.Max().Key);

                AuthorCounter.Add(maxAuthorKey1, maxAuthorValue1.Value);
                AuthorCounter.Add(maxAuthorKey2, maxAuthorValue2.Value);


            }


        }

    }
}
