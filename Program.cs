using System;
using System.Collections.Generic;
using System.Linq;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge lotr = new Challenge("What year was fellowship of the ring published", 1954, 20);
            Challenge palpatine = new Challenge("finish the star wars quote `Execute order...` ", 66, 10);
            Challenge stangerThings = new Challenge("Jane Ives is refered to by what numeric nickname in this popular tv show?", 11, 15);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            Robe robeOne = new Robe
            {
                Colors = new List<string> { "red", "blue", "green" },
                Length = 53,

            };

            Hat hatOne = new Hat
            {
                ShininessLevel = 20,
            };

            Prize newPrize = new Prize("Huzzah! 1 estus flask has been added to your inventory!");

            Console.WriteLine("What is thy name adventurer?");

            string userName = Console.ReadLine();
            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(userName, robeOne, hatOne, 0);

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                lotr,
                palpatine,
                stangerThings,
            };

            Console.WriteLine(theAdventurer.GetDiscription());

            var rnd = new Random();
            var randomChallenges = challenges.OrderBy(item => rnd.Next());

            void theQuest()
            {
                // Loop through all the challenges and subject the Adventurer to them
                int counter = 1;
                foreach (Challenge challenge in randomChallenges)
                    if (counter <= 5)
                    {
                        challenge.RunChallenge(theAdventurer);
                        counter++;
                    }
                    else
                    {
                        break;
                    }


                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                newPrize.ShowPrize(theAdventurer);

                Console.WriteLine("Would You Dare To Play Again? Y/N (yes or no)");
                string YesOrNo = Console.ReadLine().ToUpper();

                if (YesOrNo == "Y")
                {
                    theAdventurer.Awesomeness = theAdventurer.Awesomeness + (theAdventurer.SuccessCounter * 10);
                    theAdventurer.SuccessCounter = 0;
                    theQuest();
                }
            }
            theQuest();
        }
    }
}