using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace SpotifyAGAIN_
{
    public class Program
    {
        private static Client me;
        private static List<Album> allAlbums;
        static void Main(string[] args)
        {

            #region Setting The Data
            SongAuthor Kanye = new SongAuthor("Kanye", "West");
            List<Song> Heartbreak = new List<Song>()
            {
                new Song(Category.Pop, "Say You Will",Kanye,Tuple.Create(6,17)),
                new Song(Category.Pop, "Welcome To Heartbreak",Kanye,Tuple.Create(4,22)),
                new Song(Category.Pop, "Heartless",Kanye,Tuple.Create(3,31)),
                new Song(Category.Pop, "Amazing",Kanye,Tuple.Create(3,58)),
                new Song(Category.Pop, "Love Lockdown",Kanye,Tuple.Create(4,30)),
                new Song(Category.Pop, "Paranoid",Kanye,Tuple.Create(4,37)),
                new Song(Category.Pop, "RoboCop",Kanye,Tuple.Create(4,34)),
                new Song(Category.Pop, "Street Lights",Kanye,Tuple.Create(3,9)),
                new Song(Category.Pop, "Bad News",Kanye,Tuple.Create(3,58)),
                new Song(Category.Pop, "See You In My Nightmare",Kanye,Tuple.Create(4,18)),
                new Song(Category.Pop, "Coldest Winter",Kanye,Tuple.Create(2,44)),
                new Song(Category.Pop, "Pinocchio Story",Kanye,Tuple.Create(6,1)),


            };
            Album Hearbreak808 = new Album("808s & Heartbreak", Heartbreak);
            SongAuthor Kdot = new SongAuthor("Kendrick", "Lamar");
            List<Song> DamnSongs = new List<Song>()
            {
                new Song(Category.Rock,"BLOOD.",Kdot,Tuple.Create(1,58)),
                new Song(Category.Rock,"DNA.",Kdot,Tuple.Create(3,5)),
                new Song(Category.Rock,"YAH.",Kdot,Tuple.Create(2,4)),
                new Song(Category.Rock,"ELEMENT.",Kdot,Tuple.Create(3,28)),
                new Song(Category.Rock,"FEEL.",Kdot,Tuple.Create(3,34)),
                new Song(Category.Rock,"LOYALTY.",Kdot,Tuple.Create(3,47)),
                new Song(Category.Rock,"PRIDE.",Kdot,Tuple.Create(4,35)),
                new Song(Category.Rock,"HUMBLE.",Kdot,Tuple.Create(2,57)),
                new Song(Category.Rock,"LUST.",Kdot,Tuple.Create(5,7)),
                new Song(Category.Rock,"LOVE.",Kdot,Tuple.Create(3,33)),
                new Song(Category.Rock,"XXX.",Kdot,Tuple.Create(4,14)),
                new Song(Category.Rock,"FEAR.",Kdot,Tuple.Create(7,40)),
                new Song(Category.Rock,"GOD.",Kdot,Tuple.Create(4,8)),
                new Song(Category.Rock,"DUCKWORTH.",Kdot,Tuple.Create(4,8)),
            };
            Album DAMN = new Album("DAMN.", DamnSongs);
            allAlbums = new List<Album>()
            {
                DAMN,
                Hearbreak808

            };
           
            MediaPlayer myPlayer = new MediaPlayer() {};            
                       
            #endregion
            Console.WriteLine("Welcome To Spotify");
            Console.WriteLine("Enter your name :");
            string yourName  = Console.ReadLine();
            if (yourName == "")
            {
                throw new Exception("Username cant be empty");
            }
            me = new Client(yourName,"man",yourName,ClientType.Regular, myPlayer);
            Console.WriteLine($"Welcome , {yourName}");

            int choice = 0;
            bool running = true;
            while(running)
            {
                Console.WriteLine("1.Search Song");
                Console.WriteLine("2.Print Statistics");
                Console.WriteLine("3.Upgrade To Premium");
                Console.WriteLine("4.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Song Name :");
                        string ans = Console.ReadLine();
                        SearchSong(allAlbums, ans);
                        break;
                    case 2:
                        Console.ForegroundColor= ConsoleColor.Green;
                        me.PrintStatistics();
                        Console.ResetColor();
                        break;
                    case 3:
                        me.UpgradeToPremium();
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        running = false;
                        Console.WriteLine("Exiting because no option was chosen");
                        break;
                };
            }
            
        }
        private static void SearchSong(List<Album> database,string search)
        {
            List<Song> songList = new List<Song>();
            bool exits = false;
            for (int i=0; i<database.Count; i++)
            {
                songList.AddRange(database[i].SearchSongByName(search));
                
            }
            if(songList.Count == 0)
            {
                throw new SongDoesntExistException();
            }
            if (songList != null)
            {
                Console.WriteLine("Here are the songs we found: ");
                foreach (var song in songList)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    int index = 1;
                    Console.WriteLine($"{index}. " + song.ToString());
                    index++;
                }
                Console.ResetColor();

                Console.WriteLine("Choose An Option:");
                Console.WriteLine("1.Play");
                Console.WriteLine("2.Like");
                Console.WriteLine("3.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Choose which song you wish to play");
                            int songChoice = int.Parse(Console.ReadLine());
                            try
                            {
                                me.Play(songList[songChoice -1]);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                throw new IleegalChoiceException();
                            }
                            break;
                            
                        }
                     case 2:
                        {
                            Console.WriteLine("Choose which song you wish to like");
                            int songChoice = int.Parse(Console.ReadLine());
                            try
                            {
                                me.LikeSpecificSong(songList[songChoice-1]);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                throw new IleegalChoiceException();
                            }
                            break;
                        }
                    case 3:
                        {
                            return;
                        }
                    default:
                        {
                            return;
                        }
                       

                }
            }


        }
    }
}