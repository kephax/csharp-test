using NUnit.Framework;

namespace Reverse
{
  [TestFixture]
  public class CharReverseTest
  {
    private CharReverse charReverse;

        /* https://github.com/nunit/docs/wiki/Breaking-Changes */
        [SetUp]
        public void setup()
        {
          charReverse = new CharReverse();
        }

        [Test]
        public void emptyString()
        {
          Assert.AreEqual("", charReverse.Reverse(""));
        }

        [Test]
        public void singleWord()
        {
          Assert.AreEqual("abc", charReverse.Reverse("cba"));
        }

        [Test]
        public void singleSentece()
        {
          string sentence = "Most people consider piranhas to be dangerous.";
          string expected = "tsoM elpoep redisnoc sahnarip ot eb suoregnad.";
          Assert.AreEqual(expected, charReverse.Reverse(sentence));
        }

        [Test]
        public void compoundSentence()
        {
          string sentence = "Most people consider piranhas to be dangerous,  they are harmless..";
          string expected = "tsoM elpoep redisnoc sahnarip ot eb suoregnad,  yeht era sselmrah..";
          Assert.AreEqual(expected, charReverse.Reverse(sentence));
        }

        [Test]
        public void paragraph()
        {
          string sentence = "Although most people consider piranhas to be quite dangerous, they are, for the most part, entirely harmless. Piranhas rarely feed on large animals.they eat smaller fish and aquatic plants.";
          string expected = "hguohtlA tsom elpoep redisnoc sahnarip ot eb etiuq suoregnad, yeht era, rof eht tsom trap, yleritne sselmrah. sahnariP ylerar deef no egral slamina.yeht tae rellams hsif dna citauqa stnalp.";
          Assert.AreEqual(expected, charReverse.Reverse(sentence));
        }
  }
}
