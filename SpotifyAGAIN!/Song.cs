using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAGAIN_
{
    public class Song
    {
        public readonly Category Category;
        public readonly string Name;
        public readonly SongAuthor Author;
        public  Tuple<int, int> Length { get; private set; }
        public bool IsLiked { get; private set; }
        public Song(Category category, string name, SongAuthor author, Tuple<int, int> length)
        {
            if (length.Item1 > 0 && (length.Item2 <= 60 && length.Item2 >= 0))
                Length = length;
            else if (length.Item2 > 60)
            {
                int minToAdd = length.Item2 / 60;
                int secToAdd = length.Item2 - (60 *minToAdd);
                Tuple<int,int> newTuple = new Tuple<int, int>(length.Item1 + minToAdd, secToAdd);
                Length = newTuple;    
            }
            else
            {
                throw new IllegalSongLengthException();
            }
            Category = category;
            Name= name;
            Author= author;
            
            IsLiked= false;
        }
        public void Like()
        {
            IsLiked= true;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Category,Name,Author);
        }
        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;
            if (!(obj is Song))
                return false;
            Song other = (Song)obj;
            return other != null && other.Category == Category &&
                other.Name == Name &&
                other.Author == Author;
        }
        public override string ToString()
        {
            
            return $"{Name} : {Length.Item1}:{Length.Item2} BY {Author.ToString()}  ";
        }


    }
}
