using System;


class Program
{
    static void Main(string[] args)
    {
        List<String> emptyBoard = new List<string>() { "1","2","3","4","5","6","7","8","9"};
        List<String> board = new List<string>() { "1","2","3","4","5","6","7","8","9"};
        string turn = "x";
        bool playAgain = true;
        int xWins = 0;
        int oWins = 0;
        
        while (playAgain)
        {
            NewBoard(emptyBoard, board);
            while (!IsWinner(board) || !IsTie(board))
            {
                DisplayBoard(board);
                PromptTurn(turn);
                TakeTurn(board, turn);
                 turn = GetNextTurn(turn);
            }
            DisplayBoard(board);
            EndGame(board, turn, xWins, oWins);
            DisplayWins(xWins, oWins);
            playAgain = PlayAgain();
        }
        



    }

    static void NewBoard(List<String> emptyBoard, List<String> board)
    {
       for ( int i = 0; i < 8; i++)
       {
           board[i] = emptyBoard[i];
       }
    }
    
    static void DisplayBoard(List<String> board)
    {
        Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
    }

    static void PromptTurn(string turn)
    {
        Console.WriteLine($"{turn}'s turn. Please choose an open square: ");
        
    }
    static void TakeTurn(List<String> board, string turn)
    {
        int square = int.Parse(Console.ReadLine());
        if (!IsValdMove(square, board))
        {
            Console.WriteLine($"{square} is not a valid move. Choose an OPEN square!");
            square = int.Parse(Console.ReadLine());
        } 

        board[square-1] = turn;
        
    }

    static string GetNextTurn(string turn)
    {
        string nextTurn = "x";

            if (turn == "x")
            {
                nextTurn = "o";
            }

            return nextTurn;
    }

    static bool IsValdMove(int square, List<String> board)
    {
        if ((board[square-1] == "x") || (board[square-1] == "o"))
        {
            return false;
        } 
        return true;
    }

    static bool IsWinner(List<String> board)
    {
        if ( ((board[0] == board[1]) && (board[0] == board[2])) ||
             ((board[3] == board[4]) && (board[3] == board[5])) ||
             ((board[6] == board[7]) && (board[6] == board[8])) ||
             ((board[0] == board[3]) && (board[0] == board[6])) ||
             ((board[1] == board[4]) && (board[1] == board[7])) || 
             ((board[2] == board[5]) && (board[2] == board[8])) ||
             ((board[0] == board[4]) && (board[0] == board[8])) ||
             ((board[2] == board[4]) && (board[2] == board[6])))
        {
            return true;
        } else{
            return false;
        }
    }
    static bool IsTie(List<string> board)
        {
            bool foundDigit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return !foundDigit;
        }

    static void EndGame(List<String> board, string turn, int xWins, int oWins)
    {
        if (IsTie(board))
        {
            Console.WriteLine("Tie game! Thanks for playing!");
        } else{
            if (turn == "x")
            {
                xWins += 1;
            } else
            {
                oWins += 1;
            }
            Console.WriteLine($"{turn} won! Thanks for playing!");
        }
    }

    static void DisplayWins(int xWins, int oWins)
    {
        Console.WriteLine($"X has won {xWins} times.");
        Console.WriteLine($"O has won {oWins} times.");

        if (xWins > oWins)
        {
            Console.WriteLine("X is winning!");
        } else if (oWins > xWins)
        {
            Console.WriteLine("O is winning!");
        } else 
        {
            Console.WriteLine("You are tied!");
        }
    }

    static bool PlayAgain()
    {
        string answer;
        Console.WriteLine("Would you like to play again? 'y' for yes 'n' for no.");
        answer = Console.ReadLine();

        if (answer.ToLower() == "y")
        {
            return true;
        } 
        else
        {
            return false;
        }
    }
}


