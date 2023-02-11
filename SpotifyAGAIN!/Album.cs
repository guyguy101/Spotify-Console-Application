using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAGAIN_
{
    public class Album
    {
        public bool IsLiked { get; private set; }
        public readonly string Name;
        public readonly List<Song> Songs;
        public Album(string name ,List<Song> songs)
        {
            Name = name;
            Songs = songs;
            IsLiked= false;
        }
        public void LikeAlbum()
        {
            IsLiked= true;
        }
        public List<Song> SearchSongByName(string name)
        {
            List<Song> result = new List<Song>();
            foreach(Song s in Songs)
            {
                string checkFromAlbum = s.Name.ToLower();
                string checkFromSong = name.ToLower();
                if(checkFromAlbum.Contains(checkFromSong))
                    result.Add(s);
            }
            return result;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(IsLiked,Name,Songs);
        }
        public override bool Equals(object obj)
        {
            Album other = (Album)obj;
            return other.IsLiked == IsLiked &&
               other.Name == Name &&
               other.Songs == Songs;
        }
    }
}
