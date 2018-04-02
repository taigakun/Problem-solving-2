using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicsScoring {

    /// <summary>
    /// Student Name: Taiga Matsumoto
    /// Student ID: n9891285
    /// </summary>
    class Program {

        public static void Main(string[] args) {
            //ARRAYS
            int[,] results ={
                              { 4, 7, 5},
                              { 4, 7, 4},
                              { 4, 4, 9}
                             };
            int[,] larAndSmlNum = new int[results.GetLength(1), 2];
            int[] totalScore = new int[results.GetLength(0)];
            int[] finalScore = new int[results.GetLength(0)];
            int[] winner = new int[results.GetLength(0)];
            //index of 0 means total point in the array, and index of 1 means 
            //the index of the total points given by judge
            int[,] totalScoreofIndividualJudge = new int[results.GetLength(1), 2];
            //index of 0 means highest point in the array, and index of 1 means 
            //the index of the highest points given by judge
            int[] numsOfJudgeWhoGivesHigestPoint = new int[results.GetLength(1)];


            //VARIABLE
            int highestScore = 0;
            int higestScorebyJudge = 0;


            //Methods
            welcome();
            addAllPoints(ref results, ref totalScore);
            GetHighestandSmallest(ref results, ref larAndSmlNum);
            calculateFinalScore(ref results, ref totalScore, ref finalScore, ref larAndSmlNum);
            DefineWinner(results, ref highestScore, ref winner, ref finalScore);
            TotalPointsGivenbyJudges(ref results, ref totalScoreofIndividualJudge);
            DifineHighestPointandJudge(ref results, ref numsOfJudgeWhoGivesHigestPoint,
                                       ref higestScorebyJudge, ref totalScoreofIndividualJudge);
            display(results, totalScore, finalScore, highestScore, winner, higestScorebyJudge, numsOfJudgeWhoGivesHigestPoint);
            endMessage();
        } // end Main

        /// <summary>
        /// Message for the user
        /// </summary>
        static void welcome() {
            Console.WriteLine("Welcome to the BrisVegas Winter Olympics 2017");
            Console.WriteLine("\nHere are the latest results:");
            Console.WriteLine("\n\n***************************************");
        }

        /// <summary>
        /// Add up all points each competitor received
        /// </summary>
        /// <param name="results">It defines scores given by judges for the competitor.</param>
        /// <param name="totalScore"></param>
        static void addAllPoints(ref int[,] results, ref int[] totalScore) {
            int i;
            int j;
            for (i = 0; i < results.GetLength(0); i++) {
                for (j = 0; j < results.GetLength(1); j++) {
                    totalScore[i] += results[i, j];
                }
            }
        }

        /// <summary>
        /// Define the smallest number and highest number among the points each competitor received.
        /// </summary>
        /// <param name="results">It defines scores given by judges for the competitor.</param>
        /// <param name="larAndSmlNum">index 0 in the second dimentional array means the smallest number, and index 1 in the second dimentional array 
        /// means the largest number given by judges. </param>
        static void GetHighestandSmallest(ref int[,] results, ref int[,] larAndSmlNum) {
            int i;
            int j;
            //Get the largest number and smallest number in the array
            for (i = 0; i < results.GetLength(0); i++) {
                larAndSmlNum[i, 0] = results[i, 0];
                larAndSmlNum[i, 1] = results[i, 0];
                for (j = 0; j < results.GetLength(1); j++) {
                    //if the score is the highest 
                    if (larAndSmlNum[i, 0] < results[i, j]) {
                        larAndSmlNum[i, 0] = results[i, j];
                    } else if (larAndSmlNum[i, 1] > results[i, j]) {
                        larAndSmlNum[i, 1] = results[i, j];
                    }

                }
            }

        }

        /// <summary>
        /// Substract the smallest and largest points from the total points, and define the final points.
        /// </summary>
        /// <param name="results">It defines scores given by judges for the competitor.</param>
        /// <param name="totalScore">Total score of each competitor</param>
        /// <param name="finalScore">Final score of each competitor</param>
        /// <param name="larAndSmlNum">the largest and smallest score each competitor received</param>
        static void calculateFinalScore(ref int[,] results, ref int[] totalScore,
                                            ref int[] finalScore, ref int[,] larAndSmlNum) {
            int i;
            //Substract by the largest and smallest numbers
            for (i = 0; i < results.GetLength(0); i++) {
                finalScore[i] = totalScore[i] - larAndSmlNum[i, 0] - larAndSmlNum[i, 1];
            }

        }

        static void DefineWinner(int[,] results, ref int highestScore, ref int[] winner, ref int[] finalScore) {
            int i;
            highestScore = finalScore[0];

            for (i = 0; i < finalScore.GetLength(0); i++) {
                winner[i] = 0;
                if (highestScore < finalScore[i]) {
                    highestScore = finalScore[i];
                    winner = new int[finalScore.GetLength(0)];
                    winner[i] = i + 1;
                } else if (highestScore == finalScore[i]) {
                    winner[i] = i + 1;
                }
            }
        }

        /// <summary>
        /// Define the total points each judge gave.
        /// </summary>
        /// <param name="results">It defines scores given by judges for the competitor.</param>
        /// <param name="totalScoreofIndividualJudge">Index 0 in second dimentional array means 
        /// the total of points each judge gave to all competitors</param>
        static void TotalPointsGivenbyJudges(ref int[,] results, ref int[,] totalScoreofIndividualJudge) {
            int i;
            int j;

            //Define the total of highest points given by judges
            for (i = 0; i < results.GetLength(1); i++) {
                totalScoreofIndividualJudge[i, 1] = i;
                for (j = 0; j < results.GetLength(0); j++) {
                    totalScoreofIndividualJudge[i, 0] += results[j, i];
                }
            }
        }

        /// <summary>
        /// Find the judge or judges whose total score for competitors are highest.
        /// </summary>
        /// <param name="results">It defines scores given by judges for the competitor.</param>
        /// <param name="numsOfJudgeWhoGivesHigestPoint">stores number of judge whose total points are the highest among all judges.</param>
        /// <param name="higestScorebyJudge">the highest total score given by the judge</param>
        /// <param name="totalScoreofIndividualJudge">Index 0 in second dimentional array means the total score given by each judge,
        /// index 1 in second dimentional array means number of judges.</param>
        static void DifineHighestPointandJudge(ref int[,] results,
                                               ref int[] numsOfJudgeWhoGivesHigestPoint,
                                               ref int higestScorebyJudge,
                                               ref int[,] totalScoreofIndividualJudge) {
            int i;
            int j;
            for (i = 0; i < results.GetLength(1); i++) {
                numsOfJudgeWhoGivesHigestPoint[i] = 0;
                if (higestScorebyJudge < totalScoreofIndividualJudge[i, 0]) {
                    higestScorebyJudge = totalScoreofIndividualJudge[i, 0];
                    numsOfJudgeWhoGivesHigestPoint = new int[results.GetLength(1)];
                    numsOfJudgeWhoGivesHigestPoint[i] = i + 1;
                } else if (higestScorebyJudge == totalScoreofIndividualJudge[i, 0]) {
                    numsOfJudgeWhoGivesHigestPoint[i] = i + 1;
                }
            }
        }



        /// <summary>
        /// Writing down on console the results of calculations. 
        /// </summary>
        /// <param name="results">It defines scores given by judges for the competitor.</param>
        /// <param name="totalScore">Total score of each competitor</param>
        /// <param name="finalScore">Final score of each competitor</param>
        /// <param name="highestScore">Highest score the competitor receives among all competitors.</param>
        /// <param name="winner">stores the number or numbers of winner.</param>
        /// <param name="higestScorebyJudge">The highest total score given by judge or judges to competitors.</param>
        /// <param name="numsOfJudgeWhoGivesHighestPoint">stores the number or numbers of judge who gave the highest point to competitors.</param>
        static void display(int[,] results, int[] totalScore, int[] finalScore,
                        int highestScore, int[] winner, int higestScorebyJudge,
                        int[] numsOfJudgeWhoGivesHighestPoint) {
        int i;
        int j;
        int numofCompetitor = 0;
        for (i = 0; i < results.GetLength(0); i++) {
            numofCompetitor++;
            Console.Write("\nCompetitor {0}: your scores were:", numofCompetitor);
            for (j = 0; j < results.GetLength(1); j++) {
                Console.Write("{0} ", results[i, j]);
            }
            Console.WriteLine("\n\n           with a total of {0}", finalScore[i]);
        }

        Console.WriteLine("\nAnd the winner is ...");
        for (i = 0; i < winner.GetLength(0); i++) {
            if (winner[i] > 0) {
                Console.WriteLine("\nComepetitor {0} with a score of {1}", winner[i], highestScore);
            }
        }
        Console.WriteLine("\nAnd the judges with the highest score are ");
        for (i = 0; i < numsOfJudgeWhoGivesHighestPoint.GetLength(0); i++) {
            if (numsOfJudgeWhoGivesHighestPoint[i] > 0) {
                Console.WriteLine("\n      judge {0} with a score total of {1}", numsOfJudgeWhoGivesHighestPoint[i],
                                                                                 higestScorebyJudge);
            }
        }


    }

    static void endMessage() {
        Console.WriteLine("\n\n***************************************");
        Console.WriteLine("That's all for now");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
} // end class

} // end namespace



