namespace SpotifyAGAIN_
{
    public class MediaPlayer
    {
        public Queue<Song> Playlist { get;private set; }
        public bool IsPlaying { get; private set; } 
        public MediaPlayer() 
        {
            Playlist = new Queue<Song>();
            IsPlaying = false;
            
        }
        public void Play(Song songToPlay)
        {
            
            if (songToPlay != null)
            {
                if(Playlist.Count > 0)
                {
                    Queue<Song> tempPlaylist = new Queue<Song>();
                    foreach (Song songTemporarilyRemoving in Playlist.ToList())
                    {
                        if (songTemporarilyRemoving != songToPlay)
                        {
                            tempPlaylist.Enqueue(Playlist.Dequeue());
                        }
                    }
                    foreach (Song songReturningToPlaylist in tempPlaylist.ToList())
                    {
                        Playlist.Enqueue(tempPlaylist.Dequeue());
                    }
                }
                else
                {
                    Playlist.Enqueue(songToPlay);
                }
                Console.WriteLine("Playing...");
                IsPlaying= true;
                
            }
            else
            {
                throw new SongDoesntExistException();
            }
            Console.WriteLine("?");
            
            
            
        }
        public void Stop()
        {
          
            IsPlaying= false;
        }
        public Song Next()
        {
            if(Playlist.Count == 0)
            {

                return null;
            }
            if(Playlist.Count == 1)
            {
                IsPlaying= false;
            }
            return Playlist.Dequeue();
               
            
                
        }
        public void Like(Song songToLike)
        {
            if(songToLike!= null)
            {
                Queue<Song> tempPlaylist = new Queue<Song>();
                for(int i=0; i<Playlist.Count; i++)
                {
                    if (Playlist.ElementAt(i) == songToLike)
                        Playlist.ElementAt(i).Like();
                }
                
                   
                        
                        
                  

            }
            

        }
    }
}
