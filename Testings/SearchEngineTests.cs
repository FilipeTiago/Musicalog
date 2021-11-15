using MediaLib.Helpers;
using MediaLib.Interfaces;
using MediaLib.Medias;
using MediaLib.SearchRules;
using MediaLib.Template;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Testings
{
    /// <summary>
    /// Test class for testing the search engine.
    /// </summary>
    public class SearchEngineTests
    {
        private List<Media> MediaLib;
        private string ArtistName;
        private string TitleName;
        Media FullSearchReference;

        /// <summary>
        /// Random name generator, used to generate random artist names and titles.
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        private static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2;
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }

        /// <summary>
        /// Set up the testing environment.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            MediaLib = new List<Media>();
            var random = new Random();
            for (int i = 0; i<1000; i++) //Add 1000 media items with random names to test our search engine.
            {
                if (random.Next(2) == 1)
                {
                    MediaLib.Add(new Cd() { Title = GenerateName(15), Artist = GenerateName(15), Stock = random.Next(100) });
                }
                else
                {
                    MediaLib.Add(new Vinyl() { Title = GenerateName(15), Artist = GenerateName(15), Stock = random.Next(100) });
                }
            }
            ArtistName = MediaLib[random.Next(1000)].Artist;
            TitleName = MediaLib[random.Next(1000)].Title;
            FullSearchReference = MediaLib[random.Next(1000)];
        }

        /// <summary>
        /// Test if finding by an artist name returns the media item. This is a exact match test.
        /// </summary>
        [Test]
        public void FindByExistingArtist()
        {
            var MatchRules = new List<IMatchRule<Media>>();
            var rule1 = new MatchByArtist(
                    new StringSearchRule()
                    {
                        Text = ArtistName,
                        ExactMatch = true,
                        StringComparison = StringComparison.InvariantCultureIgnoreCase
                    });
            MatchRules.Add(rule1);
            var response = SearchEngine.Search(MediaLib, MatchRules).ToList();
            Assert.IsTrue(response.Any());
        }

        /// <summary>
        /// Test if finding by an artist name that does not exists returns nothing. This is a exact match test.
        /// </summary>
        [Test]
        public void FindByNonExistingArtist()
        {
            var text = string.Empty;
            do
            {
                text = GenerateName(15);
            } while (MediaLib.FirstOrDefault(x => text.Equals(x.Artist)) != null);
            var MatchRules = new List<IMatchRule<Media>>();
            var rule1 = new MatchByArtist(
                    new StringSearchRule()
                    {
                        Text = text,
                        ExactMatch = true,
                        StringComparison = StringComparison.InvariantCultureIgnoreCase
                    });
            MatchRules.Add(rule1);
            var response = SearchEngine.Search(MediaLib, MatchRules).ToList();
            Assert.IsTrue(!response.Any());
        }

        /// <summary>
        /// Test if finding by an artist name returns the media item. This is a partial name match find.
        /// </summary>
        [Test]
        public void FindByExistingArtistTrimed()
        {
            var MatchRules = new List<IMatchRule<Media>>();
            var rule1 = new MatchByArtist(
                    new StringSearchRule()
                    {
                        Text = ArtistName.Substring(0, 6),
                        ExactMatch = false,
                        StringComparison = StringComparison.InvariantCultureIgnoreCase
                    });
            MatchRules.Add(rule1);
            var response = SearchEngine.Search(MediaLib, MatchRules).ToList();
            Assert.IsTrue(response.Any());
        }

        /// <summary>
        /// Test if finding by an title returns the media item. This is a exact match test.
        /// </summary>
        [Test]
        public void FindByExistingTitle()
        {
            var MatchRules = new List<IMatchRule<Media>>();
            var rule1 = new MatchByTitle(
                    new StringSearchRule()
                    {
                        Text = TitleName,
                        ExactMatch = true,
                        StringComparison = StringComparison.InvariantCultureIgnoreCase
                    });
            MatchRules.Add(rule1);
            var response = SearchEngine.Search(MediaLib, MatchRules).ToList();
            Assert.IsTrue(response.Any());
        }

        /// <summary>
        /// Test if finding by an title that does not exists returns nothing. This is a exact match test.
        /// </summary>
        [Test]
        public void FindByNonExistingTitle()
        {
            var text = string.Empty;
            do
            {
                text = GenerateName(15);
            } while (MediaLib.FirstOrDefault(x => text.Equals(x.Title)) != null);
            var MatchRules = new List<IMatchRule<Media>>();
            var rule1 = new MatchByTitle(
                    new StringSearchRule()
                    {
                        Text = text,
                        ExactMatch = true,
                        StringComparison = StringComparison.InvariantCultureIgnoreCase
                    });
            MatchRules.Add(rule1);
            var response = SearchEngine.Search(MediaLib, MatchRules).ToList();
            Assert.IsTrue(!response.Any());
        }

        /// <summary>
        /// Test if finding by an title returns the media item. This is a partial name match find.
        /// </summary>
        [Test]
        public void FindByExistingTitleTrimed()
        {
            var MatchRules = new List<IMatchRule<Media>>();
            var rule1 = new MatchByTitle(
                    new StringSearchRule()
                    {
                        Text = TitleName.Substring(0, 6),
                        ExactMatch = false,
                        StringComparison = StringComparison.InvariantCultureIgnoreCase
                    });
            MatchRules.Add(rule1);
            var response = SearchEngine.Search(MediaLib, MatchRules).ToList();
            Assert.IsTrue(response.Any());
        }

        /// <summary>
        /// Test if combining multiple rules existing artist and title (same media item) returns the media item. This is a exact match test.
        /// </summary>
        [Test]
        public void FindByExistingArtistAndTitle()
        {
            var MatchRules = new List<IMatchRule<Media>>();
            var rule1 = new MatchByTitle(
                    new StringSearchRule()
                    {
                        Text = FullSearchReference.Title,
                        ExactMatch = true,
                        StringComparison = StringComparison.InvariantCultureIgnoreCase
                    });
            var rule2 = new MatchByArtist(
                    new StringSearchRule()
                    {
                        Text = FullSearchReference.Artist,
                        ExactMatch = true,
                        StringComparison = StringComparison.InvariantCultureIgnoreCase
                    });
            MatchRules.Add(rule1);
            MatchRules.Add(rule2);
            var response = SearchEngine.Search(MediaLib, MatchRules).ToList();
            Assert.IsTrue(response.Any());
        }

        /// <summary>
        /// Test if combining multiple rules existing artist and title (same media item) partial names returns the media item. This is a partial name match find.
        /// </summary>
        [Test]
        public void FindByExistingArtistAndTitleTrimed()
        {
            var MatchRules = new List<IMatchRule<Media>>();
            var rule1 = new MatchByTitle(
                    new StringSearchRule()
                    {
                        Text = FullSearchReference.Title.Substring(0, 6),
                        ExactMatch = false,
                        StringComparison = StringComparison.InvariantCultureIgnoreCase
                    });
            var rule2 = new MatchByArtist(
                    new StringSearchRule()
                    {
                        Text = FullSearchReference.Artist.Substring(0, 6),
                        ExactMatch = false,
                        StringComparison = StringComparison.InvariantCultureIgnoreCase
                    });
            MatchRules.Add(rule1);
            MatchRules.Add(rule2);
            var response = SearchEngine.Search(MediaLib, MatchRules).ToList();
            Assert.IsTrue(response.Any());
        }
    }
}