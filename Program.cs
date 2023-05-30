using System;

class App {
    static void Main(string[] args) {
        String greatings = "Calculatrice de Andry le BG qui nique des mères";
        Console.WriteLine(greatings);
        Console.WriteLine("Taper '=' quand vous avez fini");
        bool run = true;
        int res = 0;
        char prevOp = '#';
        string history = "";
        do {
            string? userInput = askUser(history);
            history += userInput;
            if(userInput != "=") {
                switch (userInput){
                    case "+":
                        prevOp = '+';         
                        break;
                    case "-":
                        prevOp = '-';
                        break;
                    case "*":
                        prevOp = '*';
                        break;
                    case "/": 
                        prevOp = '/';
                        break;
                    default:
                        if(userInput != null && int.TryParse(userInput, out int number)) {
                            
                            res = calc(res, number, prevOp);
                            Console.WriteLine("res =" +res);
                        } 
                        break;
                }
            } else {
                Console.WriteLine("Le resultat est : " + res);
                run = false;
            }

        } while (run);
    }

    public static string?  askUser(string history) {
        Console.WriteLine(history);
        Console.WriteLine(@"Les opérateurs sont + - * /
        Entrez un nombre ou un opérateur à la fois et toucher entrer pour valider :");
        return Console.ReadLine();    
    }

    public static int calc(int first, int second, Char op) {
        int res = first;
            switch (op){ 
                    case '+':
                        res += second;         
                        break;
                    case '-':
                        res -= second;
                        break;
                    case '*':
                        res *= second;
                        break;
                    case '/': 
                        res /= second;
                        break;
                    default: 
                        res = second;
                        break;
                }
        return res;
    }
}
