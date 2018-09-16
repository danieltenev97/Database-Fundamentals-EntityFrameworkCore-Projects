using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XmlSecondExercise
{
    class Program
    {
        static void Main(string[] args)
        {
          

            Description[] descriptions = new Description[2]
            {
               new Description()
               {
                   Link="http://en.wikipedia.org/wiki/The_King_of_Limbs",
                   description="The King of Limbs is the eighth studio album by English rock band Radiohead, produced by Nigel Godrich. It was self-released on 18 February 2011 as a download in MP3 and WAV formats, followed by physical CD and 12 vinyl releases on 28 March, a wider digital release via AWAL, and a special newspaper edition on 9 May 2011. The physical editions were released through the band's Ticker Tape imprint on XL in the United Kingdom, TBD in the United States, and Hostess Entertainment in Japan."
                },
               new Description()
               {
                   Link="http://en.wikipedia.org/wiki/Third_%28Portishead_album%29",
                    description="The King of Limbs is the eighth studio album by English rock band Radiohead, produced by Nigel Godrich. It was self-released on 18 February 2011 as a download in MP3 and WAV formats, followed by physical CD and 12 vinyl releases on 28 March, a wider digital release via AWAL, and a special newspaper edition on 9 May 2011. The physical editions were released through the band's Ticker Tape imprint on XL in the United Kingdom, TBD in the United States, and Hostess Entertainment in China."
               }
           };

            Songs[] songs = new Songs[2]{
                new Songs()
                {
                    Title="Morning Mr Magpie",
                    Length ="4:41",
                    Description=descriptions[0]
                },
                new Songs()
                {
                      Title="Wandering Star",
                    Length ="5:36",
                    Description=descriptions[1]
                }

            };

            Albums[] albums = new Albums[2]
            {
                new Albums()
                {
                    Title="Neshto si",
                    song=songs
                },
                new  Albums()
                {
                    Title="Encore",
                    song=songs
                }
            };

            var artist = new Artist()
            {
                Name = "Radiohead",
                Albums = albums

            };

            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            var serializer = new XmlSerializer(typeof(Artist), new XmlRootAttribute("music"));

            using (var writer = new StreamWriter("album.xml"))
            {
                serializer.Serialize(writer, artist,namespaces);
            }
        }
    }
}
