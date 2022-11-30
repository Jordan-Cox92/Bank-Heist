using System;
using System.Collections.Generic;

namespace BankHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment the line below to Clear your console when the application runs
            // Console.Clear();


            Console.WriteLine("Plan Your Heist!");
            Console.Write("Choose Heist Difficulty: ");
            int baseDifficulty = int.Parse(Console.ReadLine());

            Member teamMemberOne = new Member();

            Console.Write("Enter a name: ");
            teamMemberOne.Name = Console.ReadLine();

            Console.Write("Enter a skill level: ");
            teamMemberOne.SkillLevel = int.Parse(Console.ReadLine());

            Console.Write("Enter a courage factor: ");
            teamMemberOne.CourageFactor = double.Parse(Console.ReadLine());

            List<Member> teamMembers = new List<Member> { teamMemberOne };

            // Loops until user enters an empty string for name
            while (true == true)
            {
                Console.Write("Enter a name: ");
                string name = Console.ReadLine();

                // If name entered is an empty string, break out of loop and don't prompt for more info
                if (name == "")
                {
                    break;
                }

                // Create a new instance of Member class
                Member newTeamMember = new Member { Name = name };

                Console.Write("Enter a skill level: ");
                newTeamMember.SkillLevel = int.Parse(Console.ReadLine());

                Console.Write("Enter a courage factor: ");
                newTeamMember.CourageFactor = double.Parse(Console.ReadLine());

                teamMembers.Add(newTeamMember);
            }

            Console.Write("Amount of trials: ");
            int numberOfTrials = int.Parse(Console.ReadLine());

            Console.WriteLine($"There are {teamMembers.Count} team members.");

            int successes = 0;

            // Each iteration is a new "trial" run
            for (int i = 0; i < numberOfTrials; i++) // Another way to loop:  for (int i = numberOfTrials; i > 0; i--)
            {
                // Declare the base skill variable
                int totalSkillLevel = 0;

                // Calculatge total skill level in team
                foreach (Member member in teamMembers)
                {
                    totalSkillLevel += member.SkillLevel;
                }

                // Random Number between -10 and 10 (maxValue is exclusive)
                Random r = new Random();
                int luck = r.Next(-10, 11);

                // Calculate total difficulty level
                int difficulty = baseDifficulty + luck;

                // Displays the total skill and difficulty, then replies success if totalSkillLevel is higher or equal to difficulty
                Console.WriteLine($"Team Skill: {totalSkillLevel} | Difficulty: {difficulty}");
                if (totalSkillLevel >= difficulty)
                {
                    Console.WriteLine("Success!");
                    successes++;
                }
                else
                {
                    Console.WriteLine("Fail!");
                }
            }
            Console.WriteLine();
            // Declared successes and not failures, since we can subtract numberOfTrials by successes to get failures
            Console.WriteLine($"Successes: {successes} | Failures: {numberOfTrials - successes}");
        }
    }
}