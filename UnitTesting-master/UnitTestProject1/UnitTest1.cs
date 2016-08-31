using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class BobSaysTests
    {
        Bob bob = new Bob();
        string remark = "";

        [TestMethod]
        public void test_stating_something()
        {
            remark = "Tom-ay-to, tom-aaaah-to.";
            Assert.AreEqual("Whatever.", bob.hey(remark));
        }

        [TestMethod]
        public void test_shouting()
        {

            remark = "WATCH OUT!";
            Assert.AreEqual("Whoa, chill out!", bob.hey(remark));
        }

        [TestMethod]
        public void test_shouting_gibberish()
        {
            remark = String.Join("", Enumerable.Range(65, 26)
                            .Select(a => new { A = (char)(a) })
                            .OrderBy(x => Guid.NewGuid()).Select(x => x.A));


            Assert.AreEqual("Whoa, chill out!", bob.hey(remark));
        }

        [TestMethod]
        public void test_asking_a_question()
        {

            remark = "Does this cryogenic chamber make me look fat?";
            Assert.AreEqual("Sure.", bob.hey(remark));
        }

        [TestMethod]
        public void test_asking_a_numeric_question()
        {

            remark = "You are, what, like 15?";
            Assert.AreEqual("Sure.", bob.hey(remark));
        }

        [TestMethod]
        public void test_asking_gibberish()
        {
            remark = String.Join("", Enumerable.Range(97, 26)
                            .Select(a => new { A = (char)(a) })
                            .OrderBy(x => Guid.NewGuid()).Select(x => x.A)) + "?";

            Assert.AreEqual("Sure.", bob.hey(remark));
        }

        [TestMethod]
        public void test_talking_forcefully()
        {

            remark = "Let's go make out behind the gym!";
            Assert.AreEqual("Whatever.", bob.hey(remark));
        }

        [TestMethod]
        public void test_using_acronyms_in_regular_speech()
        {

            remark = "It's OK if you don't want to go to the DMV.";
            Assert.AreEqual("Whatever.", bob.hey(remark));
        }

        [TestMethod]
        public void test_forceful_questions()
        {

            remark = "WHAT THE HELL WERE YOU THINKING?";
            Assert.AreEqual("Whoa, chill out!", bob.hey(remark));
        }

        [TestMethod]
        public void test_shouting_numbers()
        {

            remark = "1, 2, 3 GO!";
            Assert.AreEqual("Whoa, chill out!", bob.hey(remark));
        }

        [TestMethod]
        public void test_only_numbers()
        {

            remark = "1, 2, 3";
            Assert.AreEqual("Whatever.", bob.hey(remark));
        }

        [TestMethod]
        public void test_question_with_only_numbers()
        {

            remark = "4?";
            Assert.AreEqual("Sure.", bob.hey(remark));
        }

        [TestMethod]
        public void test_shouting_with_special_characters()
        {

            remark = "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!";
            Assert.AreEqual("Whoa, chill out!", bob.hey(remark));
        }

        [TestMethod]
        public void test_shouting_with_no_exclamation_mark()
        {

            remark = "I HATE YOU";
            Assert.AreEqual("Whoa, chill out!", bob.hey(remark));
        }

        [TestMethod]
        public void test_statement_containing_question_mark()
        {

            remark = "}ing with ? means a question.";
            Assert.AreEqual("Whatever.", bob.hey(remark));
        }

        [TestMethod]
        public void test_prattling_on()
        {

            remark = "Wait! Hang on. Are you going to be OK?";
            Assert.AreEqual("Sure.", bob.hey(remark));
        }

        [TestMethod]
        public void test_silence()
        {

            remark = "";
            Assert.AreEqual("Fine. Be that way!", bob.hey(remark));
        }

        [TestMethod]
        public void test_prolonged_silence()
        {

            remark = "           ";
            Assert.AreEqual("Fine. Be that way!", bob.hey(remark));
        }

        [TestMethod]
        public void test_alternate_silences()
        {

            remark = "\t\t\t\t\t";
            Assert.AreEqual("Fine. Be that way!", bob.hey(remark));
        }

        [TestMethod]
        public void test_on_multiple_line_questions()
        {

            remark = @"Does this cryogenic chamber make me look fat?
                       no";
            Assert.AreEqual("Whatever.", bob.hey(remark));
        }

    }
}

